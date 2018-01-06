using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Threading;
using JetBrains.Annotations;
using TaskBoard.Common.Extensions;
using TaskBoard.Server.Exceptions;
using TaskBoard.Server.Exceptions.HttpExceptions;
using TaskBoard.Server.Extensions;
using TaskBoard.Server.Handlers;

namespace TaskBoard.Server.Servers {
	// ReSharper disable UnusedMember.Global

	public class HttpServer : IHttpServer {
		private readonly string serverAddress;
		private readonly IHttpHandler[] httpHandlers;

		private Thread serverThread;
		private HttpListener httpListener;
		private Dictionary<string, IHttpHandler> hashedHandlers;

		public HttpServer(string serverAddress, IHttpHandler[] httpHandlers) {
			this.serverAddress = serverAddress;
			this.httpHandlers = httpHandlers;

			CheckHandlers(httpHandlers);
		}
		[AssertionMethod]
		private void CheckHandlers(IEnumerable<IHttpHandler> handlers) {
			var repeatedHandlersGroups = handlers
				.GroupBy(handler => handler.HandlerName)
				.Where(group => group.Count() > 1)
				.ToArray();

			if (repeatedHandlersGroups.Any())
				throw new ArgumentException($"Обнаружено несколько функций с {nameof(IHttpHandler.HandlerName)}: " +
					$"{string.Join(", ", repeatedHandlersGroups.Select(handlersGroup => handlersGroup.First().HandlerName))}");
		}

		public void Start() {
			if (httpListener != null)
				throw new ArgumentException("Сервер уже запущен");

			httpListener = new HttpListener();
			httpListener.Prefixes.Add(serverAddress);
			httpListener.Start();

			if (hashedHandlers == null)
				hashedHandlers = httpHandlers.ToDictionary(handler => handler.HandlerName.ToLower());

			serverThread = new Thread(RunServer);
			serverThread.Start();
		}

		private void RunServer() {
			while (httpListener.IsListening) {
				var context = GetContext();
				if (context == null)
					continue;

				try {
					var handlerName = Uri.UnescapeDataString(context.Request.RawUrl).Split('?')[0].Substring(1);
					GetHandler(handlerName).Execute(context);
				}
				catch (HttpStopServerException exception) {
					context.Response.Respond(exception.StatusCode, exception.Message.ToJson());
					Thread.Sleep(1000);

					httpListener.Stop();
				}
				catch (HttpException exception) {
					context.Response.Respond(exception.StatusCode, exception.Message.ToJson());
				}
				catch (DbEntityValidationException exception) {
					context.Response.Respond(HttpStatusCode.BadRequest,
						string.Join("\n",
								new[] { exception.Message }
									.Concat(exception.EntityValidationErrors
										.SelectMany(entityError => entityError.ValidationErrors
											.Select(validationError => validationError.ErrorMessage)))
									.Where(error => error != null))
							.ToJson());
				}
				catch (Exception exception) {
					context.Response.Respond(HttpStatusCode.BadRequest, string.Join("\n", exception.GetErrorMessages()).ToJson());
				}
			}

			httpListener = null;
		}
		private HttpListenerContext GetContext() {
			try {
				return httpListener.GetContext();
			}
			catch (Exception) {
				return null;
			}
		}
		private IHttpHandler GetHandler(string handlerName) {
			var lowerHandlerName = handlerName.ToLower();
			if (hashedHandlers.ContainsKey(lowerHandlerName))
				return hashedHandlers[lowerHandlerName];

			throw new HttpNotFoundException($"Функция '{handlerName}' не найдена");
		}

		public void Wait() {
			if (httpListener == null)
				throw new ArgumentException("Сервер не запущен");

			serverThread.Join();
		}

		public void Stop() {
			if (httpListener == null)
				throw new ArgumentException("Сервер не запущен");

			httpListener.Stop();
			serverThread.Join();
		}
	}
}
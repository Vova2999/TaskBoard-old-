using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using JetBrains.Annotations;
using TaskBoard.Common.Database;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Server.Exceptions.HttpExceptions;
using TaskBoard.Server.Extensions;

namespace TaskBoard.Server.Handlers {
	public abstract class HttpHandlerBase : IHttpHandler {
		public abstract string HandlerName { get; }
		protected abstract AccessType? RequiredAccessType { get; }
		private readonly IDatabaseAuthorizer databaseAuthorizer;

		protected HttpHandlerBase(IDatabaseAuthorizer databaseAuthorizer = null) {
			this.databaseAuthorizer = databaseAuthorizer;
			CheckDatabaseAuthorizer(databaseAuthorizer);
		}
		[AssertionMethod]
		private void CheckDatabaseAuthorizer(IDatabaseAuthorizer authorizer) {
			if (RequiredAccessType != null && authorizer == null)
				throw new ArgumentNullException(nameof(IDatabaseAuthorizer));
		}

		public void Execute(HttpListenerContext context) {
			var parameters = GetParameters(context);
			var requestBody = GetRequestBody(context);

			CheckAccess(parameters);

			var responseBody = PerformRun(parameters, requestBody);
			context.Response.Respond(HttpStatusCode.OK, responseBody);
		}
		private static NameValueCollection GetParameters(HttpListenerContext context) {
			var unescapeRawUrl = Uri.UnescapeDataString(context.Request.RawUrl);
			var indexOfParametersSeparator = unescapeRawUrl.IndexOf('?');
			return indexOfParametersSeparator == -1
				? new NameValueCollection()
				: HttpUtility.ParseQueryString(unescapeRawUrl.Substring(indexOfParametersSeparator));
		}
		private static byte[] GetRequestBody(HttpListenerContext context) {
			return context.Request.InputStream.ReadAndDispose();
		}

		private void CheckAccess(NameValueCollection parameters) {
			if (RequiredAccessType == null)
				return;

			var login = parameters.Get(HttpParameters.Login);
			var password = parameters.Get(HttpParameters.Password);

			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
				throw new HttpBadRequestException("Для вызова этой функции необходимо передать параметры пользователя");

			if (!databaseAuthorizer.UserIsExist(login, password))
				throw new HttpNotFoundException("Пользователь не найден, либо введен неверный пароль");
			if (!databaseAuthorizer.AccessIsAllowed(login, password, RequiredAccessType.Value))
				throw new HttpNotFoundException("У вас нет доступа к этой функции");
		}

		protected abstract byte[] PerformRun(NameValueCollection parameters, byte[] requestBody);
	}
}
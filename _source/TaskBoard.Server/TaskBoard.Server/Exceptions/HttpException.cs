using System;
using System.Net;

namespace TaskBoard.Server.Exceptions {
	public abstract class HttpException : Exception {
		public abstract HttpStatusCode StatusCode { get; }

		protected HttpException(string message) : base(message) {
		}
	}
}
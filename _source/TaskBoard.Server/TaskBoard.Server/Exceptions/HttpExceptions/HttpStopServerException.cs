using System.Net;

namespace TaskBoard.Server.Exceptions.HttpExceptions {
	public class HttpStopServerException : HttpException {
		public override HttpStatusCode StatusCode => HttpStatusCode.OK;

		public HttpStopServerException(string message) : base(message) {
		}
	}
}
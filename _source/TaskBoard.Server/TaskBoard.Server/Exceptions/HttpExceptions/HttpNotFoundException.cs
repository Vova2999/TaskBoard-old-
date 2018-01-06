using System.Net;

namespace TaskBoard.Server.Exceptions.HttpExceptions {
	public class HttpNotFoundException : HttpException {
		public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

		public HttpNotFoundException(string message) : base(message) {
		}
	}
}
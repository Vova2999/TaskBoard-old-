using System.Net;

namespace TaskBoard.Server.Exceptions.HttpExceptions {
	public class HttpBadRequestException : HttpException {
		public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

		public HttpBadRequestException(string message) : base(message) {
		}
	}
}
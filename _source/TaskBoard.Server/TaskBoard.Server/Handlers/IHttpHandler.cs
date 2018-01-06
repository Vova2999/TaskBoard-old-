using System.Net;

namespace TaskBoard.Server.Handlers {
	public interface IHttpHandler {
		string HandlerName { get; }
		void Execute(HttpListenerContext context);
	}
}
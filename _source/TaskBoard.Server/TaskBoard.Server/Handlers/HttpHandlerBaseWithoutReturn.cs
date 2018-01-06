using System.Collections.Specialized;
using TaskBoard.Common.Database;

namespace TaskBoard.Server.Handlers {
	public abstract class HttpHandlerBaseWithoutReturn : HttpHandlerBase {
		protected HttpHandlerBaseWithoutReturn(IDatabaseAuthorizer databaseAuthorizer) : base(databaseAuthorizer) {
		}

		protected sealed override byte[] PerformRun(NameValueCollection parameters, byte[] requestBody) {
			Run(parameters, requestBody);
			return null;
		}
		protected abstract void Run(NameValueCollection parameters, byte[] requestBody);
	}
}
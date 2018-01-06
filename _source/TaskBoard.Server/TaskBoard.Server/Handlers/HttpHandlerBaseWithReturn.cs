using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Extensions;

namespace TaskBoard.Server.Handlers {
	public abstract class HttpHandlerBaseWithReturn<TResult> : HttpHandlerBase {
		protected HttpHandlerBaseWithReturn(IDatabaseAuthorizer databaseAuthorizer) : base(databaseAuthorizer) {
		}

		protected sealed override byte[] PerformRun(NameValueCollection parameters, byte[] requestBody) {
			var result = Run(parameters, requestBody);
			return result.ToJson();
		}
		protected abstract TResult Run(NameValueCollection parameters, byte[] requestBody);
	}
}
using System.Collections.Specialized;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;

namespace TaskBoard.Server.Handlers.WithoutReturn {
	// ReSharper disable UnusedMember.Global

	public class PingHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Common.Ping;
		protected override AccessType? RequiredAccessType => null;

		public PingHandler() : base(null) {
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
		}
	}
}
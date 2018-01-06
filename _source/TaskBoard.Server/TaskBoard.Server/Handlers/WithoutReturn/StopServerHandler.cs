using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Server.Exceptions.HttpExceptions;

namespace TaskBoard.Server.Handlers.WithoutReturn {
	// ReSharper disable UnusedMember.Global

	public class StopServerHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Common.StopServer;
		protected override AccessType? RequiredAccessType => AccessType.Root;

		public StopServerHandler(IDatabaseAuthorizer databaseAuthorizer) : base(databaseAuthorizer) {
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			throw new HttpStopServerException("Работа сервера завершена");
		}
	}
}
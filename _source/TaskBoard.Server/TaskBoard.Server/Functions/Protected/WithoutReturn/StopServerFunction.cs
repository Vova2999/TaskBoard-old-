using System.Net;
using TaskBoard.Common.Database;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Server.AdditionalObjects;
using TaskBoard.Server.Exceptions;

namespace TaskBoard.Server.Functions.Protected.WithoutReturn {
	// ReSharper disable UnusedMember.Global

	public class StopServerFunction : HttpProtectedFunctionWithoutReturn {
		public override string NameOfCalledMethod => HttpFunctions.StopServer;
		protected override AccessType RequiredAccessType => AccessType.AdminRead;

		public StopServerFunction(IDatabaseAuthorizer databaseAuthorizer) : base(databaseAuthorizer) {
		}

		protected override void Run(NameValues parameters, byte[] requestBody) {
			throw new HttpStopServerException(HttpStatusCode.OK, "Работа сервера завершена");
		}
	}
}
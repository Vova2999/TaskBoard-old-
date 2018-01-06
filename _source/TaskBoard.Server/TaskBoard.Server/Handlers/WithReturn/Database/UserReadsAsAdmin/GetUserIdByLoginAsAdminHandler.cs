using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetUserIdByLoginAsAdminHandler : HttpHandlerBaseWithReturn<UserId> {
		public override string HandlerName => HttpHandlerNames.User.ReadsAsAdmin.GetUserIdByLoginAsAdmin;
		protected override AccessType? RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetUserIdByLoginAsAdminHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override UserId Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseUserReaderAsAdmin.GetIdByLogin(parameters[HttpParameters.UserLogin]);
		}
	}
}
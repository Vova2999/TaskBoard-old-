using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetAllUserIdsAsAdminHandler : HttpHandlerBaseWithReturn<UserId[]> {
		public override string HandlerName => HttpHandlerNames.User.ReadsAsAdmin.GetAllUserIdsAsAdmin;
		protected override AccessType? RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetAllUserIdsAsAdminHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override UserId[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseUserReaderAsAdmin.GetAllIds();
		}
	}
}
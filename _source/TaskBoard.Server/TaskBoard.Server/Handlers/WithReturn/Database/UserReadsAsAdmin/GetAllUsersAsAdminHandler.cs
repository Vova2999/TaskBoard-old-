using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetAllUsersAsAdminHandler : HttpHandlerBaseWithReturn<User[]> {
		public override string HandlerName => HttpHandlerNames.User.ReadsAsAdmin.GetAllUsersAsAdmin;
		protected override AccessType? RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetAllUsersAsAdminHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override User[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseUserReaderAsAdmin.GetAll();
		}
	}
}
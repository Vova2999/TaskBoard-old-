using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetUsersWithUsingFiltersAsAdminHandler : HttpHandlerBaseWithReturn<User[]> {
		public override string HandlerName => HttpHandlerNames.User.ReadsAsAdmin.GetUsersWithUsingFiltersAsAdmin;
		protected override AccessType? RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetUsersWithUsingFiltersAsAdminHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override User[] Run(NameValueCollection parameters, byte[] requestBody) {
			var login = parameters.Get(HttpParameters.UserLogin);

			return databaseUserReaderAsAdmin.GetWithUsingFilters(login);
		}
	}
}
using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetUserIdsWithUsingFiltersAsAdminHandler : HttpHandlerBaseWithReturn<UserId[]> {
		public override string HandlerName => HttpHandlerNames.User.ReadsAsAdmin.GetUserIdsWithUsingFiltersAsAdmin;
		protected override AccessType? RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetUserIdsWithUsingFiltersAsAdminHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override UserId[] Run(NameValueCollection parameters, byte[] requestBody) {
			var login = parameters.Get(HttpParameters.UserLogin);

			return databaseUserReaderAsAdmin.GetIdsWithUsingFilters(login);
		}
	}
}
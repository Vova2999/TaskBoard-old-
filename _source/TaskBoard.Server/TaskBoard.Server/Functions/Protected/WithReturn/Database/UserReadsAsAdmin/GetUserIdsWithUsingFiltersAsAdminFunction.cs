using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetUserIdsWithUsingFiltersAsAdminFunction : HttpProtectedFunctionWithReturn<UserId[]> {
		public override string NameOfCalledMethod => HttpFunctions.UserReadsAsAdmin.GetUserIdsWithUsingFiltersAsAdmin;
		protected override AccessType RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetUserIdsWithUsingFiltersAsAdminFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override UserId[] Run(NameValues parameters, byte[] requestBody) {
			var login = parameters.GetValueOrNull(HttpParameters.UserLogin);

			return databaseUserReaderAsAdmin.GetIdsWithUsingFilters(login);
		}
	}
}
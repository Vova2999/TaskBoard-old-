using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetAllUserIdsAsAdminFunction : HttpProtectedFunctionWithReturn<UserId[]> {
		public override string NameOfCalledMethod => HttpFunctions.UserReadsAsAdmin.GetAllUserIdsAsAdmin;
		protected override AccessType RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetAllUserIdsAsAdminFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override UserId[] Run(NameValues parameters, byte[] requestBody) {
			return databaseUserReaderAsAdmin.GetAllIds();
		}
	}
}
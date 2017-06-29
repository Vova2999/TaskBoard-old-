using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetUserByLoginAsAdminFunction : HttpProtectedFunctionWithReturn<User> {
		public override string NameOfCalledMethod => HttpFunctions.UserReadsAsAdmin.GetUserByLoginAsAdmin;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetUserByLoginAsAdminFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override User Run(NameValues parameters, byte[] requestBody) {
			return databaseUserReaderAsAdmin.GetByLogin(parameters[HttpParameters.UserLogin]);
		}
	}
}
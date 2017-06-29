using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.UserReads {
	// ReSharper disable UnusedMember.Global

	public class GetUserByLoginFunction : HttpProtectedFunctionWithReturn<User> {
		public override string NameOfCalledMethod => HttpFunctions.UserReads.GetUserByLogin;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetUserByLoginFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override User Run(NameValues parameters, byte[] requestBody) {
			return databaseUserReader.GetByLogin(parameters[HttpParameters.UserLogin]);
		}
	}
}
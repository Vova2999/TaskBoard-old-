using System;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.UserReads {
	// ReSharper disable UnusedMember.Global

	public class GetUserIdByLoginFunction : HttpProtectedFunctionWithReturn<Guid> {
		public override string NameOfCalledMethod => HttpFunctions.UserReads.GetUserIdByLogin;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetUserIdByLoginFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override Guid Run(NameValues parameters, byte[] requestBody) {
			return databaseUserReader.GetIdByLogin(parameters[HttpParameters.UserLogin]);
		}
	}
}
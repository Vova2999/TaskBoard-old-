using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.UserReads {
	// ReSharper disable UnusedMember.Global

	public class GetAllUserIdsFunction : HttpProtectedFunctionWithReturn<UserId[]> {
		public override string NameOfCalledMethod => HttpFunctions.UserReads.GetAllUserIds;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetAllUserIdsFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override UserId[] Run(NameValues parameters, byte[] requestBody) {
			return databaseUserReader.GetAllIds();
		}
	}
}
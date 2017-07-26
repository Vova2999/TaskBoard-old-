using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.ColumnReads {
	// ReSharper disable UnusedMember.Global

	public class GetColumnIdByHeaderWithBoardNameFunction : HttpProtectedFunctionWithReturn<ColumnId> {
		public override string NameOfCalledMethod => HttpFunctions.ColumnReads.GetColumnIdByHeaderWithBoardName;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseColumnReader databaseColumnReader;

		public GetColumnIdByHeaderWithBoardNameFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseColumnReader databaseColumnReader) : base(databaseAuthorizer) {
			this.databaseColumnReader = databaseColumnReader;
		}

		protected override ColumnId Run(NameValues parameters, byte[] requestBody) {
			return databaseColumnReader.GetIdByHeaderWithBoardName(parameters[HttpParameters.ColumnHeader], parameters[HttpParameters.ColumnBoardName]);
		}
	}
}
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.ColumnReads {
	// ReSharper disable UnusedMember.Global

	public class GetColumnByHeaderWithBoardNameFunction : HttpProtectedFunctionWithReturn<Column> {
		public override string NameOfCalledMethod => HttpFunctions.ColumnReads.GetColumnByHeaderWithBoardName;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseColumnReader databaseColumnReader;

		public GetColumnByHeaderWithBoardNameFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseColumnReader databaseColumnReader) : base(databaseAuthorizer) {
			this.databaseColumnReader = databaseColumnReader;
		}

		protected override Column Run(NameValues parameters, byte[] requestBody) {
			return databaseColumnReader.GetByHeaderWithBoardName(parameters[HttpParameters.ColumnHeader], parameters[HttpParameters.ColumnBoardName]);
		}
	}
}
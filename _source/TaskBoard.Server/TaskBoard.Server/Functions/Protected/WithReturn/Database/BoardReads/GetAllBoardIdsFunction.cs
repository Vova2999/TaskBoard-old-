using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.BoardReads {
	// ReSharper disable UnusedMember.Global

	public class GetAllBoardIdsFunction : HttpProtectedFunctionWithReturn<BoardId[]> {
		public override string NameOfCalledMethod => HttpFunctions.BoardReads.GetAllBoardIds;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseBoardReader databaseBoardReader;

		public GetAllBoardIdsFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardReader databaseBoardReader) : base(databaseAuthorizer) {
			this.databaseBoardReader = databaseBoardReader;
		}

		protected override BoardId[] Run(NameValues parameters, byte[] requestBody) {
			return databaseBoardReader.GetAllIds();
		}
	}
}
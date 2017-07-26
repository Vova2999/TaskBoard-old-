using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.BoardReads {
	// ReSharper disable UnusedMember.Global

	public class GetBoardIdByNameFunction : HttpProtectedFunctionWithReturn<BoardId> {
		public override string NameOfCalledMethod => HttpFunctions.BoardReads.GetBoardIdByName;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseBoardReader databaseBoardReader;

		public GetBoardIdByNameFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardReader databaseBoardReader) : base(databaseAuthorizer) {
			this.databaseBoardReader = databaseBoardReader;
		}

		protected override BoardId Run(NameValues parameters, byte[] requestBody) {
			return databaseBoardReader.GetIdByName(parameters[HttpParameters.BoardName]);
		}
	}
}
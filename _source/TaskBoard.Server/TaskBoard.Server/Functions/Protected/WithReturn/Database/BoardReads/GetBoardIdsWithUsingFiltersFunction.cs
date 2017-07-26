using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.BoardReads {
	// ReSharper disable UnusedMember.Global

	public class GetBoardIdsWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<BoardId[]> {
		public override string NameOfCalledMethod => HttpFunctions.BoardReads.GetBoardIdsWithUsingFilters;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseBoardReader databaseBoardReader;

		public GetBoardIdsWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardReader databaseBoardReader) : base(databaseAuthorizer) {
			this.databaseBoardReader = databaseBoardReader;
		}

		protected override BoardId[] Run(NameValues parameters, byte[] requestBody) {
			var name = parameters.GetValueOrNull(HttpParameters.BoardName);

			return databaseBoardReader.GetIdsWithUsingFilters(name);
		}
	}
}
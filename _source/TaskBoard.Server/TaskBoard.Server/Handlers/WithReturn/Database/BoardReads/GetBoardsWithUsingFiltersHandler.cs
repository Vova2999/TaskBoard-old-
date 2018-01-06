using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.BoardReads {
	// ReSharper disable UnusedMember.Global

	public class GetBoardsWithUsingFiltersHandler : HttpHandlerBaseWithReturn<Board[]> {
		public override string HandlerName => HttpHandlerNames.Board.Reads.GetBoardsWithUsingFilters;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseBoardReader databaseBoardReader;

		public GetBoardsWithUsingFiltersHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardReader databaseBoardReader) : base(databaseAuthorizer) {
			this.databaseBoardReader = databaseBoardReader;
		}

		protected override Board[] Run(NameValueCollection parameters, byte[] requestBody) {
			var name = parameters.Get(HttpParameters.BoardName);

			return databaseBoardReader.GetWithUsingFilters(name);
		}
	}
}
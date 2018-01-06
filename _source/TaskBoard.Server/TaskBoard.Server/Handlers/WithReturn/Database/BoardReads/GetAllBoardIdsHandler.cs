using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.BoardReads {
	// ReSharper disable UnusedMember.Global

	public class GetAllBoardIdsHandler : HttpHandlerBaseWithReturn<BoardId[]> {
		public override string HandlerName => HttpHandlerNames.Board.Reads.GetAllBoardIds;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseBoardReader databaseBoardReader;

		public GetAllBoardIdsHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardReader databaseBoardReader) : base(databaseAuthorizer) {
			this.databaseBoardReader = databaseBoardReader;
		}

		protected override BoardId[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseBoardReader.GetAllIds();
		}
	}
}
using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.BoardReads {
	// ReSharper disable UnusedMember.Global

	public class GetBoardByIdHandler : HttpHandlerBaseWithReturn<Board> {
		public override string HandlerName => HttpHandlerNames.Board.Reads.GetBoardById;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseBoardReader databaseBoardReader;

		public GetBoardByIdHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardReader databaseBoardReader) : base(databaseAuthorizer) {
			this.databaseBoardReader = databaseBoardReader;
		}

		protected override Board Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseBoardReader.GetById(parameters[HttpParameters.BoardId].ToGuid().ToBoardId());
		}
	}
}
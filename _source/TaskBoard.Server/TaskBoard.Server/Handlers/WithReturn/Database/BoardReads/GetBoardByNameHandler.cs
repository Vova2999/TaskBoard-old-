﻿using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.BoardReads {
	// ReSharper disable UnusedMember.Global

	public class GetBoardByNameHandler : HttpHandlerBaseWithReturn<Board> {
		public override string HandlerName => HttpHandlerNames.Board.Reads.GetBoardByName;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseBoardReader databaseBoardReader;

		public GetBoardByNameHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardReader databaseBoardReader) : base(databaseAuthorizer) {
			this.databaseBoardReader = databaseBoardReader;
		}

		protected override Board Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseBoardReader.GetByName(parameters[HttpParameters.BoardName]);
		}
	}
}
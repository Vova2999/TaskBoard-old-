using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.ColumnReads {
	// ReSharper disable UnusedMember.Global

	public class GetColumnIdByHeaderWithBoardNameHandler : HttpHandlerBaseWithReturn<ColumnId> {
		public override string HandlerName => HttpHandlerNames.Column.Reads.GetColumnIdByHeaderWithBoardName;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseColumnReader databaseColumnReader;

		public GetColumnIdByHeaderWithBoardNameHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseColumnReader databaseColumnReader) : base(databaseAuthorizer) {
			this.databaseColumnReader = databaseColumnReader;
		}

		protected override ColumnId Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseColumnReader.GetIdByHeaderWithBoardName(parameters[HttpParameters.ColumnHeader], parameters[HttpParameters.ColumnBoardName]);
		}
	}
}
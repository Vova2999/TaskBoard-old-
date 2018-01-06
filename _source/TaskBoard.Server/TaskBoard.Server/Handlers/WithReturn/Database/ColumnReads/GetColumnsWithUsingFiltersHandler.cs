using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.ColumnReads {
	// ReSharper disable UnusedMember.Global

	public class GetColumnsWithUsingFiltersHandler : HttpHandlerBaseWithReturn<Column[]> {
		public override string HandlerName => HttpHandlerNames.Column.Reads.GetColumnsWithUsingFilters;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseColumnReader databaseColumnReader;

		public GetColumnsWithUsingFiltersHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseColumnReader databaseColumnReader) : base(databaseAuthorizer) {
			this.databaseColumnReader = databaseColumnReader;
		}

		protected override Column[] Run(NameValueCollection parameters, byte[] requestBody) {
			var header = parameters.Get(HttpParameters.ColumnHeader);
			var brush = parameters.Get(HttpParameters.ColumnBrush);
			var boardId = parameters.Get(HttpParameters.ColumnBoardId)?.ToGuid().ToBoardId();

			return databaseColumnReader.GetWithUsingFilters(header, brush, boardId);
		}
	}
}
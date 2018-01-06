using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.ColumnReads {
	// ReSharper disable UnusedMember.Global

	public class GetColumnByIdHandler : HttpHandlerBaseWithReturn<Column> {
		public override string HandlerName => HttpHandlerNames.Column.Reads.GetColumnById;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseColumnReader databaseColumnReader;

		public GetColumnByIdHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseColumnReader databaseColumnReader) : base(databaseAuthorizer) {
			this.databaseColumnReader = databaseColumnReader;
		}

		protected override Column Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseColumnReader.GetById(parameters[HttpParameters.ColumnId].ToGuid().ToColumnId());
		}
	}
}
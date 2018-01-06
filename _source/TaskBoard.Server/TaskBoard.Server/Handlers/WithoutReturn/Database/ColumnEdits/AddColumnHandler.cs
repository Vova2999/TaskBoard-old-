using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.ColumnEdits {
	// ReSharper disable UnusedMember.Global

	public class AddColumnHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Column.Edits.AddColumn;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseColumnEditor databaseColumnEditor;

		public AddColumnHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseColumnEditor databaseColumnEditor) : base(databaseAuthorizer) {
			this.databaseColumnEditor = databaseColumnEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseColumnEditor.Add(requestBody.FromJson<Column>());
		}
	}
}
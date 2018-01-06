using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.BoardEdits {
	// ReSharper disable UnusedMember.Global

	public class AddBoardHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Board.Edits.AddBoard;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseBoardEditor databaseBoardEditor;

		public AddBoardHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardEditor databaseBoardEditor) : base(databaseAuthorizer) {
			this.databaseBoardEditor = databaseBoardEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseBoardEditor.Add(requestBody.FromJson<Board>());
		}
	}
}
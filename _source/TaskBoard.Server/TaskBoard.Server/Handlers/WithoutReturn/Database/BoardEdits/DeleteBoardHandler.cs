using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.BoardEdits {
	// ReSharper disable UnusedMember.Global

	public class DeleteBoardHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Board.Edits.DeleteBoard;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseBoardEditor databaseBoardEditor;

		public DeleteBoardHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseBoardEditor databaseBoardEditor) : base(databaseAuthorizer) {
			this.databaseBoardEditor = databaseBoardEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseBoardEditor.Delete(parameters[HttpParameters.BoardId].ToGuid().ToBoardId());
		}
	}
}
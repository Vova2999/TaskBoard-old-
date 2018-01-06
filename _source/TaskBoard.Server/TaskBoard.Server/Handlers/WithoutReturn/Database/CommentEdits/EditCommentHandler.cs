using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.CommentEdits {
	// ReSharper disable UnusedMember.Global

	public class EditCommentHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Comment.Edits.EditComment;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseCommentEditor databaseCommentEditor;

		public EditCommentHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentEditor databaseCommentEditor) : base(databaseAuthorizer) {
			this.databaseCommentEditor = databaseCommentEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseCommentEditor.Edit(parameters[HttpParameters.CommentId].ToGuid().ToCommentId(), requestBody.FromJson<Comment>());
		}
	}
}
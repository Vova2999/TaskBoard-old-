using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.CommentEdits {
	// ReSharper disable UnusedMember.Global

	public class DeleteCommentHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Comment.Edits.DeleteComment;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseCommentEditor databaseCommentEditor;

		public DeleteCommentHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentEditor databaseCommentEditor) : base(databaseAuthorizer) {
			this.databaseCommentEditor = databaseCommentEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseCommentEditor.Delete(parameters[HttpParameters.CommentId].ToGuid().ToCommentId());
		}
	}
}
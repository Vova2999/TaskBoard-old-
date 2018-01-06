using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.CommentEdits {
	// ReSharper disable UnusedMember.Global

	public class AddCommentHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Comment.Edits.AddComment;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseCommentEditor databaseCommentEditor;

		public AddCommentHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentEditor databaseCommentEditor) : base(databaseAuthorizer) {
			this.databaseCommentEditor = databaseCommentEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseCommentEditor.Add(requestBody.FromJson<Comment>());
		}
	}
}
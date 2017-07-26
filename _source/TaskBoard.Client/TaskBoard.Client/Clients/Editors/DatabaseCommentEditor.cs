using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Editors {
	public class DatabaseCommentEditor : BaseHttpClient, IDatabaseCommentEditor {
		public DatabaseCommentEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(Comment comment) {
			SendRequest(HttpFunctions.CommentEdits.AddComment, GetDefaultParameters(), comment.ToJson());
		}

		public void Edit(CommentId oldCommentId, Comment newComment) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.CommentId] = oldCommentId.ToString();

			SendRequest(HttpFunctions.CommentEdits.EditComment, parameters, newComment.ToJson());
		}

		public void Delete(CommentId commentId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.CommentId] = commentId.ToString();

			SendRequest(HttpFunctions.CommentEdits.DeleteComment, parameters);
		}
	}
}
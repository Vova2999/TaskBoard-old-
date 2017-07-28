using System;
using System.Linq;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models.Editors {
	// ReSharper disable UnusedMember.Global

	public class DatabaseCommentEditor : DatabaseEditor, IDatabaseCommentEditor {
		public DatabaseCommentEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(Comment comment) {
			AddSpaceForCommentIndex(comment.Index);

			ModelDatabase.Comments.Add(new CommentEntity {
				Id = Guid.NewGuid(),
				Index = comment.Index,
				Content = comment.Content,
				CreateDateTime = DateTime.Now,
				UserId = ModelDatabase.GetUser(comment.UserId).Id,
				TaskId = ModelDatabase.GetTask(comment.TaskId).Id
			});

			ModelDatabase.SaveChanges();
		}

		public void Edit(CommentId oldCommentId, Comment newComment) {
			var comment = ModelDatabase.GetComment(oldCommentId);
			RemoveSpaceForCommentIndex(comment.Index);
			AddSpaceForCommentIndex(newComment.Index);

			comment.Index = newComment.Index;
			comment.Content = newComment.Content;

			ModelDatabase.SaveChanges();
		}

		public void Delete(CommentId commentId) {
			var comment = ModelDatabase.GetComment(commentId);

			RemoveSpaceForCommentIndex(comment.Index);
			DeleteComment(commentId);

			ModelDatabase.SaveChanges();
		}

		private void AddSpaceForCommentIndex(int commentIndex) {
			ModelDatabase.Comments.Where(c => c.Index >= commentIndex).ForEach(c => c.Index++);
		}
		private void RemoveSpaceForCommentIndex(int commentIndex) {
			ModelDatabase.Comments.Where(c => c.Index >= commentIndex).ForEach(c => c.Index--);
		}
	}
}
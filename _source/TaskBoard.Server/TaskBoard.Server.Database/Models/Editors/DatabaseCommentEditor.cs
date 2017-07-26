using System;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models.Editors {
	// ReSharper disable UnusedMember.Global

	public class DatabaseCommentEditor : DatabaseEditor, IDatabaseCommentEditor {
		public DatabaseCommentEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(Comment comment) {
			ModelDatabase.Comments.Add(new CommentEntity {
				Id = Guid.NewGuid(),
				Content = comment.Content,
				CreateDateTime = DateTime.Now,
				UserId = ModelDatabase.GetUser(comment.UserId).Id,
				TaskId = ModelDatabase.GetTask(comment.TaskId).Id
			});

			ModelDatabase.SaveChanges();
		}

		public void Edit(CommentId oldCommentId, Comment newComment) {
			var comment = ModelDatabase.GetComment(oldCommentId);
			comment.Content = newComment.Content;

			ModelDatabase.SaveChanges();
		}

		public void Delete(CommentId commentId) {
			DeleteComment(commentId);
			ModelDatabase.SaveChanges();
		}
	}
}
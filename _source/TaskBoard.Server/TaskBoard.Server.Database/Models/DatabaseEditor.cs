using System;
using System.Data.Entity;
using System.Linq;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Database.Models {
	// ReSharper disable MemberCanBePrivate.Global

	public abstract class DatabaseEditor {
		protected readonly ModelDatabase ModelDatabase;

		protected DatabaseEditor(ModelDatabase modelDatabase) {
			ModelDatabase = modelDatabase;
		}

		protected void DeleteBoard(BoardId boardId) {
			DeleteBoard(boardId.InstanceId);
		}
		protected void DeleteBoard(Guid boardId) {
			ModelDatabase.Tasks.Where(t => t.BoardId == boardId).ToList().ForEach(task => DeleteTask(task.Id));
			ModelDatabase.Columns.Where(c => c.BoardId == boardId).ToList().ForEach(column => DeleteColumn(column.Id));
			ModelDatabase.Boards.Remove(ModelDatabase.GetBoard(boardId));
		}

		protected void DeleteColumn(ColumnId columnId) {
			DeleteColumn(columnId.InstanceId);
		}
		protected void DeleteColumn(Guid columnId) {
			ModelDatabase.Tasks.Include(t => t.Developer).Include(t => t.Reviewer).Include(t => t.Column).Include(t => t.Board).Where(t => t.ColumnId == columnId).ToList().ForEach(task => task.ColumnId = null);
			ModelDatabase.Columns.Remove(ModelDatabase.GetColumn(columnId));
		}

		protected void DeleteComment(CommentId commentId) {
			DeleteComment(commentId.InstanceId);
		}
		protected void DeleteComment(Guid commentId) {
			ModelDatabase.Comments.Remove(ModelDatabase.GetComment(commentId));
		}

		protected void DeleteTask(TaskId taskId) {
			DeleteTask(taskId.InstanceId);
		}
		protected void DeleteTask(Guid taskId) {
			ModelDatabase.Comments.Where(comment => comment.TaskId == taskId).ToList().ForEach(comment => DeleteComment(comment.Id));
			ModelDatabase.Tasks.Remove(ModelDatabase.GetTask(taskId));
		}

		protected void DeleteUser(UserId userId) {
			DeleteUser(userId.InstanceId);
		}
		protected void DeleteUser(Guid userId) {
			ModelDatabase.Comments.Where(comment => comment.UserId == userId).ToList().ForEach(comment => DeleteComment(comment.Id));
			ModelDatabase.Tasks.Include(t => t.Developer).Include(t => t.Reviewer).Include(t => t.Column).Include(t => t.Board).Where(task => task.DeveloperId == userId).ToList().ForEach(task => task.DeveloperId = null);
			ModelDatabase.Tasks.Include(t => t.Developer).Include(t => t.Reviewer).Include(t => t.Column).Include(t => t.Board).Where(task => task.ReviewerId == userId).ToList().ForEach(task => task.ReviewerId = null);
			ModelDatabase.Users.Remove(ModelDatabase.GetUser(userId));
		}
	}
}
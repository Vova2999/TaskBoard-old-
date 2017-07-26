using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable UnusedAutoPropertyAccessor.Global

	public class ModelDatabase : DbContext {
		public DbSet<CommentEntity> Comments { get; set; }
		public DbSet<ColumnEntity> Columns { get; set; }
		public DbSet<BoardEntity> Boards { get; set; }
		public DbSet<TaskEntity> Tasks { get; set; }
		public DbSet<UserEntity> Users { get; set; }

		public ModelDatabase() : base("TaskBoardDatabase") {
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
		}

		public override int SaveChanges() {
			try {
				return base.SaveChanges();
			}
			catch (Exception) {
				ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
				throw;
			}
		}

		public BoardEntity GetBoard(BoardId boardId) {
			return GetBoard(boardId.InstanceId);
		}
		public BoardEntity GetBoard(Guid boardId) {
			return Boards
					.FirstOrDefault(b => b.Id == boardId)
				?? throw new ArgumentException($"Не найдена доска с id = '{boardId}'");
		}

		public ColumnEntity GetColumn(ColumnId columnId) {
			return GetColumn(columnId?.InstanceId);
		}
		public ColumnEntity GetColumn(Guid? columnId) {
			return columnId == null ? null : GetColumn(columnId.Value);
		}
		public ColumnEntity GetColumn(Guid columnId) {
			return Columns
					.Include(c => c.Board)
					.FirstOrDefault(c => c.Id == columnId)
				?? throw new ArgumentException($"Не найден столбец с id = '{columnId}'");
		}

		public CommentEntity GetComment(CommentId commentId) {
			return GetComment(commentId.InstanceId);
		}
		public CommentEntity GetComment(Guid commentId) {
			return Comments
					.Include(c => c.User)
					.Include(c => c.Task)
					.FirstOrDefault(c => c.Id == commentId)
				?? throw new ArgumentException($"Не найден комментарий с id = '{commentId}'");
		}

		public TaskEntity GetTask(TaskId taskId) {
			return GetTask(taskId.InstanceId);
		}
		public TaskEntity GetTask(Guid taskId) {
			return Tasks
					.Include(t => t.Developer)
					.Include(t => t.Reviewer)
					.Include(t => t.Column)
					.Include(t => t.Board)
					.FirstOrDefault(t => t.Id == taskId)
				?? throw new ArgumentException($"Не найдена задача с id = '{taskId}'");
		}

		public UserEntity GetUser(UserId userId) {
			return GetUser(userId.InstanceId);
		}
		public UserEntity GetUser(Guid? userId) {
			return userId == null ? null : GetUser(userId.Value);
		}
		public UserEntity GetUser(Guid userId) {
			return Users
					.FirstOrDefault(u => u.Id == userId)
				?? throw new ArgumentException($"Не найден пользователь с id = '{userId}'");
		}
	}
}
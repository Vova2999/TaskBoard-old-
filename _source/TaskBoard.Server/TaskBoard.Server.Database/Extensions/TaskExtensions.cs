using System.Collections.Generic;
using System.Linq;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Extensions {
	// ReSharper disable MemberCanBePrivate.Global

	public static class TaskExtensions {
		public static Task[] ToTables(this IEnumerable<TaskEntity> tasks) {
			return tasks.Select(ToTable).ToArray();
		}
		public static Task ToTable(this TaskEntity task) {
			return new Task {
				Id = task.Id.ToTaskId(),
				Header = task.Header,
				Description = task.Description,
				Branch = task.Branch,
				State = task.State,
				Priority = task.Priority,
				CreateDateTime = task.CreateDateTime,
				DeveloperId = task.DeveloperId?.ToUserId(),
				ReviewerId = task.ReviewerId?.ToUserId(),
				ColumnId = task.ColumnId?.ToColumnId(),
				BoardId = task.BoardId.ToBoardId()
			};
		}
	}
}
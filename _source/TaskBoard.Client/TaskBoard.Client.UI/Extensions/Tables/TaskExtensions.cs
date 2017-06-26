using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions {
	public static class TaskExtensions {
		public static TaskModel[] ToModels(this IEnumerable<Task> tasks, User developer, User reviewer, Column column, Board board) {
			return tasks.Select(task => task.ToModel(developer, reviewer, column, board)).ToArray();
		}

		public static TaskModel ToModel(this Task task, User developer, User reviewer, Column column, Board board) {
			if (task.DeveloperId != developer?.UserId)
				throw new InvalidOperationException($"Ошибка при преобразовании из {nameof(Task)} в {nameof(TaskModel)}");

			return new TaskModel {
				TaskId = task.TaskId,
				Header = task.Header,
				Description = task.Description,
				Branch = task.Branch,
				State = task.State,
				Priority = task.Priority,
				CreateDateTime = task.CreateDateTime,
				DeveloperName = developer?.Login,
				ReviewerName = reviewer?.Login,
				ColumnHeader = column?.Header,
				ColumnBrush = column == null ? Brushes.Black : (Brush)new BrushConverter().ConvertFromString(column.Brush),
				BoardName = board.Name
			};
		}
	}
}
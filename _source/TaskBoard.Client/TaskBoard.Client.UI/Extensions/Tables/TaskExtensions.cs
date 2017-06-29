using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class TaskExtensions {
		public static TaskModel[] ToModels(this IEnumerable<Task> tasks, IHttpClientProvider httpClientProvider) {
			return tasks.Select(task => task.ToModel(httpClientProvider)).ToArray();
		}

		public static TaskModel ToModel(this Task task, IHttpClientProvider httpClientProvider) {
			var developer = task.DeveloperId == null ? null : httpClientProvider.GetDatabaseUserReader().GetById(task.DeveloperId.Value);
			var reviewer = task.ReviewerId == null ? null : httpClientProvider.GetDatabaseUserReader().GetById(task.ReviewerId.Value);
			var column = task.ColumnId == null ? null : httpClientProvider.GetDatabaseColumnReader().GetById(task.ColumnId.Value);
			var board = httpClientProvider.GetDatabaseBoardReader().GetById(task.BoardId);

			return new TaskModel {
				TaskId = task.TaskId,
				Header = task.Header,
				Description = task.Description,
				Branch = task.Branch,
				State = task.State,
				Priority = task.Priority,
				CreateDateTime = task.CreateDateTime,
				DeveloperName = developer?.Login ?? string.Empty,
				ReviewerName = reviewer?.Login ?? string.Empty,
				ColumnHeader = column?.Header ?? string.Empty,
				ColumnBrush = column == null ? null : (Brush)new BrushConverter().ConvertFromString(column.Brush),
				BoardName = board.Name
			};
		}
	}
}
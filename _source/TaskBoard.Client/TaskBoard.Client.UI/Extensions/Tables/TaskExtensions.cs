using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class TaskExtensions {
		public static TaskModel[] ToModels(this IEnumerable<Task> tasks, IHttpClientProvider httpClientProvider, UserModel developerUserModel = null, UserModel reviewerUserModel = null, ColumnModel columnModel = null, BoardModel boardModel = null) {
			return tasks.Select(task => task.ToModel(httpClientProvider, developerUserModel, reviewerUserModel, columnModel, boardModel)).ToArray();
		}

		public static TaskModel ToModel(this Task task, IHttpClientProvider httpClientProvider, UserModel developerUserModel = null, UserModel reviewerUserModel = null, ColumnModel columnModel = null, BoardModel boardModel = null) {
			if (task.DeveloperId != null && developerUserModel?.UserId != task.DeveloperId)
				developerUserModel = httpClientProvider.GetDatabaseUserReader().GetById(task.DeveloperId.Value).ToModel(httpClientProvider);
			if (task.ReviewerId != null && reviewerUserModel?.UserId != task.ReviewerId)
				reviewerUserModel = httpClientProvider.GetDatabaseUserReader().GetById(task.ReviewerId.Value).ToModel(httpClientProvider);
			if (task.ColumnId != null && columnModel?.ColumnId != task.ColumnId)
				columnModel = httpClientProvider.GetDatabaseColumnReader().GetById(task.ColumnId.Value).ToModel(httpClientProvider);
			if (boardModel?.BoardId != task.BoardId)
				boardModel = httpClientProvider.GetDatabaseBoardReader().GetById(task.BoardId).ToModel(httpClientProvider);

			return new TaskModel {
				TaskId = task.TaskId,
				Header = task.Header,
				Description = task.Description,
				Branch = task.Branch,
				State = task.State,
				Priority = task.Priority,
				CreateDateTime = task.CreateDateTime,
				DeveloperUserModel = developerUserModel,
				ReviewerUserModel = reviewerUserModel,
				ColumnModel = columnModel,
				BoardModel = boardModel
			};
		}
	}
}
using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class TaskExtensions {
		public static TaskModel[] ToModels(this IEnumerable<Task> tasks, IHttpClientProvider httpClientProvider, IEnumerable<UserModel> userModels = null, IEnumerable<ColumnModel> columnModels = null, IEnumerable<BoardModel> boardModels = null) {
			var userModelsArray = userModels.ToArrayOrNull();
			var columnModelsArray = columnModels.ToArrayOrNull();
			var boardModelsArray = boardModels.ToArrayOrNull();

			return tasks.Select(task => task.ToModel(httpClientProvider, userModelsArray, columnModelsArray, boardModelsArray)).ToArray();
		}

		public static TaskModel ToModel(this Task task, IHttpClientProvider httpClientProvider, IEnumerable<UserModel> userModels = null, IEnumerable<ColumnModel> columnModels = null, IEnumerable<BoardModel> boardModels = null) {
			var userModelsArray = userModels.ToArrayOrNull();

			var developerUserModel = task.DeveloperId == null
				? null
				: (userModelsArray?.FirstOrDefault(model => model.Id == task.DeveloperId)
					?? httpClientProvider.GetDatabaseUserReader().GetById(task.DeveloperId).ToModel(httpClientProvider));

			var reviewerUserModel = task.ReviewerId == null
				? null
				: (userModelsArray?.FirstOrDefault(model => model.Id == task.ReviewerId)
					?? httpClientProvider.GetDatabaseUserReader().GetById(task.ReviewerId).ToModel(httpClientProvider));

			var columnModel = task.ColumnId == null
				? null
				: (columnModels?.FirstOrDefault(model => model.Id == task.ColumnId)
					?? httpClientProvider.GetDatabaseColumnReader().GetById(task.ColumnId).ToModel(httpClientProvider));

			var boardModel = boardModels?.FirstOrDefault(model => model.Id == task.BoardId)
				?? httpClientProvider.GetDatabaseBoardReader().GetById(task.BoardId).ToModel(httpClientProvider);

			return new TaskModel(task.Id) {
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
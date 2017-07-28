using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class TaskExtensions {
		public static TaskModel[] ToModels(this IEnumerable<Task> tasks, IHttpClientProvider httpClientProvider, UserModel developerUserModel = null, UserModel reviewerUserModel = null, ColumnModel columnModel = null, BoardModel boardModel = null) {
			return tasks.Select(task => task.ToModel(httpClientProvider, developerUserModel, reviewerUserModel, columnModel, boardModel)).ToArray();
		}

		public static TaskModel ToModel(this Task task, IHttpClientProvider httpClientProvider, UserModel developerUserModel = null, UserModel reviewerUserModel = null, ColumnModel columnModel = null, BoardModel boardModel = null) {
			return new TaskModel(task.Id) {
				Index = task.Index,
				Header = task.Header,
				Description = task.Description,
				Branch = task.Branch,
				State = task.State,
				Priority = task.Priority,
				CreateDateTime = task.CreateDateTime,
				DeveloperUserModel = task.CheckOrDownloadDeveloperUserModel(httpClientProvider, developerUserModel),
				ReviewerUserModel = task.CheckOrDownloadReviewerUserModel(httpClientProvider, reviewerUserModel),
				ColumnModel = task.CheckOrDownloadColumnModel(httpClientProvider, columnModel, boardModel),
				BoardModel = task.CheckOrDownloadBoardModel(httpClientProvider, boardModel)
			};
		}

		private static UserModel CheckOrDownloadDeveloperUserModel(this Task task, IHttpClientProvider httpClientProvider, UserModel userModel) {
			return task.DeveloperId == null ? null : task.DeveloperId == userModel?.Id ? userModel : httpClientProvider.GetDatabaseUserReader().GetById(task.DeveloperId).ToModel(httpClientProvider);
		}
		private static UserModel CheckOrDownloadReviewerUserModel(this Task task, IHttpClientProvider httpClientProvider, UserModel userModel) {
			return task.ReviewerId == null ? null : task.ReviewerId == userModel?.Id ? userModel : httpClientProvider.GetDatabaseUserReader().GetById(task.ReviewerId).ToModel(httpClientProvider);
		}
		private static ColumnModel CheckOrDownloadColumnModel(this Task task, IHttpClientProvider httpClientProvider, ColumnModel columnModel, BoardModel boardModel = null) {
			return task.ColumnId == columnModel?.Id ? columnModel : httpClientProvider.GetDatabaseColumnReader().GetById(task.ColumnId).ToModel(httpClientProvider, boardModel);
		}
		private static BoardModel CheckOrDownloadBoardModel(this Task task, IHttpClientProvider httpClientProvider, BoardModel boardModel) {
			return task.BoardId == boardModel?.Id ? boardModel : httpClientProvider.GetDatabaseBoardReader().GetById(task.BoardId).ToModel(httpClientProvider);
		}
	}
}
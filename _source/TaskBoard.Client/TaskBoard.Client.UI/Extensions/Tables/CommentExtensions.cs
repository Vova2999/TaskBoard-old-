using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class CommentExtensions {
		public static CommentModel[] ToModels(this IEnumerable<Comment> comments, IHttpClientProvider httpClientProvider, UserModel userModel = null, TaskModel taskModel = null) {
			return comments.Select(comment => comment.ToModel(httpClientProvider, userModel, taskModel)).ToArray();
		}

		public static CommentModel ToModel(this Comment comment, IHttpClientProvider httpClientProvider, UserModel userModel = null, TaskModel taskModel = null) {
			return new CommentModel(comment.Id) {
				Content = comment.Content,
				CreateDateTime = comment.CreateDateTime,
				UserModel = comment.CheckOrDownloadUserModel(httpClientProvider, userModel),
				TaskModel = comment.CheckOrDownloadTaskModel(httpClientProvider, taskModel, userModel, userModel)
			};
		}

		private static UserModel CheckOrDownloadUserModel(this Comment comment, IHttpClientProvider httpClientProvider, UserModel userModel) {
			return comment.UserId == userModel?.Id ? userModel : httpClientProvider.GetDatabaseUserReader().GetById(comment.UserId).ToModel(httpClientProvider);
		}
		private static TaskModel CheckOrDownloadTaskModel(this Comment comment, IHttpClientProvider httpClientProvider, TaskModel taskModel, UserModel developerUserModel = null, UserModel reviewerUserModel = null, ColumnModel columnModel = null, BoardModel boardModel = null) {
			return comment.TaskId == taskModel?.Id ? taskModel : httpClientProvider.GetDatabaseTaskReader().GetById(comment.TaskId).ToModel(httpClientProvider, developerUserModel, reviewerUserModel, columnModel, boardModel);
		}
	}
}
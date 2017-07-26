using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class CommentExtensions {
		public static CommentModel[] ToModels(this IEnumerable<Comment> comments, IHttpClientProvider httpClientProvider, IEnumerable<UserModel> userModels = null, IEnumerable<TaskModel> taskModels = null) {
			var userModelsArray = userModels.ToArrayOrNull();
			var taskModelsArray = taskModels.ToArrayOrNull();

			return comments.Select(comment => comment.ToModel(httpClientProvider, userModelsArray, taskModelsArray)).ToArray();
		}

		public static CommentModel ToModel(this Comment comment, IHttpClientProvider httpClientProvider, IEnumerable<UserModel> userModels = null, IEnumerable<TaskModel> taskModels = null) {
			var userModel = userModels?.FirstOrDefault(model => model.Id == comment.UserId)
				?? httpClientProvider.GetDatabaseUserReader().GetById(comment.UserId).ToModel(httpClientProvider);
			var taskModel = taskModels?.FirstOrDefault(model => model.Id == comment.TaskId)
				?? httpClientProvider.GetDatabaseTaskReader().GetById(comment.TaskId).ToModel(httpClientProvider);

			return new CommentModel(comment.Id) {
				Content = comment.Content,
				CreateDateTime = comment.CreateDateTime,
				UserModel = userModel,
				TaskModel = taskModel
			};
		}
	}
}
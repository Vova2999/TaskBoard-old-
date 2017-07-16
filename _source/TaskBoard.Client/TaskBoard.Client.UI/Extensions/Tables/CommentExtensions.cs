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
			if (userModel?.UserId != comment.UserId)
				userModel = httpClientProvider.GetDatabaseUserReader().GetById(comment.UserId).ToModel(httpClientProvider);
			if (taskModel?.TaskId != comment.TaskId)
				taskModel = httpClientProvider.GetDatabaseTaskReader().GetById(comment.TaskId).ToModel(httpClientProvider);

			return new CommentModel {
				CommentId = comment.CommentId,
				Content = comment.Content,
				CreateDateTime = comment.CreateDateTime,
				UserModel = userModel,
				TaskModel = taskModel
			};
		}
	}
}
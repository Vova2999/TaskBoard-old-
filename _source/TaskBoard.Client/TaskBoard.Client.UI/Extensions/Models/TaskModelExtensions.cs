using System.Collections.ObjectModel;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.Extensions.Models {
	public static class TaskModelExtensions {
		public static TaskModel DownloadCommentModels(this TaskModel taskModel, IHttpClientProvider httpClientProvider) {
			taskModel.CommentModels = new ObservableCollection<CommentModel>(httpClientProvider.GetDatabaseCommentReader().GetFromTask(taskModel.TaskId).ToModels(httpClientProvider));
			return taskModel;
		}
	}
}
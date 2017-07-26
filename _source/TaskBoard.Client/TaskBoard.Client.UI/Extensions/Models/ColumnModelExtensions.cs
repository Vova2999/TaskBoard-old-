using System.Collections.ObjectModel;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.Extensions.Models {
	public static class ColumnModelExtensions {
		public static ColumnModel DownloadTaskModels(this ColumnModel columnModel, IHttpClientProvider httpClientProvider) {
			columnModel.TaskModels = new ObservableCollection<TaskModel>(httpClientProvider.GetDatabaseTaskReader().GetFromColumn(columnModel.BoardModel.Id, columnModel.Id).ToModels(httpClientProvider));
			return columnModel;
		}
	}
}
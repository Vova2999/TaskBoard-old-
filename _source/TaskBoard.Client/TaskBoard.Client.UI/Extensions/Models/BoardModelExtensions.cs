using System.Collections.ObjectModel;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.Extensions.Models {
	public static class BoardModelExtensions {
		public static BoardModel DownloadColumnModels(this BoardModel boardModel, IHttpClientProvider httpClientProvider) {
			boardModel.ColumnModels = new ObservableCollection<ColumnModel>(httpClientProvider.GetDatabaseColumnReader().GetFromBoard(boardModel.BoardId).ToModels(httpClientProvider));
			return boardModel;
		}

		public static BoardModel DownloadTaskModels(this BoardModel boardModel, IHttpClientProvider httpClientProvider) {
			boardModel.TaskModels = new ObservableCollection<TaskModel>(httpClientProvider.GetDatabaseTaskReader().GetFromBoard(boardModel.BoardId).ToModels(httpClientProvider));
			return boardModel;
		}
	}
}
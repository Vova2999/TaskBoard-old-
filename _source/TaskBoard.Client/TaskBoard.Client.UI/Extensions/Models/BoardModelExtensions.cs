using System.Collections.ObjectModel;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Extensions;

namespace TaskBoard.Client.UI.Extensions.Models {
	public static class BoardModelExtensions {
		public static BoardModel DownloadColumnAndTaskModels(this BoardModel boardModel, IHttpClientProvider httpClientProvider) {
			boardModel.ColumnModels = new ObservableCollection<ColumnModel>(httpClientProvider.GetDatabaseColumnReader().GetFromBoard(boardModel.Id)
				.ToModels(httpClientProvider, boardModel).OrderBy(columnModel => columnModel.Index));
			boardModel.ColumnModels.ForEach(columnModel => columnModel.DownloadTaskModels(httpClientProvider));
			boardModel.TaskModels = new ObservableCollection<TaskModel>(boardModel.ColumnModels.SelectMany(columnModel => columnModel.TaskModels));
			return boardModel;
		}
	}
}
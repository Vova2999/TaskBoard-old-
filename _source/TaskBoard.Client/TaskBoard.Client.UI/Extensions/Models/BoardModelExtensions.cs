using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.UI.Extensions.Models {
	public static class BoardModelExtensions {
		public static BoardModel DownloadColumnAndTaskModels(this BoardModel boardModel, IHttpClientProvider httpClientProvider) {
			boardModel.ColumnModels = new ObservableCollection<ColumnModel>(httpClientProvider.GetDatabaseColumnReader().GetFromBoard(boardModel.Id).ToModels(httpClientProvider, new[] { boardModel }));
			boardModel.TaskModels = new ObservableCollection<TaskModel>(httpClientProvider.GetDatabaseTaskReader().GetFromBoard(boardModel.Id).ToModels(httpClientProvider));
			return boardModel;
		}

		public static BoardModel FindByIdOrDownload(this IEnumerable<BoardModel> boardModels, IHttpClientProvider httpClientProvider, BoardId boardId) {
			return boardModels?.FirstOrDefault(model => model.Id == boardId) ?? httpClientProvider.GetDatabaseBoardReader().GetById(boardId).ToModel(httpClientProvider);
		}
	}
}
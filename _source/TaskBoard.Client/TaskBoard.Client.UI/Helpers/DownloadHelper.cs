using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.UI.Helpers {
	public static class DownloadHelper {
		public static class BoardModels {
			public static BoardModel GetById(IHttpClientProvider httpClientProvider, BoardId boardId) {
				return httpClientProvider.GetDatabaseBoardReader().GetById(boardId).ToModel(httpClientProvider);
			}

			public static BoardModel GetByModel(IHttpClientProvider httpClientProvider, BoardModel boardModel) {
				return httpClientProvider.GetDatabaseBoardReader().GetById(boardModel.Id).ToModel(httpClientProvider);
			}

			public static BoardModel[] GetAll(IHttpClientProvider httpClientProvider) {
				return httpClientProvider.GetDatabaseBoardReader().GetAll().ToModels(httpClientProvider);
			}
		}

		public static class ColumnModels {
			public static ColumnModel GetById(IHttpClientProvider httpClientProvider, ColumnId columnId) {
				return httpClientProvider.GetDatabaseColumnReader().GetById(columnId).ToModel(httpClientProvider);
			}
		}
	}
}
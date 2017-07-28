using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class ColumnExtensions {
		public static ColumnModel[] ToModels(this IEnumerable<Column> columns, IHttpClientProvider httpClientProvider, BoardModel boardModel = null) {
			return columns.Select(column => column.ToModel(httpClientProvider, boardModel)).ToArray();
		}

		public static ColumnModel ToModel(this Column column, IHttpClientProvider httpClientProvider, BoardModel boardModel = null) {
			return new ColumnModel(column.Id) {
				Index = column.Index,
				Header = column.Header,
				Brush = (Brush)new BrushConverter().ConvertFromString(column.Brush),
				BoardModel = column.CheckOrDownloadBoardModel(httpClientProvider, boardModel)
			};
		}

		private static BoardModel CheckOrDownloadBoardModel(this Column column, IHttpClientProvider httpClientProvider, BoardModel boardModel) {
			return column.BoardId == boardModel?.Id ? boardModel : httpClientProvider.GetDatabaseBoardReader().GetById(column.BoardId).ToModel(httpClientProvider);
		}
	}
}
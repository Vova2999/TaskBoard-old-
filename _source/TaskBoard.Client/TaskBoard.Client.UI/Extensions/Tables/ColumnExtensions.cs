using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Models;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class ColumnExtensions {
		public static ColumnModel[] ToModels(this IEnumerable<Column> columns, IHttpClientProvider httpClientProvider, IEnumerable<BoardModel> boardModels = null) {
			var boardModelsArray = boardModels.ToArrayOrNull();

			return columns.Select(column => column.ToModel(httpClientProvider, boardModelsArray)).ToArray();
		}

		public static ColumnModel ToModel(this Column column, IHttpClientProvider httpClientProvider, IEnumerable<BoardModel> boardModels = null) {
			return new ColumnModel(column.Id) {
				Header = column.Header,
				Brush = (Brush)new BrushConverter().ConvertFromString(column.Brush),
				BoardModel = boardModels.FindByIdOrDownload(httpClientProvider, column.BoardId)
			};
		}
	}
}
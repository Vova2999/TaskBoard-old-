using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class ColumnExtensions {
		public static ColumnModel[] ToModels(this IEnumerable<Column> columns, IHttpClientProvider httpClientProvider) {
			return columns.Select(column => column.ToModel(httpClientProvider)).ToArray();
		}

		public static ColumnModel ToModel(this Column column, IHttpClientProvider httpClientProvider) {
			var board = httpClientProvider.GetDatabaseBoardReader().GetById(column.BoardId);

			return new ColumnModel {
				ColumnId = column.ColumnId,
				BoardId = column.BoardId,
				Header = column.Header,
				Brush = (Brush)new BrushConverter().ConvertFromString(column.Brush),
				BoardName = board.Name
			};
		}
	}
}
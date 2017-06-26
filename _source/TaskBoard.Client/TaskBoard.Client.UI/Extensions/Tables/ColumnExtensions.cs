using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions {
	public static class ColumnExtensions {
		public static ColumnModel[] ToModels(this IEnumerable<Column> columns, Board board) {
			return columns.Select(column => column.ToModel(board)).ToArray();
		}

		public static ColumnModel ToModel(this Column column, Board board) {
			if (column.BoardId != board.BoardId)
				throw new InvalidOperationException($"Ошибка при преобразовании из {nameof(Column)} в {nameof(ColumnModel)}");

			return new ColumnModel {
				ColumnId = column.ColumnId,
				Header = column.Header,
				Brush = (Brush)new BrushConverter().ConvertFromString(column.Brush),
				BoardName = board.Name
			};
		}
	}
}
using System;
using System.Linq;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models.Editors {
	// ReSharper disable UnusedMember.Global

	public class DatabaseColumnEditor : DatabaseEditor, IDatabaseColumnEditor {
		public DatabaseColumnEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(Column column) {
			AddSpaceForColumnIndex(column.Index);

			ModelDatabase.Columns.Add(new ColumnEntity {
				Id = Guid.NewGuid(),
				Index = column.Index,
				Header = column.Header,
				Brush = column.Brush,
				BoardId = ModelDatabase.GetBoard(column.BoardId).Id
			});

			ModelDatabase.SaveChanges();
		}

		public void Edit(ColumnId oldColumnId, Column newColumn) {
			var column = ModelDatabase.GetColumn(oldColumnId);
			RemoveSpaceForColumnIndex(column.Index);
			AddSpaceForColumnIndex(newColumn.Index);

			column.Index = newColumn.Index;
			column.Header = newColumn.Header;
			column.Brush = newColumn.Brush;

			ModelDatabase.SaveChanges();
		}

		public void Delete(ColumnId columnId) {
			var column = ModelDatabase.GetColumn(columnId);

			RemoveSpaceForColumnIndex(column.Index);
			DeleteColumn(columnId);

			ModelDatabase.SaveChanges();
		}

		private void AddSpaceForColumnIndex(int columnIndex) {
			ModelDatabase.Columns.Where(c => c.Index >= columnIndex).ForEach(c => c.Index++);
		}
		private void RemoveSpaceForColumnIndex(int taskIndex) {
			ModelDatabase.Columns.Where(c => c.Index >= taskIndex).ForEach(c => c.Index--);
		}
	}
}
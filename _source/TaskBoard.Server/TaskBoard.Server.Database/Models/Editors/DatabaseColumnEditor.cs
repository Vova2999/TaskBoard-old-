using System;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models.Editors {
	// ReSharper disable UnusedMember.Global

	public class DatabaseColumnEditor : DatabaseEditor, IDatabaseColumnEditor {
		public DatabaseColumnEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(Column column) {
			ModelDatabase.Columns.Add(new ColumnEntity {
				Id = Guid.NewGuid(),
				Header = column.Header,
				Brush = column.Brush,
				BoardId = ModelDatabase.GetBoard(column.BoardId).Id
			});

			ModelDatabase.SaveChanges();
		}

		public void Edit(ColumnId oldColumnId, Column newColumn) {
			var column = ModelDatabase.GetColumn(oldColumnId);
			column.Header = newColumn.Header;
			column.Brush = newColumn.Brush;

			ModelDatabase.SaveChanges();
		}

		public void Delete(ColumnId columnId) {
			DeleteColumn(columnId);
			ModelDatabase.SaveChanges();
		}
	}
}
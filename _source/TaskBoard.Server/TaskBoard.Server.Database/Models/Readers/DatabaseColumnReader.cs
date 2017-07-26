using System;
using System.Linq;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;
using TaskBoard.Server.Database.Extensions;

namespace TaskBoard.Server.Database.Models.Readers {
	// ReSharper disable UnusedMember.Global

	public class DatabaseColumnReader : DatabaseReader, IDatabaseColumnReader {
		public DatabaseColumnReader(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public Column GetById(ColumnId id) {
			return ModelDatabase.GetColumn(id).ToTable();
		}

		public ColumnId[] GetAllIds() {
			return ModelDatabase.Columns.Select(column => column.Id.ToColumnId()).ToArray();
		}

		public Column[] GetAll() {
			return ModelDatabase.Columns.ToTables();
		}

		public ColumnId GetIdByHeaderWithBoardId(string header, BoardId boardId) {
			return (ModelDatabase.Columns.FirstOrDefault(column => column.Header == header && column.BoardId == boardId.InstanceId)?.BoardId
				?? throw new ArgumentException($"Не найден столбец с header = '{header}', boardId = '{boardId}")).ToColumnId();
		}

		public Column GetByHeaderWithBoardId(string header, BoardId boardId) {
			return ModelDatabase.Columns.FirstOrDefault(column => column.Header == header && column.BoardId == boardId.InstanceId)?.ToTable()
				?? throw new ArgumentException($"Не найден столбец с header = '{header}', boardId = '{boardId}");
		}

		public ColumnId GetIdByHeaderWithBoardName(string header, string boardName) {
			var boardId = ModelDatabase.Boards.FirstOrDefault(b => b.Name == boardName)?.Id ?? throw new ArgumentException($"Не найдена доска с name = '{boardName}'");
			return (ModelDatabase.Columns.FirstOrDefault(column => column.Header == header && column.BoardId == boardId)?.BoardId
				?? throw new ArgumentException($"Не найден столбец с header = '{header}', boardName = '{boardName}")).ToColumnId();
		}

		public Column GetByHeaderWithBoardName(string header, string boardName) {
			var boardId = ModelDatabase.Boards.FirstOrDefault(b => b.Name == boardName)?.Id ?? throw new ArgumentException($"Не найдена доска с name = '{boardName}'");
			return ModelDatabase.Columns.FirstOrDefault(column => column.Header == header && column.BoardId == boardId)?.ToTable()
				?? throw new ArgumentException($"Не найден столбец с header = '{header}', boardName = '{boardName}");
		}

		public ColumnId[] GetIdsFromBoard(BoardId boardId) {
			return ModelDatabase.Columns.Where(column => column.BoardId == boardId.InstanceId).Select(column => column.Id.ToColumnId()).ToArray();
		}

		public Column[] GetFromBoard(BoardId boardId) {
			return ModelDatabase.Columns.Where(column => column.BoardId == boardId.InstanceId).ToTables();
		}

		public ColumnId[] GetIdsWithUsingFilters(string header, string brush, BoardId boardId) {
			return GetQueryWithUsingFilters(header, brush, boardId).Select(column => column.Id.ToColumnId()).ToArray();
		}

		public Column[] GetWithUsingFilters(string header, string brush, BoardId boardId) {
			return GetQueryWithUsingFilters(header, brush, boardId).ToTables();
		}

		private IQueryable<ColumnEntity> GetQueryWithUsingFilters(string header, string brush, BoardId boardId) {
			IQueryable<ColumnEntity> columns = ModelDatabase.Columns;
			UseFilter(header != null, ref columns, column => column.Header.Contains(header));
			UseFilter(brush != null, ref columns, column => column.Brush == brush);
			UseFilter(boardId != null, ref columns, column => column.Id == boardId.InstanceId);

			return columns;
		}
	}
}
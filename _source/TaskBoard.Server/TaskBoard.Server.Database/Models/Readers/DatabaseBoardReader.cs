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

	public class DatabaseBoardReader : DatabaseReader, IDatabaseBoardReader {
		public DatabaseBoardReader(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public Board GetById(BoardId id) {
			return ModelDatabase.GetBoard(id).ToTable();
		}

		public BoardId[] GetAllIds() {
			return ModelDatabase.Boards.Select(board => board.Id.ToBoardId()).ToArray();
		}

		public Board[] GetAll() {
			return ModelDatabase.Boards.ToTables();
		}

		public BoardId GetIdByName(string name) {
			return (ModelDatabase.Boards.FirstOrDefault(b => b.Name == name)?.Id ?? throw new ArgumentException($"Не найдена доска с name = '{name}'")).ToBoardId();
		}

		public Board GetByName(string name) {
			return ModelDatabase.Boards.FirstOrDefault(board => board.Name == name)?.ToTable() ?? throw new ArgumentException($"Не найдена доска с name = '{name}'");
		}

		public BoardId[] GetIdsWithUsingFilters(string name) {
			return GetQueryWithUsingFilters(name).Select(board => board.Id.ToBoardId()).ToArray();
		}

		public Board[] GetWithUsingFilters(string name) {
			return GetQueryWithUsingFilters(name).ToTables();
		}

		private IQueryable<BoardEntity> GetQueryWithUsingFilters(string name) {
			IQueryable<BoardEntity> boards = ModelDatabase.Boards;
			UseFilter(name != null, ref boards, board => board.Name.Contains(name));

			return boards;
		}
	}
}
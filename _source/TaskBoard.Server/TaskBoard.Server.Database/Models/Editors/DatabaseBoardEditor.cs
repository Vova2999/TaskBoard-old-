using System;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models.Editors {
	// ReSharper disable UnusedMember.Global

	public class DatabaseBoardEditor : DatabaseEditor, IDatabaseBoardEditor {
		public DatabaseBoardEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(Board board) {
			ModelDatabase.Boards.Add(new BoardEntity {
				Id = Guid.NewGuid(),
				Name = board.Name
			});

			ModelDatabase.SaveChanges();
		}

		public void Edit(BoardId oldBoardId, Board newBoard) {
			var board = ModelDatabase.GetBoard(oldBoardId);
			board.Name = newBoard.Name;

			ModelDatabase.SaveChanges();
		}

		public void Delete(BoardId boardId) {
			DeleteBoard(boardId);
			ModelDatabase.SaveChanges();
		}
	}
}
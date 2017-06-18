﻿using System;
using System.Linq;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Tables;
using TaskBoard.Server.Database.Entities;
using TaskBoard.Server.Database.Extensions;

namespace TaskBoard.Server.Database.Models.Readers {
	// ReSharper disable UnusedMember.Global

	public class DatabaseBoardReader : DatabaseReader, IDatabaseBoardReader {
		public DatabaseBoardReader(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public Board GetById(Guid id) {
			return ModelDatabase.GetBoard(id).ToTable();
		}

		public Board[] GetAll() {
			return ModelDatabase.Boards.ToTables();
		}

		public Board[] GetWithUsingFilters(string name) {
			IQueryable<BoardEntity> boards = ModelDatabase.Boards;
			UseFilter(name != null, ref boards, board => board.Name.Contains(name));

			return boards.ToTables();
		}
	}
}
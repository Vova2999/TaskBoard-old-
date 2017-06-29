using System;
using TaskBoard.Common.Tables;

namespace TaskBoard.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseBoardReader : IDatabaseReader<Board> {
		Guid GetIdByName(string name);
		Board GetByName(string name);
		Guid[] GetIdsWithUsingFilters(string name);
		Board[] GetWithUsingFilters(string name);
	}
}
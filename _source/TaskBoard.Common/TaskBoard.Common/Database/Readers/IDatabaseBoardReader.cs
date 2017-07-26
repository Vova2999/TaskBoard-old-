using JetBrains.Annotations;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseBoardReader : IDatabaseReader<BoardId, Board> {
		BoardId GetIdByName([NotNull] string name);
		Board GetByName([NotNull] string name);
		BoardId[] GetIdsWithUsingFilters([CanBeNull] string name);
		Board[] GetWithUsingFilters([CanBeNull] string name);
	}
}
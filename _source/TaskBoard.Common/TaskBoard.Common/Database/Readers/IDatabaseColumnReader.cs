using JetBrains.Annotations;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseColumnReader : IDatabaseReader<ColumnId, Column> {
		ColumnId GetIdByHeaderWithBoardId([NotNull] string header, [NotNull] BoardId boardId);
		Column GetByHeaderWithBoardId([NotNull] string header, [NotNull] BoardId boardId);
		ColumnId GetIdByHeaderWithBoardName([NotNull] string header, [NotNull] string boardName);
		Column GetByHeaderWithBoardName([NotNull] string header, [NotNull] string boardName);
		ColumnId[] GetIdsFromBoard([NotNull] BoardId boardId);
		Column[] GetFromBoard([NotNull] BoardId boardId);
		ColumnId[] GetIdsWithUsingFilters([CanBeNull] string header, [CanBeNull] string brush, [CanBeNull] BoardId boardId);
		Column[] GetWithUsingFilters([CanBeNull] string header, [CanBeNull] string brush, [CanBeNull] BoardId boardId);
	}
}
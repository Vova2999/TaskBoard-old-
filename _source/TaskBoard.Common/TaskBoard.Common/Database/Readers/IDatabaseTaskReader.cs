using JetBrains.Annotations;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseTaskReader : IDatabaseReader<TaskId, Task> {
		TaskId[] GetIdsFromBoard([NotNull] BoardId boardId);
		Task[] GetFromBoard([NotNull] BoardId boardId);
		TaskId[] GetIdsFromColumn([NotNull] BoardId boardId, [NotNull] ColumnId columnId);
		Task[] GetFromColumn([NotNull] BoardId boardId, [NotNull] ColumnId columnId);
		TaskId[] GetIdsWithUsingFilters([CanBeNull] string header, [CanBeNull] string description, [CanBeNull] string branch, [CanBeNull] State? state, [CanBeNull] Priority? priority, [CanBeNull] UserId developerId, [CanBeNull] UserId reviewerId, [CanBeNull] ColumnId columnId, [CanBeNull] BoardId boardId);
		Task[] GetWithUsingFilters([CanBeNull] string header, [CanBeNull] string description, [CanBeNull] string branch, [CanBeNull] State? state, [CanBeNull] Priority? priority, [CanBeNull] UserId developerId, [CanBeNull] UserId reviewerId, [CanBeNull] ColumnId columnId, [CanBeNull] BoardId boardId);
	}
}
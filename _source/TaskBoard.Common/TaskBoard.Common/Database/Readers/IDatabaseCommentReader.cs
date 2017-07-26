using System;
using JetBrains.Annotations;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseCommentReader : IDatabaseReader<CommentId, Comment> {
		CommentId[] GetIdsFromTask([NotNull] TaskId taskId);
		Comment[] GetFromTask([NotNull] TaskId taskId);
		CommentId[] GetIdsWithUsingFilters([CanBeNull] string content, [CanBeNull] DateTime? beginCreateDateTime, [CanBeNull] DateTime? endCreateDateTime, [CanBeNull] UserId userId, [CanBeNull] TaskId taskId);
		Comment[] GetWithUsingFilters([CanBeNull] string content, [CanBeNull] DateTime? beginCreateDateTime, [CanBeNull] DateTime? endCreateDateTime, [CanBeNull] UserId userId, [CanBeNull] TaskId taskId);
	}
}
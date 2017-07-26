using System;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Extensions {
	// ReSharper disable UnusedMember.Global

	public static class GuidExtensions {
		public static BoardId ToBoardId(this Guid id) {
			return new BoardId(id);
		}

		public static ColumnId ToColumnId(this Guid id) {
			return new ColumnId(id);
		}

		public static CommentId ToCommentId(this Guid id) {
			return new CommentId(id);
		}

		public static TaskId ToTaskId(this Guid id) {
			return new TaskId(id);
		}

		public static UserId ToUserId(this Guid id) {
			return new UserId(id);
		}
	}
}
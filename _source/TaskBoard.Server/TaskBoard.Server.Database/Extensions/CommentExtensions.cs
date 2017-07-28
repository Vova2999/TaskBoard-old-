using System.Collections.Generic;
using System.Linq;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Extensions {
	// ReSharper disable MemberCanBePrivate.Global

	public static class CommentExtensions {
		public static Comment[] ToTables(this IEnumerable<CommentEntity> comments) {
			return comments.Select(ToTable).ToArray();
		}
		public static Comment ToTable(this CommentEntity comment) {
			return new Comment {
				Id = comment.Id.ToCommentId(),
				Index = comment.Index,
				Content = comment.Content,
				CreateDateTime = comment.CreateDateTime,
				UserId = comment.UserId.ToUserId(),
				TaskId = comment.TaskId.ToTaskId()
			};
		}
	}
}
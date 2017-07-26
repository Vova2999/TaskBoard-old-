using System;
using JetBrains.Annotations;
using TaskBoard.Common.Tables.Attributes;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Tables {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable NotNullMemberIsNotInitialized
	// ReSharper disable UnusedMember.Global

	public class Comment : BaseTable<CommentId> {
		[HeaderColumn("Содержание"), NotNull]
		public string Content { get; set; }

		[HeaderColumn("Дата создания")]
		public DateTime CreateDateTime { get; set; }

		[HeaderColumn("Id пользователя"), NotNull]
		public UserId UserId { get; set; }

		[HeaderColumn("Id задачи"), NotNull]
		public TaskId TaskId { get; set; }
	}
}
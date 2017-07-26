using System;
using JetBrains.Annotations;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Tables.Attributes;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Tables {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable NotNullMemberIsNotInitialized
	// ReSharper disable UnusedMember.Global

	public class Task : BaseTable<TaskId> {
		[HeaderColumn("Заголовок"), NotNull]
		public string Header { get; set; }

		[HeaderColumn("Описание"), NotNull]
		public string Description { get; set; }

		[HeaderColumn("Ветка"), NotNull]
		public string Branch { get; set; }

		[HeaderColumn("Состояние")]
		public State State { get; set; }

		[HeaderColumn("Приоритет")]
		public Priority Priority { get; set; }

		[HeaderColumn("Дата создания")]
		public DateTime CreateDateTime { get; set; }

		[HeaderColumn("Id разработчика"), CanBeNull]
		public UserId DeveloperId { get; set; }

		[HeaderColumn("Id ревьювера"), CanBeNull]
		public UserId ReviewerId { get; set; }

		[HeaderColumn("Id столбца"), CanBeNull]
		public ColumnId ColumnId { get; set; }

		[HeaderColumn("Id доски"), NotNull]
		public BoardId BoardId { get; set; }
	}
}
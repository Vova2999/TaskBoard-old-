using System;
using JetBrains.Annotations;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Tables.Attributes;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Tables {
	// ReSharper disable AnnotationRedundancyAtValueType
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable NotNullMemberIsNotInitialized
	// ReSharper disable UnusedMember.Global

	public class Task : BaseTable<TaskId> {
		[HeaderColumn("Индекс"), NotNull]
		public int Index { get; set; }

		[HeaderColumn("Заголовок"), NotNull]
		public string Header { get; set; }

		[HeaderColumn("Описание"), NotNull]
		public string Description { get; set; }

		[HeaderColumn("Ветка"), NotNull]
		public string Branch { get; set; }

		[HeaderColumn("Состояние"), NotNull]
		public State State { get; set; }

		[HeaderColumn("Приоритет"), NotNull]
		public Priority Priority { get; set; }

		[HeaderColumn("Дата создания"), NotNull]
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
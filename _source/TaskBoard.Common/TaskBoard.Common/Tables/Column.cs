using JetBrains.Annotations;
using TaskBoard.Common.Tables.Attributes;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Tables {
	// ReSharper disable AnnotationRedundancyAtValueType
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable NotNullMemberIsNotInitialized
	// ReSharper disable UnusedMember.Global

	public class Column : BaseTable<ColumnId> {
		[HeaderColumn("Индекс"), NotNull]
		public int Index { get; set; }

		[HeaderColumn("Заголовок"), NotNull]
		public string Header { get; set; }

		[HeaderColumn("Цвет задач"), NotNull]
		public string Brush { get; set; }

		[HeaderColumn("Id доски"), NotNull]
		public BoardId BoardId { get; set; }
	}
}
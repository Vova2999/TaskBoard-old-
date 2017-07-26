using JetBrains.Annotations;
using TaskBoard.Common.Tables.Attributes;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Tables {
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable NotNullMemberIsNotInitialized
	// ReSharper disable UnusedMember.Global

	public class Board : BaseTable<BoardId> {
		[HeaderColumn("Название"), NotNull]
		public string Name { get; set; }
	}
}
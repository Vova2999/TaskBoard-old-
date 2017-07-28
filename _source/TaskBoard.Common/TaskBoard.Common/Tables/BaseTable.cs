using JetBrains.Annotations;
using TaskBoard.Common.Tables.Attributes;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Tables {
	// ReSharper disable NotNullMemberIsNotInitialized
	// ReSharper disable UnusedMember.Global

	public abstract class BaseTable<TTableId> where TTableId : BaseTableId {
		[HeaderColumn("Id"), NotNull]
		public TTableId Id { get; set; }
	}
}
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Tables {
	// ReSharper disable UnusedMember.Global

	public abstract class BaseTable<TTableId> where TTableId : BaseTableId {
		public TTableId Id { get; set; }
	}
}
using JetBrains.Annotations;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Database {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseEditor<in TTableId, in TTable> where TTableId : BaseTableId where TTable : BaseTable<TTableId> {
		void Add([NotNull] TTable table);
		void Edit([NotNull] TTableId oldTableId, [NotNull] TTable newTable);
		void Delete([NotNull] TTableId tableId);
	}
}
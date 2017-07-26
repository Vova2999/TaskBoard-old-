using JetBrains.Annotations;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Database {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseReader<TTableId, out TTable> where TTableId : BaseTableId where TTable : BaseTable<TTableId> {
		TTable GetById([NotNull] TTableId id);
		TTableId[] GetAllIds();
		TTable[] GetAll();
	}
}
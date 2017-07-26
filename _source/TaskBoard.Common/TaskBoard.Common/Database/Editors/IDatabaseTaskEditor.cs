using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Database.Editors {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseTaskEditor : IDatabaseEditor<TaskId, Task> {
	}
}
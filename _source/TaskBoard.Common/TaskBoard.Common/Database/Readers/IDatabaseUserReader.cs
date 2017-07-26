using JetBrains.Annotations;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseUserReader : IDatabaseReader<UserId, User> {
		UserId GetIdByLogin([NotNull] string login);
		User GetByLogin([NotNull] string login);
		UserId[] GetIdsWithUsingFilters([CanBeNull] string login);
		User[] GetWithUsingFilters([CanBeNull] string login);
	}
}
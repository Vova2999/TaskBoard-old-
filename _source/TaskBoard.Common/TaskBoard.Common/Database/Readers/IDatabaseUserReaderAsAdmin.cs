using System;
using TaskBoard.Common.Tables;

namespace TaskBoard.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseUserReaderAsAdmin : IDatabaseReader<User> {
		Guid[] GetIdsWithUsingFilters(string login);
		User[] GetWithUsingFilters(string login);
	}
}
using System;
using TaskBoard.Common.Tables;

namespace TaskBoard.Common.Database.Readers {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseUserReader : IDatabaseReader<User> {
		Guid GetIdByLogin(string login);
		User GetByLogin(string login);
		Guid[] GetIdsWithUsingFilters(string login);
		User[] GetWithUsingFilters(string login);
	}
}
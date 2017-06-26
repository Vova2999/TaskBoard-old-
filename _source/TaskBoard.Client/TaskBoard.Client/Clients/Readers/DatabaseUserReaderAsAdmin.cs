using System;
using System.Collections.Generic;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.Clients.Readers {
	public class DatabaseUserReaderAsAdmin : BaseHttpClient, IDatabaseUserReaderAsAdmin {
		public DatabaseUserReaderAsAdmin(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public User GetById(Guid id) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.UserId] = id.ToString();

			return SendRequest<User>(HttpFunctions.GetUserByIdAsAdmin, parameters);
		}

		public Guid[] GetAllIds() {
			return SendRequest<Guid[]>(HttpFunctions.GetAllUserIdsAsAdmin, GetDefaultParameters());
		}

		public User[] GetAll() {
			return SendRequest<User[]>(HttpFunctions.GetAllUsersAsAdmin, GetDefaultParameters());
		}

		public Guid[] GetIdsWithUsingFilters(string login) {
			return SendRequest<Guid[]>(HttpFunctions.GetAllUserIdsAsAdmin, CreateParametersForUsingFilters(login));
		}

		public User[] GetWithUsingFilters(string login) {
			return SendRequest<User[]>(HttpFunctions.GetAllUsersAsAdmin, CreateParametersForUsingFilters(login));
		}

		private Dictionary<string, string> CreateParametersForUsingFilters(string login) {
			var parameters = GetDefaultParameters();
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.UserLogin, login);

			return parameters;
		}
	}
}
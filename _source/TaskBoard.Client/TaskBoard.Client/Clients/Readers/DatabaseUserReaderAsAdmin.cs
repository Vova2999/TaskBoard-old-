using System.Collections.Generic;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Readers {
	public class DatabaseUserReaderAsAdmin : BaseHttpClient, IDatabaseUserReaderAsAdmin {
		public DatabaseUserReaderAsAdmin(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public User GetById(UserId id) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.UserId] = id.ToString();

			return SendRequest<User>(HttpFunctions.UserReadsAsAdmin.GetUserByIdAsAdmin, parameters);
		}

		public UserId[] GetAllIds() {
			return SendRequest<UserId[]>(HttpFunctions.UserReadsAsAdmin.GetAllUserIdsAsAdmin, GetDefaultParameters());
		}

		public User[] GetAll() {
			return SendRequest<User[]>(HttpFunctions.UserReadsAsAdmin.GetAllUsersAsAdmin, GetDefaultParameters());
		}

		public UserId GetIdByLogin(string login) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.UserLogin] = login;

			return SendRequest<UserId>(HttpFunctions.UserReadsAsAdmin.GetUserIdByLoginAsAdmin, parameters);
		}

		public User GetByLogin(string login) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.UserLogin] = login;

			return SendRequest<User>(HttpFunctions.UserReadsAsAdmin.GetUserByLoginAsAdmin, parameters);
		}

		public UserId[] GetIdsWithUsingFilters(string login) {
			return SendRequest<UserId[]>(HttpFunctions.UserReadsAsAdmin.GetAllUserIdsAsAdmin, CreateParametersForUsingFilters(login));
		}

		public User[] GetWithUsingFilters(string login) {
			return SendRequest<User[]>(HttpFunctions.UserReadsAsAdmin.GetAllUsersAsAdmin, CreateParametersForUsingFilters(login));
		}

		private Dictionary<string, string> CreateParametersForUsingFilters(string login) {
			var parameters = GetDefaultParameters();
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.UserLogin, login);

			return parameters;
		}
	}
}
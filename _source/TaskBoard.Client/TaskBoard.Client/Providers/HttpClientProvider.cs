using System;
using System.Collections.Concurrent;
using TaskBoard.Client.Clients;
using TaskBoard.Client.Clients.Editors;
using TaskBoard.Client.Clients.Paramerets;
using TaskBoard.Client.Clients.Readers;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Database.Readers;

namespace TaskBoard.Client.Providers {
	public class HttpClientProvider : IHttpClientProvider {
		private readonly ConcurrentDictionary<string, BaseHttpClient> hashedClients;
		private readonly HttpClientParameters httpClientParameters;
		public string Login => httpClientParameters.Login;
		public string Password => httpClientParameters.Password;
		public string ServerAddress => httpClientParameters.ServerAddress;
		public int TimeoutMs => httpClientParameters.TimeoutMs;
		public bool IsAuthorize => httpClientParameters.IsAuthorize;

		public HttpClientProvider() {
			hashedClients = new ConcurrentDictionary<string, BaseHttpClient>();
			httpClientParameters = new HttpClientParameters();
		}

		public IParameretsClient GetParameretsClient() {
			return GetClient("ParameretsClient", () => new ParameretsClient(httpClientParameters));
		}

		public IDatabaseBoardEditor GetDatabaseBoardEditor() {
			return GetClient("DatabaseBoardEditor", () => new DatabaseBoardEditor(httpClientParameters));
		}
		public IDatabaseColumnEditor GetDatabaseColumnEditor() {
			return GetClient("DatabaseColumnEditor", () => new DatabaseColumnEditor(httpClientParameters));
		}
		public IDatabaseCommentEditor GetDatabaseCommentEditor() {
			return GetClient("DatabaseCommentEditor", () => new DatabaseCommentEditor(httpClientParameters));
		}
		public IDatabaseTaskEditor GetDatabaseTaskEditor() {
			return GetClient("DatabaseTaskEditor", () => new DatabaseTaskEditor(httpClientParameters));
		}
		public IDatabaseUserEditor GetDatabaseUserEditor() {
			return GetClient("DatabaseUserEditor", () => new DatabaseUserEditor(httpClientParameters));
		}

		public IDatabaseBoardReader GetDatabaseBoardReader() {
			return GetClient("DatabaseBoardReader", () => new DatabaseBoardReader(httpClientParameters));
		}
		public IDatabaseColumnReader GetDatabaseColumnReader() {
			return GetClient("DatabaseColumnReader", () => new DatabaseColumnReader(httpClientParameters));
		}
		public IDatabaseCommentReader GetDatabaseCommentReader() {
			return GetClient("DatabaseCommentReader", () => new DatabaseCommentReader(httpClientParameters));
		}
		public IDatabaseTaskReader GetDatabaseTaskReader() {
			return GetClient("DatabaseTaskReader", () => new DatabaseTaskReader(httpClientParameters));
		}
		public IDatabaseUserReader GetDatabaseUserReader() {
			return GetClient("DatabaseUserReader", () => new DatabaseUserReader(httpClientParameters));
		}
		public IDatabaseUserReaderAsAdmin GetDatabaseUserReaderAsAdmin() {
			return GetClient("DatabaseUserReaderAsAdmin", () => new DatabaseUserReaderAsAdmin(httpClientParameters));
		}

		private TClient GetClient<TClient>(string clientName, Func<TClient> createClient) where TClient : BaseHttpClient {
			return (TClient)hashedClients.GetOrAdd(clientName, name => createClient());
		}
	}
}
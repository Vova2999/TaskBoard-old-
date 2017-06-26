using TaskBoard.Client.Clients.Paramerets;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Database.Readers;

namespace TaskBoard.Client.Providers {
	public interface IHttpClientProvider {
		string Login { get; }
		string Password { get; }
		string ServerAddress { get; }
		int TimeoutMs { get; }
		bool IsAuthorize { get; }

		IParameretsClient GetParameretsClient();
		IDatabaseBoardEditor GetDatabaseBoardEditor();
		IDatabaseBoardReader GetDatabaseBoardReader();
		IDatabaseColumnEditor GetDatabaseColumnEditor();
		IDatabaseColumnReader GetDatabaseColumnReader();
		IDatabaseCommentEditor GetDatabaseCommentEditor();
		IDatabaseCommentReader GetDatabaseCommentReader();
		IDatabaseTaskEditor GetDatabaseTaskEditor();
		IDatabaseTaskReader GetDatabaseTaskReader();
		IDatabaseUserEditor GetDatabaseUserEditor();
		IDatabaseUserReader GetDatabaseUserReader();
		IDatabaseUserReaderAsAdmin GetDatabaseUserReaderAsAdmin();
	}
}
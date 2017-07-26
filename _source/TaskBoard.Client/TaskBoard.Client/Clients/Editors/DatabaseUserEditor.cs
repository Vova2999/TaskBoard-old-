using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Editors {
	public class DatabaseUserEditor : BaseHttpClient, IDatabaseUserEditor {
		public DatabaseUserEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(User user) {
			SendRequest(HttpFunctions.UserEdits.AddUser, GetDefaultParameters(), user.ToJson());
		}

		public void Edit(UserId oldUserId, User newUser) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.UserId] = oldUserId.ToString();

			SendRequest(HttpFunctions.UserEdits.EditUser, parameters, newUser.ToJson());
		}

		public void Delete(UserId userId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.UserId] = userId.ToString();

			SendRequest(HttpFunctions.UserEdits.DeleteUser, parameters);
		}
	}
}
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Editors {
	public class DatabaseTaskEditor : BaseHttpClient, IDatabaseTaskEditor {
		public DatabaseTaskEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(Task task) {
			SendRequest(HttpFunctions.TaskEdits.AddTask, GetDefaultParameters(), task.ToJson());
		}

		public void Edit(TaskId oldTaskId, Task newTask) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.TaskId] = oldTaskId.ToString();

			SendRequest(HttpFunctions.TaskEdits.EditTask, parameters, newTask.ToJson());
		}

		public void Delete(TaskId taskId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.TaskId] = taskId.ToString();

			SendRequest(HttpFunctions.TaskEdits.DeleteTask, parameters);
		}
	}
}
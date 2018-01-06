using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.TaskEdits {
	// ReSharper disable UnusedMember.Global

	public class EditTaskHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Task.Edits.EditTask;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseTaskEditor databaseTaskEditor;

		public EditTaskHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskEditor databaseTaskEditor) : base(databaseAuthorizer) {
			this.databaseTaskEditor = databaseTaskEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseTaskEditor.Edit(parameters[HttpParameters.TaskId].ToGuid().ToTaskId(), requestBody.FromJson<Task>());
		}
	}
}
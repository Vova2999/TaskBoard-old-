using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.TaskEdits {
	// ReSharper disable UnusedMember.Global

	public class AddTaskHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Task.Edits.AddTask;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseTaskEditor databaseTaskEditor;

		public AddTaskHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskEditor databaseTaskEditor) : base(databaseAuthorizer) {
			this.databaseTaskEditor = databaseTaskEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseTaskEditor.Add(requestBody.FromJson<Task>());
		}
	}
}
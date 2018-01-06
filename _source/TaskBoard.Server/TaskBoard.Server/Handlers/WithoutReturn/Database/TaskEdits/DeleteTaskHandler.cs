using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.TaskEdits {
	// ReSharper disable UnusedMember.Global

	public class DeleteTaskHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.Task.Edits.DeleteTask;
		protected override AccessType? RequiredAccessType => AccessType.UserWrite;
		private readonly IDatabaseTaskEditor databaseTaskEditor;

		public DeleteTaskHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskEditor databaseTaskEditor) : base(databaseAuthorizer) {
			this.databaseTaskEditor = databaseTaskEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseTaskEditor.Delete(parameters[HttpParameters.TaskId].ToGuid().ToTaskId());
		}
	}
}
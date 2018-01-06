using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.TaskReads {
	// ReSharper disable UnusedMember.Global

	public class GetAllTasksHandler : HttpHandlerBaseWithReturn<Task[]> {
		public override string HandlerName => HttpHandlerNames.Task.Reads.GetAllTasks;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseTaskReader databaseTaskReader;

		public GetAllTasksHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskReader databaseTaskReader) : base(databaseAuthorizer) {
			this.databaseTaskReader = databaseTaskReader;
		}

		protected override Task[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseTaskReader.GetAll();
		}
	}
}
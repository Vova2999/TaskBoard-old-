using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.TaskReads {
	// ReSharper disable UnusedMember.Global

	public class GetTasksFromColumnHandler : HttpHandlerBaseWithReturn<Task[]> {
		public override string HandlerName => HttpHandlerNames.Task.Reads.GetTasksFromColumn;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseTaskReader databaseTaskReader;

		public GetTasksFromColumnHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskReader databaseTaskReader) : base(databaseAuthorizer) {
			this.databaseTaskReader = databaseTaskReader;
		}

		protected override Task[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseTaskReader.GetFromColumn(parameters[HttpParameters.TaskBoardId].ToGuid().ToBoardId(), parameters[HttpParameters.TaskColumnId].ToGuid().ToColumnId());
		}
	}
}
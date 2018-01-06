using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.TaskReads {
	// ReSharper disable UnusedMember.Global

	public class GetTasksWithUsingFiltersHandler : HttpHandlerBaseWithReturn<Task[]> {
		public override string HandlerName => HttpHandlerNames.Task.Reads.GetTasksWithUsingFilters;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseTaskReader databaseTaskReader;

		public GetTasksWithUsingFiltersHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskReader databaseTaskReader) : base(databaseAuthorizer) {
			this.databaseTaskReader = databaseTaskReader;
		}

		protected override Task[] Run(NameValueCollection parameters, byte[] requestBody) {
			var header = parameters.Get(HttpParameters.TaskHeader);
			var description = parameters.Get(HttpParameters.TaskDescription);
			var branch = parameters.Get(HttpParameters.TaskBranch);
			var state = parameters.Get(HttpParameters.TaskState)?.ToState();
			var priority = parameters.Get(HttpParameters.TaskPriority)?.ToPriority();
			var developerId = parameters.Get(HttpParameters.TaskDeveloperId)?.ToGuid().ToUserId();
			var reviewerId = parameters.Get(HttpParameters.TaskReviewerId)?.ToGuid().ToUserId();
			var columnId = parameters.Get(HttpParameters.TaskColumnId)?.ToGuid().ToColumnId();
			var boardId = parameters.Get(HttpParameters.TaskBoardId)?.ToGuid().ToBoardId();

			return databaseTaskReader.GetWithUsingFilters(header, description, branch, state, priority, developerId, reviewerId, columnId, boardId);
		}
	}
}
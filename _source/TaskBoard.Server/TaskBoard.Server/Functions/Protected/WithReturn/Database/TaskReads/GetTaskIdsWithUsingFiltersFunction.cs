using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.TaskReads {
	// ReSharper disable UnusedMember.Global

	public class GetTaskIdsWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<TaskId[]> {
		public override string NameOfCalledMethod => HttpFunctions.TaskReads.GetTaskIdsWithUsingFilters;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseTaskReader databaseTaskReader;

		public GetTaskIdsWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskReader databaseTaskReader) : base(databaseAuthorizer) {
			this.databaseTaskReader = databaseTaskReader;
		}

		protected override TaskId[] Run(NameValues parameters, byte[] requestBody) {
			var header = parameters.GetValueOrNull(HttpParameters.TaskHeader);
			var description = parameters.GetValueOrNull(HttpParameters.TaskDescription);
			var branch = parameters.GetValueOrNull(HttpParameters.TaskBranch);
			var state = parameters.GetValueOrNull(HttpParameters.TaskState)?.ToState();
			var priority = parameters.GetValueOrNull(HttpParameters.TaskPriority)?.ToPriority();
			var developerId = parameters.GetValueOrNull(HttpParameters.TaskDeveloperId)?.ToGuid().ToUserId();
			var reviewerId = parameters.GetValueOrNull(HttpParameters.TaskReviewerId)?.ToGuid().ToUserId();
			var columnId = parameters.GetValueOrNull(HttpParameters.TaskColumnId)?.ToGuid().ToColumnId();
			var boardId = parameters.GetValueOrNull(HttpParameters.TaskBoardId)?.ToGuid().ToBoardId();

			return databaseTaskReader.GetIdsWithUsingFilters(header, description, branch, state, priority, developerId, reviewerId, columnId, boardId);
		}
	}
}
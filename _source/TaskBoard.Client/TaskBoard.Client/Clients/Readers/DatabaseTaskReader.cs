using System.Collections.Generic;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Readers {
	public class DatabaseTaskReader : BaseHttpClient, IDatabaseTaskReader {
		public DatabaseTaskReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public Task GetById(TaskId id) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.TaskId] = id.ToString();

			return SendRequest<Task>(HttpFunctions.TaskReads.GetTaskById, parameters);
		}

		public TaskId[] GetAllIds() {
			return SendRequest<TaskId[]>(HttpFunctions.TaskReads.GetAllTaskIds, GetDefaultParameters());
		}

		public Task[] GetAll() {
			return SendRequest<Task[]>(HttpFunctions.TaskReads.GetAllTasks, GetDefaultParameters());
		}

		public TaskId[] GetIdsFromBoard(BoardId boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.TaskBoardId] = boardId.ToString();

			return SendRequest<TaskId[]>(HttpFunctions.TaskReads.GetTaskIdsFromBoard, parameters);
		}

		public Task[] GetFromBoard(BoardId boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.TaskBoardId] = boardId.ToString();

			return SendRequest<Task[]>(HttpFunctions.TaskReads.GetTasksFromBoard, parameters);
		}

		public TaskId[] GetIdsFromColumn(BoardId boardId, ColumnId columnId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.TaskBoardId] = boardId.ToString();
			parameters[HttpParameters.TaskColumnId] = columnId.ToString();

			return SendRequest<TaskId[]>(HttpFunctions.TaskReads.GetTaskIdsFromColumn, parameters);
		}

		public Task[] GetFromColumn(BoardId boardId, ColumnId columnId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.TaskBoardId] = boardId.ToString();
			parameters[HttpParameters.TaskColumnId] = columnId.ToString();

			return SendRequest<Task[]>(HttpFunctions.TaskReads.GetTasksFromColumn, parameters);
		}

		public TaskId[] GetIdsWithUsingFilters(string header, string description, string branch, State? state, Priority? priority, UserId developerId, UserId reviewerId, ColumnId columnId, BoardId boardId) {
			return SendRequest<TaskId[]>(HttpFunctions.TaskReads.GetTaskIdsWithUsingFilters, CreateParametersForUsingFilters(header, description, branch, state, priority, developerId, reviewerId, columnId, boardId));
		}

		public Task[] GetWithUsingFilters(string header, string description, string branch, State? state, Priority? priority, UserId developerId, UserId reviewerId, ColumnId columnId, BoardId boardId) {
			return SendRequest<Task[]>(HttpFunctions.TaskReads.GetTasksWithUsingFilters, CreateParametersForUsingFilters(header, description, branch, state, priority, developerId, reviewerId, columnId, boardId));
		}

		private Dictionary<string, string> CreateParametersForUsingFilters(string header, string description, string branch, State? state, Priority? priority, UserId developerId, UserId reviewerId, ColumnId columnId, BoardId boardId) {
			var parameters = GetDefaultParameters();
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskHeader, header);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskDescription, description);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskBranch, branch);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskState, state?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskPriority, priority?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskDeveloperId, developerId?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskReviewerId, reviewerId?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskColumnId, columnId?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.TaskBoardId, boardId?.ToString());

			return parameters;
		}
	}
}
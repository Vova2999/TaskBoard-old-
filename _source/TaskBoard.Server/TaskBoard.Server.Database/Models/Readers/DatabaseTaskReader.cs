using System.Linq;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;
using TaskBoard.Server.Database.Extensions;

namespace TaskBoard.Server.Database.Models.Readers {
	// ReSharper disable UnusedMember.Global

	public class DatabaseTaskReader : DatabaseReader, IDatabaseTaskReader {
		public DatabaseTaskReader(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public Task GetById(TaskId id) {
			return ModelDatabase.GetTask(id).ToTable();
		}

		public TaskId[] GetAllIds() {
			return ModelDatabase.Tasks.Select(task => task.Id.ToTaskId()).ToArray();
		}

		public Task[] GetAll() {
			return ModelDatabase.Tasks.ToTables();
		}

		public TaskId[] GetIdsFromBoard(BoardId boardId) {
			return ModelDatabase.Tasks.Where(task => task.BoardId == boardId.InstanceId).Select(task => task.Id.ToTaskId()).ToArray();
		}

		public Task[] GetFromBoard(BoardId boardId) {
			return ModelDatabase.Tasks.Where(task => task.BoardId == boardId.InstanceId).ToTables();
		}

		public TaskId[] GetIdsFromColumn(BoardId boardId, ColumnId columnId) {
			return ModelDatabase.Tasks.Where(task => task.BoardId == boardId.InstanceId && task.ColumnId == columnId.InstanceId).Select(task => task.Id.ToTaskId()).ToArray();
		}

		public Task[] GetFromColumn(BoardId boardId, ColumnId columnId) {
			return ModelDatabase.Tasks.Where(task => task.BoardId == boardId.InstanceId && task.ColumnId == columnId.InstanceId).ToTables();
		}

		public TaskId[] GetIdsWithUsingFilters(string header, string description, string branch, State? state, Priority? priority, UserId developerId, UserId reviewerId, ColumnId columnId, BoardId boardId) {
			return GetQueryWithUsingFilters(header, description, branch, state, priority, developerId, reviewerId, columnId, boardId).Select(task => task.Id.ToTaskId()).ToArray();
		}

		public Task[] GetWithUsingFilters(string header, string description, string branch, State? state, Priority? priority, UserId developerId, UserId reviewerId, ColumnId columnId, BoardId boardId) {
			return GetQueryWithUsingFilters(header, description, branch, state, priority, developerId, reviewerId, columnId, boardId).ToTables();
		}

		private IQueryable<TaskEntity> GetQueryWithUsingFilters(string header, string description, string branch, State? state, Priority? priority, UserId developerId, UserId reviewerId, ColumnId columnId, BoardId boardId) {
			IQueryable<TaskEntity> tasks = ModelDatabase.Tasks;
			UseFilter(header != null, ref tasks, task => task.Header.Contains(header));
			UseFilter(description != null, ref tasks, task => task.Description.Contains(description));
			UseFilter(branch != null, ref tasks, task => task.Branch.Contains(branch));
			UseFilter(state != null, ref tasks, task => task.State == state);
			UseFilter(priority != null, ref tasks, task => task.Priority == priority);
			UseFilter(developerId != null, ref tasks, task => task.DeveloperId == developerId.InstanceId);
			UseFilter(reviewerId != null, ref tasks, task => task.ReviewerId == reviewerId.InstanceId);
			UseFilter(columnId != null, ref tasks, task => task.ColumnId == columnId.InstanceId);
			UseFilter(boardId != null, ref tasks, task => task.BoardId == boardId.InstanceId);

			return tasks;
		}
	}
}
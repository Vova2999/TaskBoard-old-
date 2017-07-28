using System;
using System.Linq;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models.Editors {
	// ReSharper disable UnusedMember.Global

	public class DatabaseTaskEditor : DatabaseEditor, IDatabaseTaskEditor {
		public DatabaseTaskEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(Task task) {
			AddSpaceForTaskIndex(task.Index);

			ModelDatabase.Tasks.Add(new TaskEntity {
				Id = Guid.NewGuid(),
				Index = task.Index,
				Header = task.Header,
				Description = task.Description,
				Branch = string.IsNullOrEmpty(task.Branch) ? "-" : task.Branch,
				State = task.State,
				Priority = task.Priority,
				CreateDateTime = DateTime.Now,
				DeveloperId = ModelDatabase.GetUser(task.DeveloperId)?.Id,
				ReviewerId = ModelDatabase.GetUser(task.ReviewerId)?.Id,
				ColumnId = ModelDatabase.GetColumn(task.ColumnId)?.Id,
				BoardId = ModelDatabase.GetBoard(task.BoardId).Id
			});

			ModelDatabase.SaveChanges();
		}

		public void Edit(TaskId oldTaskId, Task newTask) {
			var task = ModelDatabase.GetTask(oldTaskId);
			RemoveSpaceForTaskIndex(task.Index);
			AddSpaceForTaskIndex(newTask.Index);

			task.Index = newTask.Index;
			task.Header = newTask.Header;
			task.Description = newTask.Description;
			task.Branch = string.IsNullOrEmpty(newTask.Branch) ? "-" : newTask.Branch;
			task.State = newTask.State;
			task.Priority = newTask.Priority;
			task.DeveloperId = ModelDatabase.GetUser(newTask.DeveloperId)?.Id;
			task.ReviewerId = ModelDatabase.GetUser(newTask.ReviewerId)?.Id;
			task.ColumnId = ModelDatabase.GetColumn(newTask.ColumnId)?.Id;

			ModelDatabase.SaveChanges();
		}

		public void Delete(TaskId taskId) {
			var task = ModelDatabase.GetTask(taskId);

			RemoveSpaceForTaskIndex(task.Index);
			DeleteTask(taskId);

			ModelDatabase.SaveChanges();
		}

		private void AddSpaceForTaskIndex(int taskIndex) {
			ModelDatabase.Tasks.Where(t => t.Index >= taskIndex).ForEach(t => t.Index++);
		}
		private void RemoveSpaceForTaskIndex(int taskIndex) {
			ModelDatabase.Tasks.Where(t => t.Index >= taskIndex).ForEach(t => t.Index--);
		}
	}
}
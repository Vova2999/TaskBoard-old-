using System;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using TaskBoard.Common.Enums;

namespace TaskBoard.Client.UI.Models {
	public class TaskModel : ViewModelBase {
		private Guid taskId;
		public Guid TaskId {
			get => taskId;
			set => Set(() => TaskId, ref taskId, value);
		}

		private string header;
		public string Header {
			get => header;
			set => Set(() => Header, ref header, value);
		}

		private string description;
		public string Description {
			get => description;
			set => Set(() => Description, ref description, value);
		}

		private string branch;
		public string Branch {
			get => branch;
			set => Set(() => Branch, ref branch, value);
		}

		private State state;
		public State State {
			get => state;
			set => Set(() => State, ref state, value);
		}

		private Priority priority;
		public Priority Priority {
			get => priority;
			set => Set(() => Priority, ref priority, value);
		}

		private DateTime createDateTime;
		public DateTime CreateDateTime {
			get => createDateTime;
			set => Set(() => CreateDateTime, ref createDateTime, value);
		}

		private string developerName;
		public string DeveloperName {
			get => developerName;
			set => Set(() => DeveloperName, ref developerName, value);
		}

		private string reviewerName;
		public string ReviewerName {
			get => reviewerName;
			set => Set(() => ReviewerName, ref reviewerName, value);
		}

		private string columnHeader;
		public string ColumnHeader {
			get => columnHeader;
			set => Set(() => ColumnHeader, ref columnHeader, value);
		}

		private Brush columnBrush;
		public Brush ColumnBrush {
			get => columnBrush;
			set => Set(() => ColumnBrush, ref columnBrush, value);
		}

		private string boardName;
		public string BoardName {
			get => boardName;
			set => Set(() => BoardName, ref boardName, value);
		}

		public override bool Equals(object obj) {
			return obj is TaskModel that && TaskId.Equals(that.TaskId);
		}
		public override int GetHashCode() {
			return TaskId.GetHashCode();
		}
	}
}
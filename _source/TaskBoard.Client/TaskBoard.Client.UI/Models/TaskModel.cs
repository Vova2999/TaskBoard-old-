using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.UI.Models {
	public class TaskModel : ViewModelBase {
		public TaskId Id { get; }

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

		private UserModel developerUserModel;
		public UserModel DeveloperUserModel {
			get => developerUserModel;
			set => Set(() => DeveloperUserModel, ref developerUserModel, value);
		}

		private UserModel reviewerUserModel;
		public UserModel ReviewerUserModel {
			get => reviewerUserModel;
			set => Set(() => ReviewerUserModel, ref reviewerUserModel, value);
		}

		private ColumnModel columnModel;
		public ColumnModel ColumnModel {
			get => columnModel;
			set => Set(() => ColumnModel, ref columnModel, value);
		}

		private BoardModel boardModel;
		public BoardModel BoardModel {
			get => boardModel;
			set => Set(() => BoardModel, ref boardModel, value);
		}

		private ObservableCollection<CommentModel> commentModels;
		public ObservableCollection<CommentModel> CommentModels {
			get => commentModels;
			set => Set(() => CommentModels, ref commentModels, value);
		}

		public TaskModel(TaskId id) {
			Id = id;
		}

		public override bool Equals(object obj) {
			return obj is TaskModel that && Id.Equals(that.Id);
		}
		public override int GetHashCode() {
			return Id.GetHashCode();
		}
	}
}
using System;
using GalaSoft.MvvmLight;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.UI.Models {
	public class CommentModel : ViewModelBase {
		public CommentId Id { get; }

		private string content;
		public string Content {
			get => content;
			set => Set(() => Content, ref content, value);
		}

		private DateTime createDateTime;
		public DateTime CreateDateTime {
			get => createDateTime;
			set => Set(() => CreateDateTime, ref createDateTime, value);
		}

		private UserModel userModel;
		public UserModel UserModel {
			get => userModel;
			set => Set(() => UserModel, ref userModel, value);
		}

		private TaskModel taskModel;
		public TaskModel TaskModel {
			get => taskModel;
			set => Set(() => TaskModel, ref taskModel, value);
		}

		public CommentModel(CommentId id) {
			Id = id;
		}

		public override bool Equals(object obj) {
			return obj is CommentModel that && Id.Equals(that.Id);
		}
		public override int GetHashCode() {
			return Id.GetHashCode();
		}
	}
}
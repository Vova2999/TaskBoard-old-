using System;
using GalaSoft.MvvmLight;

namespace TaskBoard.Client.UI.Models {
	public class CommentModel : ViewModelBase {
		private Guid commentId;
		public Guid CommentId {
			get => commentId;
			set => Set(() => CommentId, ref commentId, value);
		}

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

		public override bool Equals(object obj) {
			return obj is CommentModel that && CommentId.Equals(that.CommentId);
		}
		public override int GetHashCode() {
			return CommentId.GetHashCode();
		}
	}
}
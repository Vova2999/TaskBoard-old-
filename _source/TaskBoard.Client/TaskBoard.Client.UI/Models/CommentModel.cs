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

		private string userName;
		public string UserName {
			get => userName;
			set => Set(() => UserName, ref userName, value);
		}
	}
}
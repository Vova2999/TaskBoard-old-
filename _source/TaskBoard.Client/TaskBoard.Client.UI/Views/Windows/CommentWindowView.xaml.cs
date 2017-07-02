using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Messages;

namespace TaskBoard.Client.UI.Views.Windows {
	public partial class CommentWindowView {
		public CommentWindowView() {
			InitializeComponent();
			CloseWindowHelper.SetMessageOnCloseWindowView(this, ViewType.Comment);
		}
	}
}
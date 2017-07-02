using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Messages;

namespace TaskBoard.Client.UI.Views.Windows {
	public partial class TaskWindowView {
		public TaskWindowView() {
			InitializeComponent();
			CloseWindowHelper.SetMessageOnCloseWindowView(this, ViewType.Task);
		}
	}
}
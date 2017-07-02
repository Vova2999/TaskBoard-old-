using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Messages;

namespace TaskBoard.Client.UI.Views.Windows {
	public partial class UserWindowView {
		public UserWindowView() {
			InitializeComponent();
			CloseWindowHelper.SetMessageOnCloseWindowView(this, ViewType.User);
		}
	}
}
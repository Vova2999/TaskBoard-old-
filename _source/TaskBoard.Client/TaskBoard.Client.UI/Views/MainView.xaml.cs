using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Messages;

namespace TaskBoard.Client.UI.Views {
	public partial class MainView {
		public MainView() {
			InitializeComponent();
			CloseWindowHelper.SetMessageOnCloseWindowView(this, ViewType.Main);
		}
	}
}
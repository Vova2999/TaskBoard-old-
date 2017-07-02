using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Messages;

namespace TaskBoard.Client.UI.Views.Windows {
	public partial class BoardWindowView {
		public BoardWindowView() {
			InitializeComponent();
			CloseWindowHelper.SetMessageOnCloseWindowView(this, ViewType.Board);
		}
	}
}
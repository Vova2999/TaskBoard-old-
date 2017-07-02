using TaskBoard.Client.UI.Views.Windows;

namespace TaskBoard.Client.UI.Services {
	public class WindowService : IWindowService {
		public void ShowSettingsWindowView() {
			new SettingsWindowView().ShowDialog();
		}
	}
}
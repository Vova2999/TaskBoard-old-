using TaskBoard.Client.UI.Views.Windows;

namespace TaskBoard.Client.UI.Services.Realizations {
	public class WindowService : IWindowService {
		public void ShowSettingsWindowView() {
			new SettingsWindowView().ShowDialog();
		}
	}
}
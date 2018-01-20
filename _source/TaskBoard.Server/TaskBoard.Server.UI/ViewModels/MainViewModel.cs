using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace TaskBoard.Server.UI.ViewModels {
	public class MainViewModel : ViewModelBase {
		private const int controlServerTabItemIndex = 0;
		private const int addtitonalSettingsTabItemIndex = 1;

		private bool serviceStatus;
		public bool ServiceStatus {
			get => serviceStatus;
			set => Set(() => ServiceStatus, ref serviceStatus, value);
		}

		private int tabControlSelectedIndex;
		public int TabControlSelectedIndex {
			get => tabControlSelectedIndex;
			set => Set(() => TabControlSelectedIndex, ref tabControlSelectedIndex, value);
		}

		private ICommand startServiceCommand;
		public ICommand StartServiceCommand => startServiceCommand ?? (startServiceCommand =
			new RelayCommand(() => ServiceStatus = true));

		private ICommand stopServiceCommand;
		public ICommand StopServiceCommand => stopServiceCommand ?? (stopServiceCommand =
			new RelayCommand(() => ServiceStatus = false));

		private ICommand goToAddtitonalSettingsCommand;
		public ICommand GoToAddtitonalSettingsCommand => goToAddtitonalSettingsCommand ?? (goToAddtitonalSettingsCommand =
			new RelayCommand(() => TabControlSelectedIndex = addtitonalSettingsTabItemIndex));

		private ICommand goToControlServerCommand;
		public ICommand GoToControlServerCommand => goToControlServerCommand ?? (goToControlServerCommand =
			new RelayCommand(() => TabControlSelectedIndex = controlServerTabItemIndex));
	}
}
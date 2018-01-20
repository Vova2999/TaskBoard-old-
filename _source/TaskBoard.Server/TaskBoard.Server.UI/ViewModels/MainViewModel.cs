using System.ServiceProcess;
using System.Timers;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using TaskBoard.Server.UI.MvvmExtensions;
using TaskBoard.Server.UI.Providers;

namespace TaskBoard.Server.UI.ViewModels {
	// ReSharper disable UnusedAutoPropertyAccessor.Local
	// ReSharper disable UnusedMember.Local

	public class MainViewModel : AutoViewModelBase {
		private const int controlServerTabItemIndex = 0;
		private const int addtitonalSettingsTabItemIndex = 1;

		private ServiceControllerStatus? serverServiceStatus;
		public ServiceControllerStatus? ServerServiceStatus {
			get => serverServiceStatus;
			set => Set(() => ServerServiceStatus, ref serverServiceStatus, value);
		}

		private int tabControlSelectedIndex;
		public int TabControlSelectedIndex {
			get => tabControlSelectedIndex;
			set => Set(() => TabControlSelectedIndex, ref tabControlSelectedIndex, value);
		}

		private readonly ServerServiceProvider serverServiceProvider;
		private readonly Timer updateServerServiceStatusTimer;

		public MainViewModel(ServerServiceProvider serverServiceProvider) {
			this.serverServiceProvider = serverServiceProvider;
			updateServerServiceStatusTimer = new Timer(250);
			updateServerServiceStatusTimer.Elapsed += (sender, args) => ServerServiceStatus = serverServiceProvider.Status;
			updateServerServiceStatusTimer.Start();
		}

		public ICommand StartServiceCommand { get; private set; }
		private void StartService() {
			serverServiceProvider.Start();
			ServerServiceStatus = serverServiceProvider.Status;
		}

		public ICommand StopServiceCommand { get; private set; }
		private void StopService() {
			serverServiceProvider.Stop();
			ServerServiceStatus = serverServiceProvider.Status;
		}

		public ICommand GoToAddtitonalSettingsCommand { get; private set; }
		private void GoToAddtitonalSettings() {
			TabControlSelectedIndex = addtitonalSettingsTabItemIndex;
		}

		public ICommand GoToControlServerCommand { get; private set; }
		private void GoToControlServer() {
			TabControlSelectedIndex = controlServerTabItemIndex;
		}
	}
}
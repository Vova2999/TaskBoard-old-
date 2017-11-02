using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Mvvm;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Services;

namespace TaskBoard.Client.UI.ViewModels.Flyouts {
	public class SettingsFlyoutViewModel : AutoViewModelBase {
		private ClientUiConfiguration clientUiConfiguration;
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IDialogService dialogService;

		private bool isOpen;
		public bool IsOpen {
			get => isOpen;
			set {
				if (Set(() => IsOpen, ref isOpen, value) && value)
					RefreshFields();
			}
		}

		private string serverAddress;
		public string ServerAddress {
			get => serverAddress;
			set => Set(() => ServerAddress, ref serverAddress, value);
		}

		private int timeoutMs;
		public int TimeoutMs {
			get => timeoutMs;
			set => Set(() => TimeoutMs, ref timeoutMs, value);
		}

		public SettingsFlyoutViewModel() {
			DesignHelper.SetControls(this);
		}

		[PreferredConstructor]
		public SettingsFlyoutViewModel(IHttpClientProvider httpClientProvider, IDialogService dialogService, bool setServerAddressWhenCreating = true) {
			this.httpClientProvider = httpClientProvider;
			this.dialogService = dialogService;

			if (!setServerAddressWhenCreating)
				return;

			ReadConfiguration();
			RunMethodHelper.WithoutReturn(() => httpClientProvider.GetParameretsClient().SetServerAddress(ServerAddress, TimeoutMs));

			RefreshFields();
			WriteConfiguration();
		}

		public ICommand WriteConfigurationCommand { get; } = new AutoRelayCommand(nameof(WriteConfiguration));
		private void WriteConfiguration() {
			clientUiConfiguration.ServerAddress = ServerAddress;
			clientUiConfiguration.TimeoutMs = TimeoutMs;

			clientUiConfiguration.WriteConfiguration();
		}

		public ICommand ReadConfigurationCommand { get; } = new AutoRelayCommand(nameof(ReadConfiguration));
		private void ReadConfiguration() {
			clientUiConfiguration = ClientUiConfiguration.ReadConfiguration();

			ServerAddress = clientUiConfiguration.ServerAddress;
			TimeoutMs = clientUiConfiguration.TimeoutMs;
		}

		public ICommand SetServerAddressCommand { get; } = new AutoRelayCommand(nameof(SetServerAddress));
		private void SetServerAddress() {
			RunMethodHelper.WithoutReturn(
				() => httpClientProvider.GetParameretsClient().SetServerAddress(ServerAddress, TimeoutMs),
				() => {
					IsOpen = false;
					RefreshFields();
				},
				exception => dialogService.ShowErrorMessage(this, "Ошибка соединения", exception.Message));
		}

		private void RefreshFields() {
			ServerAddress = httpClientProvider.ServerAddress;
			TimeoutMs = httpClientProvider.TimeoutMs;
		}
	}
}
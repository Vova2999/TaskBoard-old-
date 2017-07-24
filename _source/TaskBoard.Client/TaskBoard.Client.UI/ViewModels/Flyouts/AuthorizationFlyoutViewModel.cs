using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.AdditionalObjects;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Services;
using TaskBoard.Common.Extensions;

namespace TaskBoard.Client.UI.ViewModels.Flyouts {
	public class AuthorizationFlyoutViewModel : AutoViewModelBase {
		private ClientUiConfiguration clientUiConfiguration;
		private const string defaultHeader = "Авторизация";
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IDialogService dialogService;

		private string header = defaultHeader;
		public string Header {
			get => header;
			set => Set(() => Header, ref header, value);
		}

		private bool isOpen;
		public bool IsOpen {
			get => isOpen;
			set {
				if (Set(() => IsOpen, ref isOpen, value) && value)
					RefreshFields();
			}
		}

		private string login;
		public string Login {
			get => login;
			set => Set(() => Login, ref login, value);
		}

		private string password;
		public string Password {
			get => password;
			set => Set(() => Password, ref password, value);
		}

		private bool saveLoginAndPassword;
		public bool SaveLoginAndPassword {
			get => saveLoginAndPassword;
			set => Set(() => SaveLoginAndPassword, ref saveLoginAndPassword, value);
		}

		public AuthorizationFlyoutViewModel() {
			DesignHelper.SetControls(this);
		}

		[PreferredConstructor]
		public AuthorizationFlyoutViewModel(IHttpClientProvider httpClientProvider, IDialogService dialogService, bool signInWhenCreating = true) {
			this.httpClientProvider = httpClientProvider;
			this.dialogService = dialogService;

			if (!signInWhenCreating)
				return;

			ReadConfiguration();
			RunMethodHelper.WithoutReturn(() => httpClientProvider.GetParameretsClient().SignIn(Login, Password));

			RefreshFields();
			WriteConfiguration();
		}

		public ICommand WriteConfigurationCommand { get; } = new AutoRelayCommand(nameof(WriteConfiguration));
		private void WriteConfiguration() {
			clientUiConfiguration.Login = SaveLoginAndPassword ? Login : null;
			clientUiConfiguration.Password = SaveLoginAndPassword ? Password : null;
			clientUiConfiguration.SaveLoginAndPassword = SaveLoginAndPassword;

			clientUiConfiguration.WriteConfiguration();
		}

		public ICommand ReadConfigurationCommand { get; } = new AutoRelayCommand(nameof(ReadConfiguration));
		private void ReadConfiguration() {
			clientUiConfiguration = ClientUiConfiguration.ReadConfiguration();

			Login = clientUiConfiguration.Login;
			Password = clientUiConfiguration.Password;
			SaveLoginAndPassword = clientUiConfiguration.SaveLoginAndPassword;
		}

		public ICommand SignInCommand { get; } = new AutoRelayCommand(nameof(SignIn));
		private void SignIn() {
			RunMethodHelper.WithoutReturn(
				() => httpClientProvider.GetParameretsClient().SignIn(Login, Password),
				() => {
					IsOpen = false;
					RefreshFields();
				},
				exception => dialogService.ShowErrorMessage(this, "Ошибка авторизации", exception.Message));
		}

		public ICommand SignOutCommand { get; } = new AutoRelayCommand(nameof(SignOut));
		private void SignOut() {
			RunMethodHelper.WithoutReturn(
				() => httpClientProvider.GetParameretsClient().SingOut(),
				RefreshFields,
				exception => dialogService.ShowErrorMessage(this, "Ошибка авторизации", exception.Message));
		}

		private void RefreshFields() {
			Header = httpClientProvider.Login.NullIfEmpty() ?? defaultHeader;

			Login = httpClientProvider.Login;
			Password = httpClientProvider.Password;
			SaveLoginAndPassword = clientUiConfiguration.SaveLoginAndPassword;
		}
	}
}
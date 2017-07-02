using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Services;
using TaskBoard.Client.UI.Services.Realizations;
using TaskBoard.Client.UI.ViewModels;

namespace TaskBoard.Client.UI.Locators {
	// ReSharper disable MemberCanBeMadeStatic.Global

	public class ViewModelLocator {
		public static MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

		static ViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
			SimpleIoc.Default.Register<IControlService, ControlService>();
			SimpleIoc.Default.Register<IWindowService, WindowService>();
			SimpleIoc.Default.Register<IDialogService, DialogService>();

			if (!SimpleIoc.Default.IsRegistered<IHttpClientProvider>())
				SimpleIoc.Default.Register(CreateHttpClientProvider);

			if (ViewModelBase.IsInDesignModeStatic)
				SimpleIoc.Default.Register(() => new MainViewModel());
			else
				SimpleIoc.Default.Register(() => new MainViewModel(
					SimpleIoc.Default.GetInstance<IHttpClientProvider>(),
					SimpleIoc.Default.GetInstance<IControlService>(),
					SimpleIoc.Default.GetInstance<IWindowService>(),
					SimpleIoc.Default.GetInstance<IDialogService>()));
		}

		private static IHttpClientProvider CreateHttpClientProvider() {
			var configuration = ClientUiConfiguration.ReadConfiguration();

			var httpClientProvider = new HttpClientProvider();
			var parameretsClient = httpClientProvider.GetParameretsClient();
			parameretsClient.SetServerAddress(configuration.ServerAddress, configuration.TimeoutMs);
			parameretsClient.SignIn(configuration.Login, configuration.Password);

			return httpClientProvider;
		}
	}
}
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.ViewModels;

namespace TaskBoard.Client.UI.Locators {
	// ReSharper disable MemberCanBeMadeStatic.Global

	public class ViewModelLocator {
		public ViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<BoardViewModel>();
			SimpleIoc.Default.Register<IHttpClientProvider>(() => {
				var configuration = ClientUiConfiguration.ReadConfiguration();

				var httpClientProvider = new HttpClientProvider();
				var parameretsClient = httpClientProvider.GetParameretsClient();
				parameretsClient.SetServerAddress(configuration.ServerAddress, configuration.TimeoutMs);
				parameretsClient.SignIn(configuration.Login, configuration.Password);

				return httpClientProvider;
			});
		}

		public MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();
	}
}
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TaskBoard.Server.UI.Providers;
using TaskBoard.Server.UI.ViewModels;

namespace TaskBoard.Server.UI.Locators {
	public class MainViewModelLocator {
		public static MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

		public MainViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();

			SimpleIoc.Default.Register<ServerServiceProvider>();
		}
	}
}
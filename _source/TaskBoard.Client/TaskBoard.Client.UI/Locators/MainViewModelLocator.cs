using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Services;
using TaskBoard.Client.UI.Services.Realizations;
using TaskBoard.Client.UI.ViewModels;

namespace TaskBoard.Client.UI.Locators {
	public class MainViewModelLocator {
		public static MainViewModel MainViewModel => SimpleIoc.Default.GetInstance<MainViewModel>();

		static MainViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();

			SimpleIoc.Default.Register<IControlService, ControlService>();
			SimpleIoc.Default.Register<IWindowService, WindowService>();
			SimpleIoc.Default.Register<IDialogService, DialogService>();
			SimpleIoc.Default.Register<IHttpClientProvider, HttpClientProvider>();

			if (ViewModelBase.IsInDesignModeStatic)
				SimpleIoc.Default.ReRegister(() => new MainViewModel());
		}
	}
}
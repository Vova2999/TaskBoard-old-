using System.Windows.Media;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using TaskBoard.Server.UI.Providers;
using TaskBoard.Server.UI.ViewModels;

namespace TaskBoard.Server.UI.Locators {
	public class MainViewModelLocator {
		public static Brush EnabledServiceStatusBrush => Brushes.Green;
		public static Brush DisabledServiceStatusBrush => Brushes.Red;
		public static Brush EnabledServiceStatusText => Brushes.Green;
		public static Brush DisabledServiceStatusText => Brushes.Green;

		public static MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

		public MainViewModelLocator() {
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<MainViewModel>();

			SimpleIoc.Default.Register<ServerServiceProvider>();
		}
	}
}
using System.Collections.Generic;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using TaskBoard.Client.UI.Messages;

namespace TaskBoard.Client.UI.Helpers {
	public static class WindowHelper {
		private static readonly IDictionary<ViewModelBase, Window> viewModelToWindow = new Dictionary<ViewModelBase, Window>();

		public static void RegisterMessages(this Window window) {
			var viewModel = (ViewModelBase)window.DataContext;
			if (!viewModelToWindow.ContainsKey(viewModel))
				viewModelToWindow.Add(viewModel, window);

			Messenger.Default.Register<CloseViewMessage>(window, closeViewMessage => {
				if (viewModelToWindow.ContainsKey(closeViewMessage.ViewModel))
					viewModelToWindow[closeViewMessage.ViewModel].Close();
			});
		}

		public static void SendCloseWindowView(this ViewModelBase viewModel) {
			Messenger.Default.Send(new CloseViewMessage(viewModel));
		}
	}
}
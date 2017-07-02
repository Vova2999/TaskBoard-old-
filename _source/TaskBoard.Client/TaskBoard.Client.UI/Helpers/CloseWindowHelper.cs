using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using TaskBoard.Client.UI.Messages;

namespace TaskBoard.Client.UI.Helpers {
	public static class CloseWindowHelper {
		public static void SetMessageOnCloseWindowView(Window window, ViewType requiredViewType) {
			Messenger.Default.Register<CloseViewMessage>(window, closeViewMessage => {
				if (closeViewMessage.ViewType == requiredViewType)
					window.Close();
			});
		}

		public static void CloseWindowView(ViewType viewType) {
			Messenger.Default.Send(new CloseViewMessage(viewType));
		}
	}
}
using System;
using GalaSoft.MvvmLight;
using MahApps.Metro.Controls.Dialogs;

namespace TaskBoard.Client.UI.Services.Realizations {
	public class DialogService : IDialogService {
		private readonly IDialogCoordinator dialogCoordinator = DialogCoordinator.Instance;

		public void ShowErrorMessage(ViewModelBase viewModel, string title, string message) {
			dialogCoordinator.ShowMessageAsync(viewModel, title, message);
		}

		public void ShowWarningMessage(ViewModelBase viewModel, string title, string message) {
			throw new NotImplementedException();
		}
	}
}
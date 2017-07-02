using GalaSoft.MvvmLight;

namespace TaskBoard.Client.UI.Services {
	public interface IDialogService {
		void ShowErrorMessage(ViewModelBase viewModel, string title, string message);
		void ShowWarningMessage(ViewModelBase viewModel, string title, string message);
	}
}
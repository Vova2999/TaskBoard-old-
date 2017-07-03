using GalaSoft.MvvmLight;

namespace TaskBoard.Client.UI.Messages {
	public class CloseViewMessage {
		public readonly ViewModelBase ViewModel;

		public CloseViewMessage(ViewModelBase viewModel) {
			ViewModel = viewModel;
		}
	}
}
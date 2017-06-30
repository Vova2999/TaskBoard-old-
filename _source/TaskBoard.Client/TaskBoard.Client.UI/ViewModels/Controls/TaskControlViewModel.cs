using GalaSoft.MvvmLight;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Creators;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels.Controls {
	public class TaskControlViewModel : ViewModelBase {
		private TaskModel currentTaskModel;
		public TaskModel CurrentTaskModel {
			get => currentTaskModel;
			set => Set(() => CurrentTaskModel, ref currentTaskModel, value);
		}

		public TaskControlViewModel() {
			DesignHelper.SetControls(this);
		}

		public TaskControlViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
		}
	}
}
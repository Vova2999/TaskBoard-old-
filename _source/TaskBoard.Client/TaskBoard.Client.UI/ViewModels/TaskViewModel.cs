using GalaSoft.MvvmLight;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Creators;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels {
	public class TaskViewModel : ViewModelBase {
		private TaskModel currentTaskModel;
		public TaskModel CurrentTaskModel {
			get => currentTaskModel;
			set => Set(() => CurrentTaskModel, ref currentTaskModel, value);
		}

		public TaskViewModel() {
			DesignHelper.SetControls(this);
		}

		public TaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
		}
	}
}
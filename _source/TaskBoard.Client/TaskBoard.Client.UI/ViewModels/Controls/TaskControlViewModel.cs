using GalaSoft.MvvmLight;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.Services;

namespace TaskBoard.Client.UI.ViewModels.Controls {
	public class TaskControlViewModel : ViewModelBase {
		private TaskModel taskModel;
		public TaskModel TaskModel {
			get => taskModel;
			set => Set(() => TaskModel, ref taskModel, value);
		}

		public TaskControlViewModel() {
			DesignHelper.SetControls(this);
		}

		public TaskControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, IDialogService dialogService) {
		}
	}
}
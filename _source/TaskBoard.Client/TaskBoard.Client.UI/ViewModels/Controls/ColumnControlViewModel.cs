using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Extensions.Models;
using TaskBoard.Client.UI.Extensions.Mvvm;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.Services;

namespace TaskBoard.Client.UI.ViewModels.Controls {
	public class ColumnControlViewModel : AutoViewModelBase {
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IControlService controlService;
		private readonly IWindowService windowService;
		private readonly IDialogService dialogService;

		public ObservableCollection<TaskControlViewModel> TaskControlViewModels { get; } = new ObservableCollection<TaskControlViewModel>();

		private ColumnModel columnModel;
		public ColumnModel ColumnModel {
			get => columnModel;
			set {
				if (Set(() => ColumnModel, ref columnModel, value))
					RefreshTasksCommand.Execute(null);
			}
		}

		public ColumnControlViewModel() {
			DesignHelper.SetControls(this);
		}

		[PreferredConstructor]
		public ColumnControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, IDialogService dialogService) {
			this.httpClientProvider = httpClientProvider;
			this.controlService = controlService;
			this.windowService = windowService;
			this.dialogService = dialogService;
		}

		public ICommand RefreshTasksCommand { get; } = new AutoRelayCommand(nameof(RefreshTasks));
		private void RefreshTasks() {
			if (ColumnModel == null)
				return;

			ColumnModel.DownloadTaskModels(httpClientProvider);
			TaskControlViewModels.Reset(ColumnModel.TaskModels.Select(columnModel => controlService.CreateTaskControlViewModel(columnModel)));
		}
	}
}
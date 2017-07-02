using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.Services;

namespace TaskBoard.Client.UI.ViewModels.Controls {
	public class ColumnControlViewModel : ViewModelBase {
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

		public ColumnControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, IDialogService dialogService) {
			this.httpClientProvider = httpClientProvider;
			this.controlService = controlService;
			this.windowService = windowService;
			this.dialogService = dialogService;

			RefreshTasksCommand = new RelayCommand(RefreshTasksMethod);
		}

		public ICommand RefreshTasksCommand { get; } = new RelayCommand(() => { });
		private void RefreshTasksMethod() {
			if (ColumnModel == null)
				return;

			TaskControlViewModels.Reset(httpClientProvider.GetDatabaseTaskReader().GetFromColumn(ColumnModel.BoardId, ColumnModel.ColumnId).ToModels(httpClientProvider)
				.Select(columnModel => controlService.CreateTaskControlViewModel(columnModel)));
		}
	}
}
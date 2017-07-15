using System;
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
	public class BoardControlViewModel : ViewModelBase {
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IControlService controlService;
		private readonly IWindowService windowService;
		private readonly IDialogService dialogService;

		public ObservableCollection<ColumnControlViewModel> ColumnControlViewModels { get; } = new ObservableCollection<ColumnControlViewModel>();

		private BoardModel boardModel;
		public BoardModel BoardModel {
			get => boardModel;
			set {
				if (Set(() => BoardModel, ref boardModel, value))
					RefreshColumnsCommand.Execute(null);
			}
		}

		public BoardControlViewModel() {
			DesignHelper.SetControls(this);
		}

		public BoardControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, IDialogService dialogService) {
			this.httpClientProvider = httpClientProvider;
			this.controlService = controlService;
			this.windowService = windowService;
			this.dialogService = dialogService;

			RefreshColumnsCommand = new RelayCommand(RefreshColumns);
		}

		public ICommand RefreshColumnsCommand { get; } = new RelayCommand(() => { });
		private void RefreshColumns() {
			ColumnControlViewModels.Clear();
			if (BoardModel == null || BoardModel.BoardId == Guid.Empty)
				return;

			ColumnControlViewModels.Add(httpClientProvider.GetDatabaseColumnReader().GetFromBoard(BoardModel.BoardId).ToModels(httpClientProvider)
				.Select(columnModel => controlService.CreateColumnControlViewModel(columnModel)));
		}
	}
}
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.Services;
using TaskBoard.Client.UI.ViewModels.Controls;

namespace TaskBoard.Client.UI.ViewModels {
	public class MainViewModel : ViewModelBase {
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IWindowService windowService;
		private readonly IDialogService dialogService;

		public ObservableCollection<BoardModel> BoardModels { get; } = new ObservableCollection<BoardModel>();

		private BoardControlViewModel boardControlViewModel;
		public BoardControlViewModel BoardControlViewModel {
			get => boardControlViewModel;
			set => Set(() => BoardControlViewModel, ref boardControlViewModel, value);
		}

		private bool changeBoardViewModel;
		private BoardModel selectedBoardModel;
		public BoardModel SelectedBoardModel {
			get => selectedBoardModel;
			set {
				if (Set(() => SelectedBoardModel, ref selectedBoardModel, value) && changeBoardViewModel)
					BoardControlViewModel.BoardModel = value;
			}
		}

		public MainViewModel() {
			DesignHelper.SetControls(this);
		}

		public MainViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, IDialogService dialogService) {
			this.httpClientProvider = httpClientProvider;
			this.windowService = windowService;
			this.dialogService = dialogService;

			BoardControlViewModel = controlService.CreateBoardControlViewModel(null);
			RefreshBoardModelsCommand = new RelayCommand(RefreshBoardModelsMethod);
		}

		public ICommand RefreshBoardModelsCommand { get; } = new RelayCommand(() => { });
		private void RefreshBoardModelsMethod() {
			changeBoardViewModel = false;
			var oldSelectedBoardModel = SelectedBoardModel;

			BoardModels.Reset(httpClientProvider.GetDatabaseBoardReader().GetAll().ToModels(httpClientProvider));

			changeBoardViewModel = true;
			if (BoardModels.Contains(oldSelectedBoardModel))
				SelectedBoardModel = oldSelectedBoardModel;
		}
	}
}
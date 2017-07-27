using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.AdditionalObjects;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.Services;
using TaskBoard.Client.UI.ViewModels.Controls;
using TaskBoard.Client.UI.ViewModels.Flyouts;
using TaskBoard.Common.Extensions;

namespace TaskBoard.Client.UI.ViewModels {
	public class MainViewModel : AutoViewModelBase {
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IWindowService windowService;
		private readonly IDialogService dialogService;

		private readonly BoardModel[] firstModelsOfBoardModels = { new BoardModel(Guid.Empty.ToBoardId()) { Name = "Выберите доску" } };
		public ObservableCollection<BoardModel> BoardModels { get; } = new ObservableCollection<BoardModel>();

		private BoardControlViewModel boardControlViewModel;
		public BoardControlViewModel BoardControlViewModel {
			get => boardControlViewModel;
			set => Set(() => BoardControlViewModel, ref boardControlViewModel, value);
		}

		private bool changeBoardModelOnBoardViewModel;
		private BoardModel selectedBoardModel;
		public BoardModel SelectedBoardModel {
			get => selectedBoardModel;
			set {
				if (Set(() => SelectedBoardModel, ref selectedBoardModel, value) && changeBoardModelOnBoardViewModel)
					BoardControlViewModel.BoardModel = value;
			}
		}

		private SettingsFlyoutViewModel settingsFlyoutViewModel;
		public SettingsFlyoutViewModel SettingsFlyoutViewModel {
			get => settingsFlyoutViewModel;
			set => Set(() => SettingsFlyoutViewModel, ref settingsFlyoutViewModel, value);
		}

		private AuthorizationFlyoutViewModel authorizationFlyoutViewModel;
		public AuthorizationFlyoutViewModel AuthorizationFlyoutViewModel {
			get => authorizationFlyoutViewModel;
			set => Set(() => AuthorizationFlyoutViewModel, ref authorizationFlyoutViewModel, value);
		}

		public MainViewModel() {
			DesignHelper.SetControls(this);
		}

		[PreferredConstructor]
		public MainViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, IDialogService dialogService) {
			this.httpClientProvider = httpClientProvider;
			this.windowService = windowService;
			this.dialogService = dialogService;

			BoardControlViewModel = controlService.CreateBoardControlViewModel(null);
			SettingsFlyoutViewModel = controlService.CreateSettingsFlyoutViewModel();
			AuthorizationFlyoutViewModel = controlService.CreateAuthorizationFlyoutViewModel();

			BoardModels.Reset(firstModelsOfBoardModels);
			SelectedBoardModel = BoardModels.First();
		}

		public ICommand RefreshBoardModelsCommand { get; } = new AutoRelayCommand(nameof(RefreshBoardModels));
		private void RefreshBoardModels() {
			changeBoardModelOnBoardViewModel = false;

			var oldSelectedBoardModel = SelectedBoardModel;
			BoardModels.Reset(firstModelsOfBoardModels.Concat(httpClientProvider.GetDatabaseBoardReader().GetAll().ToModels(httpClientProvider)));
			if (BoardModels.Contains(oldSelectedBoardModel))
				SelectedBoardModel = oldSelectedBoardModel;

			changeBoardModelOnBoardViewModel = true;
		}

		public ICommand OpenSettingsFlyoutCommand { get; } = new AutoRelayCommand(nameof(OpenSettingsFlyout));
		private void OpenSettingsFlyout() {
			SettingsFlyoutViewModel.IsOpen = !SettingsFlyoutViewModel.IsOpen;
		}

		public ICommand OpenAuthorizationFlyoutCommand { get; } = new AutoRelayCommand(nameof(OpenAuthorizationFlyout));
		private void OpenAuthorizationFlyout() {
			AuthorizationFlyoutViewModel.IsOpen = !AuthorizationFlyoutViewModel.IsOpen;
		}
	}
}
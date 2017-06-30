using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Creators;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Helpers;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels {
	public class BoardViewModel : ViewModelBase {
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IViewModelCreator viewModelCreator;

		public ObservableCollection<ColumnViewModel> ColumnViewModels { get; } = new ObservableCollection<ColumnViewModel>();

		private BoardModel currentBoardModel;
		public BoardModel CurrentBoardModel {
			get => currentBoardModel;
			set {
				if (Set(() => CurrentBoardModel, ref currentBoardModel, value))
					RefreshColumnsCommand.Execute(null);
			}
		}

		public BoardViewModel() {
			DesignHelper.SetControls(this);
		}

		public BoardViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			this.httpClientProvider = httpClientProvider;
			this.viewModelCreator = viewModelCreator;

			RefreshColumnsCommand = new RelayCommand(RefreshColumnsMethod);
		}

		public ICommand RefreshColumnsCommand { get; } = new RelayCommand(() => { });
		private void RefreshColumnsMethod() {
			if (CurrentBoardModel == null)
				return;

			ColumnViewModels.Reset(httpClientProvider.GetDatabaseColumnReader().GetFromBoard(CurrentBoardModel.BoardId).ToModels(httpClientProvider)
				.Select(columnModel => viewModelCreator.CreateColumnViewModel(httpClientProvider, viewModelCreator, columnModel)));
		}
	}
}
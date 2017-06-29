using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Creators;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels {
	public class MainViewModel : ViewModelBase {
		private readonly IHttpClientProvider httpClientProvider;

		public ObservableCollection<BoardModel> BoardModels { get; }
		public BoardViewModel BoardViewModel { get; }

		public MainViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			this.httpClientProvider = httpClientProvider;

			BoardModels = new ObservableCollection<BoardModel>();
			BoardViewModel = viewModelCreator.CreateBoardViewModel(httpClientProvider, viewModelCreator);

			RefreshBoardModelsCommand = new RelayCommand(RefreshBoardModelsMethod);
		}

		public ICommand RefreshBoardModelsCommand { get; }
		private void RefreshBoardModelsMethod() {
			BoardModels.Reset(httpClientProvider.GetDatabaseBoardReader().GetAll().ToModels(httpClientProvider));
		}
	}
}
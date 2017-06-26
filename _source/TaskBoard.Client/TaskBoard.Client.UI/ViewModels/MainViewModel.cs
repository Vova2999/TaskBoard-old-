using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels {
	public class MainViewModel : ViewModelBase {
		private readonly IHttpClientProvider httpClientProvider = SimpleIoc.Default.GetInstance<IHttpClientProvider>();
		public BoardViewModel BoardViewModel { get; set; } = SimpleIoc.Default.GetInstance<BoardViewModel>();

		public ObservableCollection<BoardModel> BoardModels { get; } = new ObservableCollection<BoardModel>();

		public MainViewModel() {
			LoadBoardsCommand = new RelayCommand(LoadBoardsMethod);
		}

		public ICommand LoadBoardsCommand { get; }
		private void LoadBoardsMethod() {
			BoardModels.ResetItems(httpClientProvider.GetDatabaseBoardReader().GetAll().ToModels());
		}
	}
}
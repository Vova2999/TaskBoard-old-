using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels {
	public class BoardViewModel : ViewModelBase {
		private readonly IHttpClientProvider httpClientProvider = SimpleIoc.Default.GetInstance<IHttpClientProvider>();
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
			RefreshColumnsCommand = new RelayCommand(RefreshColumns);
		}

		public ICommand RefreshColumnsCommand { get; }
		private void RefreshColumns() {
			if (CurrentBoardModel == null)
				return;

			ColumnViewModels.ResetItems(httpClientProvider.GetDatabaseColumnReader().GetFromBoard(CurrentBoardModel.BoardId)
				.Select(column => new ColumnViewModel(new ColumnModel { Header = column.Header, Brush = (Brush)new BrushConverter().ConvertFromString(column.Brush) })));
		}
	}
}
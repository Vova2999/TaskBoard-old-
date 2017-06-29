using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Creators;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels {
	public class ColumnViewModel : ViewModelBase {
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IViewModelCreator viewModelCreator;

		public ObservableCollection<TaskViewModel> TaskViewModels { get; } = new ObservableCollection<TaskViewModel>();

		private ColumnModel currentColumnModel;
		public ColumnModel CurrentColumnModel {
			get => currentColumnModel;
			set {
				if (Set(() => CurrentColumnModel, ref currentColumnModel, value))
					RefreshTasksCommand.Execute(null);
			}
		}

		public ColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			this.httpClientProvider = httpClientProvider;
			this.viewModelCreator = viewModelCreator;

			RefreshTasksCommand = new RelayCommand(RefreshTasksMethod);
		}

		public ICommand RefreshTasksCommand { get; }
		private void RefreshTasksMethod() {
			if (CurrentColumnModel == null)
				return;

			TaskViewModels.Reset(httpClientProvider.GetDatabaseTaskReader().GetFromColumn(CurrentColumnModel.BoardId, CurrentColumnModel.ColumnId).ToModels(httpClientProvider)
				.Select(columnModel => viewModelCreator.CreateTaskViewModel(httpClientProvider, viewModelCreator, columnModel)));
		}
	}
}
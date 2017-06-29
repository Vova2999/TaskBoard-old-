using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels;

namespace TaskBoard.Client.UI.Creators {
	public class ViewModelCreator : IViewModelCreator {
		public BoardViewModel CreateBoardViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			return new BoardViewModel(httpClientProvider, viewModelCreator);
		}

		public ColumnViewModel CreateColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			return new ColumnViewModel(httpClientProvider, viewModelCreator);
		}

		public ColumnViewModel CreateColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator, ColumnModel columnModel) {
			return new ColumnViewModel(httpClientProvider, viewModelCreator) { CurrentColumnModel = columnModel };
		}

		public TaskViewModel CreateTaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			return new TaskViewModel(httpClientProvider, viewModelCreator);
		}

		public TaskViewModel CreateTaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator, TaskModel taskModel) {
			return new TaskViewModel(httpClientProvider, viewModelCreator) { CurrentTaskModel = taskModel };
		}
	}
}
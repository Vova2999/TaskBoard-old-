using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels.Controls;

namespace TaskBoard.Client.UI.Creators {
	public class ViewModelCreator : IViewModelCreator {
		public BoardControlViewModel CreateBoardViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			return new BoardControlViewModel(httpClientProvider, viewModelCreator);
		}

		public ColumnControlViewModel CreateColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			return new ColumnControlViewModel(httpClientProvider, viewModelCreator);
		}

		public ColumnControlViewModel CreateColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator, ColumnModel columnModel) {
			return new ColumnControlViewModel(httpClientProvider, viewModelCreator) { CurrentColumnModel = columnModel };
		}

		public TaskControlViewModel CreateTaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator) {
			return new TaskControlViewModel(httpClientProvider, viewModelCreator);
		}

		public TaskControlViewModel CreateTaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator, TaskModel taskModel) {
			return new TaskControlViewModel(httpClientProvider, viewModelCreator) { CurrentTaskModel = taskModel };
		}
	}
}
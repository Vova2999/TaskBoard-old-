using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels;

namespace TaskBoard.Client.UI.Creators {
	public interface IViewModelCreator {
		BoardViewModel CreateBoardViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator);
		ColumnViewModel CreateColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator);
		ColumnViewModel CreateColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator, ColumnModel columnModel);
		TaskViewModel CreateTaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator);
		TaskViewModel CreateTaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator, TaskModel taskModel);
	}
}
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels.Controls;

namespace TaskBoard.Client.UI.Creators {
	public interface IViewModelCreator {
		BoardControlViewModel CreateBoardViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator);
		ColumnControlViewModel CreateColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator);
		ColumnControlViewModel CreateColumnViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator, ColumnModel columnModel);
		TaskControlViewModel CreateTaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator);
		TaskControlViewModel CreateTaskViewModel(IHttpClientProvider httpClientProvider, IViewModelCreator viewModelCreator, TaskModel taskModel);
	}
}
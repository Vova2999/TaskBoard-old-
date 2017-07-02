using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels.Controls;

namespace TaskBoard.Client.UI.Services {
	public interface IControlService {
		BoardControlViewModel CreateBoardControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, BoardModel boardModel);
		ColumnControlViewModel CreateColumnControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, ColumnModel columnModel);
		TaskControlViewModel CreateTaskControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, TaskModel taskModel);
	}
}
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels.Controls;

namespace TaskBoard.Client.UI.Services {
	public class ControlService : IControlService {
		public BoardControlViewModel CreateBoardControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, BoardModel boardModel) {
			return new BoardControlViewModel(httpClientProvider, controlService, windowService) { BoardModel = boardModel };
		}

		public ColumnControlViewModel CreateColumnControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, ColumnModel columnModel) {
			return new ColumnControlViewModel(httpClientProvider, controlService, windowService) { ColumnModel = columnModel };
		}

		public TaskControlViewModel CreateTaskControlViewModel(IHttpClientProvider httpClientProvider, IControlService controlService, IWindowService windowService, TaskModel taskModel) {
			return new TaskControlViewModel(httpClientProvider, controlService, windowService) { TaskModel = taskModel };
		}
	}
}
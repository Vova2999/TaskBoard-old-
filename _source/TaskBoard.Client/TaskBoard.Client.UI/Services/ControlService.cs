using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels.Controls;

namespace TaskBoard.Client.UI.Services {
	public class ControlService : IControlService {
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IWindowService windowService;

		public ControlService(IHttpClientProvider httpClientProvider, IWindowService windowService) {
			this.httpClientProvider = httpClientProvider;
			this.windowService = windowService;
		}

		public BoardControlViewModel CreateBoardControlViewModel(BoardModel boardModel) {
			return new BoardControlViewModel(httpClientProvider, this, windowService) { BoardModel = boardModel };
		}

		public ColumnControlViewModel CreateColumnControlViewModel(ColumnModel columnModel) {
			return new ColumnControlViewModel(httpClientProvider, this, windowService) { ColumnModel = columnModel };
		}

		public TaskControlViewModel CreateTaskControlViewModel(TaskModel taskModel) {
			return new TaskControlViewModel(httpClientProvider, this, windowService) { TaskModel = taskModel };
		}
	}
}
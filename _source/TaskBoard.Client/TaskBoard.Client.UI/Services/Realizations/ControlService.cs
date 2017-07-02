using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels.Controls;

namespace TaskBoard.Client.UI.Services.Realizations {
	public class ControlService : IControlService {
		private readonly IHttpClientProvider httpClientProvider;
		private readonly IWindowService windowService;
		private readonly IDialogService dialogService;

		public ControlService(IHttpClientProvider httpClientProvider, IWindowService windowService, IDialogService dialogService) {
			this.httpClientProvider = httpClientProvider;
			this.windowService = windowService;
			this.dialogService = dialogService;
		}

		public BoardControlViewModel CreateBoardControlViewModel(BoardModel boardModel) {
			return new BoardControlViewModel(httpClientProvider, this, windowService, dialogService) { BoardModel = boardModel };
		}

		public ColumnControlViewModel CreateColumnControlViewModel(ColumnModel columnModel) {
			return new ColumnControlViewModel(httpClientProvider, this, windowService, dialogService) { ColumnModel = columnModel };
		}

		public TaskControlViewModel CreateTaskControlViewModel(TaskModel taskModel) {
			return new TaskControlViewModel(httpClientProvider, this, windowService, dialogService) { TaskModel = taskModel };
		}
	}
}
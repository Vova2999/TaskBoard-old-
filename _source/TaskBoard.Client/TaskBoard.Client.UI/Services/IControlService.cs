using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels.Controls;

namespace TaskBoard.Client.UI.Services {
	public interface IControlService {
		BoardControlViewModel CreateBoardControlViewModel(BoardModel boardModel);
		ColumnControlViewModel CreateColumnControlViewModel(ColumnModel columnModel);
		TaskControlViewModel CreateTaskControlViewModel(TaskModel taskModel);
	}
}
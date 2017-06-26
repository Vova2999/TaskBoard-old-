using GalaSoft.MvvmLight;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels {
	public class TaskViewModel : ViewModelBase {
		public TaskModel TaskModel { get; }

		public TaskViewModel(TaskModel taskModel) {
			TaskModel = taskModel;
		}
	}
}
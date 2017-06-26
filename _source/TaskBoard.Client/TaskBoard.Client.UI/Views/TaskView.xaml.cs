using TaskBoard.Client.UI.ViewModels;

namespace TaskBoard.Client.UI.Views {
	public partial class TaskView {
		public TaskView(TaskViewModel taskViewModel) {
			InitializeComponent();
			DataContext = taskViewModel;
		}
	}
}
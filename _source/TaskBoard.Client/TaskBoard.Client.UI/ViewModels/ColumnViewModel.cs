using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.ViewModels {
	public class ColumnViewModel : ViewModelBase {
		public ColumnModel ColumnModel { get; set; }

		private ObservableCollection<TaskViewModel> tasks;
		public ObservableCollection<TaskViewModel> Tasks {
			get => tasks;
			set => Set(() => Tasks, ref tasks, value);
		}

#if DEBUG
		public ColumnViewModel() {
			if (!IsInDesignMode)
				throw new Exception();
		}
#endif

		public ColumnViewModel(ColumnModel columnModel) {
			ColumnModel = columnModel;
		}
	}
}
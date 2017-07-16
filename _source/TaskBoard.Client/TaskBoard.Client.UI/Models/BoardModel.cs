using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;

namespace TaskBoard.Client.UI.Models {
	public class BoardModel : ViewModelBase {
		private Guid boardId;
		public Guid BoardId {
			get => boardId;
			set => Set(() => BoardId, ref boardId, value);
		}

		private string name;
		public string Name {
			get => name;
			set => Set(() => Name, ref name, value);
		}

		private ObservableCollection<ColumnModel> columnModels;
		public ObservableCollection<ColumnModel> ColumnModels {
			get => columnModels;
			set => Set(() => ColumnModels, ref columnModels, value);
		}

		private ObservableCollection<TaskModel> taskModels;
		public ObservableCollection<TaskModel> TaskModels {
			get => taskModels;
			set => Set(() => TaskModels, ref taskModels, value);
		}

		public override bool Equals(object obj) {
			return obj is BoardModel that && BoardId.Equals(that.BoardId);
		}
		public override int GetHashCode() {
			return BoardId.GetHashCode();
		}
	}
}
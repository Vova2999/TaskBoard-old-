using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using GalaSoft.MvvmLight;

namespace TaskBoard.Client.UI.Models {
	public class ColumnModel : ViewModelBase {
		private Guid columnId;
		public Guid ColumnId {
			get => columnId;
			set => Set(() => ColumnId, ref columnId, value);
		}

		private string header;
		public string Header {
			get => header;
			set => Set(() => Header, ref header, value);
		}

		private Brush brush;
		public Brush Brush {
			get => brush;
			set => Set(() => Brush, ref brush, value);
		}

		private BoardModel boardModel;
		public BoardModel BoardModel {
			get => boardModel;
			set => Set(() => BoardModel, ref boardModel, value);
		}

		private ObservableCollection<TaskModel> taskModels;
		public ObservableCollection<TaskModel> TaskModels {
			get => taskModels;
			set => Set(() => TaskModels, ref taskModels, value);
		}

		public override bool Equals(object obj) {
			return obj is ColumnModel that && ColumnId.Equals(that.ColumnId);
		}
		public override int GetHashCode() {
			return ColumnId.GetHashCode();
		}
	}
}
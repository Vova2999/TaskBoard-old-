using System.Collections.ObjectModel;
using System.Windows.Media;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.UI.Models {
	public class ColumnModel : BaseModel<ColumnId> {
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

		public ColumnModel(ColumnId id) : base(id) {
		}

		public override bool Equals(object obj) {
			return obj is ColumnModel that && Id.Equals(that.Id);
		}
		public override int GetHashCode() {
			return Id.GetHashCode();
		}
	}
}
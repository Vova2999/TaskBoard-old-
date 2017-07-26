using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.UI.Models {
	public class BoardModel : ViewModelBase {
		public BoardId Id { get; }

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

		public BoardModel(BoardId id) {
			Id = id;
		}

		public override bool Equals(object obj) {
			return obj is BoardModel that && Id.Equals(that.Id);
		}
		public override int GetHashCode() {
			return Id.GetHashCode();
		}
	}
}
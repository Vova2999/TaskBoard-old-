using System;
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

		private string boardName;
		public string BoardName {
			get => boardName;
			set => Set(() => BoardName, ref boardName, value);
		}
	}
}
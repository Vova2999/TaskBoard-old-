using GalaSoft.MvvmLight;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.UI.Models {
	public class BaseModel<TTableId> : ViewModelBase where TTableId : BaseTableId {
		public TTableId Id { get; }

		public BaseModel(TTableId id) {
			Id = id;
		}
	}
}
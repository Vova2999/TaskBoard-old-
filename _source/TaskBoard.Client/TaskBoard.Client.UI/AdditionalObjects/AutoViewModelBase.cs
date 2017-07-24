using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using TaskBoard.Common.Extensions;

namespace TaskBoard.Client.UI.AdditionalObjects {
	public class AutoViewModelBase : ViewModelBase {
		protected AutoViewModelBase() {
			SetCommands();
		}

		private void SetCommands() {
			if (IsInDesignMode)
				return;

			GetType().GetProperties()
				.Where(propertyInfo => propertyInfo.PropertyType == typeof(ICommand))
				.ForEach(propertyInfo => (propertyInfo.GetValue(this) as AutoRelayCommand)?.SetObject(this));
		}
	}
}
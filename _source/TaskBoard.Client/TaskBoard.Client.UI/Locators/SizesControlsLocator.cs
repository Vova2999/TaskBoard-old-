using System.Windows;

namespace TaskBoard.Client.UI.Locators {
	public class SizesControlsLocator {
		public static Size TaskSize { get; } = new Size { Height = 200, Width = 250 };
		public static Size ColumnSize { get; } = new Size { Width = TaskSize.Width + 10 };
	}
}
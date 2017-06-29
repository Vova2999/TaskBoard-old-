using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TaskBoard.Client.UI.Extensions {
	public static class ObservableCollectionExtensions {
		public static void Reset<TValue>(this ObservableCollection<TValue> collection, IEnumerable<TValue> items) {
			collection.Clear();
			collection.Add(items);
		}

		public static void Add<TValue>(this ObservableCollection<TValue> collection, IEnumerable<TValue> items) {
			foreach (var item in items)
				collection.Add(item);
		}
	}
}
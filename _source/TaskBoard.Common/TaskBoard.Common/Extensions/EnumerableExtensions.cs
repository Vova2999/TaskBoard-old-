using System;
using System.Collections.Generic;

namespace TaskBoard.Common.Extensions {
	// ReSharper disable UnusedMember.Global

	public static class EnumerableExtensions {
		public static void ForEach<TValue>(this IEnumerable<TValue> enumerable, Action<TValue> action) {
			foreach (var value in enumerable)
				action(value);
		}

		public static void ForEach<TValue>(this IEnumerable<TValue> enumerable, Action<TValue, int> action) {
			var i = 0;
			foreach (var value in enumerable)
				action(value, i++);
		}
	}
}
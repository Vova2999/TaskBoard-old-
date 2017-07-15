using System;

namespace TaskBoard.Client.UI.Helpers {
	public static class RunMethodHelper {
		public static void WithoutReturn(Action action, Action<Exception> actionWhenFailure = null) {
			WithoutReturn(action, null, actionWhenFailure);
		}

		public static void WithoutReturn(Action action, Action actionWhenSuccess, Action<Exception> actionWhenFailure = null) {
			Run(action, actionWhenSuccess, actionWhenFailure);
		}

		public static TResult WithReturn<TResult>(Func<TResult> action, Action<Exception> actionWhenFailure = null) {
			return WithReturn(action, null, actionWhenFailure);
		}

		public static TResult WithReturn<TResult>(Func<TResult> action, Action actionWhenSuccess, Action<Exception> actionWhenFailure = null) {
			var defaultResult = default(TResult);
			Run(() => defaultResult = action(), actionWhenSuccess, actionWhenFailure);
			return defaultResult;
		}

		private static void Run(Action action, Action actionWhenSuccess = null, Action<Exception> actionWhenFailure = null) {
			try {
				action?.Invoke();
				actionWhenSuccess?.Invoke();
			}
			catch (Exception exception) {
				actionWhenFailure?.Invoke(exception);
			}
		}
	}
}
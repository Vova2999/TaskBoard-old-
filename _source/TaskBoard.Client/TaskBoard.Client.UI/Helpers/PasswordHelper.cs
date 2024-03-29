﻿using System.Windows;
using System.Windows.Controls;

namespace TaskBoard.Client.UI.Helpers {
	public static class PasswordHelper {
		public static readonly DependencyProperty PasswordProperty =
			DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordHelper), new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

		private static readonly DependencyProperty isUpdatingProperty =
			DependencyProperty.RegisterAttached("isUpdating", typeof(bool), typeof(PasswordHelper));

		public static string GetPassword(DependencyObject dp) {
			return (string)dp.GetValue(PasswordProperty);
		}
		public static void SetPassword(DependencyObject dp, string value) {
			dp.SetValue(PasswordProperty, value);
		}

		private static bool GetisUpdating(DependencyObject dp) {
			return (bool)dp.GetValue(isUpdatingProperty);
		}
		private static void SetisUpdating(DependencyObject dp, bool value) {
			dp.SetValue(isUpdatingProperty, value);
		}

		private static void OnPasswordPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
			if (!(sender is PasswordBox passwordBox))
				return;

			passwordBox.PasswordChanged -= PasswordChanged;

			if (!GetisUpdating(passwordBox))
				passwordBox.Password = (string)e.NewValue;

			passwordBox.PasswordChanged += PasswordChanged;
		}

		private static void PasswordChanged(object sender, RoutedEventArgs e) {
			if (!(sender is PasswordBox passwordBox))
				return;

			SetisUpdating(passwordBox, true);
			SetPassword(passwordBox, passwordBox.Password);
			SetisUpdating(passwordBox, false);
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using TaskBoard.Common.Extensions;

namespace TaskBoard.Server.UI.MvvmExtensions {
	public class AutoViewModelBase : ViewModelBase {
		protected AutoViewModelBase() {
			if (IsInDesignMode)
				return;

			var thisType = GetType();
			var methodInfos = thisType.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).ToArray();
			var propertyInfos = thisType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance).ToArray();

			SetCommands(methodInfos, propertyInfos);
			SetProperties(propertyInfos);
		}

		private void SetCommands(IEnumerable<MethodInfo> methodInfos, IEnumerable<PropertyInfo> propertyInfos) {
			var methodNames = methodInfos.Select(methodInfo => methodInfo.Name).ToArray();

			propertyInfos
				.Where(propertyInfo => propertyInfo.PropertyType == typeof(ICommand) || propertyInfo.PropertyType == typeof(AutoRelayCommand))
				.Select(propertyInfo => new { PropertyInfo = propertyInfo, Command = propertyInfo.GetValue(this) })
				.Select(x => {
					if (x.Command != null)
						return x.Command as AutoRelayCommand;

					x.PropertyInfo.SetValue(this,
						new AutoRelayCommand(
							methodNames.First(methodName => methodName.Equals(ConvertPropertyNameToExecuteMethodName(x.PropertyInfo))),
							methodNames.FirstOrDefault(methodName => methodName.Equals(ConvertPropertyNameToCanExecuteMethodName(x.PropertyInfo)))));

					return (AutoRelayCommand)x.PropertyInfo.GetValue(this);
				})
				.ForEach(command => command?.SetObject(this));
		}

		private static string ConvertPropertyNameToExecuteMethodName(PropertyInfo propertyInfo) {
			const string executeCommandPropertyEndsWith = "Command";
			return propertyInfo.Name.EndsWith(executeCommandPropertyEndsWith, StringComparison.InvariantCultureIgnoreCase)
				? propertyInfo.Name.Remove(propertyInfo.Name.Length - executeCommandPropertyEndsWith.Length)
				: throw new ArgumentException($"Имя свойства команды должно заканичваться на \"{executeCommandPropertyEndsWith}\"");
		}

		private static string ConvertPropertyNameToCanExecuteMethodName(PropertyInfo propertyInfo) {
			const string canExecuteCommandPropertyStartsWith = "Can";
			return $"{canExecuteCommandPropertyStartsWith}{ConvertPropertyNameToExecuteMethodName(propertyInfo)}";
		}

		private void SetProperties(IEnumerable<PropertyInfo> propertyInfos) {
			//string.
			//propertyInfos.First().SetMethod.CreateDelegate()
			//propertyInfos
			//	.Where(propertyInfo => !typeof(ICommand).IsAssignableFrom(propertyInfo.PropertyType))
		}
	}
}
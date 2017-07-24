using System;
using GalaSoft.MvvmLight.Ioc;

namespace TaskBoard.Client.UI.Extensions {
	public static class SimpleIocExtensions {
		public static void ReRegister<TReRegisterClass>(this SimpleIoc simpleIoc, Func<TReRegisterClass> factory) where TReRegisterClass : class {
			simpleIoc.Unregister<TReRegisterClass>();
			simpleIoc.Register(factory);
		}
	}
}
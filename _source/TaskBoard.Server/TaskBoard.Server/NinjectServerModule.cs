using System;
using System.Linq;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using TaskBoard.Server.Handlers;
using TaskBoard.Server.Servers;

namespace TaskBoard.Server {
	public class NinjectServerModule : NinjectModule {
		public override void Load() {
			if (Kernel == null)
				return;
			Kernel.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces().Configure(y => y.InSingletonScope()));
			Kernel.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllBaseClasses().Configure(y => y.InSingletonScope()));
			Kernel.Rebind<IHttpServer>().ToMethod(c => new HttpServer(GetServerAddress(), c.Kernel.GetAll<IHttpHandler>().ToArray())).InSingletonScope();
		}
		private static string GetServerAddress() {
			try {
				return new UriBuilder(ServerConfiguration.ReadConfiguration().ServerAddress).ToString();
			}
			catch (Exception) {
				throw new ArgumentException("Некорректный адрес сервера");
			}
		}
	}
}
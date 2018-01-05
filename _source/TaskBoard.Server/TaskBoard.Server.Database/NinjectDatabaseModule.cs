using Ninject.Extensions.Conventions;
using Ninject.Modules;
using TaskBoard.Server.Database.Models;

namespace TaskBoard.Server.Database {
	public class NinjectDatabaseModule : NinjectModule {
		public override void Load() {
			Kernel?.Bind<ModelDatabase>().ToSelf().InSingletonScope();
			Kernel?.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces().Configure(y => y.InSingletonScope()));
		}
	}
}
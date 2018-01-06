using System.ServiceProcess;
using Ninject;
using TaskBoard.Server.Database;
using TaskBoard.Server.Servers;

namespace TaskBoard.Server.Service {
	public partial class TaskBoardServerService : ServiceBase {
		private IHttpServer httpServer;

		public TaskBoardServerService() {
			InitializeComponent();
		}

		protected override void OnStart(string[] args) {
			var container = new StandardKernel(new NinjectServerModule(), new NinjectDatabaseModule());
			httpServer = container.Get<IHttpServer>();
			httpServer.Start();
		}

		protected override void OnStop() {
			httpServer.Stop();
		}
	}
}
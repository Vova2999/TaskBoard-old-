using Ninject;
using TaskBoard.Server.Database;
using TaskBoard.Server.Servers;

namespace TaskBoard.Server {
	public static class Program {
		public static void Main() {
			var httpServer = CreateHttpServer();
			httpServer.Start();
			httpServer.Wait();
		}
		public static void RunServer() {
			CreateHttpServer().Start();
		}
		private static IHttpServer CreateHttpServer() {
			var container = new StandardKernel(new NinjectServerModule(), new NinjectDatabaseModule());
			return container.Get<IHttpServer>();
		}
	}
}
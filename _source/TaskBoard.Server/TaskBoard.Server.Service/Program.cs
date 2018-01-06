using System.ServiceProcess;

namespace TaskBoard.Server.Service {
	internal static class Program {
		private static void Main() {
			ServiceBase.Run(new ServiceBase[] { new TaskBoardServerService() });
		}
	}
}
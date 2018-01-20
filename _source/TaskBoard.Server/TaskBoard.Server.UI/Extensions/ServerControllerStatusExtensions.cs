using System.ServiceProcess;
using TaskBoard.Server.UI.Providers;

namespace TaskBoard.Server.UI.Extensions {
	public static class ServerControllerStatusExtensions {
		public static ServerServiceStatus ToServerServiceStatus(this ServiceControllerStatus status) {
			switch (status) {
				case ServiceControllerStatus.Running:
					return ServerServiceStatus.Running;
				case ServiceControllerStatus.Stopped:
					return ServerServiceStatus.Stopped;
				default:
					return ServerServiceStatus.Unknown;
			}
		}
	}
}
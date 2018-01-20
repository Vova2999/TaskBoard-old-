using System;
using System.Linq;
using System.ServiceProcess;
using TaskBoard.Server.Service;
using TaskBoard.Server.UI.Extensions;

namespace TaskBoard.Server.UI.Providers {
	public enum ServerServiceStatus {
		Unknown,
		NotInstalled,
		Running,
		Stopped
	}

	public class ServerServiceProvider {
		public ServerServiceStatus Status { get; private set; }
		private ServiceController serverServiceController;

		public void Update() {
			var serverService = ServiceController.GetServices().FirstOrDefault(service => service.ServiceName.Equals(TaskBoardServerService.Name, StringComparison.InvariantCultureIgnoreCase));

			if (serverService == null) {
				Status = ServerServiceStatus.NotInstalled;
				serverServiceController = null;
			}
			else {
				Status = serverService.Status.ToServerServiceStatus();
				serverServiceController = serverService;
			}
		}

		public void Start() {
			Update();
			if (Status != ServerServiceStatus.Stopped)
				throw new ArgumentException($"Сервис не может быть запущен, т.к. его статус = {Status}");

			serverServiceController.Start();
		}

		public void Stop() {
			Update();
			if (Status != ServerServiceStatus.Running)
				throw new ArgumentException($"Сервис не может быть остановлен, т.к. его статус = {Status}");

			serverServiceController.Start();
		}
	}
}
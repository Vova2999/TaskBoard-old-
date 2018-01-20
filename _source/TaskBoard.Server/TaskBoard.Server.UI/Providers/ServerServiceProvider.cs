using System;
using System.Linq;
using System.ServiceProcess;
using TaskBoard.Server.Service;

namespace TaskBoard.Server.UI.Providers {
	public class ServerServiceProvider {
		public ServiceControllerStatus? Status {
			get {
				Update();
				return serverServiceController?.Status;
			}
		}

		private ServiceController serverServiceController;

		public void Start() {
			if (serverServiceController?.Status != ServiceControllerStatus.Stopped)
				throw new ArgumentException($"Сервис не может быть запущен, т.к. его статус = {serverServiceController?.Status.ToString() ?? "NotInstalled"}");

			serverServiceController.Start();
		}

		public void Stop() {
			if (serverServiceController?.Status != ServiceControllerStatus.Running)
				throw new ArgumentException($"Сервис не может быть остановлен, т.к. его статус = {serverServiceController?.Status.ToString() ?? "NotInstalled"}");

			serverServiceController.Stop();
		}

		private void Update() {
			serverServiceController = ServiceController.GetServices()
				.FirstOrDefault(service => service.ServiceName.Equals(TaskBoardServerService.Name, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}
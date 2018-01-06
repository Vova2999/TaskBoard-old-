using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace TaskBoard.Server.Service {
	// ReSharper disable UnusedMember.Global

	[RunInstaller(true)]
	public partial class TaskBoardServerServiceInstaller : Installer {
		public TaskBoardServerServiceInstaller() {
			InitializeComponent();

			Installers.Add(new ServiceProcessInstaller { Account = ServiceAccount.LocalSystem });
			Installers.Add(new ServiceInstaller { StartType = ServiceStartMode.Manual, ServiceName = "TaskBoardServerService" });
		}
	}
}
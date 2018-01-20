using System.ServiceProcess;
using System.Windows;
using System.Windows.Input;

namespace TaskBoard.Server.UI.Controls {
	public partial class ServerStatusControl {
		public static readonly DependencyProperty ServerServiceStatusProperty = DependencyProperty.Register(nameof(ServerServiceStatus), typeof(ServiceControllerStatus?), typeof(ServerStatusControl), new PropertyMetadata(null));
		public ServiceControllerStatus? ServerServiceStatus {
			get => (ServiceControllerStatus?)GetValue(ServerServiceStatusProperty);
			set => SetValue(ServerServiceStatusProperty, value);
		}

		public static readonly DependencyProperty StartServiceCommandProperty = DependencyProperty.Register(nameof(StartServiceCommand), typeof(ICommand), typeof(ServerStatusControl), new PropertyMetadata(null));
		public ICommand StartServiceCommand {
			get => (ICommand)GetValue(StartServiceCommandProperty);
			set => SetValue(StartServiceCommandProperty, value);
		}

		public static readonly DependencyProperty StopServiceCommandProperty = DependencyProperty.Register(nameof(StopServiceCommand), typeof(ICommand), typeof(ServerStatusControl), new PropertyMetadata(null));
		public ICommand StopServiceCommand {
			get => (ICommand)GetValue(StopServiceCommandProperty);
			set => SetValue(StopServiceCommandProperty, value);
		}

		public ServerStatusControl() {
			InitializeComponent();
		}
	}
}
namespace TaskBoard.Client.UI.Messages {
	public class CloseViewMessage {
		public readonly ViewType ViewType;

		public CloseViewMessage(ViewType viewType) {
			ViewType = viewType;
		}
	}
}
namespace TaskBoard.Client.Clients.Paramerets {
	public interface IParameretsClient {
		void SetServerAddress(string serverAddress, int timeoutMs);
		void SignIn(string login, string password);
		void SingOut();
	}
}
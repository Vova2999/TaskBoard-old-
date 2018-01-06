namespace TaskBoard.Server.Servers {
	public interface IHttpServer {
		void Start();
		void Wait();
		void Stop();
	}
}
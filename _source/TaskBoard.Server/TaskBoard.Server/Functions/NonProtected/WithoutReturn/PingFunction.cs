using TaskBoard.Common.Http;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.NonProtected.WithoutReturn {
	// ReSharper disable UnusedMember.Global

	public class PingFunction : HttpFunctionWithoutReturn {
		public override string NameOfCalledMethod => HttpFunctions.Ping;

		protected override void Run(NameValues parameters, byte[] requestBody) {
		}
	}
}
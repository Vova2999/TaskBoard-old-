using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.TaskReads {
	// ReSharper disable UnusedMember.Global

	public class GetTasksFromBoardHandler : HttpHandlerBaseWithReturn<Task[]> {
		public override string HandlerName => HttpHandlerNames.Task.Reads.GetTasksFromBoard;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseTaskReader databaseTaskReader;

		public GetTasksFromBoardHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskReader databaseTaskReader) : base(databaseAuthorizer) {
			this.databaseTaskReader = databaseTaskReader;
		}

		protected override Task[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseTaskReader.GetFromBoard(parameters[HttpParameters.TaskBoardId].ToGuid().ToBoardId());
		}
	}
}
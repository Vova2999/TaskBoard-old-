using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.TaskReads {
	// ReSharper disable UnusedMember.Global

	public class GetTaskIdsFromBoardHandler : HttpHandlerBaseWithReturn<TaskId[]> {
		public override string HandlerName => HttpHandlerNames.Task.Reads.GetTaskIdsFromBoard;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseTaskReader databaseTaskReader;

		public GetTaskIdsFromBoardHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskReader databaseTaskReader) : base(databaseAuthorizer) {
			this.databaseTaskReader = databaseTaskReader;
		}

		protected override TaskId[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseTaskReader.GetIdsFromBoard(parameters[HttpParameters.TaskBoardId].ToGuid().ToBoardId());
		}
	}
}
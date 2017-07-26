using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.TaskReads {
	// ReSharper disable UnusedMember.Global

	public class GetTaskIdsFromBoardFunction : HttpProtectedFunctionWithReturn<TaskId[]> {
		public override string NameOfCalledMethod => HttpFunctions.TaskReads.GetTaskIdsFromBoard;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseTaskReader databaseTaskReader;

		public GetTaskIdsFromBoardFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseTaskReader databaseTaskReader) : base(databaseAuthorizer) {
			this.databaseTaskReader = databaseTaskReader;
		}

		protected override TaskId[] Run(NameValues parameters, byte[] requestBody) {
			return databaseTaskReader.GetIdsFromBoard(parameters[HttpParameters.TaskBoardId].ToGuid().ToBoardId());
		}
	}
}
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.CommentReads {
	// ReSharper disable UnusedMember.Global

	public class GetCommentIdsFromTaskFunction : HttpProtectedFunctionWithReturn<CommentId[]> {
		public override string NameOfCalledMethod => HttpFunctions.CommentReads.GetCommentIdsFromTask;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseCommentReader databaseCommentReader;

		public GetCommentIdsFromTaskFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentReader databaseCommentReader) : base(databaseAuthorizer) {
			this.databaseCommentReader = databaseCommentReader;
		}

		protected override CommentId[] Run(NameValues parameters, byte[] requestBody) {
			return databaseCommentReader.GetIdsFromTask(parameters[HttpParameters.CommentTaskId].ToGuid().ToTaskId());
		}
	}
}
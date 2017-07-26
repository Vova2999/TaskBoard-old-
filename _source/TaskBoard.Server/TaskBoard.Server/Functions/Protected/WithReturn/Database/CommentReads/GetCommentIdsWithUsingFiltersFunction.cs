using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.CommentReads {
	// ReSharper disable UnusedMember.Global

	public class GetCommentIdsWithUsingFiltersFunction : HttpProtectedFunctionWithReturn<CommentId[]> {
		public override string NameOfCalledMethod => HttpFunctions.CommentReads.GetCommentIdsWithUsingFilters;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseCommentReader databaseCommentReader;

		public GetCommentIdsWithUsingFiltersFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentReader databaseCommentReader) : base(databaseAuthorizer) {
			this.databaseCommentReader = databaseCommentReader;
		}

		protected override CommentId[] Run(NameValues parameters, byte[] requestBody) {
			var content = parameters.GetValueOrNull(HttpParameters.CommentContent);
			var beginCreateDateTime = parameters.GetValueOrNull(HttpParameters.CommentBeginCreateDateTime)?.ToDateTime();
			var endCreateDateTime = parameters.GetValueOrNull(HttpParameters.CommentEndCreateDateTime)?.ToDateTime();
			var userId = parameters.GetValueOrNull(HttpParameters.CommentUserId)?.ToGuid().ToUserId();
			var taskId = parameters.GetValueOrNull(HttpParameters.CommentTaskId)?.ToGuid().ToTaskId();

			return databaseCommentReader.GetIdsWithUsingFilters(content, beginCreateDateTime, endCreateDateTime, userId, taskId);
		}
	}
}
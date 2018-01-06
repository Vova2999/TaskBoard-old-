using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.CommentReads {
	// ReSharper disable UnusedMember.Global

	public class GetCommentsWithUsingFiltersHandler : HttpHandlerBaseWithReturn<Comment[]> {
		public override string HandlerName => HttpHandlerNames.Comment.Reads.GetCommentsWithUsingFilters;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseCommentReader databaseCommentReader;

		public GetCommentsWithUsingFiltersHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentReader databaseCommentReader) : base(databaseAuthorizer) {
			this.databaseCommentReader = databaseCommentReader;
		}

		protected override Comment[] Run(NameValueCollection parameters, byte[] requestBody) {
			var content = parameters.Get(HttpParameters.CommentContent);
			var beginCreateDateTime = parameters.Get(HttpParameters.CommentBeginCreateDateTime)?.ToDateTime();
			var endCreateDateTime = parameters.Get(HttpParameters.CommentEndCreateDateTime)?.ToDateTime();
			var userId = parameters.Get(HttpParameters.CommentUserId)?.ToGuid().ToUserId();
			var taskId = parameters.Get(HttpParameters.CommentTaskId)?.ToGuid().ToTaskId();

			return databaseCommentReader.GetWithUsingFilters(content, beginCreateDateTime, endCreateDateTime, userId, taskId);
		}
	}
}
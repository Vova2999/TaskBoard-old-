using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.CommentReads {
	// ReSharper disable UnusedMember.Global

	public class GetCommentsFromTaskHandler : HttpHandlerBaseWithReturn<Comment[]> {
		public override string HandlerName => HttpHandlerNames.Comment.Reads.GetCommentsFromTask;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseCommentReader databaseCommentReader;

		public GetCommentsFromTaskHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentReader databaseCommentReader) : base(databaseAuthorizer) {
			this.databaseCommentReader = databaseCommentReader;
		}

		protected override Comment[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseCommentReader.GetFromTask(parameters[HttpParameters.CommentTaskId].ToGuid().ToTaskId());
		}
	}
}
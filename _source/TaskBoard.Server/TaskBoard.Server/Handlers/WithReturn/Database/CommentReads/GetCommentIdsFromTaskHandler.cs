using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.CommentReads {
	// ReSharper disable UnusedMember.Global

	public class GetCommentIdsFromTaskHandler : HttpHandlerBaseWithReturn<CommentId[]> {
		public override string HandlerName => HttpHandlerNames.Comment.Reads.GetCommentIdsFromTask;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseCommentReader databaseCommentReader;

		public GetCommentIdsFromTaskHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentReader databaseCommentReader) : base(databaseAuthorizer) {
			this.databaseCommentReader = databaseCommentReader;
		}

		protected override CommentId[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseCommentReader.GetIdsFromTask(parameters[HttpParameters.CommentTaskId].ToGuid().ToTaskId());
		}
	}
}
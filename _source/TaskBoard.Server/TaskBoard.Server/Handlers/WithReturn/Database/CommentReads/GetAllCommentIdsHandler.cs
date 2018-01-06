using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.CommentReads {
	// ReSharper disable UnusedMember.Global

	public class GetAllCommentIdsHandler : HttpHandlerBaseWithReturn<CommentId[]> {
		public override string HandlerName => HttpHandlerNames.Comment.Reads.GetAllCommentIds;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseCommentReader databaseCommentReader;

		public GetAllCommentIdsHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentReader databaseCommentReader) : base(databaseAuthorizer) {
			this.databaseCommentReader = databaseCommentReader;
		}

		protected override CommentId[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseCommentReader.GetAllIds();
		}
	}
}
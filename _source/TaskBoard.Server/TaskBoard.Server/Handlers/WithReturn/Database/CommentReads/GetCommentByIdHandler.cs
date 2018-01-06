using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.CommentReads {
	// ReSharper disable UnusedMember.Global

	public class GetCommentByIdHandler : HttpHandlerBaseWithReturn<Comment> {
		public override string HandlerName => HttpHandlerNames.Comment.Reads.GetCommentById;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseCommentReader databaseCommentReader;

		public GetCommentByIdHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseCommentReader databaseCommentReader) : base(databaseAuthorizer) {
			this.databaseCommentReader = databaseCommentReader;
		}

		protected override Comment Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseCommentReader.GetById(parameters[HttpParameters.CommentId].ToGuid().ToCommentId());
		}
	}
}
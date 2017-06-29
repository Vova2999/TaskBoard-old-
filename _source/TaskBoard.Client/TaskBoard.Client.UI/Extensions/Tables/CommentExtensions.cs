using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class CommentExtensions {
		public static CommentModel[] ToModels(this IEnumerable<Comment> comments, IHttpClientProvider httpClientProvider) {
			return comments.Select(comment => comment.ToModel(httpClientProvider)).ToArray();
		}

		public static CommentModel ToModel(this Comment comment, IHttpClientProvider httpClientProvider) {
			var user = httpClientProvider.GetDatabaseUserReader().GetById(comment.UserId);

			return new CommentModel {
				CommentId = comment.CommentId,
				Content = comment.Content,
				CreateDateTime = comment.CreateDateTime,
				UserName = user.Login
			};
		}
	}
}
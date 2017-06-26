using System;
using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions {
	public static class CommentExtensions {
		public static CommentModel[] ToModels(this IEnumerable<Comment> comments, User user) {
			return comments.Select(comment => comment.ToModel(user)).ToArray();
		}

		public static CommentModel ToModel(this Comment comment, User user) {
			if (comment.UserId != user.UserId)
				throw new InvalidOperationException($"Ошибка при преобразовании из {nameof(Comment)} в {nameof(CommentModel)}");

			return new CommentModel {
				CommentId = comment.CommentId,
				Content = comment.Content,
				CreateDateTime = comment.CreateDateTime,
				UserName = user.Login
			};
		}
	}
}
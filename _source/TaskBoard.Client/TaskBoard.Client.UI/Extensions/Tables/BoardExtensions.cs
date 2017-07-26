using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class BoardExtensions {
		public static BoardModel[] ToModels(this IEnumerable<Board> boards, IHttpClientProvider httpClientProvider) {
			return boards.Select(board => board.ToModel(httpClientProvider)).ToArray();
		}

		public static BoardModel ToModel(this Board board, IHttpClientProvider httpClientProvider) {
			return new BoardModel(board.Id) {
				Name = board.Name
			};
		}
	}
}
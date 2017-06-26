using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions {
	public static class BoardExtensions {
		public static BoardModel[] ToModels(this IEnumerable<Board> boards) {
			return boards.Select(ToModel).ToArray();
		}

		public static BoardModel ToModel(this Board board) {
			return new BoardModel {
				BoardId = board.BoardId,
				Name = board.Name
			};
		}
	}
}
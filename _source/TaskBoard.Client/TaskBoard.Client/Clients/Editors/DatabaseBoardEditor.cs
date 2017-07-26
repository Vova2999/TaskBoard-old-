using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Editors {
	public class DatabaseBoardEditor : BaseHttpClient, IDatabaseBoardEditor {
		public DatabaseBoardEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(Board board) {
			SendRequest(HttpFunctions.BoardEdits.AddBoard, GetDefaultParameters(), board.ToJson());
		}

		public void Edit(BoardId boardId, Board newBoard) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.BoardId] = boardId.ToString();

			SendRequest(HttpFunctions.BoardEdits.EditBoard, parameters, newBoard.ToJson());
		}

		public void Delete(BoardId boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.BoardId] = boardId.ToString();

			SendRequest(HttpFunctions.BoardEdits.DeleteBoard, parameters);
		}
	}
}
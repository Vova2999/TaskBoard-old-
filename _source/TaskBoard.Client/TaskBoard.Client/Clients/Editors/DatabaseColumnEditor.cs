using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Editors {
	public class DatabaseColumnEditor : BaseHttpClient, IDatabaseColumnEditor {
		public DatabaseColumnEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(Column column) {
			SendRequest(HttpFunctions.ColumnEdits.AddColumn, GetDefaultParameters(), column.ToJson());
		}

		public void Edit(ColumnId oldColumnId, Column newColumn) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnId] = oldColumnId.ToString();

			SendRequest(HttpFunctions.ColumnEdits.EditColumn, parameters, newColumn.ToJson());
		}

		public void Delete(ColumnId tableId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnId] = tableId.ToString();

			SendRequest(HttpFunctions.ColumnEdits.DeleteColumn, parameters);
		}
	}
}
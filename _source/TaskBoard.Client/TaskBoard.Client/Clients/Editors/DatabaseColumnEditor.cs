using System;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.Clients.Editors {
	public class DatabaseColumnEditor : BaseHttpClient, IDatabaseColumnEditor {
		public DatabaseColumnEditor(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public void Add(Column table) {
			SendRequest(HttpFunctions.ColumnEdits.AddColumn, GetDefaultParameters(), table.ToJson());
		}

		public void Edit(Guid oldTableId, Column newTable) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnId] = oldTableId.ToString();

			SendRequest(HttpFunctions.ColumnEdits.EditColumn, parameters, newTable.ToJson());
		}

		public void Delete(Guid tableId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnId] = tableId.ToString();

			SendRequest(HttpFunctions.ColumnEdits.DeleteColumn, parameters);
		}
	}
}
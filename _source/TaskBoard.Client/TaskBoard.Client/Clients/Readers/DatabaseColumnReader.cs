using System.Collections.Generic;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Readers {
	public class DatabaseColumnReader : BaseHttpClient, IDatabaseColumnReader {
		public DatabaseColumnReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public Column GetById(ColumnId id) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnId] = id.ToString();

			return SendRequest<Column>(HttpFunctions.ColumnReads.GetColumnById, parameters);
		}

		public ColumnId[] GetAllIds() {
			return SendRequest<ColumnId[]>(HttpFunctions.ColumnReads.GetAllColumnIds, GetDefaultParameters());
		}

		public Column[] GetAll() {
			return SendRequest<Column[]>(HttpFunctions.ColumnReads.GetAllColumns, GetDefaultParameters());
		}

		public ColumnId GetIdByHeaderWithBoardId(string header, BoardId boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnHeader] = header;
			parameters[HttpParameters.ColumnBoardId] = boardId.ToString();

			return SendRequest<ColumnId>(HttpFunctions.ColumnReads.GetColumnIdByHeaderWithBoardId, parameters);
		}

		public Column GetByHeaderWithBoardId(string header, BoardId boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnHeader] = header;
			parameters[HttpParameters.ColumnBoardId] = boardId.ToString();

			return SendRequest<Column>(HttpFunctions.ColumnReads.GetColumnByHeaderWithBoardId, parameters);
		}

		public ColumnId GetIdByHeaderWithBoardName(string header, string boardName) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnHeader] = header;
			parameters[HttpParameters.ColumnBoardName] = boardName;

			return SendRequest<ColumnId>(HttpFunctions.ColumnReads.GetColumnIdByHeaderWithBoardName, parameters);
		}

		public Column GetByHeaderWithBoardName(string header, string boardName) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnHeader] = header;
			parameters[HttpParameters.ColumnBoardName] = boardName;

			return SendRequest<Column>(HttpFunctions.ColumnReads.GetColumnByHeaderWithBoardName, parameters);
		}

		public ColumnId[] GetIdsFromBoard(BoardId boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnBoardId] = boardId.ToString();

			return SendRequest<ColumnId[]>(HttpFunctions.ColumnReads.GetColumnIdsFromBoard, parameters);
		}

		public Column[] GetFromBoard(BoardId boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnBoardId] = boardId.ToString();

			return SendRequest<Column[]>(HttpFunctions.ColumnReads.GetColumnsFromBoard, parameters);
		}

		public ColumnId[] GetIdsWithUsingFilters(string header, string brush, BoardId boardId) {
			return SendRequest<ColumnId[]>(HttpFunctions.ColumnReads.GetColumnIdsWithUsingFilters, CreateParametersForUsingFilters(header, brush, boardId));
		}

		public Column[] GetWithUsingFilters(string header, string brush, BoardId boardId) {
			return SendRequest<Column[]>(HttpFunctions.ColumnReads.GetColumnsWithUsingFilters, CreateParametersForUsingFilters(header, brush, boardId));
		}

		private Dictionary<string, string> CreateParametersForUsingFilters(string header, string brush, BoardId boardId) {
			var parameters = GetDefaultParameters();
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.ColumnHeader, header);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.ColumnBrush, brush);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.ColumnBoardId, boardId?.ToString());

			return parameters;
		}
	}
}
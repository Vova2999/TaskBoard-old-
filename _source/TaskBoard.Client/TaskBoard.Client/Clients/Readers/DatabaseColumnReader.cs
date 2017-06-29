﻿using System;
using System.Collections.Generic;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.Clients.Readers {
	public class DatabaseColumnReader : BaseHttpClient, IDatabaseColumnReader {
		public DatabaseColumnReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public Column GetById(Guid id) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnId] = id.ToString();

			return SendRequest<Column>(HttpFunctions.ColumnReads.GetColumnById, parameters);
		}

		public Guid[] GetAllIds() {
			return SendRequest<Guid[]>(HttpFunctions.ColumnReads.GetAllColumnIds, GetDefaultParameters());
		}

		public Column[] GetAll() {
			return SendRequest<Column[]>(HttpFunctions.ColumnReads.GetAllColumns, GetDefaultParameters());
		}

		public Guid GetIdByHeaderWithBoardId(string header, Guid boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnHeader] = header;
			parameters[HttpParameters.ColumnBoardId] = boardId.ToString();

			return SendRequest<Guid>(HttpFunctions.ColumnReads.GetColumnIdByHeaderWithBoardId, parameters);
		}

		public Column GetByHeaderWithBoardId(string header, Guid boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnHeader] = header;
			parameters[HttpParameters.ColumnBoardId] = boardId.ToString();

			return SendRequest<Column>(HttpFunctions.ColumnReads.GetColumnByHeaderWithBoardId, parameters);
		}

		public Guid GetIdByHeaderWithBoardName(string header, string boardName) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnHeader] = header;
			parameters[HttpParameters.ColumnBoardName] = boardName;

			return SendRequest<Guid>(HttpFunctions.ColumnReads.GetColumnIdByHeaderWithBoardName, parameters);
		}

		public Column GetByHeaderWithBoardName(string header, string boardName) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnHeader] = header;
			parameters[HttpParameters.ColumnBoardName] = boardName;

			return SendRequest<Column>(HttpFunctions.ColumnReads.GetColumnByHeaderWithBoardName, parameters);
		}

		public Guid[] GetIdsFromBoard(Guid boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnBoardId] = boardId.ToString();

			return SendRequest<Guid[]>(HttpFunctions.ColumnReads.GetColumnIdsFromBoard, parameters);
		}

		public Column[] GetFromBoard(Guid boardId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.ColumnBoardId] = boardId.ToString();

			return SendRequest<Column[]>(HttpFunctions.ColumnReads.GetColumnsFromBoard, parameters);
		}

		public Guid[] GetIdsWithUsingFilters(string header, string brush, Guid? boardId) {
			return SendRequest<Guid[]>(HttpFunctions.ColumnReads.GetColumnIdsWithUsingFilters, CreateParametersForUsingFilters(header, brush, boardId));
		}

		public Column[] GetWithUsingFilters(string header, string brush, Guid? boardId) {
			return SendRequest<Column[]>(HttpFunctions.ColumnReads.GetColumnsWithUsingFilters, CreateParametersForUsingFilters(header, brush, boardId));
		}

		private Dictionary<string, string> CreateParametersForUsingFilters(string header, string brush, Guid? boardId) {
			var parameters = GetDefaultParameters();
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.ColumnHeader, header);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.ColumnBrush, brush);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.ColumnBoardId, boardId?.ToString());

			return parameters;
		}
	}
}
using System;
using System.Collections.Generic;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.Clients.Readers {
	public class DatabaseBoardReader : BaseHttpClient, IDatabaseBoardReader {
		public DatabaseBoardReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public Board GetById(Guid id) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.BoardId] = id.ToString();

			return SendRequest<Board>(HttpFunctions.BoardReads.GetBoardById, parameters);
		}

		public Guid[] GetAllIds() {
			return SendRequest<Guid[]>(HttpFunctions.BoardReads.GetAllBoardIds, GetDefaultParameters());
		}

		public Board[] GetAll() {
			return SendRequest<Board[]>(HttpFunctions.BoardReads.GetAllBoards, GetDefaultParameters());
		}

		public Guid GetIdByName(string name) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.BoardName] = name;

			return SendRequest<Guid>(HttpFunctions.BoardReads.GetBoardIdByName, parameters);
		}

		public Board GetByName(string name) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.BoardName] = name;

			return SendRequest<Board>(HttpFunctions.BoardReads.GetBoardByName, parameters);
		}

		public Guid[] GetIdsWithUsingFilters(string name) {
			return SendRequest<Guid[]>(HttpFunctions.BoardReads.GetBoardIdsWithUsingFilters, CreateParametersForUsingFilters(name));
		}

		public Board[] GetWithUsingFilters(string name) {
			return SendRequest<Board[]>(HttpFunctions.BoardReads.GetBoardsWithUsingFilters, CreateParametersForUsingFilters(name));
		}

		private Dictionary<string, string> CreateParametersForUsingFilters(string name) {
			var parameters = GetDefaultParameters();
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.BoardName, name);

			return parameters;
		}
	}
}
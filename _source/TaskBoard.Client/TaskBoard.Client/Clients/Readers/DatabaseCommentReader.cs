﻿using System;
using System.Collections.Generic;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.Clients.Readers {
	public class DatabaseCommentReader : BaseHttpClient, IDatabaseCommentReader {
		public DatabaseCommentReader(HttpClientParameters httpClientParameters) : base(httpClientParameters) {
		}

		public Comment GetById(CommentId id) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.CommentId] = id.ToString();

			return SendRequest<Comment>(HttpFunctions.CommentReads.GetCommentById, parameters);
		}

		public CommentId[] GetAllIds() {
			return SendRequest<CommentId[]>(HttpFunctions.CommentReads.GetAllCommentIds, GetDefaultParameters());
		}

		public Comment[] GetAll() {
			return SendRequest<Comment[]>(HttpFunctions.CommentReads.GetAllComments, GetDefaultParameters());
		}

		public CommentId[] GetIdsFromTask(TaskId taskId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.CommentTaskId] = taskId.ToString();

			return SendRequest<CommentId[]>(HttpFunctions.CommentReads.GetCommentIdsFromTask, parameters);
		}

		public Comment[] GetFromTask(TaskId taskId) {
			var parameters = GetDefaultParameters();
			parameters[HttpParameters.CommentTaskId] = taskId.ToString();

			return SendRequest<Comment[]>(HttpFunctions.CommentReads.GetCommentsFromTask, parameters);
		}

		public CommentId[] GetIdsWithUsingFilters(string content, DateTime? beginCreateDateTime, DateTime? endCreateDateTime, UserId userId, TaskId taskId) {
			return SendRequest<CommentId[]>(HttpFunctions.CommentReads.GetCommentIdsWithUsingFilters, CreateParametersForUsingFilters(content, beginCreateDateTime, endCreateDateTime, userId, taskId));
		}

		public Comment[] GetWithUsingFilters(string content, DateTime? beginCreateDateTime, DateTime? endCreateDateTime, UserId userId, TaskId taskId) {
			return SendRequest<Comment[]>(HttpFunctions.CommentReads.GetCommentsWithUsingFilters, CreateParametersForUsingFilters(content, beginCreateDateTime, endCreateDateTime, userId, taskId));
		}

		private Dictionary<string, string> CreateParametersForUsingFilters(string content, DateTime? beginCreateDateTime, DateTime? endCreateDateTime, UserId userId, TaskId taskId) {
			var parameters = GetDefaultParameters();
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.CommentContent, content);
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.CommentBeginCreateDateTime, beginCreateDateTime?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.CommentEndCreateDateTime, endCreateDateTime?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.CommentUserId, userId?.ToString());
			AddParameterIfNotNullOrEmpty(parameters, HttpParameters.CommentTaskId, taskId?.ToString());

			return parameters;
		}
	}
}
using System;
using System.Linq;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;
using TaskBoard.Server.Database.Extensions;

namespace TaskBoard.Server.Database.Models.Readers {
	// ReSharper disable UnusedMember.Global

	public class DatabaseCommentReader : DatabaseReader, IDatabaseCommentReader {
		public DatabaseCommentReader(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public Comment GetById(CommentId id) {
			return ModelDatabase.GetComment(id).ToTable();
		}

		public CommentId[] GetAllIds() {
			return ModelDatabase.Comments.Select(comment => comment.Id.ToCommentId()).ToArray();
		}

		public Comment[] GetAll() {
			return ModelDatabase.Comments.ToTables();
		}

		public CommentId[] GetIdsFromTask(TaskId taskId) {
			return ModelDatabase.Comments.Where(comment => comment.TaskId == taskId.InstanceId).Select(comment => comment.Id.ToCommentId()).ToArray();
		}

		public Comment[] GetFromTask(TaskId taskId) {
			return ModelDatabase.Comments.Where(comment => comment.TaskId == taskId.InstanceId).ToTables();
		}

		public CommentId[] GetIdsWithUsingFilters(string content, DateTime? beginCreateDateTime, DateTime? endCreateDateTime, UserId userId, TaskId taskId) {
			return GetQueryWithUsingFilters(content, beginCreateDateTime, endCreateDateTime, userId, taskId).Select(comment => comment.Id.ToCommentId()).ToArray();
		}

		public Comment[] GetWithUsingFilters(string content, DateTime? beginCreateDateTime, DateTime? endCreateDateTime, UserId userId, TaskId taskId) {
			return GetQueryWithUsingFilters(content, beginCreateDateTime, endCreateDateTime, userId, taskId).ToTables();
		}

		private IQueryable<CommentEntity> GetQueryWithUsingFilters(string content, DateTime? beginCreateDateTime, DateTime? endCreateDateTime, UserId userId, TaskId taskId) {
			IQueryable<CommentEntity> comments = ModelDatabase.Comments;
			UseFilter(content != null, ref comments, comment => comment.Content.Contains(content));
			UseFilter(beginCreateDateTime != null, ref comments, comment => comment.CreateDateTime >= beginCreateDateTime);
			UseFilter(endCreateDateTime != null, ref comments, comment => comment.CreateDateTime <= endCreateDateTime);
			UseFilter(userId != null, ref comments, comment => comment.UserId == userId.InstanceId);
			UseFilter(taskId != null, ref comments, comment => comment.TaskId == taskId.InstanceId);

			return comments;
		}
	}
}
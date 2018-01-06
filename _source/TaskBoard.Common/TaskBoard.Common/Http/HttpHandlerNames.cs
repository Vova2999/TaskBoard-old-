namespace TaskBoard.Common.Http {
	// ReSharper disable UnusedMember.Global

	public static class HttpHandlerNames {
		public static class Common {
			public const string Ping = "Ping";
			public const string StopServer = "Stop";
			public const string CheckUserIsExist = "CheckUserIsExist";
		}

		public static class Board {
			public static class Edits {
				public const string AddBoard = "AddBoard";
				public const string EditBoard = "EditBoard";
				public const string DeleteBoard = "DeleteBoard";
			}

			public static class Reads {
				public const string GetBoardById = "GetBoardById";
				public const string GetAllBoardIds = "GetAllBoardIds";
				public const string GetAllBoards = "GetAllBoards";
				public const string GetBoardIdByName = "GetBoardIdByName";
				public const string GetBoardByName = "GetBoardByName";
				public const string GetBoardIdsWithUsingFilters = "GetBoardIdsWithUsingFilters";
				public const string GetBoardsWithUsingFilters = "GetBoardsWithUsingFilters";
			}
		}

		public static class Column {
			public static class Edits {
				public const string AddColumn = "AddColumn";
				public const string EditColumn = "EditColumn";
				public const string DeleteColumn = "DeleteColumn";
			}

			public static class Reads {
				public const string GetColumnById = "GetColumnById";
				public const string GetAllColumnIds = "GetAllColumnIds";
				public const string GetAllColumns = "GetAllColumns";
				public const string GetColumnIdByHeaderWithBoardId = "GetColumnIdByHeaderWithBoardId";
				public const string GetColumnByHeaderWithBoardId = "GetColumnByHeaderWithBoardId";
				public const string GetColumnIdByHeaderWithBoardName = "GetColumnIdByHeaderWithBoardName";
				public const string GetColumnByHeaderWithBoardName = "GetColumnByHeaderWithBoardName";
				public const string GetColumnIdsFromBoard = "GetColumnIdsFromBoard";
				public const string GetColumnsFromBoard = "GetColumnsFromBoard";
				public const string GetColumnIdsWithUsingFilters = "GetColumnIdsWithUsingFilters";
				public const string GetColumnsWithUsingFilters = "GetColumnsWithUsingFilters";
			}
		}

		public static class Comment {
			public static class Edits {
				public const string AddComment = "AddComment";
				public const string EditComment = "EditComment";
				public const string DeleteComment = "DeleteComment";
			}

			public static class Reads {
				public const string GetCommentById = "GetCommentById";
				public const string GetAllCommentIds = "GetAllCommentIds";
				public const string GetAllComments = "GetAllComments";
				public const string GetCommentIdsFromTask = "GetCommentIdsFromTask";
				public const string GetCommentsFromTask = "GetCommentsFromTask";
				public const string GetCommentIdsWithUsingFilters = "GetCommentIdsWithUsingFilters";
				public const string GetCommentsWithUsingFilters = "GetCommentsWithUsingFilters";
			}
		}

		public static class Task {
			public static class Edits {
				public const string AddTask = "AddTask";
				public const string EditTask = "EditTask";
				public const string DeleteTask = "DeleteTask";
			}

			public static class Reads {
				public const string GetTaskById = "GetTaskById";
				public const string GetAllTaskIds = "GetAllTaskIds";
				public const string GetAllTasks = "GetAllTasks";
				public const string GetTaskIdsFromBoard = "GetTaskIdsFromBoard";
				public const string GetTasksFromBoard = "GetTasksFromBoard";
				public const string GetTaskIdsFromColumn = "GetTaskIdsFromColumn";
				public const string GetTasksFromColumn = "GetTasksFromColumn";
				public const string GetTaskIdsWithUsingFilters = "GetTaskIdsWithUsingFilters";
				public const string GetTasksWithUsingFilters = "GetTasksWithUsingFilters";
			}
		}

		public static class User {
			public static class Edits {
				public const string AddUser = "AddUser";
				public const string EditUser = "EditUser";
				public const string DeleteUser = "DeleteUser";
			}

			public static class Reads {
				public const string GetUserById = "GetUserById";
				public const string GetAllUserIds = "GetAllUserIds";
				public const string GetAllUsers = "GetAllUsers";
				public const string GetUserIdByLogin = "GetUserIdByLogin";
				public const string GetUserByLogin = "GetUserByLogin";
				public const string GetUserIdsWithUsingFilters = "GetUserIdsWithUsingFilters";
				public const string GetUsersWithUsingFilters = "GetUsersWithUsingFilters";
			}

			public static class ReadsAsAdmin {
				public const string GetUserByIdAsAdmin = "GetUserByIdAsAdmin";
				public const string GetAllUserIdsAsAdmin = "GetAllUserIdsAsAdmin";
				public const string GetAllUsersAsAdmin = "GetAllUsersAsAdmin";
				public const string GetUserIdByLoginAsAdmin = "GetUserIdByLoginAsAdmin";
				public const string GetUserByLoginAsAdmin = "GetUserByLoginAsAdmin";
				public const string GetUserIdsWithUsingFiltersAsAdmin = "GetUserIdsWithUsingFiltersAsAdmin";
				public const string GetUsersWithUsingFiltersAsAdmin = "GetUsersWithUsingFiltersAsAdmin";
			}
		}
	}
}
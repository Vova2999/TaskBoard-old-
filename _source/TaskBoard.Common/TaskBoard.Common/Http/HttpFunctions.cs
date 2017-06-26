namespace TaskBoard.Common.Http {
	// ReSharper disable UnusedMember.Global

	public static class HttpFunctions {
		public const string Ping = "Ping";
		public const string StopServer = "Stop";
		public const string CheckUserIsExist = "CheckUserIsExist";

		public const string AddBoard = "AddBoard";
		public const string EditBoard = "EditBoard";
		public const string DeleteBoard = "DeleteBoard";

		public const string AddColumn = "AddColumn";
		public const string EditColumn = "EditColumn";
		public const string DeleteColumn = "DeleteColumn";

		public const string AddComment = "AddComment";
		public const string EditComment = "EditComment";
		public const string DeleteComment = "DeleteComment";

		public const string AddTask = "AddTask";
		public const string EditTask = "EditTask";
		public const string DeleteTask = "DeleteTask";

		public const string AddUser = "AddUser";
		public const string EditUser = "EditUser";
		public const string DeleteUser = "DeleteUser";

		public const string GetBoardById = "GetBoardById";
		public const string GetAllBoardIds = "GetAllBoardIds";
		public const string GetAllBoards = "GetAllBoards";
		public const string GetBoardIdsWithUsingFilters = "GetBoardIdsWithUsingFilters";
		public const string GetBoardsWithUsingFilters = "GetBoardsWithUsingFilters";

		public const string GetColumnById = "GetColumnById";
		public const string GetAllColumnIds = "GetAllColumnIds";
		public const string GetAllColumns = "GetAllColumns";
		public const string GetColumnIdsFromBoard = "GetColumnIdsFromBoard";
		public const string GetColumnsFromBoard = "GetColumnsFromBoard";
		public const string GetColumnIdsWithUsingFilters = "GetColumnIdsWithUsingFilters";
		public const string GetColumnsWithUsingFilters = "GetColumnsWithUsingFilters";

		public const string GetCommentById = "GetCommentById";
		public const string GetAllCommentIds = "GetAllCommentIds";
		public const string GetAllComments = "GetAllComments";
		public const string GetCommentIdsFromTask = "GetCommentIdsFromTask";
		public const string GetCommentsFromTask = "GetCommentsFromTask";
		public const string GetCommentIdsWithUsingFilters = "GetCommentIdsWithUsingFilters";
		public const string GetCommentsWithUsingFilters = "GetCommentsWithUsingFilters";

		public const string GetTaskById = "GetTaskById";
		public const string GetAllTaskIds = "GetAllTaskIds";
		public const string GetAllTasks = "GetAllTasks";
		public const string GetTaskIdsFromBoard = "GetTaskIdsFromBoard";
		public const string GetTasksFromBoard = "GetTasksFromBoard";
		public const string GetTaskIdsFromColumn = "GetTaskIdsFromColumn";
		public const string GetTasksFromColumn = "GetTasksFromColumn";
		public const string GetTaskIdsWithUsingFilters = "GetTaskIdsWithUsingFilters";
		public const string GetTasksWithUsingFilters = "GetTasksWithUsingFilters";

		public const string GetUserById = "GetUserById";
		public const string GetAllUserIds = "GetAllUserIds";
		public const string GetAllUsers = "GetAllUsers";
		public const string GetUserIdsWithUsingFilters = "GetUserIdsWithUsingFilters";
		public const string GetUsersWithUsingFilters = "GetUsersWithUsingFilters";

		public const string GetUserByIdAsAdmin = "GetUserByIdAsAdmin";
		public const string GetAllUserIdsAsAdmin = "GetAllUserIdsAsAdmin";
		public const string GetAllUsersAsAdmin = "GetAllUsersAsAdmin";
		public const string GetUserIdsWithUsingFiltersAsAdmin = "GetUserIdsWithUsingFiltersAsAdmin";
		public const string GetUsersWithUsingFiltersAsAdmin = "GetUsersWithUsingFiltersAsAdmin";
	}
}
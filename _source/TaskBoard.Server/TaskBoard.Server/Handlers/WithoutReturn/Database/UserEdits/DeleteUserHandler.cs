using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.UserEdits {
	// ReSharper disable UnusedMember.Global

	public class DeleteUserHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.User.Edits.DeleteUser;
		protected override AccessType? RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseUserEditor databaseUserEditor;

		public DeleteUserHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserEditor databaseUserEditor) : base(databaseAuthorizer) {
			this.databaseUserEditor = databaseUserEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseUserEditor.Delete(parameters[HttpParameters.UserId].ToGuid().ToUserId());
		}
	}
}
using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.UserEdits {
	// ReSharper disable UnusedMember.Global

	public class EditUserHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.User.Edits.EditUser;
		protected override AccessType? RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseUserEditor databaseUserEditor;

		public EditUserHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserEditor databaseUserEditor) : base(databaseAuthorizer) {
			this.databaseUserEditor = databaseUserEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseUserEditor.Edit(parameters[HttpParameters.UserId].ToGuid().ToUserId(), requestBody.FromJson<User>());
		}
	}
}
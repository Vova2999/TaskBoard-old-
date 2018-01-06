using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithoutReturn.Database.UserEdits {
	// ReSharper disable UnusedMember.Global

	public class AddUserHandler : HttpHandlerBaseWithoutReturn {
		public override string HandlerName => HttpHandlerNames.User.Edits.AddUser;
		protected override AccessType? RequiredAccessType => AccessType.AdminWrite;
		private readonly IDatabaseUserEditor databaseUserEditor;

		public AddUserHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserEditor databaseUserEditor) : base(databaseAuthorizer) {
			this.databaseUserEditor = databaseUserEditor;
		}

		protected override void Run(NameValueCollection parameters, byte[] requestBody) {
			databaseUserEditor.Add(requestBody.FromJson<User>());
		}
	}
}
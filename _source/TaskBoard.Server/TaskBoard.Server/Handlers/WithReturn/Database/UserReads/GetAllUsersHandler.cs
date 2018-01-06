using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReads {
	// ReSharper disable UnusedMember.Global

	public class GetAllUsersHandler : HttpHandlerBaseWithReturn<User[]> {
		public override string HandlerName => HttpHandlerNames.User.Reads.GetAllUsers;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetAllUsersHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override User[] Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseUserReader.GetAll();
		}
	}
}
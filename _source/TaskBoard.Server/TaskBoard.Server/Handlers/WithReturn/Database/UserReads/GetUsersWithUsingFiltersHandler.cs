using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReads {
	// ReSharper disable UnusedMember.Global

	public class GetUsersWithUsingFiltersHandler : HttpHandlerBaseWithReturn<User[]> {
		public override string HandlerName => HttpHandlerNames.User.Reads.GetUsersWithUsingFilters;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetUsersWithUsingFiltersHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override User[] Run(NameValueCollection parameters, byte[] requestBody) {
			var login = parameters.Get(HttpParameters.UserLogin);

			return databaseUserReader.GetWithUsingFilters(login);
		}
	}
}
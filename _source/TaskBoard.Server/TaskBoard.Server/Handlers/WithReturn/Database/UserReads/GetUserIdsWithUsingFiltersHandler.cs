using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReads {
	// ReSharper disable UnusedMember.Global

	public class GetUserIdsWithUsingFiltersHandler : HttpHandlerBaseWithReturn<UserId[]> {
		public override string HandlerName => HttpHandlerNames.User.Reads.GetUserIdsWithUsingFilters;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetUserIdsWithUsingFiltersHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override UserId[] Run(NameValueCollection parameters, byte[] requestBody) {
			var login = parameters.Get(HttpParameters.UserLogin);

			return databaseUserReader.GetIdsWithUsingFilters(login);
		}
	}
}
using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReads {
	// ReSharper disable UnusedMember.Global

	public class GetUserIdByLoginHandler : HttpHandlerBaseWithReturn<UserId> {
		public override string HandlerName => HttpHandlerNames.User.Reads.GetUserIdByLogin;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReader databaseUserReader;

		public GetUserIdByLoginHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReader databaseUserReader) : base(databaseAuthorizer) {
			this.databaseUserReader = databaseUserReader;
		}

		protected override UserId Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseUserReader.GetIdByLogin(parameters[HttpParameters.UserLogin]);
		}
	}
}
using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Common.Tables;

namespace TaskBoard.Server.Handlers.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetUserByLoginAsAdminHandler : HttpHandlerBaseWithReturn<User> {
		public override string HandlerName => HttpHandlerNames.User.ReadsAsAdmin.GetUserByLoginAsAdmin;
		protected override AccessType? RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetUserByLoginAsAdminHandler(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override User Run(NameValueCollection parameters, byte[] requestBody) {
			return databaseUserReaderAsAdmin.GetByLogin(parameters[HttpParameters.UserLogin]);
		}
	}
}
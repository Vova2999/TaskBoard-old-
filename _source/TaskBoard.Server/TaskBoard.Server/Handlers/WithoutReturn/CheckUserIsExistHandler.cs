using System.Collections.Specialized;
using TaskBoard.Common.Database;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Server.Exceptions.HttpExceptions;

namespace TaskBoard.Server.Handlers.WithoutReturn {
	// ReSharper disable UnusedMember.Global

	public class CheckUserIsExistHandler : HttpHandlerBaseWithReturn<bool> {
		public override string HandlerName => HttpHandlerNames.Common.CheckUserIsExist;
		protected override AccessType? RequiredAccessType => null;
		private readonly IDatabaseAuthorizer databaseAuthorizer;

		public CheckUserIsExistHandler(IDatabaseAuthorizer databaseAuthorizer) : base(null) {
			this.databaseAuthorizer = databaseAuthorizer;
		}

		protected override bool Run(NameValueCollection parameters, byte[] requestBody) {
			var login = parameters.Get(HttpParameters.Login);
			var password = parameters.Get(HttpParameters.Password);

			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
				throw new HttpBadRequestException("Для вызова этой функции необходимо передать параметры пользователя");

			return databaseAuthorizer.UserIsExist(login, password);
		}
	}
}
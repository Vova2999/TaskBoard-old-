using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions.Tables {
	public static class UserExtensions {
		public static UserModel[] ToModels(this IEnumerable<User> users, IHttpClientProvider httpClientProvider) {
			return users.Select(user => user.ToModel(httpClientProvider)).ToArray();
		}

		public static UserModel ToModel(this User user, IHttpClientProvider httpClientProvider) {
			return new UserModel(user.Id) {
				Login = user.Login,
				Password = user.Password,
				AccessType = user.AccessType
			};
		}
	}
}
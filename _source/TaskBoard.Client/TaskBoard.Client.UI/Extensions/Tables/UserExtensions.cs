using System.Collections.Generic;
using System.Linq;
using TaskBoard.Client.UI.Models;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.Extensions {
	public static class UserExtensions {
		public static UserModel[] ToModels(this IEnumerable<User> users) {
			return users.Select(ToModel).ToArray();
		}

		public static UserModel ToModel(this User user) {
			return new UserModel {
				UserId = user.UserId,
				Login = user.Login,
				Password = user.Password,
				AccessType = user.AccessType
			};
		}
	}
}
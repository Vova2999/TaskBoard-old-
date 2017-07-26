using System;
using TaskBoard.Common.Database.Editors;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;

namespace TaskBoard.Server.Database.Models.Editors {
	// ReSharper disable UnusedMember.Global

	public class DatabaseUserEditor : DatabaseEditor, IDatabaseUserEditor {
		public DatabaseUserEditor(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public void Add(User user) {
			ModelDatabase.Users.Add(new UserEntity {
				Id = Guid.NewGuid(),
				Login = user.Login,
				Password = user.Password,
				AccessType = user.AccessType
			});

			ModelDatabase.SaveChanges();
		}

		public void Edit(UserId oldUserId, User newUser) {
			var user = ModelDatabase.GetUser(oldUserId);
			user.Login = newUser.Login;
			user.Password = newUser.Password;
			user.AccessType = newUser.AccessType;

			ModelDatabase.SaveChanges();
		}

		public void Delete(UserId userId) {
			DeleteUser(userId);
			ModelDatabase.SaveChanges();
		}
	}
}
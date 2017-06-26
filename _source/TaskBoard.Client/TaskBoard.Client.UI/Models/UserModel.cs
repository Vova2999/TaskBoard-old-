using System;
using GalaSoft.MvvmLight;

namespace TaskBoard.Client.UI.Models {
	public class UserModel : ViewModelBase {
		private Guid userId;
		public Guid UserId {
			get => userId;
			set => Set(() => UserId, ref userId, value);
		}

		private string login;
		public string Login {
			get => login;
			set => Set(() => Login, ref login, value);
		}

		private string password;
		public string Password {
			get => password;
			set => Set(() => Password, ref password, value);
		}

		private int accessType;
		public int AccessType {
			get => accessType;
			set => Set(() => AccessType, ref accessType, value);
		}
	}
}
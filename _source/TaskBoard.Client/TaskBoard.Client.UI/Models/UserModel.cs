using GalaSoft.MvvmLight;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Client.UI.Models {
	public class UserModel : ViewModelBase {
		public UserId Id { get; }

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

		public UserModel(UserId id) {
			Id = id;
		}

		public override bool Equals(object obj) {
			return obj is UserModel that && Id.Equals(that.Id);
		}
		public override int GetHashCode() {
			return Id.GetHashCode();
		}
	}
}
using JetBrains.Annotations;
using TaskBoard.Common.Enums;

namespace TaskBoard.Common.Database {
	// ReSharper disable UnusedMember.Global

	public interface IDatabaseAuthorizer {
		bool UserIsExist([NotNull] string login, [NotNull] string password);
		bool AccessIsAllowed([NotNull] string login, [NotNull] string password, AccessType requiredAccessType);
	}
}
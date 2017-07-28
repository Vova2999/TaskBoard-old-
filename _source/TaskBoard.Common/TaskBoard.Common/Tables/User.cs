using JetBrains.Annotations;
using TaskBoard.Common.Tables.Attributes;
using TaskBoard.Common.Tables.TableIds;

namespace TaskBoard.Common.Tables {
	// ReSharper disable AnnotationRedundancyAtValueType
	// ReSharper disable ClassNeverInstantiated.Global
	// ReSharper disable NotNullMemberIsNotInitialized
	// ReSharper disable UnusedMember.Global

	public class User : BaseTable<UserId> {
		[HeaderColumn("Логин"), NotNull]
		public string Login { get; set; }

		[HeaderColumn("Пароль"), NotNull]
		public string Password { get; set; }

		[HeaderColumn("Тип доступа"), NotNull]
		public int AccessType { get; set; }
	}
}
namespace TaskBoard.Common.Enums {
	// ReSharper disable UnusedMember.Global

	public enum AccessType {
		Root = 0x01,
		UserRead = 0x02,
		UserWrite = 0x04,
		AdminRead = 0x08,
		AdminWrite = 0x10
	}
}
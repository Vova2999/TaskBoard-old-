using System;

namespace TaskBoard.Common.Tables.TableIds {
	// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NonReadonlyMemberInGetHashCode
	// ReSharper disable NotAccessedField.Global

	public abstract class BaseTableId {
		public Guid InstanceId { get; set; }

		protected BaseTableId(Guid instanceId) {
			InstanceId = instanceId;
		}

		public static bool operator ==(BaseTableId firstTableId, BaseTableId secondTableId) {
			var isFirstTableIdNull = firstTableId?.Equals(null) != false;
			var isSecondTableIdNull = secondTableId?.Equals(null) != false;

			return isFirstTableIdNull && isSecondTableIdNull || !isFirstTableIdNull && !isSecondTableIdNull && firstTableId.Equals(secondTableId);
		}
		public static bool operator !=(BaseTableId firstTableId, BaseTableId secondTableId) {
			return !(firstTableId == secondTableId);
		}

		public override bool Equals(object obj) {
			return obj is BaseTableId tableId && tableId.InstanceId.Equals(InstanceId);
		}
		public override int GetHashCode() {
			return InstanceId.GetHashCode();
		}

		public override string ToString() {
			return InstanceId.ToString();
		}
	}
}
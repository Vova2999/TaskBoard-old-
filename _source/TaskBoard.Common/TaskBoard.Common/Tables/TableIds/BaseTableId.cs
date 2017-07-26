using System;

namespace TaskBoard.Common.Tables.TableIds {
	// ReSharper disable MemberCanBePrivate.Global
	// ReSharper disable NotAccessedField.Global

	public abstract class BaseTableId {
		public readonly Guid InstanceId;

		protected BaseTableId(Guid instanceId) {
			InstanceId = instanceId;
		}

		public static bool operator ==(BaseTableId firstTableId, BaseTableId secondTableId) {
			var isFirstTableIdNull = firstTableId == null;
			var isSecondTableIdNull = secondTableId == null;

			return isFirstTableIdNull == isSecondTableIdNull && !isFirstTableIdNull && firstTableId.Equals(secondTableId);
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
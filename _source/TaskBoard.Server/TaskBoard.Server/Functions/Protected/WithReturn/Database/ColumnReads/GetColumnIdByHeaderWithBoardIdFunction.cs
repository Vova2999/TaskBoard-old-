﻿using System;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Http;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.ColumnReads {
	// ReSharper disable UnusedMember.Global

	public class GetColumnIdByHeaderWithBoardIdFunction : HttpProtectedFunctionWithReturn<Guid> {
		public override string NameOfCalledMethod => HttpFunctions.ColumnReads.GetColumnIdByHeaderWithBoardId;
		protected override AccessType RequiredAccessType => AccessType.UserRead;
		private readonly IDatabaseColumnReader databaseColumnReader;

		public GetColumnIdByHeaderWithBoardIdFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseColumnReader databaseColumnReader) : base(databaseAuthorizer) {
			this.databaseColumnReader = databaseColumnReader;
		}

		protected override Guid Run(NameValues parameters, byte[] requestBody) {
			return databaseColumnReader.GetIdByHeaderWithBoardId(parameters[HttpParameters.ColumnHeader], parameters[HttpParameters.ColumnBoardId].ToGuid());
		}
	}
}
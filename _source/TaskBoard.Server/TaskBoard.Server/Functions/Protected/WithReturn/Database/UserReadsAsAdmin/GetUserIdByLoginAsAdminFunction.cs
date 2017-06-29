﻿using System;
using TaskBoard.Common.Database;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Http;
using TaskBoard.Server.AdditionalObjects;

namespace TaskBoard.Server.Functions.Protected.WithReturn.Database.UserReadsAsAdmin {
	// ReSharper disable UnusedMember.Global

	public class GetUserIdByLoginAsAdminFunction : HttpProtectedFunctionWithReturn<Guid> {
		public override string NameOfCalledMethod => HttpFunctions.UserReadsAsAdmin.GetUserIdByLoginAsAdmin;
		protected override AccessType RequiredAccessType => AccessType.AdminRead;
		private readonly IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin;

		public GetUserIdByLoginAsAdminFunction(IDatabaseAuthorizer databaseAuthorizer, IDatabaseUserReaderAsAdmin databaseUserReaderAsAdmin) : base(databaseAuthorizer) {
			this.databaseUserReaderAsAdmin = databaseUserReaderAsAdmin;
		}

		protected override Guid Run(NameValues parameters, byte[] requestBody) {
			return databaseUserReaderAsAdmin.GetIdByLogin(parameters[HttpParameters.UserLogin]);
		}
	}
}
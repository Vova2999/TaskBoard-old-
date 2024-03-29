﻿using System;
using System.Linq;
using TaskBoard.Common.Database.Readers;
using TaskBoard.Common.Extensions;
using TaskBoard.Common.Tables;
using TaskBoard.Common.Tables.TableIds;
using TaskBoard.Server.Database.Entities;
using TaskBoard.Server.Database.Extensions;

namespace TaskBoard.Server.Database.Models.Readers {
	// ReSharper disable UnusedMember.Global

	public class DatabaseUserReader : DatabaseReader, IDatabaseUserReader {
		public DatabaseUserReader(ModelDatabase modelDatabase) : base(modelDatabase) {
		}

		public User GetById(UserId id) {
			return ModelDatabase.GetUser(id).ToTable();
		}

		public UserId[] GetAllIds() {
			return ModelDatabase.Users.Select(user => user.Id.ToUserId()).ToArray();
		}

		public User[] GetAll() {
			return ModelDatabase.Users.ToTables();
		}

		public UserId GetIdByLogin(string login) {
			return (ModelDatabase.Users.FirstOrDefault(user => user.Login == login)?.Id ?? throw new ArgumentException($"Не найден пользователь с login = '{login}'")).ToUserId();
		}

		public User GetByLogin(string login) {
			return ModelDatabase.Users.FirstOrDefault(user => user.Login == login)?.ToTable() ?? throw new ArgumentException($"Не найден пользователь с login = '{login}'");
		}

		public UserId[] GetIdsWithUsingFilters(string login) {
			return GetQueryWithUsingFilters(login).Select(user => user.Id.ToUserId()).ToArray();
		}

		public User[] GetWithUsingFilters(string login) {
			return GetQueryWithUsingFilters(login).ToTables();
		}

		private IQueryable<UserEntity> GetQueryWithUsingFilters(string login) {
			IQueryable<UserEntity> users = ModelDatabase.Users;
			UseFilter(login != null, ref users, user => user.Login.Contains(login));

			return users;
		}
	}
}
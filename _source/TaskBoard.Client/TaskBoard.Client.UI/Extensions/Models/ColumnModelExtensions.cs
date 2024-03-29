﻿using System.Collections.ObjectModel;
using System.Linq;
using TaskBoard.Client.Providers;
using TaskBoard.Client.UI.Extensions.Tables;
using TaskBoard.Client.UI.Models;

namespace TaskBoard.Client.UI.Extensions.Models {
	public static class ColumnModelExtensions {
		public static ColumnModel DownloadTaskModels(this ColumnModel columnModel, IHttpClientProvider httpClientProvider, UserModel developerUserModels = null, UserModel reviewerUserModels = null) {
			columnModel.TaskModels = new ObservableCollection<TaskModel>(httpClientProvider.GetDatabaseTaskReader().GetFromColumn(columnModel.BoardModel.Id, columnModel.Id)
				.ToModels(httpClientProvider, developerUserModels, reviewerUserModels, columnModel, columnModel.BoardModel).OrderBy(taskModel => taskModel.Index));
			return columnModel;
		}
	}
}
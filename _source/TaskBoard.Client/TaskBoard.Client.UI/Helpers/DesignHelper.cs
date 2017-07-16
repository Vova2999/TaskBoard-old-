using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels;
using TaskBoard.Client.UI.ViewModels.Controls;
using TaskBoard.Client.UI.ViewModels.Flyouts;
using TaskBoard.Common.Enums;
using TaskBoard.Common.Extensions;

namespace TaskBoard.Client.UI.Helpers {
	public static class DesignHelper {
		private static readonly BoardModel boardModel;
		private static readonly ColumnModel[] columnModels;
		private static readonly TaskModel[][] taskModels;

		static DesignHelper() {
			if (!ViewModelBase.IsInDesignModeStatic)
				return;

			var countColumns = 3;
			var countTasks = new[] { 3, 2, 1 };

			boardModel = new BoardModel {
				BoardId = Guid.NewGuid(),
				Name = "Название доски"
			};

			columnModels = Enumerable.Range(0, countColumns)
				.Select(x => new ColumnModel {
					ColumnId = Guid.NewGuid(),
					Header = $"Столбец №{x + 1}",
					Brush = (Brush)new BrushConverter().ConvertFromString($"#FF{(x % 3 == 0 ? "FF" : "00")}{(x % 3 == 1 ? "FF" : "00")}{(x % 3 == 2 ? "FF" : "00")}"),
					BoardModel = boardModel
				}).ToArray();

			taskModels = Enumerable.Range(0, countColumns)
				.Select(x => Enumerable.Range(0, countTasks[x % countTasks.Length])
					.Select(y => new TaskModel {
						TaskId = Guid.NewGuid(),
						Header = $"Задача №{x + 1}-{y + 1}",
						Description = "Описание задачи",
						Branch = "Branch",
						State = State.NoState,
						Priority = Priority.NoPriority,
						CreateDateTime = DateTime.Now,
						DeveloperUserModel = new UserModel { Login = "Developer" },
						ReviewerUserModel = new UserModel { Login = "Reviewer" },
						ColumnModel = columnModels[x],
						BoardModel = boardModel
					}).ToArray()).ToArray();

			boardModel.ColumnModels = new ObservableCollection<ColumnModel>(columnModels);
			boardModel.TaskModels = new ObservableCollection<TaskModel>(taskModels.SelectMany(taskModel => taskModel));
			columnModels.ForEach((columnModel, x) => columnModel.TaskModels = new ObservableCollection<TaskModel>(taskModels[x]));
		}


		public static void SetControls(MainViewModel mainViewModel) {
			CheckDesignMode();

			mainViewModel.BoardControlViewModel = new BoardControlViewModel();
			mainViewModel.BoardModels.Reset(new[] { boardModel });
			mainViewModel.SelectedBoardModel = boardModel;

			SetControls(mainViewModel.BoardControlViewModel);
		}

		public static void SetControls(BoardControlViewModel boardViewModel) {
			CheckDesignMode();

			boardViewModel.BoardModel = boardModel;
			boardViewModel.ColumnControlViewModels.Reset(columnModels.Select((columnModel, x) => {
				var columnControlViewModel = new ColumnControlViewModel { ColumnModel = columnModel };
				columnControlViewModel.TaskControlViewModels.Reset(taskModels[x].Select(taskModel => new TaskControlViewModel { TaskModel = taskModel }));
				return columnControlViewModel;
			}));
		}

		public static void SetControls(ColumnControlViewModel columnViewModel) {
			CheckDesignMode();

			columnViewModel.ColumnModel = columnModels.First();
			columnViewModel.TaskControlViewModels.Reset(taskModels.First().Select(taskModel => new TaskControlViewModel { TaskModel = taskModel }));
		}

		public static void SetControls(TaskControlViewModel taskViewModel) {
			CheckDesignMode();

			taskViewModel.TaskModel = taskModels.First().First();
		}

		public static void SetControls(SettingsFlyoutViewModel columnViewModel) {
			CheckDesignMode();
		}

		public static void SetControls(AuthorizationFlyoutViewModel columnViewModel) {
			CheckDesignMode();
		}

		private static void CheckDesignMode() {
			if (!ViewModelBase.IsInDesignModeStatic)
				throw new NotImplementedException("Ошибочный вызов конструктора");
		}
	}
}
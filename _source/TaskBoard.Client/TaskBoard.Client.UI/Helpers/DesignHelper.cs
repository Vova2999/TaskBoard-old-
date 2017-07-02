using System;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels;
using TaskBoard.Client.UI.ViewModels.Controls;
using TaskBoard.Common.Enums;

namespace TaskBoard.Client.UI.Helpers {
	public static class DesignHelper {
		public static void SetControls(MainViewModel mainViewModel) {
			CheckDesignMode();

			var selectedBoardModel = new BoardModel { Name = "Название доски" };
			mainViewModel.BoardControlViewModel = new BoardControlViewModel();
			mainViewModel.BoardModels.Reset(new[] { selectedBoardModel });
			mainViewModel.SelectedBoardModel = selectedBoardModel;

			SetControls(mainViewModel.BoardControlViewModel);
		}

		public static void SetControls(BoardControlViewModel boardViewModel) {
			CheckDesignMode();

			boardViewModel.BoardModel = new BoardModel {
				Name = "Название доски"
			};

			boardViewModel.ColumnControlViewModels.Reset(new[] {
				new ColumnControlViewModel { ColumnModel = new ColumnModel { Header = "Первый столбец", Brush = Brushes.Green, BoardName = "Название доски" } },
				new ColumnControlViewModel { ColumnModel = new ColumnModel { Header = "Второй столбец", Brush = Brushes.Blue, BoardName = "Название доски" } },
				new ColumnControlViewModel { ColumnModel = new ColumnModel { Header = "Третий столбец", Brush = Brushes.Red, BoardName = "Название доски" } }
			});
		}

		public static void SetControls(ColumnControlViewModel columnViewModel) {
			CheckDesignMode();

			columnViewModel.ColumnModel = new ColumnModel { Header = "Название столбца", Brush = Brushes.Blue, BoardName = "Название доски" };

			columnViewModel.TaskControlViewModels.Reset(new[] {
				new TaskControlViewModel {
					TaskModel = new TaskModel {
						Header = "Задача №1",
						Description = "Описание",
						Branch = "Ветка",
						State = State.NoState,
						Priority = Priority.NoPriority,
						CreateDateTime = DateTime.Now,
						DeveloperName = "Имя разработчика",
						ReviewerName = "Имя ревьюера",
						ColumnHeader = "Заголовок столбца",
						ColumnBrush = Brushes.Green,
						BoardName = "Название доски"
					}
				}
			});
		}

		public static void SetControls(TaskControlViewModel taskViewModel) {
			CheckDesignMode();

			taskViewModel.TaskModel = new TaskModel {
				Header = "Задача №1",
				Description = "Описание",
				Branch = "Ветка",
				State = State.NoState,
				Priority = Priority.NoPriority,
				CreateDateTime = DateTime.Now,
				DeveloperName = "Имя разработчика",
				ReviewerName = "Имя ревьюера",
				ColumnHeader = "Заголовок столбца",
				ColumnBrush = Brushes.Green,
				BoardName = "Название доски"
			};
		}

		private static void CheckDesignMode() {
			if (!ViewModelBase.IsInDesignModeStatic)
				throw new NotImplementedException("Ошибочный вызов конструктора");
		}
	}
}
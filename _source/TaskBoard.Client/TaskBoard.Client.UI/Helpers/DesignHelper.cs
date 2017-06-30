using System;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using TaskBoard.Client.UI.Extensions;
using TaskBoard.Client.UI.Models;
using TaskBoard.Client.UI.ViewModels;
using TaskBoard.Common.Enums;

namespace TaskBoard.Client.UI.Helpers {
	public static class DesignHelper {
		public static void SetControls(BoardViewModel boardViewModel) {
			CheckDesignMode();

			boardViewModel.CurrentBoardModel = new BoardModel {
				Name = "Название доски"
			};

			boardViewModel.ColumnViewModels.Reset(new[] {
				new ColumnViewModel { CurrentColumnModel = new ColumnModel { Header = "Первый столбец", Brush = Brushes.Green, BoardName = "Название доски" } },
				new ColumnViewModel { CurrentColumnModel = new ColumnModel { Header = "Второй столбец", Brush = Brushes.Blue, BoardName = "Название доски" } },
				new ColumnViewModel { CurrentColumnModel = new ColumnModel { Header = "Третий столбец", Brush = Brushes.Red, BoardName = "Название доски" } }
			});
		}

		public static void SetControls(ColumnViewModel columnViewModel) {
			CheckDesignMode();

			columnViewModel.CurrentColumnModel = new ColumnModel { Header = "Название столбца", Brush = Brushes.Blue, BoardName = "Название доски" };

			columnViewModel.TaskViewModels.Reset(new[] {
				new TaskViewModel {
					CurrentTaskModel = new TaskModel {
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

		public static void SetControls(TaskViewModel taskViewModel) {
			taskViewModel.CurrentTaskModel = new TaskModel {
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
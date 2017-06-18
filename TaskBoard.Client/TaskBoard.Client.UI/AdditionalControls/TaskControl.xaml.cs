﻿using System.Windows.Media;
using TaskBoard.Common.Tables;

namespace TaskBoard.Client.UI.AdditionalControls {
	public partial class TaskControl {
		public TaskControl(Task task, Brush taskControlBrush) {
			InitializeComponent();
			
			BorderBrush = taskControlBrush;
			TextBlockHeader.Text = "Это очень-очень-очень-очень-очень-очень-очень длинное название"; //task.Header;
			TextBlockDescription.Text = task.Description;
			LabelBranch.Content = task.Branch;
			LabelState.Content = task.State;
			LabelPriority.Content = task.Priority;
		}
	}
}

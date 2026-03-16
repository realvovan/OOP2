using lab3.BLL.DTOs;
using System.ComponentModel;

namespace lab3.PL;

public partial class TaskDisplay : UserControl {
	public static readonly Color BaseColor = SystemColors.ButtonHighlight;
	public static readonly Color ClickedColor = SystemColors.Info;
	public static readonly Dictionary<Domain.TaskStatus,string> TaskStatusText = new() {
		{ Domain.TaskStatus.NotStarted, "Not started" },
		{ Domain.TaskStatus.InProgress, "In progress" },
		{ Domain.TaskStatus.Completed, "Completed" },
	};

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public TaskItemDto TaskItem { get; set; }
	public TaskDisplay(TaskItemDto taskItem) {
		InitializeComponent();
		this.TaskItem = taskItem;
		this.TaskDescription.MaximumSize = new Size(this.Width,0);
	}
	public void UpdateFrameSize() {
		const int TEXT_MARGIN = 5;
		this.Height =
			this.OverdueLabel.Height
			+ this.TaskName.Height
			+ this.TaskDescription.Height + TEXT_MARGIN
			+ this.TimestampLabel.Height
			+ (this.DueLabel.Visible ? this.DueLabel.Height + TEXT_MARGIN : 0);
		this.TimestampLabel.Top = this.TaskDescription.Top + this.TaskDescription.Height + TEXT_MARGIN;
		this.DueLabel.Top = this.TimestampLabel.Top + this.TimestampLabel.Height;
		bool noPriority = string.IsNullOrWhiteSpace(this.PriorityLabel.Text);
		this.TaskName.Left = noPriority ? 0 : 16;
		this.PriorityLabel.Visible = !noPriority;
	}
	public void UpdateTextLabels() {
		this.TaskName.Text = this.TaskItem.Name;
		this.TaskDescription.Text = this.TaskItem.Description;
		this.PriorityLabel.Text = new string('!',Math.Clamp((int)this.TaskItem.Proirity,0,(int)Domain.TaskProirity.High));
		this.TaskStatusLabel.Text = TaskStatusText.GetValueOrDefault(this.TaskItem.Status,string.Empty);
		this.TimestampLabel.Text = $"Created on {_getFormattedDate(this.TaskItem.CreatedAt)}";
		if (this.TaskItem.DueTime is null) {
			this.DueLabel.Visible = false;
			this.OverdueLabel.Visible = false;
		} else {
			this.DueLabel.Visible = true;
			this.DueLabel.Text = $"Due: {_getFormattedDate(this.TaskItem.DueTime.Value)}";
			this.OverdueLabel.Visible = this.TaskItem.Status != Domain.TaskStatus.Completed && this.TaskItem.DueTime < DateTime.Now;
		}
		this.UpdateFrameSize();
	}
	public void Remove() {
		this.Parent?.Controls.Remove(this);
		this.Dispose();
	}
	public void Remove(EventHandler clickEventHandler) {
		this.UnsubscribeFromClickEvent(clickEventHandler);
		this.Remove();
	}
	public void SubscribeToClickEvent(EventHandler handler) {
		this.Click += handler;
		this.TaskName.Click += handler;
		this.TaskDescription.Click += handler;
	}
	public void UnsubscribeFromClickEvent(EventHandler handler) {
		this.Click -= handler;
		this.TaskName.Click -= handler;
		this.TaskDescription.Click -= handler;
	}

	private static string _getFormattedDate(DateTime date) => date.ToString("dd/MM/yyyy HH:mm");
}

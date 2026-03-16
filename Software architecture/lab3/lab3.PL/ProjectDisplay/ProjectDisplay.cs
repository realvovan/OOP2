namespace lab3.PL;

public partial class ProjectDisplay : UserControl {
	public const int BASE_HEIGHT = 23;
	public const int BASE_WIDTH = 194;
	public static readonly Color OPEN_COLOR = SystemColors.Info;
	public static readonly Color CLOSED_COLOR = SystemColors.Control;

	public readonly Guid ProjectId;
	public ProjectDisplay(Guid projectId) {
		InitializeComponent();
		this.BackColor = CLOSED_COLOR;
		this.Height = BASE_HEIGHT;
		this.ProjectDescription.MaximumSize = new Size(this.Width,0);
		this.ProjectId = projectId;
	}
	public void SetTitle(string title) => this.ProjectName.Text = title;
	public void SetDescription(string description) => this.ProjectDescription.Text = description;
	public void SetSelectionState(bool state) {
		if (state) {
			if (string.IsNullOrWhiteSpace(this.ProjectDescription.Text)) {
				this.Height = BASE_HEIGHT;
			} else {
				const int MARGIN = 10;
				this.Height = BASE_HEIGHT + this.ProjectDescription.Height + MARGIN;
			}
				this.BackColor = OPEN_COLOR;
			this.ProjectName.Font = new Font(this.ProjectName.Font,FontStyle.Bold);
		} else {
			this.Height = BASE_HEIGHT;
			this.BackColor = CLOSED_COLOR;
			this.ProjectName.Font = new Font(this.ProjectName.Font,FontStyle.Regular);
		}
	}
}

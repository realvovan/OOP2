using Coursework.PresentationLevel.Values;

namespace Coursework.PresentationLevel;

/// <summary>
/// Window allows to view full info about a client with a set <see cref="clientGuid"/> and to open the editing window
/// </summary>
public partial class ClientInfoWindow : Form {
	MainWindow context;
	Guid clientGuid;

	GuidLabel? selected;
	public ClientInfoWindow(MainWindow context,Guid clientGuid) {
		InitializeComponent();
		this.context = context;
		this.clientGuid = clientGuid;
		this.CancelButton = this.DoneButton;
		this.AcceptButton = this.DoneButton;

		var entity = context.clientService.GetEntityInfo(clientGuid);
		if (entity == null) {
			MessageBox.Show(
				text: "Something went wrong! Couldn't find information about this object",
				caption: "Oops!",
				buttons: MessageBoxButtons.OK,
				icon: MessageBoxIcon.Warning
			);
			this.Close();
			return;
		}
		this.Title.Text = $"{entity.FirstName} {entity.LastName}";
		this.FirstLabel.Text = entity.FirstName;
		this.LastLabel.Text = entity.LastName;
		this.EmailLabel.Text = entity.Email;
		this.PhoneNumLabel.Text = entity.PhoneNumber;
		this.PassportLabel.Text = entity.PassportNumber;
		this.IbanLabel.Text = entity.IBAN;
		this.PriceLabel.Text = entity.DesiredPrice.ToString() + '$';
		this.RoomsLabel.Text = entity.DesiredRoomCount.ToString();
		this.CreatedAtLabel.Text = entity.CreatedAt?.ToString() ?? "N/A";

		// tool tips on hover for email and iban because they are too long
		this.Tooltip.SetToolTip(this.EmailLabel,this.EmailLabel.Text);
		this.Tooltip.SetToolTip(this.IbanLabel,this.IbanLabel.Text);

		try {
			this.PictureBox.Image =
				string.IsNullOrWhiteSpace(entity.PhotoFilePath)
				? Images.ClientImagePlaceholder
				: new Bitmap(entity.PhotoFilePath);
		} catch {
			this.PictureBox.Image = Images.ErrorImage;
		}

		foreach (Guid i in entity.SuggestedRealEstates) {
			var estate = this.context.estateService.GetEntityInfo(i);
			var label = new GuidLabel(guid: i) {
				Text = estate?.ToString() ?? "Invalid real estate",
				AutoSize = false,
				Font = new Font("Segoe UI",12f),
				Size = new Size(372,22),
				BackColor = Colors.EntityLabel,
				ForeColor = Colors.EntityLabelText,
			};

			label.Click += (sender,e) => {
				var label = (sender as GuidLabel)!;
				if (this.selected != null) {
					this.selected.BackColor = Colors.EntityLabel;
					this.selected.ForeColor = Colors.EntityLabelText;
					this.selected.Font = new Font(this.selected.Font,FontStyle.Regular);
				}
				this.selected = label;
				label.BackColor = Colors.EntityLabelSelected;
				label.ForeColor = Colors.EntityLabelTextSelected;
				label.Font = new Font(label.Font,FontStyle.Bold);
			};
			label.DoubleClick += (sender,e) => {
				// opens full info viewer
				var label = (sender as GuidLabel)!;
				if (!this.context.estateService.EntityExists(label.Guid)) return;
				using var infoWin = new RealEstateInfoWindow(this.context.estateService,label.Guid,allowEdit: false);
				infoWin.ShowDialog();
			};

			this.SuggestionsList.Controls.Add(label);
		}
	}

	void DoneButton_Click(object sender,EventArgs e) {
		this.Close();
	}
	void EditButton_Click(object sender,EventArgs e) {
		if (!this.EditButton.Enabled) return;
		using var editWin = new ClientCreateWindow(
			CreateWindowOpenModes.Edit,
			this.context,
			this.clientGuid
		) { Location = this.Location };
		this.Hide();
		editWin.ShowDialog();
		this.Close();
	}
}
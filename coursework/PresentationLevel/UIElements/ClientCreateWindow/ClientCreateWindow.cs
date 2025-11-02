using Coursework.BusinessLevel.DTOs;
using Coursework.BusinessLevel;
using Coursework.Commons.Validators;
using Coursework.PresentationLevel.Values;
using Coursework.BusinessLevel.Services;

namespace Coursework.PresentationLevel;

/// <summary>
/// Window allows to create or edit an exiting client
/// </summary>
public partial class ClientCreateWindow : Form {
	string photoPath = string.Empty;
	CreateWindowOpenModes mode;
	MainWindow context;
	GuidLabel? selected;
	Guid? objectGuid;
	public ClientCreateWindow(CreateWindowOpenModes openMode,MainWindow context,Guid? objectGuid = null) {
		InitializeComponent();
		this.mode = openMode;
		this.context = context;
		this.objectGuid = objectGuid;
		this.CancelButton = this.CancelBut;

		if (mode == CreateWindowOpenModes.AddNew) {
			this.AddSuggestionButton.Enabled = false;
			this.RemoveSuggestionButton.Enabled = false;
			this.Title.Text = "Add new client";
			this.SuggestionsLabel.Text = "Add the client first, before adding suggestions";
			this.AddButton.Text = "Add";
			this.PictureBox.Image = Images.ClientImagePlaceholder;
		} else {
			void showInvalidGuidMessage() {
				MessageBox.Show(
					text: "Invalid entity Guid",
					caption: "Couldn't load entity",
					buttons: MessageBoxButtons.OK,
					icon: MessageBoxIcon.Warning
				);
			}
			if (objectGuid == null) {
				showInvalidGuidMessage();
				this.Close();
				return;
			}
			var entity = context.clientService.GetEntityInfo(objectGuid.Value);
			if (entity == null) {
				showInvalidGuidMessage();
				this.Close();
				return;
			}
			this.AddSuggestionButton.Enabled = entity.SuggestedRealEstates.Count < ClientService.MAX_SUGGESTIONS;
			this.RemoveSuggestionButton.Enabled = false;
			this.AddButton.Text = "Save";
			this.SuggestionsLabel.Text = $"Real estate suggestions {entity.SuggestedRealEstates.Count}/{ClientService.MAX_SUGGESTIONS}";
			this.Title.Text = $"{entity.FirstName} {entity.LastName}";
			this.FirstBox.Text = entity.FirstName;
			this.LastBox.Text = entity.LastName;
			this.EmailBox.Text = entity.Email;
			this.PhoneBox.Text = entity.PhoneNumber;
			this.PassportBox.Text = entity.PassportNumber;
			this.IbanBox.Text = entity.IBAN;
			this.PriceBox.Text = entity.DesiredPrice.ToString();
			this.RoomCountBox.Text = entity.DesiredRoomCount.ToString();
			this.photoPath = entity.PhotoFilePath;

			// adds suggestion labels
			foreach (Guid i in entity.SuggestedRealEstates) {
				var estate = this.context.estateService.GetEntityInfo(i);
				var label = new GuidLabel(guid: i) {
					Text = estate?.ToString() ?? "Invalid real estate",
					AutoSize = false,
					Font = new Font("Segoe UI",12f),
					Size = new Size(228,22),
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
					this.RemoveSuggestionButton.Enabled = true;
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

			try {
				this.PictureBox.Image =
					string.IsNullOrWhiteSpace(entity.PhotoFilePath)
					? Images.ClientImagePlaceholder
					: new Bitmap(entity.PhotoFilePath);
			} catch {
				this.PictureBox.Image = Images.ErrorImage;
			}
		}
		foreach (Control control in this.Controls) {
			if (control is TextBox textBox) {
				switch (textBox.Name) {
					case "FirstBox":
					case "LastBox":
						textBox.KeyPress += nameBoxChanged;
						break;
					case "PhoneBox":
						textBox.KeyPress += phoneBoxChanged;
						break;
					case "PriceBox":
						textBox.KeyPress += priceBoxChanged;
						break;
					case "RoomCountBox":
						textBox.KeyPress += roomsBoxChanged;
						break;
				}
			}
		}
	}

	#region Text box event handlers
	void nameBoxChanged(object? sender,KeyPressEventArgs e) {
		if (sender is not TextBox textBox) return;
		if (e.KeyChar == '\b') return;
		e.Handled = !ClientValidator.ValidateName(textBox.Text + e.KeyChar);
	}
	void phoneBoxChanged(object? sender,KeyPressEventArgs e) {
		if (sender is not TextBox textBox) return;
		if (e.KeyChar == '\b') return;
		e.Handled = e.KeyChar != '+' && !int.TryParse(e.KeyChar.ToString(),out int _);
	}
	void priceBoxChanged(object? sender,KeyPressEventArgs e) {
		if (sender is not TextBox textBox) return;
		if (e.KeyChar == '\b') return;
		string newText = textBox.Text + e.KeyChar;
		e.Handled = !double.TryParse(newText,out double num) || !RealEstateValidators.ValidatePrice(num);
	}
	void roomsBoxChanged(object? sender,KeyPressEventArgs e) {
		if (sender is not TextBox textBox) return;
		if (e.KeyChar == '\b') return;
		string newText = textBox.Text + e.KeyChar;
		e.Handled = !byte.TryParse(newText,out byte num) || !RealEstateValidators.ValidateRoomNumber(num);
	}
	#endregion

	void CancelBut_Click(object sender,EventArgs e) {
		this.Close();
	}
	void AddButton_Click(object sender,EventArgs e) {
		void showMessageBox(string message) {
			MessageBox.Show(
				text: message,
				caption: "Oops...",
				MessageBoxButtons.OK,
				MessageBoxIcon.Warning
			);
		}
		// make sure all the fields are filled out
		foreach (Control control in this.Controls) {
			if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text)) {
				this.ActiveControl = control;
				showMessageBox($"Can't leave {textBox.PlaceholderText} field empty!");
				return;
			}
		}
		// try parsing the number fields
		if (!double.TryParse(this.PriceBox.Text,out double price)) {
			showMessageBox("Please enter a valid price!");
			return;
		}
		if (!byte.TryParse(this.RoomCountBox.Text,out byte rCount)) {
			showMessageBox("Please enter a valid room count!");
			return;
		}
		// creating dto to pass it to the service
		var dto = new ClientDTO(
			this.FirstBox.Text,
			this.LastBox.Text,
			this.EmailBox.Text,
			this.PhoneBox.Text,
			this.PassportBox.Text,
			this.IbanBox.Text,
			price,
			rCount,
			this.photoPath,
			// gets suggestions list or sets it to an empty list
			this.context.clientService.GetEntityInfo(this.objectGuid ?? new Guid())?.SuggestedRealEstates ?? [],
			guid: this.objectGuid
		);

		Result result;
		if (this.mode == CreateWindowOpenModes.AddNew) {
			result = this.context.clientService.AddEntity(dto);
		} else {
			result = this.context.clientService.UpdateEntity(dto);
		}

		if (result.Success) {
			this.Close();
		} else {
			showMessageBox(result.Message);
		}
	}
	void PictureBox_Click(object sender,EventArgs e) {
		var result = this.OpenFileDialog.ShowDialog();
		if (result == DialogResult.Cancel) return;
		this.photoPath = this.OpenFileDialog.FileName;
		try {
			this.PictureBox.Image = new Bitmap(this.photoPath);
		} catch (Exception ex) {
			this.PictureBox.Image = Images.ErrorImage;
			MessageBox.Show(
				text: $"Invalid image: {ex.Message}",
				caption: "Oops!",
				buttons: MessageBoxButtons.OK,
				icon: MessageBoxIcon.Information
			);
		}
	}
	void PictureBox_MouseEnter(object sender,EventArgs e) {
		if (this.photoPath == string.Empty) return;
		int size = 25;
		var button = new Label() {
			Text = "X",
			Font = new Font("Segoe UI",13f,FontStyle.Bold),
			ForeColor = Colors.XButtonText,
			BackColor = Colors.XButton,
			AutoSize = false,
			ClientSize = new Size(size,size),
			Location = new Point(
				this.PictureBox.Width - size,
				0
			)
		};
		button.MouseEnter += (sender,e) => {
			var button = (sender as Label)!;
			button.BackColor = Colors.XButtonHover;
		};
		button.MouseLeave += (sender,e) => {
			var button = (sender as Label)!;
			button.BackColor = Colors.XButton;
		};
		button.MouseClick += (sender,e) => {
			var button = (sender as Label)!;
			this.photoPath = string.Empty;
			this.PictureBox.Image = Images.ClientImagePlaceholder;
			button.Dispose();
		};
		this.PictureBox.Controls.Add(button);
	}
	void ClientCreateWindow_MouseEnter(object sender,EventArgs e) {
		this.PictureBox.Controls.Clear();
	}
	void AddSuggestionButton_Click(object sender,EventArgs e) {
		if (this.context.estateService.Count == 0) {
			MessageBox.Show(
				caption:"Oops!",
				text:"There are no real estates!",
				icon:MessageBoxIcon.Warning,
				buttons:MessageBoxButtons.OK
			);
			return;
		}
		if (this.mode == CreateWindowOpenModes.AddNew) return;
		this.context.viewMode = ViewMode.Suggestions;
		this.context.suggestionModeClient = this.objectGuid;
		this.Close();
	}
	void RemoveSuggestionButton_Click(object sender,EventArgs e) {
		if (this.selected == null || this.objectGuid == null) return;
		var result = this.context.clientService.RemoveSuggestion(this.objectGuid.Value,this.selected.Guid);
		int newSuggestionsCount = this.context.clientService.GetNumberOfSuggestions(this.objectGuid.Value);
		if (!result.Success) {
			MessageBox.Show(
				caption:"Oops!",
				text:result.Message,
				buttons:MessageBoxButtons.OK,
				icon:MessageBoxIcon.Warning
			);
		}
		this.selected.Dispose();
		this.selected = null;
		this.RemoveSuggestionButton.Enabled = false;
		this.AddSuggestionButton.Enabled = newSuggestionsCount < ClientService.MAX_SUGGESTIONS;
		this.SuggestionsLabel.Text = $"Real estate suggestions {newSuggestionsCount} / {ClientService.MAX_SUGGESTIONS}";
	}

	protected override void OnShown(EventArgs e) {
		base.OnShown(e);
		this.ActiveControl = null; // removes focus from text boxes when the window opens
	}
}

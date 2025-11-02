using Coursework.PresentationLevel.Values;
using Coursework.Commons.Validators;
using Coursework.BusinessLevel.Services;
using Coursework.BusinessLevel;
using Coursework.BusinessLevel.DTOs;
using Coursework.Commons.Enums;

namespace Coursework.PresentationLevel;

/// <summary>
/// Window allows to create or edit an existing real estate object
/// </summary>
public partial class RealEstateCreateWindow : Form {
	string photoPath = string.Empty;
	CreateWindowOpenModes mode;
	RealEstateService service;
	Guid? openedObjectGuid;
	public RealEstateCreateWindow(CreateWindowOpenModes openMode,RealEstateService service,Guid? guid = null) {
		InitializeComponent();
		this.mode = openMode;
		this.service = service;
		this.openedObjectGuid = guid;
		this.CancelButton = this.CancelBut;
		if (openMode == CreateWindowOpenModes.AddNew) {
			// window was opened to create a new entity
			this.Title.Text = "Add new real estate";
			this.AddButton.Text = "Add";
			this.PictureBox.Image = Images.RealEstateImagePlaceholder;
		} else {
			// window was opened to edit current entity
			void showInvalidGuidMessage() {
				MessageBox.Show(
					text: "Invalid entity Guid",
					caption: "Couldn't load entity",
					buttons: MessageBoxButtons.OK,
					icon: MessageBoxIcon.Warning
				);
			}
			if (guid == null) {
				showInvalidGuidMessage();
				this.Close();
				return;
			}
			var entity = service.GetEntityInfo(guid.Value);
			if (entity == null) {
				showInvalidGuidMessage();
				this.Close();
				return;
			}
			this.Title.Text = "Edit real estate";
			this.AddButton.Text = "Save";
			this.CountryBox.Text = entity.Country;
			this.ProvinceBox.Text = entity.Provice;
			this.CityBox.Text = entity.City;
			this.StreetBox.Text = entity.Street;
			this.HouseNumBox.Text = entity.HouseNumber;
			this.ZipBox.Text = entity.Zip;
			this.PriceBox.Text = entity.Price.ToString();
			this.RoomCountBox.Text = entity.RoomCount.ToString();
			this.photoPath = entity.PhotoFilePath;
			if (entity.Type == RealEstateType.Apartment) this.ApartmentButton.Select();
			else this.HouseButton.Select();
			try {
				this.PictureBox.Image =
					string.IsNullOrWhiteSpace(entity.PhotoFilePath)
					? Images.RealEstateImagePlaceholder
					: new Bitmap(entity.PhotoFilePath);
			} catch {
				this.PictureBox.Image = Images.ErrorImage;
			}
		}

		// listening to text box changes
		foreach (Control control in this.Controls) {
			if (control is TextBox textBox) {
				switch (textBox.Name) {
					case "CountryBox":
					case "ProvinceBox":
					case "CityBox":
					case "StreetBox":
						textBox.KeyPress += addressBoxChanged;
						break;
					case "HouseNumBox":
						textBox.KeyPress += houseNumBoxChanged;
						break;
					case "ZipBox":
						textBox.KeyPress += zipBoxChanged;
						break;
					case "PriceBox":
						textBox.KeyPress += priceBoxChanged;
						break;
					case "RoomCountBox":
						textBox.KeyPress += roomCountBoxChanged;
						break;
				}
			}
		}
	}
	#region Text box event handlers
	void addressBoxChanged(object? sender,KeyPressEventArgs e) {
		if (sender is not TextBox textBox) return;
		if (e.KeyChar == '\b') return;
		e.Handled = !RealEstateValidators.ValidateAddress(textBox.Text + e.KeyChar);
	}
	void houseNumBoxChanged(object? sender,KeyPressEventArgs e) {
		if (sender is not TextBox textBox) return;
		if (e.KeyChar == '\b') return;
		e.Handled = !RealEstateValidators.ValidateHouseNumber(textBox.Text + e.KeyChar);
	}
	void zipBoxChanged(object? sender,KeyPressEventArgs e) {
		if (sender is not TextBox textBox) return;
		if (e.KeyChar == '\b') return;
		string newText = textBox.Text + e.KeyChar;
		e.Handled = newText.Length > 4 && !RealEstateValidators.ValidateZip(newText);
	}
	void priceBoxChanged(object? sender,KeyPressEventArgs e) {
		if (sender is not TextBox textBox) return;
		if (e.KeyChar == '\b') return;
		string newText = textBox.Text + e.KeyChar;
		e.Handled = !double.TryParse(newText,out double num) || !RealEstateValidators.ValidatePrice(num);
	}
	void roomCountBoxChanged(object? sender,KeyPressEventArgs e) {
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
		var dto = new RealEstateDTO(
			this.CountryBox.Text,
			this.ProvinceBox.Text,
			this.CityBox.Text,
			this.StreetBox.Text,
			this.HouseNumBox.Text,
			this.ZipBox.Text,
			price,
			rCount,
			this.photoPath,
			this.ApartmentButton.Checked ? RealEstateType.Apartment : RealEstateType.House,
			guid: this.openedObjectGuid
		);

		Result result;
		if (this.mode == CreateWindowOpenModes.AddNew) {
			result = this.service.AddEntity(dto);
		} else {
			result = this.service.UpdateEntity(dto);
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
			this.PictureBox.Image = Images.RealEstateImagePlaceholder;
			button.Dispose();
		};
		this.PictureBox.Controls.Add(button);
	}
	void RealEstateCreateWindow_MouseEnter(object sender,EventArgs e) {
		this.PictureBox.Controls.Clear();
	}

	protected override void OnShown(EventArgs e) {
		base.OnShown(e);
		this.ActiveControl = null; // removes focus from text boxes when the window opens
	}
}
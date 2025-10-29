using Coursework.BusinessLevel.Services;
using Coursework.PresentationLevel.Values;

namespace Coursework.PresentationLevel;

public partial class RealEstateInfoWindow : Form {
	RealEstateService service;
	Guid objectGuid;
	public RealEstateInfoWindow(RealEstateService service,Guid guid) {
		InitializeComponent();
		this.service = service;
		this.objectGuid = guid;
		this.CancelButton = this.DoneButton;
		this.AcceptButton = this.DoneButton;

		var entity = service.GetEntityInfo(objectGuid);
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
		this.CountryLabel.Text = entity.Country;
		this.ProvinceLabel.Text = entity.Provice;
		this.CityLabel.Text = entity.City;
		this.StreetLabel.Text = entity.Street;
		this.HouseNumLabel.Text = entity.HouseNumber;
		this.ZipLabel.Text = entity.Zip;
		this.PriceLabel.Text = entity.Price.ToString();
		this.RoomCountLabel.Text = entity.RoomCount.ToString();
		this.TypeLabel.Text = entity.Type.ToString();
		this.CreatedOnLabel.Text = entity.CreatedAt?.ToString() ?? "N/A";
		if (entity.PhotoFilePath == string.Empty) {
			this.PictureBox.Image = Images.RealEstateImagePlaceholder;
		} else {
			try {
				this.PictureBox.Image = new Bitmap(entity.PhotoFilePath);
			} catch {
				this.PictureBox.Image = Images.ErrorImage;
			}
		}
	}
	void DoneButton_Click(object sender,EventArgs e) {
		this.Close();
	}
	void EditButton_Click(object sender,EventArgs e) {
		using var editWin = new RealEstateCreateWindow(
			CreateWindowOpenModes.Edit,
			this.service,
			this.objectGuid
		) { Location = this.Location };
		this.Hide();
		editWin.ShowDialog();
		this.Close();
	}
}

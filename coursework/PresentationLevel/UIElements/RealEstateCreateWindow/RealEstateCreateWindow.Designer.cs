namespace Coursework.PresentationLevel {
	partial class RealEstateCreateWindow {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.PictureBox = new PictureBox();
			this.Title = new Label();
			this.CountryBox = new TextBox();
			this.ProvinceBox = new TextBox();
			this.CityBox = new TextBox();
			this.StreetBox = new TextBox();
			this.HouseNumBox = new TextBox();
			this.ZipBox = new TextBox();
			this.PriceBox = new TextBox();
			this.RoomCountBox = new TextBox();
			this.AddButton = new Button();
			this.CancelBut = new Button();
			this.ApartmentButton = new RadioButton();
			this.HouseButton = new RadioButton();
			this.label2 = new Label();
			this.OpenFileDialog = new OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)this.PictureBox).BeginInit();
			this.SuspendLayout();
			// 
			// PictureBox
			// 
			this.PictureBox.BackColor = SystemColors.ControlDarkDark;
			this.PictureBox.BackgroundImageLayout = ImageLayout.Stretch;
			this.PictureBox.Cursor = Cursors.Hand;
			this.PictureBox.ImageLocation = "";
			this.PictureBox.Location = new Point(12,55);
			this.PictureBox.Name = "PictureBox";
			this.PictureBox.Size = new Size(175,233);
			this.PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.PictureBox.TabIndex = 0;
			this.PictureBox.TabStop = false;
			this.PictureBox.Click += this.PictureBox_Click;
			this.PictureBox.MouseEnter += this.PictureBox_MouseEnter;
			// 
			// Title
			// 
			this.Title.AutoSize = true;
			this.Title.Font = new Font("Segoe UI",20F,FontStyle.Bold);
			this.Title.Location = new Point(12,9);
			this.Title.Name = "Title";
			this.Title.Size = new Size(272,37);
			this.Title.TabIndex = 1;
			this.Title.Text = "Add new real estate";
			// 
			// CountryBox
			// 
			this.CountryBox.Font = new Font("Segoe UI",12F);
			this.CountryBox.Location = new Point(202,55);
			this.CountryBox.Name = "CountryBox";
			this.CountryBox.PlaceholderText = "Country";
			this.CountryBox.Size = new Size(200,29);
			this.CountryBox.TabIndex = 2;
			// 
			// ProvinceBox
			// 
			this.ProvinceBox.Font = new Font("Segoe UI",12F);
			this.ProvinceBox.Location = new Point(202,90);
			this.ProvinceBox.Name = "ProvinceBox";
			this.ProvinceBox.PlaceholderText = "Province";
			this.ProvinceBox.Size = new Size(200,29);
			this.ProvinceBox.TabIndex = 3;
			// 
			// CityBox
			// 
			this.CityBox.Font = new Font("Segoe UI",12F);
			this.CityBox.Location = new Point(202,125);
			this.CityBox.Name = "CityBox";
			this.CityBox.PlaceholderText = "City";
			this.CityBox.Size = new Size(200,29);
			this.CityBox.TabIndex = 4;
			// 
			// StreetBox
			// 
			this.StreetBox.Font = new Font("Segoe UI",12F);
			this.StreetBox.Location = new Point(202,160);
			this.StreetBox.Name = "StreetBox";
			this.StreetBox.PlaceholderText = "Street";
			this.StreetBox.Size = new Size(200,29);
			this.StreetBox.TabIndex = 5;
			// 
			// HouseNumBox
			// 
			this.HouseNumBox.Font = new Font("Segoe UI",12F);
			this.HouseNumBox.Location = new Point(202,195);
			this.HouseNumBox.Name = "HouseNumBox";
			this.HouseNumBox.PlaceholderText = "House number";
			this.HouseNumBox.Size = new Size(200,29);
			this.HouseNumBox.TabIndex = 6;
			// 
			// ZipBox
			// 
			this.ZipBox.Font = new Font("Segoe UI",12F);
			this.ZipBox.Location = new Point(202,230);
			this.ZipBox.Name = "ZipBox";
			this.ZipBox.PlaceholderText = "Postal code";
			this.ZipBox.Size = new Size(200,29);
			this.ZipBox.TabIndex = 7;
			// 
			// PriceBox
			// 
			this.PriceBox.Font = new Font("Segoe UI",12F);
			this.PriceBox.Location = new Point(202,265);
			this.PriceBox.Name = "PriceBox";
			this.PriceBox.PlaceholderText = "Price";
			this.PriceBox.Size = new Size(89,29);
			this.PriceBox.TabIndex = 8;
			// 
			// RoomCountBox
			// 
			this.RoomCountBox.Font = new Font("Segoe UI",12F);
			this.RoomCountBox.Location = new Point(297,265);
			this.RoomCountBox.Name = "RoomCountBox";
			this.RoomCountBox.PlaceholderText = "Room count";
			this.RoomCountBox.Size = new Size(105,29);
			this.RoomCountBox.TabIndex = 9;
			// 
			// AddButton
			// 
			this.AddButton.Font = new Font("Segoe UI",12F);
			this.AddButton.Location = new Point(204,367);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new Size(96,32);
			this.AddButton.TabIndex = 10;
			this.AddButton.Text = "Add";
			this.AddButton.UseVisualStyleBackColor = true;
			this.AddButton.Click += this.AddButton_Click;
			// 
			// CancelBut
			// 
			this.CancelBut.Font = new Font("Segoe UI",12F);
			this.CancelBut.Location = new Point(306,367);
			this.CancelBut.Name = "CancelBut";
			this.CancelBut.Size = new Size(96,32);
			this.CancelBut.TabIndex = 11;
			this.CancelBut.Text = "Cancel";
			this.CancelBut.UseVisualStyleBackColor = true;
			this.CancelBut.Click += this.CancelBut_Click;
			// 
			// ApartmentButton
			// 
			this.ApartmentButton.AutoSize = true;
			this.ApartmentButton.Checked = true;
			this.ApartmentButton.Font = new Font("Segoe UI",12F);
			this.ApartmentButton.Location = new Point(173,300);
			this.ApartmentButton.Name = "ApartmentButton";
			this.ApartmentButton.Size = new Size(102,25);
			this.ApartmentButton.TabIndex = 12;
			this.ApartmentButton.TabStop = true;
			this.ApartmentButton.Text = "Apartment";
			this.ApartmentButton.UseVisualStyleBackColor = true;
			// 
			// HouseButton
			// 
			this.HouseButton.AutoSize = true;
			this.HouseButton.Font = new Font("Segoe UI",12F);
			this.HouseButton.Location = new Point(281,300);
			this.HouseButton.Name = "HouseButton";
			this.HouseButton.Size = new Size(72,25);
			this.HouseButton.TabIndex = 13;
			this.HouseButton.TabStop = true;
			this.HouseButton.Text = "House";
			this.HouseButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Segoe UI",14F);
			this.label2.Location = new Point(12,299);
			this.label2.Name = "label2";
			this.label2.Size = new Size(147,25);
			this.label2.TabIndex = 14;
			this.label2.Text = "Real estate type:";
			// 
			// RealEstateCreateWindow
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(414,411);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.HouseButton);
			this.Controls.Add(this.ApartmentButton);
			this.Controls.Add(this.CancelBut);
			this.Controls.Add(this.AddButton);
			this.Controls.Add(this.RoomCountBox);
			this.Controls.Add(this.PriceBox);
			this.Controls.Add(this.ZipBox);
			this.Controls.Add(this.HouseNumBox);
			this.Controls.Add(this.StreetBox);
			this.Controls.Add(this.CityBox);
			this.Controls.Add(this.ProvinceBox);
			this.Controls.Add(this.CountryBox);
			this.Controls.Add(this.Title);
			this.Controls.Add(this.PictureBox);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RealEstateCreateWindow";
			this.ShowInTaskbar = false;
			this.Text = "Real estate editor";
			this.MouseEnter += this.RealEstateCreateWindow_MouseEnter;
			((System.ComponentModel.ISupportInitialize)this.PictureBox).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private PictureBox PictureBox;
		private Label Title;
		private TextBox CountryBox;
		private TextBox ProvinceBox;
		private TextBox CityBox;
		private TextBox StreetBox;
		private TextBox HouseNumBox;
		private TextBox ZipBox;
		private TextBox PriceBox;
		private TextBox RoomCountBox;
		private Button AddButton;
		private Button CancelBut;
		private RadioButton ApartmentButton;
		private RadioButton HouseButton;
		private Label label2;
		private OpenFileDialog OpenFileDialog;
	}
}
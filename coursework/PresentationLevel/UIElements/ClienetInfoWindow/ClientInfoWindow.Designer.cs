namespace Coursework.PresentationLevel {
	partial class ClientInfoWindow {
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
			this.components = new System.ComponentModel.Container();
			this.Title = new Label();
			this.PictureBox = new PictureBox();
			this.label1 = new Label();
			this.label2 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label5 = new Label();
			this.FirstLabel = new Label();
			this.LastLabel = new Label();
			this.EmailLabel = new Label();
			this.PhoneNumLabel = new Label();
			this.PassportLabel = new Label();
			this.label6 = new Label();
			this.IbanLabel = new Label();
			this.label7 = new Label();
			this.PriceLabel = new Label();
			this.label8 = new Label();
			this.RoomsLabel = new Label();
			this.label9 = new Label();
			this.SuggestionsList = new FlowLayoutPanel();
			this.EditButton = new Button();
			this.DoneButton = new Button();
			this.label10 = new Label();
			this.CreatedAtLabel = new Label();
			this.Tooltip = new ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)this.PictureBox).BeginInit();
			this.SuspendLayout();
			// 
			// Title
			// 
			this.Title.AutoSize = true;
			this.Title.Font = new Font("Segoe UI",20F,FontStyle.Bold);
			this.Title.Location = new Point(12,9);
			this.Title.Name = "Title";
			this.Title.Size = new Size(288,37);
			this.Title.TabIndex = 3;
			this.Title.Text = "First name Last name";
			// 
			// PictureBox
			// 
			this.PictureBox.BackColor = SystemColors.ControlDarkDark;
			this.PictureBox.BackgroundImageLayout = ImageLayout.Stretch;
			this.PictureBox.ImageLocation = "";
			this.PictureBox.Location = new Point(12,55);
			this.PictureBox.Name = "PictureBox";
			this.PictureBox.Size = new Size(175,233);
			this.PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.PictureBox.TabIndex = 4;
			this.PictureBox.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label1.Location = new Point(202,55);
			this.label1.Name = "label1";
			this.label1.Size = new Size(93,21);
			this.label1.TabIndex = 5;
			this.label1.Text = "First name:";
			this.label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label2.Location = new Point(202,80);
			this.label2.Name = "label2";
			this.label2.Size = new Size(91,21);
			this.label2.TabIndex = 6;
			this.label2.Text = "Last name:";
			this.label2.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label3.Location = new Point(202,105);
			this.label3.Name = "label3";
			this.label3.Size = new Size(57,21);
			this.label3.TabIndex = 7;
			this.label3.Text = "Email:";
			this.label3.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label4.Location = new Point(202,147);
			this.label4.Name = "label4";
			this.label4.Size = new Size(128,21);
			this.label4.TabIndex = 8;
			this.label4.Text = "Phone number:";
			this.label4.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label5.Location = new Point(202,197);
			this.label5.Name = "label5";
			this.label5.Size = new Size(144,21);
			this.label5.TabIndex = 9;
			this.label5.Text = "Passport number:";
			this.label5.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// FirstLabel
			// 
			this.FirstLabel.AutoSize = true;
			this.FirstLabel.Font = new Font("Segoe UI",12F);
			this.FirstLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.FirstLabel.Location = new Point(301,55);
			this.FirstLabel.Name = "FirstLabel";
			this.FirstLabel.Size = new Size(83,21);
			this.FirstLabel.TabIndex = 15;
			this.FirstLabel.Text = "First name";
			this.FirstLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// LastLabel
			// 
			this.LastLabel.AutoSize = true;
			this.LastLabel.Font = new Font("Segoe UI",12F);
			this.LastLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.LastLabel.Location = new Point(299,80);
			this.LastLabel.Name = "LastLabel";
			this.LastLabel.Size = new Size(81,21);
			this.LastLabel.TabIndex = 16;
			this.LastLabel.Text = "Last name";
			this.LastLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// EmailLabel
			// 
			this.EmailLabel.AutoSize = true;
			this.EmailLabel.Font = new Font("Segoe UI",12F);
			this.EmailLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.EmailLabel.Location = new Point(202,126);
			this.EmailLabel.Name = "EmailLabel";
			this.EmailLabel.Size = new Size(48,21);
			this.EmailLabel.TabIndex = 17;
			this.EmailLabel.Text = "Email";
			this.EmailLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// PhoneNumLabel
			// 
			this.PhoneNumLabel.AutoSize = true;
			this.PhoneNumLabel.Font = new Font("Segoe UI",12F);
			this.PhoneNumLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.PhoneNumLabel.Location = new Point(202,172);
			this.PhoneNumLabel.Name = "PhoneNumLabel";
			this.PhoneNumLabel.Size = new Size(113,21);
			this.PhoneNumLabel.TabIndex = 18;
			this.PhoneNumLabel.Text = "Phone number";
			this.PhoneNumLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// PassportLabel
			// 
			this.PassportLabel.AutoSize = true;
			this.PassportLabel.Font = new Font("Segoe UI",12F);
			this.PassportLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.PassportLabel.Location = new Point(202,222);
			this.PassportLabel.Name = "PassportLabel";
			this.PassportLabel.Size = new Size(128,21);
			this.PassportLabel.TabIndex = 19;
			this.PassportLabel.Text = "Passport number";
			this.PassportLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label6.Location = new Point(202,247);
			this.label6.Name = "label6";
			this.label6.Size = new Size(53,21);
			this.label6.TabIndex = 20;
			this.label6.Text = "IBAN:";
			this.label6.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// IbanLabel
			// 
			this.IbanLabel.AutoSize = true;
			this.IbanLabel.Font = new Font("Segoe UI",12F);
			this.IbanLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.IbanLabel.Location = new Point(202,272);
			this.IbanLabel.Name = "IbanLabel";
			this.IbanLabel.Size = new Size(193,21);
			this.IbanLabel.TabIndex = 21;
			this.IbanLabel.Text = "UA123456789123456789";
			this.IbanLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label7.Location = new Point(12,293);
			this.label7.Name = "label7";
			this.label7.Size = new Size(127,21);
			this.label7.TabIndex = 22;
			this.label7.Text = "Preferred price:";
			this.label7.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// PriceLabel
			// 
			this.PriceLabel.AutoSize = true;
			this.PriceLabel.Font = new Font("Segoe UI",12F);
			this.PriceLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.PriceLabel.Location = new Point(145,293);
			this.PriceLabel.Name = "PriceLabel";
			this.PriceLabel.Size = new Size(53,21);
			this.PriceLabel.TabIndex = 23;
			this.PriceLabel.Text = "price$";
			this.PriceLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label8.Location = new Point(12,320);
			this.label8.Name = "label8";
			this.label8.Size = new Size(178,21);
			this.label8.TabIndex = 24;
			this.label8.Text = "Preferred room count:";
			this.label8.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// RoomsLabel
			// 
			this.RoomsLabel.AutoSize = true;
			this.RoomsLabel.Font = new Font("Segoe UI",12F);
			this.RoomsLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.RoomsLabel.Location = new Point(196,320);
			this.RoomsLabel.Name = "RoomsLabel";
			this.RoomsLabel.Size = new Size(55,21);
			this.RoomsLabel.TabIndex = 25;
			this.RoomsLabel.Text = "rooms";
			this.RoomsLabel.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label9.Location = new Point(12,346);
			this.label9.Name = "label9";
			this.label9.Size = new Size(192,21);
			this.label9.TabIndex = 26;
			this.label9.Text = "Real estate suggestions:";
			this.label9.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// SuggestionsList
			// 
			this.SuggestionsList.AutoScroll = true;
			this.SuggestionsList.BackColor = SystemColors.ControlLight;
			this.SuggestionsList.FlowDirection = FlowDirection.TopDown;
			this.SuggestionsList.Location = new Point(16,376);
			this.SuggestionsList.Name = "SuggestionsList";
			this.SuggestionsList.Size = new Size(379,111);
			this.SuggestionsList.TabIndex = 27;
			this.SuggestionsList.WrapContents = false;
			// 
			// EditButton
			// 
			this.EditButton.Font = new Font("Segoe UI",12F);
			this.EditButton.Location = new Point(306,493);
			this.EditButton.Name = "EditButton";
			this.EditButton.Size = new Size(96,32);
			this.EditButton.TabIndex = 29;
			this.EditButton.Text = "Edit";
			this.EditButton.UseVisualStyleBackColor = true;
			this.EditButton.Click += this.EditButton_Click;
			// 
			// DoneButton
			// 
			this.DoneButton.Font = new Font("Segoe UI",12F);
			this.DoneButton.Location = new Point(204,493);
			this.DoneButton.Name = "DoneButton";
			this.DoneButton.Size = new Size(96,32);
			this.DoneButton.TabIndex = 28;
			this.DoneButton.Text = "Done";
			this.DoneButton.UseVisualStyleBackColor = true;
			this.DoneButton.Click += this.DoneButton_Click;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new Font("Segoe UI",12F,FontStyle.Bold);
			this.label10.Location = new Point(283,293);
			this.label10.Name = "label10";
			this.label10.Size = new Size(97,21);
			this.label10.TabIndex = 30;
			this.label10.Text = "Created on:";
			this.label10.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// CreatedAtLabel
			// 
			this.CreatedAtLabel.Font = new Font("Segoe UI",12F);
			this.CreatedAtLabel.ImageAlign = ContentAlignment.MiddleRight;
			this.CreatedAtLabel.Location = new Point(283,314);
			this.CreatedAtLabel.Name = "CreatedAtLabel";
			this.CreatedAtLabel.Size = new Size(119,59);
			this.CreatedAtLabel.TabIndex = 31;
			this.CreatedAtLabel.Text = "Date";
			// 
			// ClientInfoWindow
			// 
			this.AutoScaleDimensions = new SizeF(7F,15F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(414,533);
			this.Controls.Add(this.CreatedAtLabel);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.EditButton);
			this.Controls.Add(this.DoneButton);
			this.Controls.Add(this.SuggestionsList);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.RoomsLabel);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.PriceLabel);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.IbanLabel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.PassportLabel);
			this.Controls.Add(this.PhoneNumLabel);
			this.Controls.Add(this.EmailLabel);
			this.Controls.Add(this.LastLabel);
			this.Controls.Add(this.FirstLabel);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PictureBox);
			this.Controls.Add(this.Title);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ClientInfoWindow";
			this.ShowInTaskbar = false;
			this.Text = "Client info";
			((System.ComponentModel.ISupportInitialize)this.PictureBox).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		#endregion

		private Label Title;
		private PictureBox PictureBox;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label FirstLabel;
		private Label LastLabel;
		private Label EmailLabel;
		private Label PhoneNumLabel;
		private Label PassportLabel;
		private Label label6;
		private Label IbanLabel;
		private Label label7;
		private Label PriceLabel;
		private Label label8;
		private Label RoomsLabel;
		private Label label9;
		private FlowLayoutPanel SuggestionsList;
		private Button EditButton;
		private Button DoneButton;
		private Label label10;
		private Label CreatedAtLabel;
		private ToolTip Tooltip;
	}
}
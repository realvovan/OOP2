namespace Coursework.PresentationLevel; 
partial class MainWindow {
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
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
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
		this.panel1 = new Panel();
		this.button1 = new Button();
		this.SearchBox = new TextBox();
		this.FilterButton = new Button();
		this.LoadButton = new Button();
		this.SaveButton = new Button();
		this.CombinedView = new Button();
		this.EstateView = new Button();
		this.ClientsView = new Button();
		this.panel2 = new Panel();
		this.EditButton = new Button();
		this.InfoButton = new Button();
		this.RemoveButton = new Button();
		this.AddButton = new Button();
		this.EntityList = new FlowLayoutPanel();
		this.EmptyListLabel = new Label();
		this.SaveFileDialog = new SaveFileDialog();
		this.OpenFileDialog = new OpenFileDialog();
		this.EstateSortList = new RadioButtonGroup();
		this.EstateSortDescending = new RadioButton();
		this.EstateSortAscending = new RadioButton();
		this.EstateSortOrder = new Label();
		this.EstateSortOptions = new RadioButtonGroup();
		this.EstateSortDate = new RadioButton();
		this.EstateSortRooms = new RadioButton();
		this.EstateSortPrice = new RadioButton();
		this.EstateSortCountry = new RadioButton();
		this.EstateSortName = new RadioButton();
		this.EstateSearchList = new RadioButtonGroup();
		this.EstateSearchCountry = new CheckBox();
		this.checkBox1 = new CheckBox();
		this.checkBox2 = new CheckBox();
		this.checkBox3 = new CheckBox();
		this.panel1.SuspendLayout();
		this.panel2.SuspendLayout();
		this.EstateSortList.SuspendLayout();
		this.EstateSortOptions.SuspendLayout();
		this.EstateSearchList.SuspendLayout();
		this.SuspendLayout();
		// 
		// panel1
		// 
		this.panel1.BackColor = SystemColors.Info;
		this.panel1.BorderStyle = BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.button1);
		this.panel1.Controls.Add(this.SearchBox);
		this.panel1.Controls.Add(this.FilterButton);
		this.panel1.Controls.Add(this.LoadButton);
		this.panel1.Controls.Add(this.SaveButton);
		this.panel1.Controls.Add(this.CombinedView);
		this.panel1.Controls.Add(this.EstateView);
		this.panel1.Controls.Add(this.ClientsView);
		this.panel1.Dock = DockStyle.Top;
		this.panel1.Location = new Point(0,0);
		this.panel1.Name = "panel1";
		this.panel1.Size = new Size(804,60);
		this.panel1.TabIndex = 0;
		// 
		// button1
		// 
		this.button1.Font = new Font("Segoe UI",12F);
		this.button1.Location = new Point(738,14);
		this.button1.Name = "button1";
		this.button1.Size = new Size(29,29);
		this.button1.TabIndex = 7;
		this.button1.Text = "v";
		this.button1.UseVisualStyleBackColor = true;
		// 
		// SearchBox
		// 
		this.SearchBox.Font = new Font("Segoe UI",12F);
		this.SearchBox.Location = new Point(503,14);
		this.SearchBox.Name = "SearchBox";
		this.SearchBox.PlaceholderText = "Search...";
		this.SearchBox.Size = new Size(236,29);
		this.SearchBox.TabIndex = 6;
		// 
		// FilterButton
		// 
		this.FilterButton.BackColor = SystemColors.Window;
		this.FilterButton.BackgroundImageLayout = ImageLayout.None;
		this.FilterButton.Image = (Image)resources.GetObject("FilterButton.Image");
		this.FilterButton.ImageAlign = ContentAlignment.MiddleLeft;
		this.FilterButton.Location = new Point(407,4);
		this.FilterButton.Name = "FilterButton";
		this.FilterButton.Size = new Size(90,50);
		this.FilterButton.TabIndex = 5;
		this.FilterButton.Text = "            Filter&&             Sort";
		this.FilterButton.UseVisualStyleBackColor = false;
		this.FilterButton.Click += this.FilterButton_Click;
		// 
		// LoadButton
		// 
		this.LoadButton.BackColor = SystemColors.Window;
		this.LoadButton.BackgroundImageLayout = ImageLayout.None;
		this.LoadButton.Image = (Image)resources.GetObject("LoadButton.Image");
		this.LoadButton.ImageAlign = ContentAlignment.MiddleLeft;
		this.LoadButton.Location = new Point(288,4);
		this.LoadButton.Name = "LoadButton";
		this.LoadButton.Size = new Size(118,50);
		this.LoadButton.TabIndex = 4;
		this.LoadButton.Text = "Load to file";
		this.LoadButton.TextAlign = ContentAlignment.MiddleRight;
		this.LoadButton.UseVisualStyleBackColor = false;
		this.LoadButton.Click += this.LoadButton_Click;
		// 
		// SaveButton
		// 
		this.SaveButton.BackColor = SystemColors.Window;
		this.SaveButton.BackgroundImageLayout = ImageLayout.None;
		this.SaveButton.Image = (Image)resources.GetObject("SaveButton.Image");
		this.SaveButton.ImageAlign = ContentAlignment.MiddleLeft;
		this.SaveButton.Location = new Point(169,4);
		this.SaveButton.Name = "SaveButton";
		this.SaveButton.Size = new Size(118,50);
		this.SaveButton.TabIndex = 3;
		this.SaveButton.Text = "Save to file";
		this.SaveButton.TextAlign = ContentAlignment.MiddleRight;
		this.SaveButton.UseVisualStyleBackColor = false;
		this.SaveButton.Click += this.SaveButton_Click;
		// 
		// CombinedView
		// 
		this.CombinedView.BackColor = SystemColors.Window;
		this.CombinedView.BackgroundImageLayout = ImageLayout.None;
		this.CombinedView.Image = (Image)resources.GetObject("CombinedView.Image");
		this.CombinedView.Location = new Point(113,4);
		this.CombinedView.Name = "CombinedView";
		this.CombinedView.Size = new Size(50,50);
		this.CombinedView.TabIndex = 2;
		this.CombinedView.UseVisualStyleBackColor = false;
		this.CombinedView.Click += this.CombinedView_Click;
		// 
		// EstateView
		// 
		this.EstateView.BackColor = SystemColors.Window;
		this.EstateView.BackgroundImageLayout = ImageLayout.None;
		this.EstateView.Image = (Image)resources.GetObject("EstateView.Image");
		this.EstateView.Location = new Point(62,4);
		this.EstateView.Name = "EstateView";
		this.EstateView.Size = new Size(50,50);
		this.EstateView.TabIndex = 1;
		this.EstateView.UseVisualStyleBackColor = false;
		this.EstateView.Click += this.EstateView_Click;
		// 
		// ClientsView
		// 
		this.ClientsView.BackColor = SystemColors.InactiveCaption;
		this.ClientsView.BackgroundImageLayout = ImageLayout.None;
		this.ClientsView.Enabled = false;
		this.ClientsView.Image = (Image)resources.GetObject("ClientsView.Image");
		this.ClientsView.Location = new Point(11,4);
		this.ClientsView.Name = "ClientsView";
		this.ClientsView.Size = new Size(50,50);
		this.ClientsView.TabIndex = 0;
		this.ClientsView.UseVisualStyleBackColor = false;
		this.ClientsView.Click += this.ClientsView_Click;
		// 
		// panel2
		// 
		this.panel2.BackColor = SystemColors.Info;
		this.panel2.BorderStyle = BorderStyle.FixedSingle;
		this.panel2.Controls.Add(this.EditButton);
		this.panel2.Controls.Add(this.InfoButton);
		this.panel2.Controls.Add(this.RemoveButton);
		this.panel2.Controls.Add(this.AddButton);
		this.panel2.Dock = DockStyle.Right;
		this.panel2.Location = new Point(574,60);
		this.panel2.Name = "panel2";
		this.panel2.Size = new Size(230,421);
		this.panel2.TabIndex = 1;
		// 
		// EditButton
		// 
		this.EditButton.BackColor = SystemColors.InactiveCaption;
		this.EditButton.BackgroundImageLayout = ImageLayout.None;
		this.EditButton.Enabled = false;
		this.EditButton.Font = new Font("Segoe UI",14F);
		this.EditButton.Image = (Image)resources.GetObject("EditButton.Image");
		this.EditButton.ImageAlign = ContentAlignment.MiddleLeft;
		this.EditButton.Location = new Point(14,247);
		this.EditButton.Name = "EditButton";
		this.EditButton.Size = new Size(200,50);
		this.EditButton.TabIndex = 9;
		this.EditButton.Text = "     Edit";
		this.EditButton.UseVisualStyleBackColor = false;
		this.EditButton.Click += this.EditButton_Click;
		// 
		// InfoButton
		// 
		this.InfoButton.BackColor = SystemColors.InactiveCaption;
		this.InfoButton.BackgroundImageLayout = ImageLayout.None;
		this.InfoButton.Enabled = false;
		this.InfoButton.Font = new Font("Segoe UI",14F);
		this.InfoButton.Image = (Image)resources.GetObject("InfoButton.Image");
		this.InfoButton.ImageAlign = ContentAlignment.MiddleLeft;
		this.InfoButton.Location = new Point(14,177);
		this.InfoButton.Name = "InfoButton";
		this.InfoButton.Size = new Size(200,50);
		this.InfoButton.TabIndex = 8;
		this.InfoButton.Text = "     Info";
		this.InfoButton.UseVisualStyleBackColor = false;
		this.InfoButton.Click += this.InfoButton_Click;
		// 
		// RemoveButton
		// 
		this.RemoveButton.BackColor = SystemColors.InactiveCaption;
		this.RemoveButton.BackgroundImageLayout = ImageLayout.None;
		this.RemoveButton.Enabled = false;
		this.RemoveButton.Font = new Font("Segoe UI",14F);
		this.RemoveButton.Image = (Image)resources.GetObject("RemoveButton.Image");
		this.RemoveButton.ImageAlign = ContentAlignment.MiddleLeft;
		this.RemoveButton.Location = new Point(14,110);
		this.RemoveButton.Name = "RemoveButton";
		this.RemoveButton.Size = new Size(200,50);
		this.RemoveButton.TabIndex = 7;
		this.RemoveButton.Text = "     Remove";
		this.RemoveButton.UseVisualStyleBackColor = false;
		this.RemoveButton.Click += this.RemoveButton_Click;
		// 
		// AddButton
		// 
		this.AddButton.BackColor = SystemColors.Window;
		this.AddButton.BackgroundImageLayout = ImageLayout.None;
		this.AddButton.Font = new Font("Segoe UI",14F);
		this.AddButton.Image = (Image)resources.GetObject("AddButton.Image");
		this.AddButton.ImageAlign = ContentAlignment.MiddleLeft;
		this.AddButton.Location = new Point(14,40);
		this.AddButton.Name = "AddButton";
		this.AddButton.Size = new Size(200,50);
		this.AddButton.TabIndex = 6;
		this.AddButton.Text = "     Add";
		this.AddButton.UseVisualStyleBackColor = false;
		this.AddButton.Click += this.AddButton_Click;
		// 
		// EntityList
		// 
		this.EntityList.AutoScroll = true;
		this.EntityList.BackColor = SystemColors.ControlDark;
		this.EntityList.FlowDirection = FlowDirection.TopDown;
		this.EntityList.Location = new Point(12,66);
		this.EntityList.Name = "EntityList";
		this.EntityList.Size = new Size(556,403);
		this.EntityList.TabIndex = 2;
		this.EntityList.WrapContents = false;
		// 
		// EmptyListLabel
		// 
		this.EmptyListLabel.AutoSize = true;
		this.EmptyListLabel.BackColor = SystemColors.ControlDark;
		this.EmptyListLabel.Font = new Font("Segoe UI",18F,FontStyle.Italic);
		this.EmptyListLabel.ForeColor = SystemColors.InactiveBorder;
		this.EmptyListLabel.Location = new Point(220,70);
		this.EmptyListLabel.Name = "EmptyListLabel";
		this.EmptyListLabel.Size = new Size(143,32);
		this.EmptyListLabel.TabIndex = 3;
		this.EmptyListLabel.Text = "List is empty";
		this.EmptyListLabel.TextAlign = ContentAlignment.TopCenter;
		// 
		// SaveFileDialog
		// 
		this.SaveFileDialog.DefaultExt = "json";
		this.SaveFileDialog.Filter = "Json file|*.json";
		// 
		// EstateSortList
		// 
		this.EstateSortList.BackColor = Color.FromArgb(214,214,189);
		this.EstateSortList.Controls.Add(this.EstateSortDescending);
		this.EstateSortList.Controls.Add(this.EstateSortAscending);
		this.EstateSortList.Controls.Add(this.EstateSortOrder);
		this.EstateSortList.Controls.Add(this.EstateSortOptions);
		this.EstateSortList.Location = new Point(20,75);
		this.EstateSortList.Name = "EstateSortList";
		this.EstateSortList.Size = new Size(184,158);
		this.EstateSortList.TabIndex = 0;
		this.EstateSortList.Visible = false;
		// 
		// EstateSortDescending
		// 
		this.EstateSortDescending.AutoSize = true;
		this.EstateSortDescending.Location = new Point(93,131);
		this.EstateSortDescending.Name = "EstateSortDescending";
		this.EstateSortDescending.Size = new Size(87,19);
		this.EstateSortDescending.TabIndex = 3;
		this.EstateSortDescending.TabStop = true;
		this.EstateSortDescending.Text = "Descending";
		this.EstateSortDescending.UseVisualStyleBackColor = true;
		// 
		// EstateSortAscending
		// 
		this.EstateSortAscending.AutoSize = true;
		this.EstateSortAscending.Checked = true;
		this.EstateSortAscending.Location = new Point(6,131);
		this.EstateSortAscending.Name = "EstateSortAscending";
		this.EstateSortAscending.Size = new Size(81,19);
		this.EstateSortAscending.TabIndex = 2;
		this.EstateSortAscending.TabStop = true;
		this.EstateSortAscending.Text = "Ascending";
		this.EstateSortAscending.UseVisualStyleBackColor = true;
		// 
		// EstateSortOrder
		// 
		this.EstateSortOrder.AutoSize = true;
		this.EstateSortOrder.Font = new Font("Segoe UI",9F);
		this.EstateSortOrder.Location = new Point(3,113);
		this.EstateSortOrder.Name = "EstateSortOrder";
		this.EstateSortOrder.Size = new Size(76,15);
		this.EstateSortOrder.TabIndex = 1;
		this.EstateSortOrder.Text = "Sorting order";
		// 
		// EstateSortOptions
		// 
		this.EstateSortOptions.Controls.Add(this.EstateSortDate);
		this.EstateSortOptions.Controls.Add(this.EstateSortRooms);
		this.EstateSortOptions.Controls.Add(this.EstateSortPrice);
		this.EstateSortOptions.Controls.Add(this.EstateSortCountry);
		this.EstateSortOptions.Controls.Add(this.EstateSortName);
		this.EstateSortOptions.Location = new Point(3,3);
		this.EstateSortOptions.Name = "EstateSortOptions";
		this.EstateSortOptions.Size = new Size(177,106);
		this.EstateSortOptions.TabIndex = 0;
		// 
		// EstateSortDate
		// 
		this.EstateSortDate.AutoSize = true;
		this.EstateSortDate.Location = new Point(3,82);
		this.EstateSortDate.Name = "EstateSortDate";
		this.EstateSortDate.Size = new Size(49,19);
		this.EstateSortDate.TabIndex = 4;
		this.EstateSortDate.Text = "Date";
		this.EstateSortDate.UseVisualStyleBackColor = true;
		// 
		// EstateSortRooms
		// 
		this.EstateSortRooms.AutoSize = true;
		this.EstateSortRooms.Location = new Point(3,62);
		this.EstateSortRooms.Name = "EstateSortRooms";
		this.EstateSortRooms.Size = new Size(91,19);
		this.EstateSortRooms.TabIndex = 3;
		this.EstateSortRooms.Text = "Room count";
		this.EstateSortRooms.UseVisualStyleBackColor = true;
		// 
		// EstateSortPrice
		// 
		this.EstateSortPrice.AutoSize = true;
		this.EstateSortPrice.Location = new Point(3,42);
		this.EstateSortPrice.Name = "EstateSortPrice";
		this.EstateSortPrice.Size = new Size(51,19);
		this.EstateSortPrice.TabIndex = 2;
		this.EstateSortPrice.Text = "Price";
		this.EstateSortPrice.UseVisualStyleBackColor = true;
		// 
		// EstateSortCountry
		// 
		this.EstateSortCountry.AutoSize = true;
		this.EstateSortCountry.Location = new Point(3,23);
		this.EstateSortCountry.Name = "EstateSortCountry";
		this.EstateSortCountry.Size = new Size(68,19);
		this.EstateSortCountry.TabIndex = 1;
		this.EstateSortCountry.Text = "Country";
		this.EstateSortCountry.UseVisualStyleBackColor = true;
		// 
		// EstateSortName
		// 
		this.EstateSortName.AutoSize = true;
		this.EstateSortName.Checked = true;
		this.EstateSortName.Location = new Point(3,3);
		this.EstateSortName.Name = "EstateSortName";
		this.EstateSortName.Size = new Size(57,19);
		this.EstateSortName.TabIndex = 0;
		this.EstateSortName.TabStop = true;
		this.EstateSortName.Text = "Name";
		this.EstateSortName.UseVisualStyleBackColor = true;
		// 
		// EstateSearchList
		// 
		this.EstateSearchList.BackColor = Color.FromArgb(214,214,189);
		this.EstateSearchList.Controls.Add(this.checkBox3);
		this.EstateSearchList.Controls.Add(this.checkBox2);
		this.EstateSearchList.Controls.Add(this.checkBox1);
		this.EstateSearchList.Controls.Add(this.EstateSearchCountry);
		this.EstateSearchList.Location = new Point(220,75);
		this.EstateSearchList.Name = "EstateSearchList";
		this.EstateSearchList.Size = new Size(200,158);
		this.EstateSearchList.TabIndex = 4;
		// 
		// EstateSearchCountry
		// 
		this.EstateSearchCountry.AutoSize = true;
		this.EstateSearchCountry.Location = new Point(3,8);
		this.EstateSearchCountry.Name = "EstateSearchCountry";
		this.EstateSearchCountry.Size = new Size(69,19);
		this.EstateSearchCountry.TabIndex = 0;
		this.EstateSearchCountry.Text = "Country";
		this.EstateSearchCountry.UseVisualStyleBackColor = true;
		// 
		// checkBox1
		// 
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new Point(3,27);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new Size(69,19);
		this.checkBox1.TabIndex = 1;
		this.checkBox1.Text = "Country";
		this.checkBox1.UseVisualStyleBackColor = true;
		// 
		// checkBox2
		// 
		this.checkBox2.AutoSize = true;
		this.checkBox2.Location = new Point(3,46);
		this.checkBox2.Name = "checkBox2";
		this.checkBox2.Size = new Size(69,19);
		this.checkBox2.TabIndex = 2;
		this.checkBox2.Text = "Country";
		this.checkBox2.UseVisualStyleBackColor = true;
		// 
		// checkBox3
		// 
		this.checkBox3.AutoSize = true;
		this.checkBox3.Location = new Point(3,66);
		this.checkBox3.Name = "checkBox3";
		this.checkBox3.Size = new Size(69,19);
		this.checkBox3.TabIndex = 3;
		this.checkBox3.Text = "Country";
		this.checkBox3.UseVisualStyleBackColor = true;
		// 
		// MainWindow
		// 
		this.AutoScaleDimensions = new SizeF(7F,15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.ClientSize = new Size(804,481);
		this.Controls.Add(this.EstateSearchList);
		this.Controls.Add(this.EstateSortList);
		this.Controls.Add(this.EmptyListLabel);
		this.Controls.Add(this.EntityList);
		this.Controls.Add(this.panel2);
		this.Controls.Add(this.panel1);
		this.FormBorderStyle = FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.Name = "MainWindow";
		this.Text = "Realtor Manager";
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.panel2.ResumeLayout(false);
		this.EstateSortList.ResumeLayout(false);
		this.EstateSortList.PerformLayout();
		this.EstateSortOptions.ResumeLayout(false);
		this.EstateSortOptions.PerformLayout();
		this.EstateSearchList.ResumeLayout(false);
		this.EstateSearchList.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	#endregion

	private Panel panel1;
	private Panel panel2;
	private FlowLayoutPanel EntityList;
	private Button ClientsView;
	private Button EstateView;
	private Button CombinedView;
	private Button FilterButton;
	private Button LoadButton;
	private Button SaveButton;
	private Button AddButton;
	private Button EditButton;
	private Button InfoButton;
	private Button RemoveButton;
	private Label EmptyListLabel;
	private SaveFileDialog SaveFileDialog;
	private OpenFileDialog OpenFileDialog;
	private RadioButtonGroup EstateSortList;
	private RadioButtonGroup EstateSortOptions;
	private RadioButton EstateSortName;
	private RadioButton EstateSortCountry;
	private RadioButton EstateSortPrice;
	private RadioButton EstateSortDate;
	private RadioButton EstateSortRooms;
	private Label EstateSortOrder;
	private RadioButton EstateSortAscending;
	private RadioButton EstateSortDescending;
	private TextBox SearchBox;
	private Button button1;
	private RadioButtonGroup EstateSearchList;
	private CheckBox EstateSearchCountry;
	private CheckBox checkBox3;
	private CheckBox checkBox2;
	private CheckBox checkBox1;
}

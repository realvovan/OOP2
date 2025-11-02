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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
		this.panel1 = new Panel();
		this.SearchDropdownButton = new Button();
		this.SearchBox = new TextBox();
		this.FilterButton = new Button();
		this.LoadButton = new Button();
		this.SaveButton = new Button();
		this.CombinedView = new Button();
		this.EstateView = new Button();
		this.ClientsView = new Button();
		this.panel2 = new Panel();
		this.SuggestionsFilterRequests = new CheckBox();
		this.EditButton = new Button();
		this.InfoButton = new Button();
		this.RemoveButton = new Button();
		this.AddButton = new Button();
		this.EntityList = new FlowLayoutPanel();
		this.EmptyListLabel = new Label();
		this.SaveFileDialog = new SaveFileDialog();
		this.OpenFileDialog = new OpenFileDialog();
		this.EstateSortList = new UserInputsGroup();
		this.EstateSortDescending = new RadioButton();
		this.EstateSortAscending = new RadioButton();
		this.EstateSortOrder = new Label();
		this.EstateSortOptions = new UserInputsGroup();
		this.EstateSortDate = new RadioButton();
		this.EstateSortRooms = new RadioButton();
		this.EstateSortPrice = new RadioButton();
		this.EstateSortCountry = new RadioButton();
		this.EstateSortName = new RadioButton();
		this.EstateSearchList = new UserInputsGroup();
		this.EstateSearchRoomsMax = new TextBox();
		this.EstateSearchRoomsMin = new TextBox();
		this.EstateSearchRooms = new Label();
		this.EstateSearchPriceMax = new TextBox();
		this.EstateSearchPriceMin = new TextBox();
		this.EstateSearchPrice = new Label();
		this.EstateSearchZip = new CheckBox();
		this.EstateSearchCity = new CheckBox();
		this.EstateSearchProvince = new CheckBox();
		this.EstateSearchCountry = new CheckBox();
		this.ToolTip = new ToolTip(this.components);
		this.ClientSortList = new UserInputsGroup();
		this.ClientSortDescending = new RadioButton();
		this.ClientSortAscending = new RadioButton();
		this.ClientSortOrder = new Label();
		this.ClientSortOptions = new UserInputsGroup();
		this.ClientSortDate = new RadioButton();
		this.ClientSortPrice = new RadioButton();
		this.ClientSortRooms = new RadioButton();
		this.ClientSortIban = new RadioButton();
		this.ClientSortLast = new RadioButton();
		this.ClientSortFirst = new RadioButton();
		this.ClientSearchList = new UserInputsGroup();
		this.ClientSearchIban = new CheckBox();
		this.ClientSearchPassport = new CheckBox();
		this.ClientSearchRoomsMax = new TextBox();
		this.ClientSearchRoomsMin = new TextBox();
		this.label1 = new Label();
		this.ClientSearchPriceMax = new TextBox();
		this.ClientSearchPriceMin = new TextBox();
		this.label2 = new Label();
		this.ClientSearchPhone = new CheckBox();
		this.ClientSearchEmail = new CheckBox();
		this.ClientSearchLast = new CheckBox();
		this.ClientSearchFirst = new CheckBox();
		this.CombinedSortList = new UserInputsGroup();
		this.CombinedSortDescending = new RadioButton();
		this.CombinedSortAscending = new RadioButton();
		this.CombinedSortOrder = new Label();
		this.CombinedSortOptions = new UserInputsGroup();
		this.CombinedSortDate = new RadioButton();
		this.CombinedSortType = new RadioButton();
		this.CombinedSortName = new RadioButton();
		this.panel1.SuspendLayout();
		this.panel2.SuspendLayout();
		this.EstateSortList.SuspendLayout();
		this.EstateSortOptions.SuspendLayout();
		this.EstateSearchList.SuspendLayout();
		this.ClientSortList.SuspendLayout();
		this.ClientSortOptions.SuspendLayout();
		this.ClientSearchList.SuspendLayout();
		this.CombinedSortList.SuspendLayout();
		this.CombinedSortOptions.SuspendLayout();
		this.SuspendLayout();
		// 
		// panel1
		// 
		this.panel1.BackColor = SystemColors.Info;
		this.panel1.BorderStyle = BorderStyle.FixedSingle;
		this.panel1.Controls.Add(this.SearchDropdownButton);
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
		// SearchDropdownButton
		// 
		this.SearchDropdownButton.Font = new Font("Segoe UI",12F);
		this.SearchDropdownButton.Location = new Point(759,14);
		this.SearchDropdownButton.Name = "SearchDropdownButton";
		this.SearchDropdownButton.Size = new Size(29,29);
		this.SearchDropdownButton.TabIndex = 7;
		this.SearchDropdownButton.Text = "v";
		this.SearchDropdownButton.UseVisualStyleBackColor = true;
		this.SearchDropdownButton.Click += this.SearchDropdownButton_Click;
		// 
		// SearchBox
		// 
		this.SearchBox.Font = new Font("Segoe UI",12F);
		this.SearchBox.Location = new Point(503,14);
		this.SearchBox.Name = "SearchBox";
		this.SearchBox.PlaceholderText = "Search...";
		this.SearchBox.Size = new Size(260,29);
		this.SearchBox.TabIndex = 6;
		this.SearchBox.TextChanged += this.SearchBox_TextChanged;
		this.SearchBox.KeyDown += this.SearchBox_KeyDown;
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
		this.FilterButton.Text = "          Sort";
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
		this.ToolTip.SetToolTip(this.LoadButton,"Ctrl + O");
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
		this.ToolTip.SetToolTip(this.SaveButton,"Ctrl + S");
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
		this.ToolTip.SetToolTip(this.CombinedView,"Combined view (Ctrl + 3)");
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
		this.ToolTip.SetToolTip(this.EstateView,"Real estates view (Ctrl + 2)");
		this.EstateView.UseVisualStyleBackColor = false;
		this.EstateView.Click += this.EstateView_Click;
		// 
		// ClientsView
		// 
		this.ClientsView.AccessibleDescription = "";
		this.ClientsView.AccessibleName = "";
		this.ClientsView.BackColor = SystemColors.InactiveCaption;
		this.ClientsView.BackgroundImageLayout = ImageLayout.None;
		this.ClientsView.Enabled = false;
		this.ClientsView.Image = (Image)resources.GetObject("ClientsView.Image");
		this.ClientsView.Location = new Point(11,4);
		this.ClientsView.Name = "ClientsView";
		this.ClientsView.Size = new Size(50,50);
		this.ClientsView.TabIndex = 0;
		this.ToolTip.SetToolTip(this.ClientsView,"Clients view (Ctrl + 1)");
		this.ClientsView.UseVisualStyleBackColor = false;
		this.ClientsView.Click += this.ClientsView_Click;
		// 
		// panel2
		// 
		this.panel2.BackColor = SystemColors.Info;
		this.panel2.BorderStyle = BorderStyle.FixedSingle;
		this.panel2.Controls.Add(this.SuggestionsFilterRequests);
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
		// SuggestionsFilterRequests
		// 
		this.SuggestionsFilterRequests.BackColor = Color.FromArgb(214,214,189);
		this.SuggestionsFilterRequests.Font = new Font("Segoe UI",11F);
		this.SuggestionsFilterRequests.Location = new Point(10,316);
		this.SuggestionsFilterRequests.Name = "SuggestionsFilterRequests";
		this.SuggestionsFilterRequests.Size = new Size(211,49);
		this.SuggestionsFilterRequests.TabIndex = 10;
		this.SuggestionsFilterRequests.Text = "Only show real estates that match the client's requests";
		this.SuggestionsFilterRequests.TextAlign = ContentAlignment.MiddleCenter;
		this.SuggestionsFilterRequests.UseVisualStyleBackColor = false;
		this.SuggestionsFilterRequests.Visible = false;
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
		this.EstateSearchList.Controls.Add(this.EstateSearchRoomsMax);
		this.EstateSearchList.Controls.Add(this.EstateSearchRoomsMin);
		this.EstateSearchList.Controls.Add(this.EstateSearchRooms);
		this.EstateSearchList.Controls.Add(this.EstateSearchPriceMax);
		this.EstateSearchList.Controls.Add(this.EstateSearchPriceMin);
		this.EstateSearchList.Controls.Add(this.EstateSearchPrice);
		this.EstateSearchList.Controls.Add(this.EstateSearchZip);
		this.EstateSearchList.Controls.Add(this.EstateSearchCity);
		this.EstateSearchList.Controls.Add(this.EstateSearchProvince);
		this.EstateSearchList.Controls.Add(this.EstateSearchCountry);
		this.EstateSearchList.Location = new Point(220,75);
		this.EstateSearchList.Name = "EstateSearchList";
		this.EstateSearchList.Size = new Size(200,158);
		this.EstateSearchList.TabIndex = 4;
		this.EstateSearchList.Visible = false;
		// 
		// EstateSearchRoomsMax
		// 
		this.EstateSearchRoomsMax.Location = new Point(142,119);
		this.EstateSearchRoomsMax.Name = "EstateSearchRoomsMax";
		this.EstateSearchRoomsMax.PlaceholderText = "Max";
		this.EstateSearchRoomsMax.Size = new Size(50,23);
		this.EstateSearchRoomsMax.TabIndex = 9;
		// 
		// EstateSearchRoomsMin
		// 
		this.EstateSearchRoomsMin.Location = new Point(85,119);
		this.EstateSearchRoomsMin.Name = "EstateSearchRoomsMin";
		this.EstateSearchRoomsMin.PlaceholderText = "Min";
		this.EstateSearchRoomsMin.Size = new Size(50,23);
		this.EstateSearchRoomsMin.TabIndex = 8;
		// 
		// EstateSearchRooms
		// 
		this.EstateSearchRooms.AutoSize = true;
		this.EstateSearchRooms.Location = new Point(3,122);
		this.EstateSearchRooms.Name = "EstateSearchRooms";
		this.EstateSearchRooms.Size = new Size(73,15);
		this.EstateSearchRooms.TabIndex = 7;
		this.EstateSearchRooms.Text = "Room count";
		// 
		// EstateSearchPriceMax
		// 
		this.EstateSearchPriceMax.Location = new Point(142,91);
		this.EstateSearchPriceMax.Name = "EstateSearchPriceMax";
		this.EstateSearchPriceMax.PlaceholderText = "Max";
		this.EstateSearchPriceMax.Size = new Size(50,23);
		this.EstateSearchPriceMax.TabIndex = 6;
		// 
		// EstateSearchPriceMin
		// 
		this.EstateSearchPriceMin.Location = new Point(85,91);
		this.EstateSearchPriceMin.Name = "EstateSearchPriceMin";
		this.EstateSearchPriceMin.PlaceholderText = "Min";
		this.EstateSearchPriceMin.Size = new Size(50,23);
		this.EstateSearchPriceMin.TabIndex = 5;
		// 
		// EstateSearchPrice
		// 
		this.EstateSearchPrice.AutoSize = true;
		this.EstateSearchPrice.Location = new Point(3,94);
		this.EstateSearchPrice.Name = "EstateSearchPrice";
		this.EstateSearchPrice.Size = new Size(33,15);
		this.EstateSearchPrice.TabIndex = 4;
		this.EstateSearchPrice.Text = "Price";
		// 
		// EstateSearchZip
		// 
		this.EstateSearchZip.AutoSize = true;
		this.EstateSearchZip.Location = new Point(3,66);
		this.EstateSearchZip.Name = "EstateSearchZip";
		this.EstateSearchZip.Size = new Size(87,19);
		this.EstateSearchZip.TabIndex = 3;
		this.EstateSearchZip.Text = "Postal code";
		this.EstateSearchZip.UseVisualStyleBackColor = true;
		// 
		// EstateSearchCity
		// 
		this.EstateSearchCity.AutoSize = true;
		this.EstateSearchCity.Location = new Point(3,46);
		this.EstateSearchCity.Name = "EstateSearchCity";
		this.EstateSearchCity.Size = new Size(47,19);
		this.EstateSearchCity.TabIndex = 2;
		this.EstateSearchCity.Text = "City";
		this.EstateSearchCity.UseVisualStyleBackColor = true;
		// 
		// EstateSearchProvince
		// 
		this.EstateSearchProvince.AutoSize = true;
		this.EstateSearchProvince.Location = new Point(3,27);
		this.EstateSearchProvince.Name = "EstateSearchProvince";
		this.EstateSearchProvince.Size = new Size(72,19);
		this.EstateSearchProvince.TabIndex = 1;
		this.EstateSearchProvince.Text = "Province";
		this.EstateSearchProvince.UseVisualStyleBackColor = true;
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
		// ClientSortList
		// 
		this.ClientSortList.BackColor = Color.FromArgb(214,214,189);
		this.ClientSortList.Controls.Add(this.ClientSortDescending);
		this.ClientSortList.Controls.Add(this.ClientSortAscending);
		this.ClientSortList.Controls.Add(this.ClientSortOrder);
		this.ClientSortList.Controls.Add(this.ClientSortOptions);
		this.ClientSortList.Location = new Point(20,250);
		this.ClientSortList.Name = "ClientSortList";
		this.ClientSortList.Size = new Size(184,175);
		this.ClientSortList.TabIndex = 4;
		this.ClientSortList.Visible = false;
		// 
		// ClientSortDescending
		// 
		this.ClientSortDescending.AutoSize = true;
		this.ClientSortDescending.Location = new Point(93,148);
		this.ClientSortDescending.Name = "ClientSortDescending";
		this.ClientSortDescending.Size = new Size(87,19);
		this.ClientSortDescending.TabIndex = 3;
		this.ClientSortDescending.TabStop = true;
		this.ClientSortDescending.Text = "Descending";
		this.ClientSortDescending.UseVisualStyleBackColor = true;
		// 
		// ClientSortAscending
		// 
		this.ClientSortAscending.AutoSize = true;
		this.ClientSortAscending.Checked = true;
		this.ClientSortAscending.Location = new Point(6,148);
		this.ClientSortAscending.Name = "ClientSortAscending";
		this.ClientSortAscending.Size = new Size(81,19);
		this.ClientSortAscending.TabIndex = 2;
		this.ClientSortAscending.TabStop = true;
		this.ClientSortAscending.Text = "Ascending";
		this.ClientSortAscending.UseVisualStyleBackColor = true;
		// 
		// ClientSortOrder
		// 
		this.ClientSortOrder.AutoSize = true;
		this.ClientSortOrder.Font = new Font("Segoe UI",9F);
		this.ClientSortOrder.Location = new Point(3,130);
		this.ClientSortOrder.Name = "ClientSortOrder";
		this.ClientSortOrder.Size = new Size(76,15);
		this.ClientSortOrder.TabIndex = 1;
		this.ClientSortOrder.Text = "Sorting order";
		// 
		// ClientSortOptions
		// 
		this.ClientSortOptions.Controls.Add(this.ClientSortDate);
		this.ClientSortOptions.Controls.Add(this.ClientSortPrice);
		this.ClientSortOptions.Controls.Add(this.ClientSortRooms);
		this.ClientSortOptions.Controls.Add(this.ClientSortIban);
		this.ClientSortOptions.Controls.Add(this.ClientSortLast);
		this.ClientSortOptions.Controls.Add(this.ClientSortFirst);
		this.ClientSortOptions.Location = new Point(3,3);
		this.ClientSortOptions.Name = "ClientSortOptions";
		this.ClientSortOptions.Size = new Size(177,124);
		this.ClientSortOptions.TabIndex = 0;
		// 
		// ClientSortDate
		// 
		this.ClientSortDate.AutoSize = true;
		this.ClientSortDate.Location = new Point(3,102);
		this.ClientSortDate.Name = "ClientSortDate";
		this.ClientSortDate.Size = new Size(49,19);
		this.ClientSortDate.TabIndex = 5;
		this.ClientSortDate.Text = "Date";
		this.ClientSortDate.UseVisualStyleBackColor = true;
		// 
		// ClientSortPrice
		// 
		this.ClientSortPrice.AutoSize = true;
		this.ClientSortPrice.Location = new Point(3,82);
		this.ClientSortPrice.Name = "ClientSortPrice";
		this.ClientSortPrice.Size = new Size(102,19);
		this.ClientSortPrice.TabIndex = 4;
		this.ClientSortPrice.Text = "Preferred price";
		this.ClientSortPrice.UseVisualStyleBackColor = true;
		// 
		// ClientSortRooms
		// 
		this.ClientSortRooms.AutoSize = true;
		this.ClientSortRooms.Location = new Point(3,62);
		this.ClientSortRooms.Name = "ClientSortRooms";
		this.ClientSortRooms.Size = new Size(139,19);
		this.ClientSortRooms.TabIndex = 3;
		this.ClientSortRooms.Text = "Preferred room count";
		this.ClientSortRooms.UseVisualStyleBackColor = true;
		// 
		// ClientSortIban
		// 
		this.ClientSortIban.AutoSize = true;
		this.ClientSortIban.Location = new Point(3,42);
		this.ClientSortIban.Name = "ClientSortIban";
		this.ClientSortIban.Size = new Size(48,19);
		this.ClientSortIban.TabIndex = 2;
		this.ClientSortIban.Text = "Iban";
		this.ClientSortIban.UseVisualStyleBackColor = true;
		// 
		// ClientSortLast
		// 
		this.ClientSortLast.AutoSize = true;
		this.ClientSortLast.Location = new Point(3,23);
		this.ClientSortLast.Name = "ClientSortLast";
		this.ClientSortLast.Size = new Size(79,19);
		this.ClientSortLast.TabIndex = 1;
		this.ClientSortLast.Text = "Last name";
		this.ClientSortLast.UseVisualStyleBackColor = true;
		// 
		// ClientSortFirst
		// 
		this.ClientSortFirst.AutoSize = true;
		this.ClientSortFirst.Checked = true;
		this.ClientSortFirst.Location = new Point(3,3);
		this.ClientSortFirst.Name = "ClientSortFirst";
		this.ClientSortFirst.Size = new Size(80,19);
		this.ClientSortFirst.TabIndex = 0;
		this.ClientSortFirst.TabStop = true;
		this.ClientSortFirst.Text = "First name";
		this.ClientSortFirst.UseVisualStyleBackColor = true;
		// 
		// ClientSearchList
		// 
		this.ClientSearchList.BackColor = Color.FromArgb(214,214,189);
		this.ClientSearchList.Controls.Add(this.ClientSearchIban);
		this.ClientSearchList.Controls.Add(this.ClientSearchPassport);
		this.ClientSearchList.Controls.Add(this.ClientSearchRoomsMax);
		this.ClientSearchList.Controls.Add(this.ClientSearchRoomsMin);
		this.ClientSearchList.Controls.Add(this.label1);
		this.ClientSearchList.Controls.Add(this.ClientSearchPriceMax);
		this.ClientSearchList.Controls.Add(this.ClientSearchPriceMin);
		this.ClientSearchList.Controls.Add(this.label2);
		this.ClientSearchList.Controls.Add(this.ClientSearchPhone);
		this.ClientSearchList.Controls.Add(this.ClientSearchEmail);
		this.ClientSearchList.Controls.Add(this.ClientSearchLast);
		this.ClientSearchList.Controls.Add(this.ClientSearchFirst);
		this.ClientSearchList.Location = new Point(220,250);
		this.ClientSearchList.Name = "ClientSearchList";
		this.ClientSearchList.Size = new Size(200,194);
		this.ClientSearchList.TabIndex = 10;
		this.ClientSearchList.Visible = false;
		// 
		// ClientSearchIban
		// 
		this.ClientSearchIban.AutoSize = true;
		this.ClientSearchIban.Location = new Point(3,106);
		this.ClientSearchIban.Name = "ClientSearchIban";
		this.ClientSearchIban.Size = new Size(53,19);
		this.ClientSearchIban.TabIndex = 11;
		this.ClientSearchIban.Text = "IBAN";
		this.ClientSearchIban.UseVisualStyleBackColor = true;
		// 
		// ClientSearchPassport
		// 
		this.ClientSearchPassport.AutoSize = true;
		this.ClientSearchPassport.Location = new Point(3,86);
		this.ClientSearchPassport.Name = "ClientSearchPassport";
		this.ClientSearchPassport.Size = new Size(116,19);
		this.ClientSearchPassport.TabIndex = 10;
		this.ClientSearchPassport.Text = "Passport number";
		this.ClientSearchPassport.UseVisualStyleBackColor = true;
		// 
		// ClientSearchRoomsMax
		// 
		this.ClientSearchRoomsMax.Location = new Point(142,152);
		this.ClientSearchRoomsMax.Name = "ClientSearchRoomsMax";
		this.ClientSearchRoomsMax.PlaceholderText = "Max";
		this.ClientSearchRoomsMax.Size = new Size(50,23);
		this.ClientSearchRoomsMax.TabIndex = 9;
		// 
		// ClientSearchRoomsMin
		// 
		this.ClientSearchRoomsMin.Location = new Point(85,152);
		this.ClientSearchRoomsMin.Name = "ClientSearchRoomsMin";
		this.ClientSearchRoomsMin.PlaceholderText = "Min";
		this.ClientSearchRoomsMin.Size = new Size(50,23);
		this.ClientSearchRoomsMin.TabIndex = 8;
		// 
		// label1
		// 
		this.label1.Location = new Point(3,148);
		this.label1.Name = "label1";
		this.label1.Size = new Size(76,35);
		this.label1.TabIndex = 7;
		this.label1.Text = "Preferred room count";
		// 
		// ClientSearchPriceMax
		// 
		this.ClientSearchPriceMax.Location = new Point(142,124);
		this.ClientSearchPriceMax.Name = "ClientSearchPriceMax";
		this.ClientSearchPriceMax.PlaceholderText = "Max";
		this.ClientSearchPriceMax.Size = new Size(50,23);
		this.ClientSearchPriceMax.TabIndex = 6;
		// 
		// ClientSearchPriceMin
		// 
		this.ClientSearchPriceMin.Location = new Point(85,124);
		this.ClientSearchPriceMin.Name = "ClientSearchPriceMin";
		this.ClientSearchPriceMin.PlaceholderText = "Min";
		this.ClientSearchPriceMin.Size = new Size(50,23);
		this.ClientSearchPriceMin.TabIndex = 5;
		// 
		// label2
		// 
		this.label2.AutoSize = true;
		this.label2.Location = new Point(3,127);
		this.label2.Name = "label2";
		this.label2.Size = new Size(84,15);
		this.label2.TabIndex = 4;
		this.label2.Text = "Preferred price";
		// 
		// ClientSearchPhone
		// 
		this.ClientSearchPhone.AutoSize = true;
		this.ClientSearchPhone.Location = new Point(3,66);
		this.ClientSearchPhone.Name = "ClientSearchPhone";
		this.ClientSearchPhone.Size = new Size(105,19);
		this.ClientSearchPhone.TabIndex = 3;
		this.ClientSearchPhone.Text = "Phone number";
		this.ClientSearchPhone.UseVisualStyleBackColor = true;
		// 
		// ClientSearchEmail
		// 
		this.ClientSearchEmail.AutoSize = true;
		this.ClientSearchEmail.Location = new Point(3,46);
		this.ClientSearchEmail.Name = "ClientSearchEmail";
		this.ClientSearchEmail.Size = new Size(98,19);
		this.ClientSearchEmail.TabIndex = 2;
		this.ClientSearchEmail.Text = "Email address";
		this.ClientSearchEmail.UseVisualStyleBackColor = true;
		// 
		// ClientSearchLast
		// 
		this.ClientSearchLast.AutoSize = true;
		this.ClientSearchLast.Location = new Point(3,27);
		this.ClientSearchLast.Name = "ClientSearchLast";
		this.ClientSearchLast.Size = new Size(80,19);
		this.ClientSearchLast.TabIndex = 1;
		this.ClientSearchLast.Text = "Last name";
		this.ClientSearchLast.UseVisualStyleBackColor = true;
		// 
		// ClientSearchFirst
		// 
		this.ClientSearchFirst.AutoSize = true;
		this.ClientSearchFirst.Location = new Point(3,8);
		this.ClientSearchFirst.Name = "ClientSearchFirst";
		this.ClientSearchFirst.Size = new Size(81,19);
		this.ClientSearchFirst.TabIndex = 0;
		this.ClientSearchFirst.Text = "First name";
		this.ClientSearchFirst.UseVisualStyleBackColor = true;
		// 
		// CombinedSortList
		// 
		this.CombinedSortList.BackColor = Color.FromArgb(214,214,189);
		this.CombinedSortList.Controls.Add(this.CombinedSortDescending);
		this.CombinedSortList.Controls.Add(this.CombinedSortAscending);
		this.CombinedSortList.Controls.Add(this.CombinedSortOrder);
		this.CombinedSortList.Controls.Add(this.CombinedSortOptions);
		this.CombinedSortList.Location = new Point(440,75);
		this.CombinedSortList.Name = "CombinedSortList";
		this.CombinedSortList.Size = new Size(184,114);
		this.CombinedSortList.TabIndex = 4;
		this.CombinedSortList.Visible = false;
		// 
		// CombinedSortDescending
		// 
		this.CombinedSortDescending.AutoSize = true;
		this.CombinedSortDescending.Location = new Point(93,86);
		this.CombinedSortDescending.Name = "CombinedSortDescending";
		this.CombinedSortDescending.Size = new Size(87,19);
		this.CombinedSortDescending.TabIndex = 3;
		this.CombinedSortDescending.TabStop = true;
		this.CombinedSortDescending.Text = "Descending";
		this.CombinedSortDescending.UseVisualStyleBackColor = true;
		// 
		// CombinedSortAscending
		// 
		this.CombinedSortAscending.AutoSize = true;
		this.CombinedSortAscending.Checked = true;
		this.CombinedSortAscending.Location = new Point(6,86);
		this.CombinedSortAscending.Name = "CombinedSortAscending";
		this.CombinedSortAscending.Size = new Size(81,19);
		this.CombinedSortAscending.TabIndex = 2;
		this.CombinedSortAscending.TabStop = true;
		this.CombinedSortAscending.Text = "Ascending";
		this.CombinedSortAscending.UseVisualStyleBackColor = true;
		// 
		// CombinedSortOrder
		// 
		this.CombinedSortOrder.AutoSize = true;
		this.CombinedSortOrder.Font = new Font("Segoe UI",9F);
		this.CombinedSortOrder.Location = new Point(3,68);
		this.CombinedSortOrder.Name = "CombinedSortOrder";
		this.CombinedSortOrder.Size = new Size(76,15);
		this.CombinedSortOrder.TabIndex = 1;
		this.CombinedSortOrder.Text = "Sorting order";
		// 
		// CombinedSortOptions
		// 
		this.CombinedSortOptions.Controls.Add(this.CombinedSortDate);
		this.CombinedSortOptions.Controls.Add(this.CombinedSortType);
		this.CombinedSortOptions.Controls.Add(this.CombinedSortName);
		this.CombinedSortOptions.Location = new Point(3,3);
		this.CombinedSortOptions.Name = "CombinedSortOptions";
		this.CombinedSortOptions.Size = new Size(177,62);
		this.CombinedSortOptions.TabIndex = 0;
		// 
		// CombinedSortDate
		// 
		this.CombinedSortDate.AutoSize = true;
		this.CombinedSortDate.Location = new Point(3,41);
		this.CombinedSortDate.Name = "CombinedSortDate";
		this.CombinedSortDate.Size = new Size(49,19);
		this.CombinedSortDate.TabIndex = 4;
		this.CombinedSortDate.Text = "Date";
		this.CombinedSortDate.UseVisualStyleBackColor = true;
		// 
		// CombinedSortType
		// 
		this.CombinedSortType.AutoSize = true;
		this.CombinedSortType.Location = new Point(3,22);
		this.CombinedSortType.Name = "CombinedSortType";
		this.CombinedSortType.Size = new Size(117,19);
		this.CombinedSortType.TabIndex = 3;
		this.CombinedSortType.Text = "Client/Real estate";
		this.CombinedSortType.UseVisualStyleBackColor = true;
		// 
		// CombinedSortName
		// 
		this.CombinedSortName.AutoSize = true;
		this.CombinedSortName.Checked = true;
		this.CombinedSortName.Location = new Point(3,3);
		this.CombinedSortName.Name = "CombinedSortName";
		this.CombinedSortName.Size = new Size(57,19);
		this.CombinedSortName.TabIndex = 0;
		this.CombinedSortName.TabStop = true;
		this.CombinedSortName.Text = "Name";
		this.CombinedSortName.UseVisualStyleBackColor = true;
		// 
		// MainWindow
		// 
		this.AutoScaleDimensions = new SizeF(7F,15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.ClientSize = new Size(804,481);
		this.Controls.Add(this.CombinedSortList);
		this.Controls.Add(this.ClientSearchList);
		this.Controls.Add(this.ClientSortList);
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
		this.ClientSortList.ResumeLayout(false);
		this.ClientSortList.PerformLayout();
		this.ClientSortOptions.ResumeLayout(false);
		this.ClientSortOptions.PerformLayout();
		this.ClientSearchList.ResumeLayout(false);
		this.ClientSearchList.PerformLayout();
		this.CombinedSortList.ResumeLayout(false);
		this.CombinedSortList.PerformLayout();
		this.CombinedSortOptions.ResumeLayout(false);
		this.CombinedSortOptions.PerformLayout();
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
	private UserInputsGroup EstateSortList;
	private UserInputsGroup EstateSortOptions;
	private RadioButton EstateSortName;
	private RadioButton EstateSortCountry;
	private RadioButton EstateSortPrice;
	private RadioButton EstateSortDate;
	private RadioButton EstateSortRooms;
	private Label EstateSortOrder;
	private RadioButton EstateSortAscending;
	private RadioButton EstateSortDescending;
	private TextBox SearchBox;
	private Button SearchDropdownButton;
	private UserInputsGroup EstateSearchList;
	private CheckBox EstateSearchCountry;
	private CheckBox EstateSearchZip;
	private CheckBox EstateSearchCity;
	private CheckBox EstateSearchProvince;
	private TextBox EstateSearchPriceMin;
	private Label EstateSearchPrice;
	private TextBox EstateSearchRoomsMax;
	private TextBox EstateSearchRoomsMin;
	private Label EstateSearchRooms;
	private TextBox EstateSearchPriceMax;
	private ToolTip ToolTip;
	private UserInputsGroup ClientSortList;
	private RadioButton ClientSortDescending;
	private RadioButton ClientSortAscending;
	private Label ClientSortOrder;
	private UserInputsGroup ClientSortOptions;
	private RadioButton ClientSortPrice;
	private RadioButton ClientSortRooms;
	private RadioButton ClientSortIban;
	private RadioButton ClientSortLast;
	private RadioButton ClientSortFirst;
	private RadioButton ClientSortDate;
	private UserInputsGroup ClientSearchList;
	private TextBox ClientSearchRoomsMax;
	private TextBox ClientSearchRoomsMin;
	private Label label1;
	private TextBox ClientSearchPriceMax;
	private TextBox ClientSearchPriceMin;
	private Label label2;
	private CheckBox ClientSearchPhone;
	private CheckBox ClientSearchEmail;
	private CheckBox ClientSearchLast;
	private CheckBox ClientSearchFirst;
	private CheckBox ClientSearchPassport;
	private CheckBox ClientSearchIban;
	private UserInputsGroup CombinedSortList;
	private RadioButton CombinedSortDescending;
	private RadioButton CombinedSortAscending;
	private Label CombinedSortOrder;
	private UserInputsGroup CombinedSortOptions;
	private RadioButton CombinedSortDate;
	private RadioButton CombinedSortType;
	private RadioButton CombinedSortName;
	private CheckBox SuggestionsFilterRequests;
}

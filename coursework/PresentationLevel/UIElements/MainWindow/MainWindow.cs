using Coursework.BusinessLevel;
using Coursework.BusinessLevel.DTOs;
using Coursework.BusinessLevel.Services;
using Coursework.PresentationLevel.Values;

namespace Coursework.PresentationLevel;

enum ViewMode {
	Clients,
	RealEstates,
	Combined
}

public partial class MainWindow : Form {
	ClientService clientService = new();
	RealEstateService estateService = new();
	ViewMode viewMode = ViewMode.Clients;
	GuidLabel? selected = null;
	public MainWindow() {
		InitializeComponent();
		this.EntityList.Click += (sender,e) => {
			hideSortingLists();
			if (this.selected == null) return;
			this.selected.BackColor = Colors.MainWindow.EntityLabel;
			this.selected.ForeColor = Colors.MainWindow.EntityLabelText;
			this.selected.Font = new Font(selected.Font,FontStyle.Regular);
			this.RemoveButton.Enabled = false;
			this.RemoveButton.BackColor = Colors.MainWindow.InactiveButton;
			this.InfoButton.Enabled = false;
			this.InfoButton.BackColor = Colors.MainWindow.InactiveButton;
			this.EditButton.Enabled = false;
			this.EditButton.BackColor = Colors.MainWindow.InactiveButton;
			this.selected = null;
		};
		this.KeyPreview = true; // needed so the window receives key strokes
		this.KeyDown += (sender,e) => {
			if (e.KeyCode == Keys.F5) {
				displayEntityList();
				toggleViewButtons();
				hideSortingLists();
			}
		};
		this.EstateSortList.RadioButtonChecked += displayEntityList;
		this.EstateSortOptions.RadioButtonChecked += displayEntityList;
	}

	void toggleViewButtons() {
		// toggles client/estate/combine view buttons on top of the screen
		this.ClientsView.BackColor = this.viewMode == ViewMode.Clients ? Colors.MainWindow.InactiveButton : Colors.MainWindow.ActiveButton;
		this.ClientsView.Enabled = this.viewMode != ViewMode.Clients;
		this.EstateView.BackColor = this.viewMode == ViewMode.RealEstates ? Colors.MainWindow.InactiveButton : Colors.MainWindow.ActiveButton;
		this.EstateView.Enabled = this.viewMode != ViewMode.RealEstates;
		this.CombinedView.BackColor = this.viewMode == ViewMode.Combined ? Colors.MainWindow.InactiveButton : Colors.MainWindow.ActiveButton; ;
		this.CombinedView.Enabled = this.viewMode != ViewMode.Combined;
		// also disable the save and load buttons if combined view
		this.SaveButton.BackColor = this.viewMode == ViewMode.Combined ? Colors.MainWindow.InactiveButton : Colors.MainWindow.ActiveButton;
		this.SaveButton.Enabled = this.viewMode != ViewMode.Combined;
		this.LoadButton.BackColor = this.SaveButton.BackColor;
		this.LoadButton.Enabled = this.SaveButton.Enabled;
		// disable remove/info/edit buttons when view mode is changed
		this.RemoveButton.Enabled = false;
		this.RemoveButton.BackColor = Colors.MainWindow.InactiveButton;
		this.InfoButton.Enabled = false;
		this.InfoButton.BackColor = Colors.MainWindow.InactiveButton;
		this.EditButton.Enabled = false;
		this.EditButton.BackColor = Colors.MainWindow.InactiveButton;
		// disable the add button if combined view
		this.AddButton.BackColor = this.viewMode == ViewMode.Combined ? Colors.MainWindow.InactiveButton : Colors.MainWindow.ActiveButton;
		this.AddButton.Enabled = this.viewMode != ViewMode.Combined;
	}
	void hideSortingLists() {
		this.EstateSortList.Visible = false;
	}
	void displayEntityList() {
		this.EntityList.Controls.Clear();
		this.EntityList.BackColor = this.EmptyListLabel.BackColor;
		this.EmptyListLabel.Visible = true;
		this.selected = null;

		IDTO[] entities;
		if (this.viewMode == ViewMode.Clients) {
			entities = this.clientService.GetAllEntities();
		} else if (this.viewMode == ViewMode.RealEstates) {
			var result = this.estateService.GetAllEntities();
			bool isAscending = this.EstateSortAscending.Checked;
			// add search
			if (this.EstateSortCountry.Checked) result.SortBy(dto => dto.Country,isAscending);
			else if (this.EstateSortPrice.Checked) result.SortBy(dto => dto.Price,isAscending);
			else if (this.EstateSortRooms.Checked) result.SortBy(dto => dto.RoomCount,isAscending);
			else if (this.EstateSortDate.Checked) result.SortBy(dto => dto.CreatedAt,isAscending);
			else result.SortBy(dto => dto.ToString(),isAscending);
			entities = result.Entities;
		} else {
			entities = [
				..this.clientService.GetAllEntities(),
				..this.estateService.GetAllEntities(),
			];
		}

		foreach (IDTO i in entities) {
			if (i.Guid == null) continue;
			var label = new GuidLabel(i.Guid.Value) {
				BackColor = Colors.MainWindow.EntityLabel,
				ForeColor = Colors.MainWindow.EntityLabelText,
				Text = i.ToString(),
				Size = new Size(550,25),
				Font = new Font("Segoe UI",14f),
				AutoSize = false
			};
			this.EntityList.BackColor = Colors.MainWindow.EntityList;
			this.EmptyListLabel.Visible = false;
			this.EntityList.Controls.Add(label);
			label.Click += (sender,e) => {
				var label = (sender as GuidLabel)!;
				if (this.selected != null) {
					this.selected.BackColor = Colors.MainWindow.EntityLabel;
					this.selected.ForeColor = Colors.MainWindow.EntityLabelText;
					this.selected.Font = new Font(selected.Font,FontStyle.Regular);
				}
				this.selected = label;
				label.BackColor = Colors.MainWindow.EntityLabelSelected;
				label.ForeColor = Colors.MainWindow.EntityLabelTextSelected;
				label.Font = new Font(label.Font,FontStyle.Bold);
				this.RemoveButton.Enabled = true;
				this.RemoveButton.BackColor = Colors.MainWindow.ActiveButton;
				this.InfoButton.Enabled = true;
				this.InfoButton.BackColor = Colors.MainWindow.ActiveButton;
				this.EditButton.Enabled = true;
				this.EditButton.BackColor = Colors.MainWindow.ActiveButton;
			};
			label.DoubleClick += this.InfoButton_Click;
		}
	}
	void ClientsView_Click(object sender,EventArgs e) {
		if (this.viewMode == ViewMode.Clients) return;
		this.viewMode = ViewMode.Clients;
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void EstateView_Click(object sender,EventArgs e) {
		if (this.viewMode == ViewMode.RealEstates) return;
		this.viewMode = ViewMode.RealEstates;
		displayEntityList();
		toggleViewButtons();
	}
	void CombinedView_Click(object sender,EventArgs e) {
		if (this.viewMode == ViewMode.Combined) return;
		this.viewMode = ViewMode.Combined;
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void AddButton_Click(object sender,EventArgs e) {
		if (this.viewMode == ViewMode.Clients) {
			throw new NotImplementedException();
		} else if (this.viewMode == ViewMode.RealEstates) {
			using var creationWin = new RealEstateCreateWindow(CreateWindowOpenModes.AddNew,this.estateService);
			creationWin.ShowDialog();
		}
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void SaveButton_Click(object sender,EventArgs e) {
		if (this.viewMode == ViewMode.Combined) return;
		DialogResult dialogResult = this.SaveFileDialog.ShowDialog();
		if (dialogResult == DialogResult.Cancel) return;
		Result saveResult;
		if (this.viewMode == ViewMode.Clients) {
			saveResult = this.clientService.SaveEntitiesToFile(this.SaveFileDialog.FileName);
		} else if (this.viewMode == ViewMode.RealEstates) {
			saveResult = this.estateService.SaveEntitiesToFile(this.SaveFileDialog.FileName);
		} else saveResult = Result.Fail("Something went wrong!");
		if (saveResult.Success) {
			MessageBox.Show(
				text: "Objects saved successfully!",
				caption: "Yay!",
				buttons: MessageBoxButtons.OK,
				icon: MessageBoxIcon.Information
			);
		} else {
			MessageBox.Show(
				text: $"We encountered an error while saving: {saveResult.Message}",
				caption: "Saving error",
				buttons: MessageBoxButtons.OK,
				icon: MessageBoxIcon.Warning
			);
		}
	}
	void LoadButton_Click(object sender,EventArgs e) {
		if (this.viewMode == ViewMode.Combined) return;
		DialogResult dialogResult = this.OpenFileDialog.ShowDialog();
		if (dialogResult == DialogResult.Cancel) return;
		Result saveResult;
		if (this.viewMode == ViewMode.Clients) {
			saveResult = this.clientService.LoadEntitiesFromFile(this.OpenFileDialog.FileName);
		} else if (this.viewMode == ViewMode.RealEstates) {
			saveResult = this.estateService.LoadEntitiesFromFile(this.OpenFileDialog.FileName);
		} else saveResult = Result.Fail("Something went wrong!");
		if (saveResult.Success) {
			displayEntityList();
			toggleViewButtons();
			hideSortingLists();
		} else {
			MessageBox.Show(
				text: $"We encountered an error while loading: {saveResult.Message}",
				caption: "Loading error",
				buttons: MessageBoxButtons.OK,
				icon: MessageBoxIcon.Warning
			);
		}
	}
	void RemoveButton_Click(object sender,EventArgs e) {
		if (this.selected == null) return;
		Result removeResult;
		if (this.viewMode == ViewMode.Clients) {
			removeResult = this.clientService.RemoveEntity(this.selected.Guid);
		} else if (this.viewMode == ViewMode.RealEstates) {
			removeResult = this.estateService.RemoveEntity(this.selected.Guid);
		} else {
			removeResult = this.clientService.RemoveEntity(this.selected.Guid);
			if (!removeResult.Success) {
				removeResult = this.estateService.RemoveEntity(this.selected.Guid);
			}
		}
		if (!removeResult.Success) {
			MessageBox.Show(
				text: removeResult.Message,
				caption: "Oops!",
				buttons: MessageBoxButtons.OK,
				icon: MessageBoxIcon.Warning
			);
		}
		this.selected.Dispose();
		this.selected = null;
		this.RemoveButton.Enabled = false;
		this.RemoveButton.BackColor = Colors.MainWindow.InactiveButton;
		this.InfoButton.Enabled = false;
		this.InfoButton.BackColor = Colors.MainWindow.InactiveButton;
		this.EditButton.Enabled = false;
		this.EditButton.BackColor = Colors.MainWindow.InactiveButton;
	}
	void EditButton_Click(object sender,EventArgs e) {
		if (this.selected == null) return;
		if (this.viewMode == ViewMode.Clients) {
			throw new NotImplementedException();
		} else if (this.viewMode == ViewMode.RealEstates) {
			using var creationWin = new RealEstateCreateWindow(CreateWindowOpenModes.Edit,this.estateService,this.selected.Guid);
			creationWin.ShowDialog();
		} else {
			throw new NotImplementedException();
		}
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void InfoButton_Click(object? sender,EventArgs e) {
		if (this.selected == null) return;
		if (this.viewMode == ViewMode.Clients) {
			throw new NotImplementedException();
		} else if (this.viewMode == ViewMode.RealEstates) {
			using var infoWin = new RealEstateInfoWindow(this.estateService,this.selected.Guid);
			infoWin.ShowDialog();
		} else {
			throw new NotImplementedException();
		}
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void FilterButton_Click(object sender,EventArgs e) {
		Panel panel;
		if (this.viewMode == ViewMode.Clients) {
			throw new NotImplementedException();
		} else if (this.viewMode == ViewMode.RealEstates) {
			panel = this.EstateSortList;
		} else {
			// change this
			panel = this.EstateSortList;
		}
		panel.Location = this.FilterButton.Location + new Size(0,this.FilterButton.Height);
		panel.Visible = !panel.Visible;
	}
}

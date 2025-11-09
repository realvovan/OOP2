using Coursework.BusinessLevel;
using Coursework.BusinessLevel.DTOs;
using Coursework.BusinessLevel.Services;
using Coursework.PresentationLevel.Values;
using System.Reflection;

namespace Coursework.PresentationLevel;

enum ViewMode {
	Clients,
	RealEstates,
	Combined,
	Suggestions
}

/// <summary>
/// The main window of the program that allows: viewing clients/real estates/both;
/// creating new objects, sorting, searching, saving/loading from a file.
/// <br/><i>This window is meant to be launched first</i>
/// </summary>
public partial class MainWindow : Form {
	/// <summary>
	/// How much deviation is allowed in clients' preferred price to the actual house price
	/// </summary>
	const double CLIENT_PRICE_TOLERANCE = 1500d;

	internal ViewMode viewMode = ViewMode.Clients;
	internal ClientService clientService = new();
	internal RealEstateService estateService = new();
	internal Guid? suggestionModeClient = null;

	GuidLabel? selected = null;
	public MainWindow() {
		InitializeComponent();
		this.EntityList.Click += (sender,e) => {
			hideSortingLists();
			if (this.selected == null) return;
			this.selected.BackColor = Colors.EntityLabel;
			this.selected.ForeColor = Colors.EntityLabelText;
			this.selected.Font = new Font(selected.Font,FontStyle.Regular);
			this.RemoveButton.Enabled = false;
			this.RemoveButton.BackColor = Colors.InactiveButton;
			this.InfoButton.Enabled = false;
			this.InfoButton.BackColor = Colors.InactiveButton;
			this.EditButton.Enabled = false;
			this.EditButton.BackColor = Colors.InactiveButton;
			this.selected = null;
		};
		this.KeyPreview = true; // needed so the window receives key strokes
		this.KeyDown += (sender,e) => {
			if (e.KeyCode == Keys.F5) {
				// f5 refreshes the list
				displayEntityList();
				toggleViewButtons();
				hideSortingLists();
			} else if (e.KeyCode == Keys.Delete && this.selected != null) {
				// pressing DEL deleted the selected object
				this.RemoveButton_Click(this,EventArgs.Empty);
			} else if (e.Control) {
				// if CTRL is pressed check for key combinations
				var keyComboOptions = new Dictionary<Keys,EventHandler>() {
					{ Keys.D1,this.ClientsView_Click },
					{ Keys.D2,this.EstateView_Click },
					{ Keys.D3,this.CombinedView_Click },
					{ Keys.S,this.SaveButton_Click },
					{ Keys.O,this.LoadButton_Click },
				};
				if (keyComboOptions.TryGetValue(e.KeyCode,out var func)) func(this,EventArgs.Empty);
			}
		};

		// set up listeners to changes in search/sort options
		foreach (var field in this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)) {
			if (field.GetValue(this) is UserInputsGroup list) {
				list.ChildChanged += displayEntityList;
			}
		}
		this.SuggestionsFilterRequests.CheckedChanged += (sender,e) => displayEntityList();
	}

	void toggleViewButtons() {
		// toggles client/estate/combine view buttons on top of the screen
		this.ClientsView.BackColor = this.viewMode == ViewMode.Clients || this.viewMode == ViewMode.Suggestions ? Colors.InactiveButton : Colors.ActiveButton;
		this.ClientsView.Enabled = this.viewMode != ViewMode.Clients && this.viewMode != ViewMode.Suggestions;
		this.EstateView.BackColor = this.viewMode == ViewMode.RealEstates || this.viewMode == ViewMode.Suggestions ? Colors.InactiveButton : Colors.ActiveButton;
		this.EstateView.Enabled = this.viewMode != ViewMode.RealEstates && this.viewMode != ViewMode.Suggestions;
		this.CombinedView.BackColor = this.viewMode == ViewMode.Combined || this.viewMode == ViewMode.Suggestions ? Colors.InactiveButton : Colors.ActiveButton; ;
		this.CombinedView.Enabled = this.viewMode != ViewMode.Combined && this.viewMode != ViewMode.Suggestions;
		// also disable the save and load buttons if combined view
		this.SaveButton.BackColor = this.viewMode == ViewMode.Combined || this.viewMode == ViewMode.Suggestions ? Colors.InactiveButton : Colors.ActiveButton;
		this.SaveButton.Enabled = this.viewMode != ViewMode.Combined && this.viewMode != ViewMode.Suggestions;
		this.LoadButton.BackColor = this.SaveButton.BackColor;
		this.LoadButton.Enabled = this.SaveButton.Enabled;
		// disable remove/info/edit buttons when view mode is changed
		this.RemoveButton.Enabled = false;
		this.RemoveButton.BackColor = Colors.InactiveButton;
		this.InfoButton.Enabled = false;
		this.InfoButton.BackColor = Colors.InactiveButton;
		this.EditButton.Enabled = false;
		this.EditButton.BackColor = Colors.InactiveButton;
		// disable the add button if combined view
		this.AddButton.BackColor = this.viewMode == ViewMode.Combined || this.viewMode == ViewMode.Suggestions ? Colors.InactiveButton : Colors.ActiveButton;
		this.AddButton.Enabled = this.viewMode != ViewMode.Combined && this.viewMode != ViewMode.Suggestions;

		this.SearchDropdownButton.Enabled = this.viewMode != ViewMode.Combined;
		this.SuggestionsFilterRequests.Enabled = this.viewMode == ViewMode.Suggestions;
		this.SuggestionsFilterRequests.Visible = this.SuggestionsFilterRequests.Enabled;
		this.SuggestionsFilterRequests.Checked = false;
		this.PriceToleranceBox.Visible = this.SuggestionsFilterRequests.Visible;
		this.PriceToleranceLabel.Visible = this.SuggestionsFilterRequests.Visible;
	}
	void hideSortingLists() {
		this.EstateSortList.Visible = false;
		this.EstateSearchList.Visible = false;
		this.ClientSortList.Visible = false;
		this.ClientSearchList.Visible = false;
		this.CombinedSortList.Visible = false;
	}
	void displayEntityList() {
		this.EntityList.Controls.Clear();
		this.EntityList.BackColor = this.EmptyListLabel.BackColor;
		this.EmptyListLabel.Visible = true;
		this.selected = null;

		IDTO[] entities;
		if (this.viewMode == ViewMode.Clients) {
			var result = this.clientService.GetAllEntities();
			bool isAscending = this.ClientSortAscending.Checked;

			// searching by price/rooms ranges
			result.SearchBy(dto => {
				bool fitsPrice = true;
				bool fitsRooms = true;
				if (double.TryParse(this.ClientSearchPriceMin.Text,out double priceMin)) {
					fitsPrice = dto.DesiredPrice >= priceMin;
				}
				if (double.TryParse(this.ClientSearchPriceMax.Text,out double priceMax)) {
					fitsPrice = fitsPrice && dto.DesiredPrice < priceMax;
				}
				if (double.TryParse(this.ClientSearchRoomsMin.Text,out double roomsMin)) {
					fitsRooms = dto.DesiredRoomCount >= roomsMin;
				}
				if (double.TryParse(this.ClientSearchRoomsMax.Text,out double roomsMax)) {
					fitsRooms = fitsRooms && dto.DesiredRoomCount < roomsMax;
				}
				return fitsPrice && fitsRooms;
			}).SearchBy(dto => {
				// searching by search bar values
				if (string.IsNullOrWhiteSpace(this.SearchBox.Text)) return true;
				string[] searchFilter = this.SearchBox.Text.Split(' ');
				Func<string,bool> contains = s => {
					return searchFilter.Any(text => s.Contains(text,StringComparison.CurrentCultureIgnoreCase));
				};
				if (
					!this.ClientSearchFirst.Checked
					&& !this.ClientSearchLast.Checked
					&& !this.ClientSearchEmail.Checked
					&& !this.ClientSearchPhone.Checked
					&& !this.ClientSearchPassport.Checked
					&& !this.ClientSearchIban.Checked
					&& contains(dto.ToString())
				) return true;
				if (
					this.ClientSearchFirst.Checked && contains(dto.FirstName)
					|| this.ClientSearchLast.Checked && contains(dto.LastName)
					|| this.ClientSearchEmail.Checked && contains(dto.Email)
					|| this.ClientSearchPhone.Checked && contains(dto.PhoneNumber)
					|| this.ClientSearchPassport.Checked && contains(dto.PassportNumber)
					|| this.ClientSearchIban.Checked && contains(dto.IBAN)
				) return true;
				return false;
			});
			// sorting
			if (this.ClientSortFirst.Checked) result.SortBy(dto => dto.FirstName,isAscending);
			else if (this.ClientSortLast.Checked) result.SortBy(dto => dto.LastName,isAscending);
			else if (this.ClientSortIban.Checked) result.SortBy(dto => dto.IBAN,isAscending);
			else if (this.ClientSortPrice.Checked) result.SortBy(dto => dto.DesiredPrice,isAscending);
			else if (this.ClientSortRooms.Checked) result.SortBy(dto => dto.DesiredRoomCount,isAscending);
			else if (this.ClientSortDate.Checked) result.SortBy(dto => dto.CreatedAt,isAscending);
			else result.SortBy(dto => dto.ToString(),isAscending);

			entities = result.Entities;
		} else if (this.viewMode == ViewMode.RealEstates || this.viewMode == ViewMode.Suggestions) {
			var result = this.estateService.GetAllEntities();
			bool isAscending = this.EstateSortAscending.Checked;
			// searching by price/room count ranges
			result.SearchBy(dto => {
				bool fitsPrice = true;
				bool fitsRooms = true;
				if (
					this.SuggestionsFilterRequests.Checked
					&& this.suggestionModeClient != null
					&& this.clientService.EntityExists(this.suggestionModeClient.Value)
				) {
					// filter by client's request instead of search filters
					var client = this.clientService.GetEntityInfo(this.suggestionModeClient.Value)!;
					double tolerance = double.TryParse(this.PriceToleranceBox.Text,out double res) ? res : CLIENT_PRICE_TOLERANCE;
					fitsPrice =
						client.DesiredPrice >= dto.Price - tolerance
						&& client.DesiredPrice < dto.Price + tolerance;
					fitsRooms = client.DesiredRoomCount == dto.RoomCount;
					return fitsPrice && fitsRooms;
				}
				if (double.TryParse(this.EstateSearchPriceMin.Text,out double priceMin)) {
					fitsPrice = dto.Price >= priceMin;
				}
				if (double.TryParse(this.EstateSearchPriceMax.Text,out double priceMax)) {
					fitsPrice = fitsPrice && dto.Price < priceMax;
				}
				if (double.TryParse(this.EstateSearchRoomsMin.Text,out double roomsMin)) {
					fitsRooms = dto.RoomCount >= roomsMin;
				}
				if (double.TryParse(this.EstateSearchRoomsMax.Text,out double roomsMax)) {
					fitsRooms = fitsRooms && dto.RoomCount < roomsMax;
				}
				return fitsPrice && fitsRooms;
			}).SearchBy(dto => {
				// searching by search box inputs
				if (string.IsNullOrWhiteSpace(this.SearchBox.Text)) return true;
				string[] searchFilter = this.SearchBox.Text.Split(' ');
				Func<string,bool> contains = s => {
					return searchFilter.Any(text => s.Contains(text,StringComparison.CurrentCultureIgnoreCase));
				};
				if (
					!this.EstateSearchCountry.Checked
					&& !this.EstateSearchProvince.Checked
					&& !this.EstateSearchCity.Checked
					&& !this.EstateSearchZip.Checked
					&& contains(dto.ToString())
				) return true;
				if (
					this.EstateSearchCountry.Checked && contains(dto.Country)
				|| this.EstateSearchProvince.Checked && contains(dto.Provice)
				|| this.EstateSearchCity.Checked && contains(dto.City)
				|| this.EstateSearchZip.Checked && contains(dto.Zip)
				) return true;
				return false;
			});
			// sorting
			if (this.EstateSortCountry.Checked) result.SortBy(dto => dto.Country,isAscending);
			else if (this.EstateSortPrice.Checked) result.SortBy(dto => dto.Price,isAscending);
			else if (this.EstateSortRooms.Checked) result.SortBy(dto => dto.RoomCount,isAscending);
			else if (this.EstateSortDate.Checked) result.SortBy(dto => dto.CreatedAt,isAscending);
			else result.SortBy(dto => dto.ToString(),isAscending);

			entities = result.Entities;
		} else {
			var result = new FilterResult<IDTO>(this.clientService.GetAllEntities())
				.Append(this.estateService.GetAllEntities());
			var isAscending = this.CombinedSortAscending.Checked;
			// searching
			result.SearchBy(dto => {
				if (string.IsNullOrWhiteSpace(this.SearchBox.Text)) return true;
				string[] searchFilter = this.SearchBox.Text.Split(' ');
				string name = dto.ToString() ?? "";
				return searchFilter.Any(text => name.Contains(text,StringComparison.CurrentCultureIgnoreCase));
			});
			// sorting
			if (this.CombinedSortName.Checked) result.SortBy(dto => dto.ToString(),isAscending);
			else if (this.CombinedSortType.Checked) result.SortBy(dto => dto.GetType().Name,isAscending);
			else result.SortBy(dto => dto.CreatedAt,isAscending);

			entities = result.Entities;
		}

		foreach (IDTO i in entities) {
			if (i.Guid == null) continue;
			var label = new GuidLabel(i.Guid.Value) {
				BackColor = Colors.EntityLabel,
				ForeColor = Colors.EntityLabelText,
				Text = i.ToString(),
				Size = new Size(550,25),
				Font = new Font("Segoe UI",14f),
				AutoSize = false
			};
			this.EntityList.BackColor = Colors.EntityList;
			this.EmptyListLabel.Visible = false;
			this.EntityList.Controls.Add(label);
			label.Click += (sender,e) => {
				// clicking on an object label
				var label = (sender as GuidLabel)!;
				if (this.viewMode == ViewMode.Suggestions) {
					// if suggestion selector enabled add the real estate to the suggestion list
					if (this.suggestionModeClient == null) {
						MessageBox.Show(
							caption: "Oops!",
							text: "Something went wrong and we couldn't add a suggestions to this client!",
							buttons: MessageBoxButtons.OK,
							icon: MessageBoxIcon.Warning
						);
					} else {
						var result = this.clientService.AddSuggestion(this.suggestionModeClient.Value,label.Guid,this.estateService);
						MessageBox.Show(
							caption: result.Success ? "Success" : "Oops!",
							text: result.Success
								? $"Successfully added real estate [{this.estateService.GetEntityInfo(label.Guid)}] to suggestions"
								: $"Couldn't add suggestions. Error message: {result.Message}",
							buttons: MessageBoxButtons.OK,
							icon: result.Success ? MessageBoxIcon.Information : MessageBoxIcon.Warning
						);
					}
					this.suggestionModeClient = null;
					this.viewMode = ViewMode.RealEstates;
					toggleViewButtons();
				}
				// toggle selection
				if (this.selected != null) {
					this.selected.BackColor = Colors.EntityLabel;
					this.selected.ForeColor = Colors.EntityLabelText;
					this.selected.Font = new Font(selected.Font,FontStyle.Regular);
				}
				this.selected = label;
				label.BackColor = Colors.EntityLabelSelected;
				label.ForeColor = Colors.EntityLabelTextSelected;
				label.Font = new Font(label.Font,FontStyle.Bold);
				this.RemoveButton.Enabled = true;
				this.RemoveButton.BackColor = Colors.ActiveButton;
				this.InfoButton.Enabled = true;
				this.InfoButton.BackColor = Colors.ActiveButton;
				this.EditButton.Enabled = true;
				this.EditButton.BackColor = Colors.ActiveButton;
			};
			label.DoubleClick += this.InfoButton_Click;
		}
	}
	void ClientsView_Click(object? sender,EventArgs e) {
		if (this.viewMode == ViewMode.Clients || this.viewMode == ViewMode.Suggestions) return;
		this.viewMode = ViewMode.Clients;
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void EstateView_Click(object? sender,EventArgs e) {
		if (this.viewMode == ViewMode.RealEstates || this.viewMode == ViewMode.Suggestions) return;
		this.viewMode = ViewMode.RealEstates;
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void CombinedView_Click(object? sender,EventArgs e) {
		if (this.viewMode == ViewMode.Combined || this.viewMode == ViewMode.Suggestions) return;
		this.viewMode = ViewMode.Combined;
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void AddButton_Click(object sender,EventArgs e) {
		if (this.viewMode == ViewMode.Clients) {
			using var creationWin = new ClientCreateWindow(CreateWindowOpenModes.AddNew,context: this);
			creationWin.ShowDialog();
		} else if (this.viewMode == ViewMode.RealEstates) {
			using var creationWin = new RealEstateCreateWindow(CreateWindowOpenModes.AddNew,this.estateService);
			creationWin.ShowDialog();
		}
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void SaveButton_Click(object? sender,EventArgs e) {
		if (this.viewMode == ViewMode.Combined || this.viewMode == ViewMode.Suggestions) return;
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
	void LoadButton_Click(object? sender,EventArgs e) {
		if (this.viewMode == ViewMode.Combined || this.viewMode == ViewMode.Suggestions) return;
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
		if (this.selected == null || this.viewMode == ViewMode.Suggestions) return;
		Result removeResult;
		if (this.clientService.EntityExists(this.selected.Guid)) {
			removeResult = this.clientService.RemoveEntity(this.selected.Guid);
		} else {
			removeResult = this.estateService.RemoveEntity(this.selected.Guid);
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
		this.RemoveButton.BackColor = Colors.InactiveButton;
		this.InfoButton.Enabled = false;
		this.InfoButton.BackColor = Colors.InactiveButton;
		this.EditButton.Enabled = false;
		this.EditButton.BackColor = Colors.InactiveButton;
	}
	void EditButton_Click(object sender,EventArgs e) {
		if (this.selected == null || this.viewMode == ViewMode.Suggestions) return;
		if (this.clientService.EntityExists(this.selected.Guid)) {
			using var creationWin = new ClientCreateWindow(CreateWindowOpenModes.Edit,this,this.selected.Guid);
			creationWin.ShowDialog();
		} else {
			using var creationWin = new RealEstateCreateWindow(CreateWindowOpenModes.Edit,this.estateService,this.selected.Guid);
			creationWin.ShowDialog();
		}
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void InfoButton_Click(object? sender,EventArgs e) {
		if (this.selected == null || this.viewMode == ViewMode.Suggestions) return;
		if (this.clientService.EntityExists(this.selected.Guid)) {
			using var infoWin = new ClientInfoWindow(context: this,this.selected.Guid);
			infoWin.ShowDialog();
		} else {
			using var infoWin = new RealEstateInfoWindow(this.estateService,this.selected.Guid);
			infoWin.ShowDialog();
		}
		displayEntityList();
		toggleViewButtons();
		hideSortingLists();
	}
	void FilterButton_Click(object sender,EventArgs e) {
		UserInputsGroup panel;
		if (this.viewMode == ViewMode.Clients) {
			panel = this.ClientSortList;
		} else if (this.viewMode == ViewMode.RealEstates || this.viewMode == ViewMode.Suggestions) {
			panel = this.EstateSortList;
		} else if (this.viewMode == ViewMode.Combined) {
			panel = this.CombinedSortList;
		} else {
			return;
		}
		panel.Location = this.FilterButton.Location + new Size(0,this.FilterButton.Height);
		panel.Visible = !panel.Visible;
	}
	void SearchDropdownButton_Click(object sender,EventArgs e) {
		UserInputsGroup panel;
		if (this.viewMode == ViewMode.Clients) {
			panel = this.ClientSearchList;
		} else if (this.viewMode == ViewMode.RealEstates || this.viewMode == ViewMode.Suggestions) {
			panel = this.EstateSearchList;
		} else {
			return;
		}
		panel.Location = this.SearchDropdownButton.Location + new Size(
			this.SearchDropdownButton.Width - panel.Width,
			this.SearchDropdownButton.Height
		);
		panel.Visible = !panel.Visible;
	}
	void SearchBox_KeyDown(object sender,KeyEventArgs e) {
		// automatically update the list when you hit enter or space
		if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space) {
			displayEntityList();
		}
	}
	void SearchBox_TextChanged(object sender,EventArgs e) {
		// automatically update the list if you enter the third character or the input is cleared
		// no automatic updates every for every key stroke to prevent too many queries
		if (this.SearchBox.Text.Length == 0 || this.SearchBox.Text.Length == 3) {
			displayEntityList();
		}
	}
	void PriceToleranceBox_KeyDown(object sender,KeyEventArgs e) {
		if (e.KeyCode == Keys.Enter) {
			displayEntityList();
		}
	}
}

namespace Coursework.PresentationLevel;

public class RadioButtonGroup : Panel {
	public event Action? RadioButtonChecked;

	public RadioButtonGroup() {
		this.ControlAdded += (sender,e) => {
			if (e.Control is RadioButton rb) {
				rb.CheckedChanged += this.onRadioChanged;
			} else if (e.Control is CheckBox cb) {
				cb.CheckedChanged += this.onCheckChanged;
			}
		};
	}

	private void onRadioChanged(object? sender,EventArgs e) {
		if (sender is not RadioButton rb || !rb.Checked) return;
		this.RadioButtonChecked?.Invoke();
	}
	private void onCheckChanged(object? sender,EventArgs e) {
		if (sender is not CheckBox cb) return;
		this.RadioButtonChecked?.Invoke();
	}
}
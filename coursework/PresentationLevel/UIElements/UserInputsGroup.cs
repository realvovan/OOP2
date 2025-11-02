namespace Coursework.PresentationLevel;

/// <summary>
/// Panel that is meant to store <see cref="RadioButton"/> / <see cref="CheckBox"/> / <see cref="TextBox"/>
/// to notify about their changed state
/// </summary>
public class UserInputsGroup : Panel {
	/// <summary>
	/// Fired when one of the child's visible state is changed: checkbox or radio button checked, or text box's text is changed
	/// </summary>
	public event Action? ChildChanged;

	public UserInputsGroup() {
		this.ControlAdded += (sender,e) => {
			if (e.Control is RadioButton rb) {
				rb.CheckedChanged += onChildChanged;
			} else if (e.Control is CheckBox cb) {
				cb.CheckedChanged += onChildChanged;
			} else if (e.Control is TextBox tb) {
				tb.TextChanged += onChildChanged;
			}
		};
	}
	private void onChildChanged(object? sender,EventArgs e) {
		this.ChildChanged?.Invoke();
	}
}
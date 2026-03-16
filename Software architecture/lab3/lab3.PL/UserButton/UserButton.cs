namespace lab3.PL;

public class UserButton : Button {
	private Color _baseColor;
	private Font _baseFont;
	public UserButton() {
		this._baseColor = this.BackColor;
		this._baseFont = this.Font;
	}
	public void Disable() {
		if (!this.Enabled) return; 
		this.Enabled = false;
		this._baseFont = this.Font;
		this._baseColor = this.BackColor;
		this.BackColor = SystemColors.ControlDark;
		this.Font = new Font(this._baseFont,FontStyle.Italic);
		this.Font = new Font(this._baseFont,FontStyle.Italic);
	}
	public void Enable() {
		if (this.Enabled) return;
		this.Enabled = true;
		this.BackColor = this._baseColor;
		this.Font = new Font(this._baseFont,FontStyle.Regular);
	}
	public void SetEnabled(bool enabled) {
		if (enabled) this.Enable();
		else this.Disable();
	}
}
namespace SoftwareDesign.lab2.Views;

partial class LoginPage
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
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
		this.UsernameBox = new TextBox();
		this.label1 = new Label();
		this.LoginButton = new Button();
		this.SignupButton = new Button();
		this.SuspendLayout();
		// 
		// UsernameBox
		// 
		this.UsernameBox.Font = new Font("Segoe UI",14F);
		this.UsernameBox.Location = new Point(12,59);
		this.UsernameBox.Name = "UsernameBox";
		this.UsernameBox.Size = new Size(314,32);
		this.UsernameBox.TabIndex = 0;
		this.UsernameBox.Enter += this.UsernameBox_Enter;
		// 
		// label1
		// 
		this.label1.AutoSize = true;
		this.label1.Font = new Font("Segoe UI",20F,FontStyle.Bold);
		this.label1.Location = new Point(12,19);
		this.label1.Name = "label1";
		this.label1.Size = new Size(153,37);
		this.label1.TabIndex = 1;
		this.label1.Text = "Username:";
		// 
		// LoginButton
		// 
		this.LoginButton.AutoSize = true;
		this.LoginButton.Font = new Font("Segoe UI",12F);
		this.LoginButton.Location = new Point(170,109);
		this.LoginButton.Name = "LoginButton";
		this.LoginButton.Size = new Size(75,31);
		this.LoginButton.TabIndex = 2;
		this.LoginButton.Text = "Log in";
		this.LoginButton.UseVisualStyleBackColor = true;
		this.LoginButton.Click += this.LoginButton_Click;
		// 
		// SignupButton
		// 
		this.SignupButton.AutoSize = true;
		this.SignupButton.Font = new Font("Segoe UI",12F);
		this.SignupButton.Location = new Point(251,109);
		this.SignupButton.Name = "SignupButton";
		this.SignupButton.Size = new Size(75,31);
		this.SignupButton.TabIndex = 3;
		this.SignupButton.Text = "Sign up";
		this.SignupButton.UseVisualStyleBackColor = true;
		this.SignupButton.Click += this.SignupButton_Click;
		// 
		// LoginPage
		// 
		this.AutoScaleDimensions = new SizeF(7F,15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.ClientSize = new Size(338,154);
		this.Controls.Add(this.SignupButton);
		this.Controls.Add(this.LoginButton);
		this.Controls.Add(this.label1);
		this.Controls.Add(this.UsernameBox);
		this.FormBorderStyle = FormBorderStyle.FixedSingle;
		this.MaximizeBox = false;
		this.Name = "LoginPage";
		this.Text = "Login";
		this.ResumeLayout(false);
		this.PerformLayout();
	}

	#endregion

	private TextBox UsernameBox;
	private Label label1;
	private Button LoginButton;
	private Button SignupButton;
}

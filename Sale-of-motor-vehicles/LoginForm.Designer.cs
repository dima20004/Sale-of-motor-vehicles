
namespace Sale_of_motor_vehicles {
	partial class LoginForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.loginTextbox = new System.Windows.Forms.TextBox();
			this.passwordTextbox = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.logInButton = new System.Windows.Forms.Button();
			this.registerButton = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.statusTooltip = new System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.loginTextbox, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.passwordTextbox, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.statusLabel, 0, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(386, 193);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(23, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Логин:";
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(23, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(57, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Пароль:";
			// 
			// loginTextbox
			// 
			this.loginTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.loginTextbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.loginTextbox.Location = new System.Drawing.Point(86, 23);
			this.loginTextbox.Name = "loginTextbox";
			this.loginTextbox.Size = new System.Drawing.Size(277, 25);
			this.loginTextbox.TabIndex = 2;
			// 
			// passwordTextbox
			// 
			this.passwordTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.passwordTextbox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.passwordTextbox.Location = new System.Drawing.Point(86, 54);
			this.passwordTextbox.Name = "passwordTextbox";
			this.passwordTextbox.Size = new System.Drawing.Size(277, 25);
			this.passwordTextbox.TabIndex = 3;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.logInButton, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.registerButton, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 85);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(340, 35);
			this.tableLayoutPanel2.TabIndex = 5;
			// 
			// logInButton
			// 
			this.logInButton.AutoSize = true;
			this.logInButton.BackColor = System.Drawing.Color.SlateBlue;
			this.logInButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logInButton.FlatAppearance.BorderSize = 0;
			this.logInButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
			this.logInButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumPurple;
			this.logInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.logInButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.logInButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.logInButton.Location = new System.Drawing.Point(3, 3);
			this.logInButton.Name = "logInButton";
			this.logInButton.Size = new System.Drawing.Size(164, 29);
			this.logInButton.TabIndex = 4;
			this.logInButton.Text = "Войти";
			this.logInButton.UseVisualStyleBackColor = false;
			this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
			// 
			// registerButton
			// 
			this.registerButton.AutoSize = true;
			this.registerButton.BackColor = System.Drawing.Color.Transparent;
			this.registerButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.registerButton.FlatAppearance.BorderSize = 0;
			this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.registerButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.registerButton.Location = new System.Drawing.Point(173, 3);
			this.registerButton.Name = "registerButton";
			this.registerButton.Size = new System.Drawing.Size(164, 29);
			this.registerButton.TabIndex = 5;
			this.registerButton.Text = "Регистрация";
			this.registerButton.UseVisualStyleBackColor = false;
			this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.statusLabel, 2);
			this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statusLabel.ForeColor = System.Drawing.Color.Firebrick;
			this.statusLabel.Location = new System.Drawing.Point(23, 123);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(340, 50);
			this.statusLabel.TabIndex = 6;
			// 
			// LoginForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 193);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "LoginForm";
			this.Text = "Войти";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox loginTextbox;
		private System.Windows.Forms.TextBox passwordTextbox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button logInButton;
		private System.Windows.Forms.Button registerButton;
		private System.Windows.Forms.Label statusLabel;
		private System.Windows.Forms.ToolTip statusTooltip;
	}
}
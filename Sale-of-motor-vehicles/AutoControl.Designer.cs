
namespace Sale_of_motor_vehicles {
	partial class AutoControl {
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent() {
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.NameLabel = new System.Windows.Forms.Label();
			this.priceLabel = new System.Windows.Forms.Label();
			this.characteristicsLabel = new System.Windows.Forms.Label();
			this.descrtiptionLabel = new System.Windows.Forms.Label();
			this.showButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
			this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 152);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(10, 10);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(167, 132);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
			this.tableLayoutPanel2.Controls.Add(this.NameLabel, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.priceLabel, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.characteristicsLabel, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.descrtiptionLabel, 0, 3);
			this.tableLayoutPanel2.Controls.Add(this.showButton, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(182, 10);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(391, 132);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// NameLabel
			// 
			this.NameLabel.AutoSize = true;
			this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.NameLabel.Location = new System.Drawing.Point(3, 0);
			this.NameLabel.Name = "NameLabel";
			this.NameLabel.Size = new System.Drawing.Size(46, 20);
			this.NameLabel.TabIndex = 0;
			this.NameLabel.Text = "name";
			// 
			// priceLabel
			// 
			this.priceLabel.AutoSize = true;
			this.priceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.priceLabel.Location = new System.Drawing.Point(3, 20);
			this.priceLabel.Name = "priceLabel";
			this.priceLabel.Size = new System.Drawing.Size(33, 15);
			this.priceLabel.TabIndex = 1;
			this.priceLabel.Text = "price";
			// 
			// characteristicsLabel
			// 
			this.characteristicsLabel.AutoSize = true;
			this.tableLayoutPanel2.SetColumnSpan(this.characteristicsLabel, 2);
			this.characteristicsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.characteristicsLabel.Location = new System.Drawing.Point(3, 35);
			this.characteristicsLabel.Name = "characteristicsLabel";
			this.characteristicsLabel.Size = new System.Drawing.Size(82, 15);
			this.characteristicsLabel.TabIndex = 2;
			this.characteristicsLabel.Text = "characteristics";
			// 
			// descrtiptionLabel
			// 
			this.descrtiptionLabel.AutoEllipsis = true;
			this.tableLayoutPanel2.SetColumnSpan(this.descrtiptionLabel, 2);
			this.descrtiptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.descrtiptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.descrtiptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.descrtiptionLabel.Location = new System.Drawing.Point(3, 50);
			this.descrtiptionLabel.Name = "descrtiptionLabel";
			this.descrtiptionLabel.Size = new System.Drawing.Size(385, 82);
			this.descrtiptionLabel.TabIndex = 3;
			this.descrtiptionLabel.Text = "descrtiption";
			// 
			// showButton
			// 
			this.showButton.AutoSize = true;
			this.showButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.showButton.BackColor = System.Drawing.Color.SlateBlue;
			this.showButton.Dock = System.Windows.Forms.DockStyle.Fill;
			this.showButton.FlatAppearance.BorderSize = 0;
			this.showButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.showButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.showButton.Location = new System.Drawing.Point(303, 3);
			this.showButton.Name = "showButton";
			this.tableLayoutPanel2.SetRowSpan(this.showButton, 2);
			this.showButton.Size = new System.Drawing.Size(85, 29);
			this.showButton.TabIndex = 4;
			this.showButton.Text = "Просмотреть";
			this.showButton.UseVisualStyleBackColor = false;
			this.showButton.Click += new System.EventHandler(this.showButton_Click);
			// 
			// AutoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "AutoControl";
			this.Size = new System.Drawing.Size(583, 152);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label NameLabel;
		private System.Windows.Forms.Label priceLabel;
		private System.Windows.Forms.Label characteristicsLabel;
		private System.Windows.Forms.Label descrtiptionLabel;
		private System.Windows.Forms.Button showButton;
	}
}

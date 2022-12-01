
namespace Sale_of_motor_vehicles {
	partial class CriteriaForm {
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.addCriteriaButton = new System.Windows.Forms.Button();
			this.criteriaTable = new System.Windows.Forms.TableLayoutPanel();
			this.criteriaTypeCombobox = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.addCriteriaButton, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.criteriaTable, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.criteriaTypeCombobox, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(263, 107);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(23, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 31);
			this.label1.TabIndex = 0;
			this.label1.Text = "Критерий:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(23, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 17);
			this.label2.TabIndex = 1;
			this.label2.Text = "Значение:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// addCriteriaButton
			// 
			this.addCriteriaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.addCriteriaButton.AutoSize = true;
			this.addCriteriaButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.addCriteriaButton.BackColor = System.Drawing.Color.SlateBlue;
			this.tableLayoutPanel1.SetColumnSpan(this.addCriteriaButton, 2);
			this.addCriteriaButton.FlatAppearance.BorderSize = 0;
			this.addCriteriaButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SlateBlue;
			this.addCriteriaButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSlateBlue;
			this.addCriteriaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.addCriteriaButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.addCriteriaButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.addCriteriaButton.Location = new System.Drawing.Point(164, 71);
			this.addCriteriaButton.Name = "addCriteriaButton";
			this.addCriteriaButton.Size = new System.Drawing.Size(76, 27);
			this.addCriteriaButton.TabIndex = 2;
			this.addCriteriaButton.Text = "Добавить";
			this.addCriteriaButton.UseVisualStyleBackColor = false;
			this.addCriteriaButton.Click += new System.EventHandler(this.addCriteriaButton_Click);
			// 
			// criteriaTable
			// 
			this.criteriaTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.criteriaTable.AutoSize = true;
			this.criteriaTable.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.criteriaTable.ColumnCount = 1;
			this.criteriaTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.criteriaTable.Location = new System.Drawing.Point(94, 59);
			this.criteriaTable.Margin = new System.Windows.Forms.Padding(0);
			this.criteriaTable.Name = "criteriaTable";
			this.criteriaTable.RowCount = 1;
			this.criteriaTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.criteriaTable.Size = new System.Drawing.Size(149, 0);
			this.criteriaTable.TabIndex = 3;
			// 
			// criteriaTypeCombobox
			// 
			this.criteriaTypeCombobox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.criteriaTypeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.criteriaTypeCombobox.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.criteriaTypeCombobox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.criteriaTypeCombobox.FormattingEnabled = true;
			this.criteriaTypeCombobox.Location = new System.Drawing.Point(97, 23);
			this.criteriaTypeCombobox.Name = "criteriaTypeCombobox";
			this.criteriaTypeCombobox.Size = new System.Drawing.Size(143, 25);
			this.criteriaTypeCombobox.TabIndex = 4;
			this.criteriaTypeCombobox.SelectedIndexChanged += new System.EventHandler(this.criteriaTypeCombobox_SelectedIndexChanged);
			// 
			// CriteriaForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(263, 107);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "CriteriaForm";
			this.Text = "Добавение критерия";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button addCriteriaButton;
		private System.Windows.Forms.TableLayoutPanel criteriaTable;
		private System.Windows.Forms.ComboBox criteriaTypeCombobox;
	}
}
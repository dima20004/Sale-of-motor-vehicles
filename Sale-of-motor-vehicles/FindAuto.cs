using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles {
	public partial class FindAuto : Form {
		private Context context;

		private CriteriaList critList;
		public FindAuto(Context context) {
			this.context = context;
			this.critList = new CriteriaList(context.criteria);

			InitializeComponent();
		}

		void updateLoginDisplay() {
			if(context.customer.LoggedIn) {
				loginButton.Text = "Выйти";
			}
			else {
				loginButton.Text = "Вход/Регистрация";
			}
		}

		private void acountLabel_Click(object sender, EventArgs e) {
			new AutoAddForm(context).ShowDialog();
		}

		private void loginButton_Click(object sender, EventArgs e) {
			if(context.customer.LoggedIn) {
				context.customer.logOut();
				updateLoginDisplay();
			}
			else {
				var result = new LoginForm(context).ShowDialog();
				if(result == DialogResult.OK) {
					updateLoginDisplay();
				}
			}
		}

		private void addCriteriaButton_Click(object sender, EventArgs e) {
			var form = new CriteriaForm(context, null);
			if(form.ShowDialog() == DialogResult.OK) {
				critList.Add(form.criterium);
				
				updateCritListDisplay();
			}
		}
		private void updateCritListDisplay() {
			var cl = critList.List;

			criteriaTable.SuspendLayout();
			criteriaTable.Controls.Clear();
			criteriaTable.RowStyles.Clear();
			criteriaTable.RowCount = cl.Count + 1;


			for(int i = 0; i < cl.Count; i++) {
				var it = cl[i];

				var j = i;
				EventHandler eh = (a, b) => {
					var form = new CriteriaForm(context, it);
					if(form.ShowDialog() == DialogResult.OK) {
						critList.List.RemoveAt(j);
						critList.Add(form.criterium);
						updateCritListDisplay();
					}
				};

				criteriaTable.RowStyles.Add(new RowStyle(SizeType.AutoSize)); 

				var c1 = new Label();
				c1.AutoSize = true;
				c1.Text = context.criteria.name(it.type);
				c1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
				c1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				c1.TextAlign = ContentAlignment.MiddleLeft;
				c1.Click += eh;

				criteriaTable.Controls.Add(c1, 1, i);

				var c2 = new Label();
				c2.AutoSize = true;
				c2.Text = context.criteria.valueString(it.type, it.value);
				c2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
				c2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
				c2.TextAlign = ContentAlignment.MiddleLeft;
				c2.Click += eh;

				criteriaTable.Controls.Add(c2, 2, i);

				var c3 = new Label();
				c3.AutoSize = true;
				c3.Text = "x";
				c3.ForeColor = Color.Firebrick;
				c3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
				c3.Dock = DockStyle.Fill;
				c3.TextAlign = ContentAlignment.MiddleCenter;
				c3.Click += (a, b) => { critList.List.RemoveAt(j); updateCritListDisplay(); };

				criteriaTable.Controls.Add(c3, 0, i);
			}

			criteriaTable.RowStyles.Add(new RowStyle(SizeType.Percent, 1));

			criteriaTable.ResumeLayout(false);
			criteriaTable.PerformLayout();
		}

		private void findButton_Click(object sender, EventArgs e) {
			var result = context.messaging.attempt((it) => it.findAdverts(critList.List));
			if(result) {
				autosTable.SuspendLayout();
				autosTable.Controls.Clear();
				autosTable.RowStyles.Clear();
				autosTable.RowCount = 0;

				var autos = result.s;

				if(autos.Count == 0) {
					autosTable.RowStyles.Add(new RowStyle(SizeType.AutoSize));
					autosTable.RowCount++;
					autosTable.Controls.Add(new Label{ 
						Text = "Объявлений нет", Font =  new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204),
						TextAlign = ContentAlignment.TopCenter,
						Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
					});
				}
				else for(int i = 0; i < autos.Count; i++) {
					var auto = autos[i];
					var cont = new AutoControl(context, auto){
						Margin = new Padding(0, 0, 0, 10),
						Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
					};
					autosTable.Controls.Add(cont, 0, autosTable.RowCount++);
				}

				autosTable.ResumeLayout(false);
				autosTable.PerformLayout();
			}
		}
	}
}

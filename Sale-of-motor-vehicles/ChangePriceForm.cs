﻿using Autos;
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
	public partial class ChangePriceForm : Form {
		private Context context;
		private Auto auto;

		public int newPrice{ get; private set; }

		public ChangePriceForm(Context context, Auto auto) {
			this.context = context;
			this.auto = auto;

			InitializeComponent();

			numericUpDown1.Value = auto.priceRub;
		}

		private void buyButton_Click(object sender, EventArgs e) {
			var np = (int) numericUpDown1.Value;
			var res = context.messaging.attempt((it) => it.buyAdvert(auto.id, np));

			if(res) {
				newPrice = np;
				DialogResult = DialogResult.OK;
			}
			else {
				DialogResult = DialogResult.Cancel;
			}
		}
	}
}
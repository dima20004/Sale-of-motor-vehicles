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
	public partial class AnalysisForm : Form {
		public AnalysisForm(Context context) {
			InitializeComponent();

			var res = context.messaging.attempt((it) => it.getStatistics());

			if(res) {
				var s = res.s;
				autosCount.Text = s.autosCount + " шт.";
				soldOutCount.Text = s.soldOutCount + " шт.";
				soldPriceSum.Text = s.soldOutPriceSum + " руб.";
				discountSum.Text = s.discountSum + " руб.";
			}
			else {
				autosCount.Text = "Ошибка";
				soldOutCount.Text = "Ошибка";
				soldPriceSum.Text = "Ошибка";
				discountSum.Text = "Ошибка";
			}
		}
	}
}

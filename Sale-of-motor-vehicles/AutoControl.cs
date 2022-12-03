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
	public partial class AutoControl : UserControl {
		private Context context;
		private Autos.Auto auto;
		public AutoControl(Context context, Autos.Auto auto) {
			this.context = context;
			this.auto = auto;

			InitializeComponent();

			NameLabel.Text = context.criteria.valueString(Criteria.CriteriumType.brand, auto.brand)
				+ " " + auto.model;

			pictureBox1.Image = decodeImage(auto.image);

			priceLabel.Text = auto.priceRub + "руб.";
			characteristicsLabel.Text = auto.mileageKm + "км., " + auto.enginePower + "л.с., "
				+ Autos.Names.typeName(auto.type) + ", " + Autos.Names.EngineTypeName(auto.engineType);

			descrtiptionLabel.Text = auto.description;
		}

		private Image decodeImage(byte[] img) {
			if(img == null) return null;
			else using(var s = new System.IO.MemoryStream(auto.image, false)) {
				return Image.FromStream(s);
			}
		}

		private void showButton_Click(object sender, EventArgs e) {
			new AutoAddForm(context, auto, true).ShowDialog();
		}
	}
}

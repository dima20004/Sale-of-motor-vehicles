using Autos;
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
	public partial class AutoAddForm : Form {
		private Context context;
		public AutoAddForm(Context context) {
			this.context = context;

			InitializeComponent();

			brandCB.DataSource = new BindingSource{ 
				DataSource = context.criteria.values(Criteria.CriteriumType.brand)
			};
			brandCB.DisplayMember = "Value";
			transCB.DataSource = new BindingSource{ 
				DataSource = new EnumCollection<Autos.Transmission>(
					(i) => Autos.Names.TransName(i)
				)
			};
			typeCB.DataSource = new BindingSource{ 
				DataSource = new EnumCollection<Autos.Type>(
					(i) => Autos.Names.typeName(i)
				)
			};
			engineTypeCB.DataSource = new BindingSource{ 
				DataSource = new EnumCollection<Autos.EngineType>(
					(i) => Autos.Names.EngineTypeName(i)
				)
			};
			stWheelCB.DataSource = new BindingSource{ 
				DataSource = new EnumCollection<Autos.StWheel>(
					(i) => Autos.Names.stWheelName(i)
				)
			};
			colorCB.DataSource = new BindingSource{ 
				DataSource = new EnumCollection<Autos.Color>(
					(i) => Autos.Names.colorName(i)
				)
			};
		}

		private void addButton_Click(object sender, EventArgs e) {
			var result = context.messaging.attempt((it) => {
				var val = new Auto();
				val.brand = ((KeyValuePair<int, object>) brandCB.SelectedItem).Key;
				val.model = modelTB.Text;
				val.manufYear = (int) manufYearNUD.Value;
				val.trans = enumAt<Transmission>(transCB.SelectedIndex);
				val.type = enumAt<Autos.Type>(typeCB.SelectedIndex);
				val.engineType = enumAt<EngineType>(engineTypeCB.SelectedIndex);
				val.mileageKm = (int) mileageNUD.Value;
				val.stWheel = enumAt<StWheel>(stWheelCB.SelectedIndex);
				val.enginePower = (int) enginePowerNUD.Value;
				val.color = enumAt<Autos.Color>(colorCB.SelectedIndex);
				val.ownersCount = (sbyte) ownersCountNUD.Value;
				val.aquisitionDate = aquDateDTP.Value; 
				val.description = descriptionTextbox.Text;
				val.priceRub = (int) priceNUD.Value;
				it.addAdvert(val);
			});

			if(result) {
				statusLabel.ForeColor = System.Drawing.Color.Black;
				statusLabel.Text = "Объявление добавлено";
				addButton.Enabled = false;
			}
			else {
				statusLabel.ForeColor = System.Drawing.Color.Firebrick;
				statusLabel.Text = result.f.Message;
			}
		}

		private static T enumAt<T>(int i) where T : Enum {
			return (T) Enum.GetValues(typeof(T)).GetValue(i);
		}

		private void pictureBox1_Click(object sender, EventArgs e) {
			openFileDialog1.Filter = "Изображения | *.BMP;*.JPG;*.JPEG;*.PNG";
			if(openFileDialog1.ShowDialog() == DialogResult.OK) {
				var newImage = new Bitmap(new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open));
				pictureBox1.Image?.Dispose();
				pictureBox1.Image = newImage;
			}
		}

		private void deleteImageLabel_Click(object sender, EventArgs e) {
			var it = pictureBox1.Image;
			pictureBox1.Image = null;
			it.Dispose();
		}
	}
}

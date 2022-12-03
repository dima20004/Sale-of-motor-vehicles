using Autos;
using Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles {
	public partial class AutoAddForm : Form {
		private Context context;
		private Auto auto; 
		private bool viewing;

		private bool canEdit{ get{ return auto?.owner == null || auto?.owner == context.customer.account?.id; } }

		public AutoAddForm(Context context, Auto auto, bool viewing) {
			this.context = context;
			this.viewing = viewing;
			this.auto = auto;

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

			pictureBox1.Image = decodeImage(auto?.image);

			updateEditMode();
		}

		private Image decodeImage(byte[] img) {
			if(img == null) return null;
			else using(var s = new System.IO.MemoryStream(auto.image, false)) {
				return Image.FromStream(s);
			}
		}

		private void updateEditMode() {
			var en = !viewing;
			var br = viewing ? BorderStyle.None : BorderStyle.FixedSingle;
			
			pictureBox1.Enabled = en;
			brandCB.Enabled = en;
			modelTB.Enabled = en;
			manufYearNUD.Enabled = en;
			transCB.Enabled = en;
			typeCB.Enabled = en;
			enginePowerNUD.Enabled = en;
			mileageNUD.Enabled = en;
			stWheelCB.Enabled = en;
			enginePowerNUD.Enabled = en;
			colorCB.Enabled = en;
			ownersCountNUD.Enabled = en;
			aquDateDTP.Enabled = en;
			priceNUD.Enabled = en;
			descriptionTextbox.Enabled = en;
			deleteImageLabel.Visible = en;

			pictureBox1.BackColor = System.Drawing.Color.White;
			brandCB.BackColor = System.Drawing.Color.White;
			modelTB.BackColor = System.Drawing.Color.White;
			manufYearNUD.BackColor = System.Drawing.Color.White;
			transCB.BackColor = System.Drawing.Color.White;
			typeCB.BackColor = System.Drawing.Color.White;
			enginePowerNUD.BackColor = System.Drawing.Color.White;
			mileageNUD.BackColor = System.Drawing.Color.White;
			stWheelCB.BackColor = System.Drawing.Color.White;
			enginePowerNUD.BackColor = System.Drawing.Color.White;
			colorCB.BackColor = System.Drawing.Color.White;
			ownersCountNUD.BackColor = System.Drawing.Color.White;
			aquDateDTP.BackColor = System.Drawing.Color.White;
			priceNUD.BackColor = System.Drawing.Color.White;
			descriptionTextbox.BackColor = System.Drawing.Color.White;
			deleteImageLabel.BackColor = System.Drawing.Color.White;

			modelTB.BorderStyle = br;
			modelTB.BorderStyle = br;
			manufYearNUD.BorderStyle = br;
			enginePowerNUD.BorderStyle = br;
			mileageNUD.BorderStyle = br;
			enginePowerNUD.BorderStyle = br;
			ownersCountNUD.BorderStyle = br;
			priceNUD.BorderStyle = br;
			descriptionTextbox.BorderStyle = br;
			deleteImageLabel.BorderStyle = br;

			button3.Text = canEdit ? "Удалить" : "Купить";
			button3.Visible = auto != null;
			
			if(viewing) {
				if(canEdit) {
					button2.Visible = true;
					button2.Text = "Выйти";

					button1.Visible = true;
					button1.Text = "Изменить";
				}
				else {
					button2.Visible = true;
					button2.Text = "Выйти";

					button1.Visible = false;
				}
			}
			else {
				if(auto == null) {
					button2.Visible = true;
					button2.Text = "Добавить";

					button1.Visible = true;
					button1.Text = "Отменить";
				}
				else {
					button2.Visible = true;
					button2.Text = "Сохранить";

					button1.Visible = true;
					button1.Text = "Отменить";
				}
			}
		}

		private static T enumAt<T>(int i) where T : Enum {
			return (T) Enum.GetValues(typeof(T)).GetValue(i);
		}

		private void pictureBox1_Click(object sender, EventArgs e) {
			openFileDialog1.Filter = "Изображения | *.BMP;*.JPG;*.JPEG;*.PNG";
			if(openFileDialog1.ShowDialog() == DialogResult.OK) {
				using(var fs = new System.IO.FileStream(openFileDialog1.FileName, System.IO.FileMode.Open)) {
				var newImage = Image.FromStream(fs);
				pictureBox1.Image?.Dispose();
				pictureBox1.Image = newImage;
			}}
		}

		private void deleteImageLabel_Click(object sender, EventArgs e) {
			pictureBox1.Image?.Dispose();
			pictureBox1.Image = null;
		}

		private void button2_Click(object sender, EventArgs e) {
			if(viewing) {
				DialogResult = DialogResult.Cancel;
			}
			else {
				var val = new Auto();
				val.owner = context.customer.account.Value.id;
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
				val.image = getImageBytes(pictureBox1.Image);

				if(auto == null) {
					var result = context.messaging.attempt((it) => {
						it.addAdvert(context.customer.accountData, val);
					});

					if(result) {
						statusLabel.ForeColor = System.Drawing.Color.Black;
						statusLabel.Text = "Объявление добавлено";
						
						viewing = true;
						auto = val;

						updateEditMode();
					}
					else {
						statusLabel.ForeColor = System.Drawing.Color.Firebrick;
						statusLabel.Text = result.f.Message;
					}
				}
				else {
					val.id = auto.id;

					var result = context.messaging.attempt((it) => {
						it.addAdvert(context.customer.accountData, val);
					});

					if(result) {
						statusLabel.ForeColor = System.Drawing.Color.Black;
						statusLabel.Text = "Объявление изменено";
						
						viewing = true;
						auto = val;

						updateEditMode();
					}
					else {
						statusLabel.ForeColor = System.Drawing.Color.Firebrick;
						statusLabel.Text = result.f.Message;
					}
				}
			}
		}


		private byte[] getImageBytes(Image img) {
			if(img == null) return null;
			else using(var it = new System.IO.MemoryStream()) {
			using(var img2 = new Bitmap(img)) {
				img2.Save(it, System.Drawing.Imaging.ImageFormat.Jpeg);
				return it.ToArray();
			}}
		}
		private void button1_Click(object sender, EventArgs e) {
			if(viewing && canEdit) {
				viewing = false;
				updateEditMode();
			}
			else if(!viewing) {
				viewing = true;
				updateEditMode();
			}
		}

		private void button3_Click(object sender, EventArgs e) {
			if(canEdit) {
				if(auto == null) return;

				var res = context.messaging.attempt((it) => it.deleteAdvert(context.customer.accountData, auto.id));

				if(res) {
					statusLabel.ForeColor = System.Drawing.Color.Black;
					statusLabel.Text = "Объявление удалено";

					auto = null;
					viewing = true;

					updateEditMode();
				}
				else {
					statusLabel.ForeColor = System.Drawing.Color.Firebrick;
					statusLabel.Text = res.f.Message;
				}
			}
			else {
				var form = new ChangePriceForm(context, auto);
				if(form.ShowDialog() == DialogResult.OK) {
					statusLabel.ForeColor = System.Drawing.Color.Black;
					statusLabel.Text = "Объявление  продано за " + form.newPrice + " руб.";
				}
				else {
					statusLabel.ForeColor = System.Drawing.Color.Firebrick;
					statusLabel.Text = "Продажа отменена";
				}
			}
		}
	}
}

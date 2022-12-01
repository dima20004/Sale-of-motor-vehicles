using System;
using Common;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles {
	public partial class RegisterForm : Form {
		public Context context;

		public RegisterForm(Context context) {
			this.context = context;
			InitializeComponent();
		}

		private void registerButton_Click(object sender, EventArgs e) {
			var accountCand = new Accounts.AccountData{ login = loginTextbox.Text, pass = passwordTextbox.Text };
			var result = context.messaging.attempt((it) => it.register(accountCand, nameTextbox.Text, surnameTextbox.Text));
			if(result) {
				if(result.s) DialogResult = DialogResult.OK;
				else {
					statusLabel.Text = "Невозможно зарегестрировать аккаунт";
					statusTooltip.SetToolTip(statusLabel, "Неизвестная ошибка");
				}
			}
			else {
				statusLabel.Text = result.f.Message;
				statusTooltip.SetToolTip(statusLabel, result.f.Message);
			}
		}
	}
}

using System;
using Common;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles {
	public partial class LoginForm : Form {
		private Context context;
		public LoginForm(Context context) {
			this.context = context;
			InitializeComponent();
		}

		private void logInButton_Click(object sender, EventArgs e) {
			var accountCand = new Accounts.AccountData{ login = loginTextbox.Text, pass = passwordTextbox.Text };
			var result = context.messaging.attempt((it) => it.login(accountCand));
			if(result) {
				if(result.s.HasValue) {
					context.customer.logIn(accountCand, result.s.Value);
					DialogResult = DialogResult.OK;
				}
				else {
					statusLabel.Text = "Невозможно войти в аккаунт";
					statusTooltip.SetToolTip(statusLabel, "Неизвестная ошибка");
				}
			}
			else {
				statusLabel.Text = result.f.Message;
				statusTooltip.SetToolTip(statusLabel, result.f.Message);
			}
		}

		private void registerButton_Click(object sender, EventArgs e) {
			new RegisterForm(context).ShowDialog();
		}
	}
}

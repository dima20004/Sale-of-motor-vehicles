using ClientMessaging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Sale_of_motor_vehicles {
	public partial class Авторизация : Form {
		private Context context;

		public Авторизация(Context context) {
			this.context = context;

			InitializeComponent();

			passField.UseSystemPasswordChar=true;
			loginField.Text = "Введите логин";
			loginField.ForeColor = Color.Blue;
			passField.Text = "Введите пароль";
			passField.ForeColor= Color.Blue;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

		private void label3_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void label2_Click(object sender, EventArgs e) {
			this.WindowState = FormWindowState.Minimized;
		}
		Point lastPoint;
		private void label1_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}
		private void label1_MouseDown(object sender, MouseEventArgs e) {
			lastPoint = new Point(e.X, e.Y);
		}
		private void panel1_MouseDown(object sender, MouseEventArgs e) {
			lastPoint=new Point(e.X,e.Y);
		}
		
		private void panel1_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				this.Left += e.X - lastPoint.X;
				this.Top += e.Y - lastPoint.Y;
			}
		}

		private void buttonLogin_Click(object sender, EventArgs e) {
			string loginUser = loginField.Text;
            string passUser = passField.Text;
         

            if (loginUser == "Введите логин") {
                MessageBox.Show("Введите логин");
                return;
            }
            if (passUser == "Введите пароль") {
                MessageBox.Show("Введите пароль");
                return;
            }

			var accountCandidate = new AccountData{ login = loginUser, pass = passUser };
			var result = context.messaging.attempt((it) => it.login(accountCandidate));

			if (result && result.s) {
				context.customer.updateAccount(accountCandidate);
				MainForm mainform = new MainForm(context);
				mainform.Show();
				this.Hide();
			}
			else {
				MessageBox.Show("Произошла ошибка, либо ваш аккаунт не зарегистрирован, либо вы ввели неправильно логин или пароль");
			}
        }

		private void loginField_Enter(object sender, EventArgs e)
		{
            if (loginField.Text == "Введите логин")
                loginField.Text = "";
            loginField.ForeColor = Color.Blue;
        }

		private void loginField_Leave(object sender, EventArgs e)
		{
            if (loginField.Text == "")
            {
                loginField.Text = "Введите логин";
                loginField.ForeColor = Color.Blue;
            }
        }

		

		private void passField_Enter_1(object sender, EventArgs e)
		{
            if (passField.Text == "Введите пароль")
            {
                passField.Text = "";
                passField.UseSystemPasswordChar = false;
            }
        }

		private void passField_Leave_1(object sender, EventArgs e)
		{
            if (passField.Text == "")
            {
                passField.UseSystemPasswordChar = true;
                passField.Text = "Введите пароль";
            }
        }

		private void labelRegistor_Click(object sender, EventArgs e)
		{
			this.Hide();
			Регистрация redistraziy = new Регистрация(context);
			redistraziy.Show();
       

        }
    

		private void labelRegistor_MouseEnter(object sender, EventArgs e)
		{
			labelRegistor.BackColor= Color.Silver;
            
        }

		private void labelRegistor_MouseLeave(object sender, EventArgs e)
		{

            labelRegistor.BackColor = Color.Transparent;
        }
	}
}

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles
{
    public partial class Регистрация : Form {

        public Регистрация() 
        {
            InitializeComponent();
            passField.UseSystemPasswordChar = true;
            userNameField.Text = "Введите имя";
            userNameField.ForeColor = Color.Blue;
            userSurnameField.Text = "Введите фамилию";
            userSurnameField.ForeColor = Color.Blue;
            loginField.Text = "Введите логин";
            loginField.ForeColor = Color.Blue;
            passField.Text = "Введите пароль";
            passField.ForeColor = Color.Blue;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        Point lastPoint;
        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label3_Click(object sender, EventArgs e)
        {
           Application.Exit();  
        }

        private void userNameField_Enter_1(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя")
                userNameField.Text = "";
            userNameField.ForeColor = Color.Blue;
        }

        private void userNameField_Leave_1(object sender, EventArgs e)
        {
            if (userNameField.Text == "")

                userNameField.Text = "Введите имя";
            userNameField.ForeColor = Color.Blue;
        }

        private void userSurnameField_Enter_1(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "Введите фамилию")
                userSurnameField.Text = "";
            userNameField.ForeColor = Color.Blue;
        }

        private void userSurnameField_Leave_1(object sender, EventArgs e)
        {
            if (userSurnameField.Text == "")
            {
                userSurnameField.Text = "Введите фамилию";
                userSurnameField.ForeColor = Color.Blue;
            }
        }

        private void loginField_Enter_1(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите логин")
                loginField.Text = "";
            loginField.ForeColor = Color.Blue;
        }

        private void loginField_Leave_1(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Введите логин";
                loginField.ForeColor = Color.Blue;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите пароль")
            {
                passField.Text = "";
                passField.ForeColor = Color.Blue;
                passField.UseSystemPasswordChar = false;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.UseSystemPasswordChar = true;
                passField.Text = "Введите пароль";
                passField.ForeColor = Color.Blue;

            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (userNameField.Text == "Введите имя") { MessageBox.Show("Введите имя");
                return;
            }

            if (userSurnameField.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите фамилию");
                return;
            }

            if (loginField.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (passField.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль");
                return;
            }
        }

        /*public Boolean isUserExists()
        {
           
            DB db = new DB();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@uL", db.GetConnection()); // Заглушки для безопасности, чтобы было сложнее взломать
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginField.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть, введите другой");
                return true;
            }
            else
            return false;

        }*/

        private void labelRegistor_Click(object sender, EventArgs e)
        {
            this.Hide(); //Закрытие тек окна
            Авторизация awtoriza = new Авторизация();
            awtoriza.Show();
        }

        private void labelRegistor_MouseEnter(object sender, EventArgs e)
        {
            labelRegistor.BackColor = Color.Silver;
        }

        private void labelRegistor_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void labelRegistor_MouseLeave_1(object sender, EventArgs e)
        {
            labelRegistor.BackColor = Color.Transparent;
        }
    }




}

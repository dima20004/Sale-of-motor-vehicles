using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Главная glaw = new Главная();
            glaw.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Мои_Анкеты mi = new Мои_Анкеты();
            mi.Show();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Покупки pop = new Покупки();
            pop.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutUs pop = new AboutUs();
            pop.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

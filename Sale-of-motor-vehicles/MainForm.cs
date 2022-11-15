using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sale_of_motor_vehicles
{
    public partial class MainForm : Form {

        public MainForm() 
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
;            label7.Text = "Приложение AutoDas подберет автомобиль для Вас\n10 лет на рынке\n" +
                "Миллионы положительных отзывов\nНаши партнеры:\nПокрышка " +
                "(Самые лучшие и дешевые покрышки для вашего автомобиля" +
                ")\nКожаЦех (Кожа крокодилов из Африки для вашего салона всегда в наличии)\n" +
                "Наша деспетчерская служба по номеру +7 (800)-(555)-35-35";
        }

        private void label3_Click(object sender, EventArgs e)
        {
           Application.Exit();  
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

        private void label7_Click(object sender, EventArgs e)
        {
         
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AboutUs about=new AboutUs();
            about.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Главная glaw = new Главная();
            glaw.Show();
        }
    }
}

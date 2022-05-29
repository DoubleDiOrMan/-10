using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public class Writes
        {
            public DateTime Date;
            public DateTime LogoutT;
            public DateTime TimeSpent;
            public string Unsuccess;
        }

        List<Writes> list = new List<Writes>()
        {
            new Writes { Date = new DateTime(2021, 1, 22, 15, 2, 5), LogoutT = new DateTime(2021, 1, 22, 16, 6, 5), TimeSpent = new DateTime(2021, 1, 22, 1, 4, 2), Unsuccess = ""},
            new Writes { Date = new DateTime(2020, 12, 15, 12, 25, 14), LogoutT = new DateTime(2020, 12, 15, 15, 31, 14), TimeSpent = new DateTime(2020, 12, 15, 3, 6, 0), Unsuccess = ""},
            new Writes { Date = new DateTime(2020, 12, 11, 8, 10, 4), LogoutT = new DateTime(2020, 1, 1, 1, 1, 1), TimeSpent = new DateTime(2020, 1, 1, 1, 1, 1), Unsuccess = "Power outage"}
        };

        Form5 f5;
        Form2 f2;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = false;
           
        }

        List<Listik> list1 = new List<Listik>()
            {
            new Listik { Name = "Ashot", Password = "228228", LastName = "Nurman", Age = 32, Role = "administrator", Email = "Nur2007@mail.shit", Office = "PaleoBeach", Ban = false },
            new Listik { Name = "Jamshut", Password = "231881", LastName = "Muhmed", Age = 16, Role = "user", Email = "WTF@gmail.cum", Office = "PaleoBeach", Ban = false },
            new Listik { Name = "Ramzan", Password = "LoxSGory", LastName = "Kadyrov", Age = 44, Role = "user", Email = "God@Kadyr.kz", Office = "Clouds", Ban = false },
            new Listik { Name = "Faramzan", Password = "NeaNeYa", LastName = "fakadyrov", Age = 44, Role = "user", Email = "God@Kadyr.kzzz", Office = "Cloudsss", Ban = true }
            };

        int a = 1, count = 0, counter = 0;

        public class Listik
        {
            public string Name;
            public string Password;
            public string LastName;
            public int Age;
            public string Role;
            public string Email;
            public string Office;
            public bool Ban;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Suka()
        {
            if (a == 1)
                a = 0;
            foreach (var item in list1)
            {
                if ((textBox1.Text == item.Email) && ("administrator" == item.Role) && (textBox2.Text == item.Password) && (item.Ban != true))
                {
                    a = 1;
                    f2 = new Form2(this, list1);
                    f2.Show();
                    this.Hide();
                }
                else if ((textBox1.Text == item.Email) && ("user" == item.Role) && (textBox2.Text == item.Password) && (item.Ban != true))
                {
                    a = 1;
                    f5 = new Form5(this, item, list);
                    f5.Show();
                    this.Hide();
                }
                else if ((textBox1.Text == item.Email) && (textBox2.Text == item.Password) && (item.Ban == true))
                {
                    label3.Text = "This user has been banned";
                    a = 1;
                }
            }
            if (a == 0)
            {
                a = 0;
                label3.Text = "Wrong Password or Email " + "Attempts: " + (3 - count);
                count++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((count >= 0) && (count < 3) && (counter < 10))
            {
                Suka();  
            }
            else
            {
                timer1.Enabled = true;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            label3.Text = "Time for another try: " + (11 - counter);
            if (counter == 11)
            {
                counter = 0;
                timer1.Enabled = false;
                label3.Text = "";
                count = 0;
            }
        }
    }
}

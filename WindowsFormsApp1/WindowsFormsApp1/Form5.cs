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
    public partial class Form5 : Form
    {
        Form1 form1;

        Form1.Listik item;
        List<Form1.Writes> list1;

        DateTime dtNow = DateTime.Now;
        DateTime dtd;
        int counter = 0, counter2 = 0, seccounter = 0, seccounter2 = 0;

        public void ReFresh()
        {
            int n = -1;
            dataGridView1.Rows.Clear();
            foreach (var item in list1)
            {
                DateTime Ds = new DateTime(2020, 1, 1, 1, 1, 1);
                n++;
                if (item.LogoutT == Ds)
                {
                    dataGridView1.Rows.Add((item.Date.Day + ":" + item.Date.Month + ":" + item.Date.Year), (item.Date.Hour + ":" + item.Date.Minute), "**", "**", item.Unsuccess);
                }
                else
                    dataGridView1.Rows.Add((item.Date.Day + ":" + item.Date.Month + ":" + item.Date.Year), (item.Date.Hour + ":" + item.Date.Minute), (item.LogoutT.Hour + ":" + item.LogoutT.Minute), (item.TimeSpent.Hour + ":" + item.TimeSpent.Minute), item.Unsuccess);
                if (item.Unsuccess == "Power outage")
                    dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Red;
            }
        }

        public Form5(Form1 f1, Form1.Listik item, List<Form1.Writes> list1)
        {
            this.list1 = list1;
            InitializeComponent();
            form1 = f1;
            this.item = item;
            label1.Text = "Hi " + item.Name + ", Wolcome to AMONIC Airlines.";
            label2.Text = "Time spent on system : ";
            timer1.Enabled = true;
            label3.Text = "Number of crashes : 1";
            dtNow = DateTime.Now;
            list1.Add(new Form1.Writes { Date = dtNow, LogoutT = new DateTime(2020, 1, 1, 1, 1, 1), TimeSpent = new DateTime(2020, 1, 1, 1, 1, 1), Unsuccess = "" });

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dtd = dtNow;
            dtNow = DateTime.Now;
            TimeSpan dif = (dtNow - dtd);
            list1[list1.Count - 1].LogoutT = dtNow;
            list1[list1.Count - 1].TimeSpent = Convert.ToDateTime(dif.ToString());
            form1.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Time spent on system : 00." + seccounter2 + seccounter + "." + counter2 + counter;
            counter++;
            if (counter == 10)
            {
                counter = 0;
                counter2++;
            }
            if (counter2 == 6)
            {
                counter2 = 0;
                seccounter++;
            }
            if (seccounter == 10)
            {
                seccounter = 0;
                seccounter2++;
            }
            ReFresh();
        }
    }
}

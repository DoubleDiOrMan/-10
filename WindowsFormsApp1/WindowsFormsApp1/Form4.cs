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
    public partial class Form4 : Form
    {
        Form2 form2;
        Form1.Listik item;
        public Form4(Form2 f2,Form1.Listik item)
        {
            InitializeComponent();
            form2 = f2;
            this.item = item;
            Email.Text = item.Email;
            Namec.Text = item.Name;
            LastName.Text = item.LastName;
            Office.Text = item.Office;
            if (item.Role == "administrator")
            {
                radioButton2.Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2.Show();
            this.Hide();
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            form2.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(item.Role);
            if (radioButton1.Checked == true)
                item.Role = "user";
            else
                item.Role = "administrator";
            Console.WriteLine(item.Role);
            form2.RowsAdd();
        }
    }
}

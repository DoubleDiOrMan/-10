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
    public partial class Form3 : Form
    {
        Form2 form2;
        List<Form1.Listik> list1;
        public Form3(Form2 f2, List<Form1.Listik> list1)
        {
            InitializeComponent();
            form2 = f2;
            this.list1 = list1;
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            form2.Show();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            DateTime dt = DateTime.Parse(maskedTextBox1.Text);
            TimeSpan dif = (dtNow - dt);
            list1.Add(new Form1.Listik { Name = Namec.Text, LastName = LastName.Text, Age = dif.Days / 365, Role = "user", Email = Email.Text, Office = ComboOffice.Text, Ban = false, Password = Password.Text });
            this.Hide();
            form2.Show();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

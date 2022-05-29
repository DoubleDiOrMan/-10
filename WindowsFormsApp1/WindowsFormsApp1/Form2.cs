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

    public partial class Form2 : Form
    {
        Form4 f4;
        Form3 f3;
        Form1 form1;

        List<Form1.Listik> list1;

        public Form2(Form1 f1, List<Form1.Listik> list1)
        {
            InitializeComponent();
            form1 = f1;
            
            this.list1 = list1;
            RowsAdd();
            comboBox1.SelectedIndex = 0;
        }

        public void RowsAdd()
        {
            dataGridView1.Rows.Clear();
            int n = -1;
            foreach (var item in list1)
            {
                if (comboBox1.Text == "All offices")
                {
                    n++;
                    dataGridView1.Rows.Add(item.Name, item.LastName, item.Age, item.Role, item.Email, item.Office);
                    if (item.Role == "administrator")
                        dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Green;
                    if (item.Ban == true)
                        dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Red;
                }
                else if (comboBox1.Text == item.Office)
                {
                    n++;
                    dataGridView1.Rows.Add(item.Name, item.LastName, item.Age, item.Role, item.Email, item.Office);
                    if (item.Role == "administrator")
                        dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Green;
                    if (item.Ban == true)
                        dataGridView1.Rows[n].DefaultCellStyle.BackColor = Color.Red;
                    
                }
                
                
            }
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3 = new Form3(this, list1);
            f3.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Hide();
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in list1)
            {
                if (item.Email == dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString())
                {
                    f4 = new Form4(this,item);
                    f4.Show();
                    this.Hide();
                }
            }

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RowsAdd();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in list1)
            {
                if (item.Email == dataGridView1.SelectedRows[0].Cells["Email"].Value.ToString())
                {
                    item.Ban = !item.Ban;
                    RowsAdd();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RowsAdd();
        }
    }
}

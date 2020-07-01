using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DAProject
{
    public partial class Form3 : Form
    {
        Form1 f1 = new Form1();
        public string value;
        public Form3()
        {
            InitializeComponent();
            dataGridView1.Visible = false;

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
                value = "name";
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
                value = "mobile";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from records where " + value + "='" + textBox1.Text + "'";
                Form1.con.Open();
                DataTable d = new DataTable();
                MySqlCommand c = new MySqlCommand(qry, Form1.con);
                MySqlDataReader r = c.ExecuteReader();
                d.Load(r);
                Form1.con.Close();
                if (d.Rows.Count > 0)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = d;
                    dataGridView1.ClearSelection();
                }
                else
                {
                    label4.Visible = true;
                    label4.Text = "Match Not Found...";
                    dataGridView1.Visible = false;
                }
                button3.Visible = true;
            }
            catch (Exception w)
            {
                label4.Visible = true;
                label4.Text = "Some Error Occured :-(";
                dataGridView1.Visible = false;
                button3.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                string qry = "select * from records";
                Form1.con.Open();
                DataTable d = new DataTable();
                MySqlCommand c = new MySqlCommand(qry, Form1.con);
                MySqlDataReader r = c.ExecuteReader();
                d.Load(r);
                Form1.con.Close();
                if (d.Rows.Count > 0)
                {
                    dataGridView1.Visible = true;
                    dataGridView1.DataSource = d;
                    dataGridView1.ClearSelection();
                    label4.Visible = false;
                }
                else
                {
                    label4.Visible = true;
                    label4.Text = "No Record!!!";
                }
                button3.Visible = false;
            }
            catch (Exception w)
            {
                label4.Visible = true;
                label4.Text = "Some Error Occured :-(";
                button3.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3_Load(sender, e);
        }
    }
}

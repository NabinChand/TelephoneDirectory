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
using System.Text.RegularExpressions;

namespace DAProject
{
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();
        public Form2(string mytext, string nm, string no, string add)
        {
            InitializeComponent();
            textBox1.Select();
            label1.Text = mytext;
            if (mytext == "Modify Record")
            {
                textBox1.Text = nm;
                textBox2.Text = no;
                textBox2.Enabled= false;
                richTextBox1.Text = add;
                button1.Text = "Modify";
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            richTextBox1.Text = String.Empty;
            textBox1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int flag = 1;
            string name = textBox1.Text;
            string number = textBox2.Text;
            string address = richTextBox1.Text;
            string nam = @"(^[a-zA-Z]+[a-zA-Z ]*$)";
            Regex rnam = new Regex(nam);
            string num= @"(^[6-9][0-9]{9}$)";
            Regex rnum= new Regex(num);
            if (rnam.IsMatch(name) == false)
            {
                MessageBox.Show("Invalid Name.", "InValid");
                flag = 0;
            }
            if (rnum.IsMatch(number) == false)
            {
                MessageBox.Show("Invalid Contact Number.", "InValid"); 
                flag = 0;
            }
            if (address.Length < 15)
            {
                MessageBox.Show("Please provide proper address."); 
                flag = 0;
            }

            if(flag==1)
            {
                try
                {
                    Form1.con.Open();
                    if (label1.Text == "Add Record")
                    {
                        string data = "insert into records values('" + name + "', '" + number + "', '" + address + "');";
                        MySqlCommand cmd = new MySqlCommand(data, Form1.con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Inserted Successfully.", "Message");
                        textBox1.Text = String.Empty;
                        textBox2.Text = String.Empty;
                        richTextBox1.Text = String.Empty;
                        textBox1.Select();
                    }
                    else
                    {
                        string qry = "update records set name='" + name + "', address='" + address + "' where mobile='" + number + "';";
                        MySqlCommand c = new MySqlCommand(qry, Form1.con);
                        c.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully.", "Updated");
                    }
                    Form1.con.Close();
                }
                catch (MySqlException w)
                {
                    MessageBox.Show("Problem Inserting Data.", "Error");
                    Form1.con.Close();
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
            this.Dispose();
        }
    }
}

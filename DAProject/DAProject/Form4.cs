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
    public partial class Form4 : Form
    {
        Form1 f1 = new Form1();
        public Form4()
        {
            InitializeComponent();
            if (Form1.work == "delete")
                label1.Text = "Delete Record";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dg = new DataTable();
                Form1.con.Open();
                string qry= "select * from records where mobile='"+textBox1.Text+"';";
                MySqlCommand c = new MySqlCommand(qry, Form1.con);
                MySqlDataReader r = c.ExecuteReader();
                dg.Load(r);
                Form1.con.Close();
                if (dg.Rows.Count > 0)
                {
                    if (Form1.work == "modify")
                    {
                        Form2 f2 = new Form2("Modify Record", dg.Rows[0][0].ToString(), dg.Rows[0][1].ToString(), dg.Rows[0][2].ToString());
                        f2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;  
                        DialogResult result = MessageBox.Show("Are you sure you want to delete data related to "+dg.Rows[0][1]+" number?", "Confirm", buttons);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                Form1.con.Open();
                                string del = "delete from records where mobile='" + textBox1.Text + "';";
                                MySqlCommand cmd = new MySqlCommand(del, Form1.con);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Data Deleted Succesfully.", "Success");
                                Form1.con.Close();
                                f1.Show();
                                this.Hide();
                            }
                            catch (MySqlException ew)
                            {    
                                MessageBox.Show("Some Error Occured.", "Error");
                                Form1.con.Close();
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Data Not Found.", Form1.work.ToUpper());
            }
            catch (MySqlException w)
            {
                MessageBox.Show("Some Error Occured.", "Error");
                Form1.con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f1.Show();
            this.Hide();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
            this.Hide();
        }
    }
}

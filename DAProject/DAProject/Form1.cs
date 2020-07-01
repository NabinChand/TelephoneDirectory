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
    public partial class Form1 : Form
    {
        public static MySqlConnection con = new MySqlConnection("SERVER=localhost;DATABASE=telephone;UID=root;PASSWORD=");
        public static string work;
        public Form1()
        {
            InitializeComponent();
            try
            {
                con.Open();
                con.Close();
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Problem Creating Connection", "Error");
                addRecordToolStripMenuItem.Enabled = false;
                searchRecordToolStripMenuItem.Enabled = false;
                viewRecordToolStripMenuItem.Enabled = false;
                deleteRecordToolStripMenuItem.Enabled = false;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2("Add Record", "", "", "");
            f2.Show();
            this.Hide();
        }

        private void viewRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            this.Hide();
        }
        private void updateRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            work = "modify";
            Form4 f4 = new Form4();
            f4.Show();
            this.Hide();
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string promptValue = Microsoft.VisualBasic.Interaction.InputBox("Enter Pass Key", "Authentication", "", 0, 0);
            string pass = "King";
            if (promptValue != "")
            {
                if (promptValue == pass)
                {
                    work = "delete";
                    Form4 ff4 = new Form4();
                    ff4.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Invalid Pass Key.");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}

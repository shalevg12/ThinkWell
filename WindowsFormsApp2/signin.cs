using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2{
    public partial class signin : Form{
        public signin(){
            InitializeComponent();
        }
        //exit
        private void button2_Click(object sender, EventArgs e){
            this.Close();
        }
        //sound
        private void button1_Click(object sender, EventArgs e){

        }
        //back
        private void button3_Click(object sender, EventArgs e){
            Form1 myForm = new Form1();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int count = 0;
            SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Username from UsersInfoDataBase Where Username= '" + Username.Text + "' and Password= '" + Password.Text + "'", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                UserInformation.CurrentLoggedInUser = Username.Text;
                RegMenu myForm = new RegMenu();
                myForm.Text = Username.Text;
                this.Hide();
                this.Close();
                myForm.ShowDialog();
            }
            else
            {
                if (count <= 2)
                {
                    count = count + 1;
                    MessageBox.Show("Wrong Username or Password, Please try again!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Username.Clear();
                    Password.Clear();
                }
                if (count >= 3)
                {
                    menuGuest newform = new menuGuest();
                    newform.ShowDialog();
                    this.Close();
                }
            }
        }

        private void signin_Load(object sender, EventArgs e){
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Size = this.Size.Width == 400 ? new Size(1000, 200) : new Size(1920, 1080);
        }
        //forget password
        private void button5_Click(object sender, EventArgs e){
            PassRecovery myform = new PassRecovery();
            this.Hide();
            myform.ShowDialog();
        }
        //signup
        private void button6_Click(object sender, EventArgs e){
            signup myForm = new signup();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            Password.PasswordChar = '*';
        }
    }
}

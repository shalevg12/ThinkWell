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
    public partial class signup : Form{
        public signup(){
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");

        //exit
        private void button3_Click(object sender, EventArgs e){
            this.Close();
        }
        //sound
        private void button1_Click(object sender, EventArgs e){

        }
        //back
        private void button2_Click(object sender, EventArgs e){
            Form1 myForm = new Form1();
            this.Hide();
            myForm.ShowDialog();
        }
        //SIGNUP
        private void button4_Click(object sender, EventArgs e)
        {
            {
                bool ErrorFlag = false;
                if (Username.Text == "")
                {
                    ErrorFlag = true;
                }
                if (FirstName.Text == "")
                {
                    ErrorFlag = true;
                }
                if (LastName.Text == "")
                {
                    ErrorFlag = true;
                }
                if (Email.Text == "")
                {
                    ErrorFlag = true;
                }
                if (Password.Text == "")
                {
                    ErrorFlag = true;
                }
                if (ErrorFlag == true)
                {
                    MessageBox.Show("One or more empty lines!", "ok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ///// בדיקת השם משתמש ואימייל במאגר הנתונים
                    bool EmailExists = false;
                    bool UsernameExists = false;
                    SqlDataAdapter da = new SqlDataAdapter("Select Username From UsersInfoDataBase where Username='" + Username.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    SqlDataAdapter da1 = new SqlDataAdapter("Select Email from UsersInfoDataBase where Email ='" + Email.Text + "'", con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    if (dt.Rows.Count >= 1)
                    {
                        UsernameExists = true;
                    }
                    if (dt1.Rows.Count >= 1)
                    {
                        EmailExists = true;
                    }
                    if (EmailExists)
                    {
                        MessageBox.Show("Error! \nEmail is already Registered!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (UsernameExists)
                    {
                        MessageBox.Show("Error! \nUsername is Taken!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (!UsernameExists && !EmailExists)
                    {
                        con.Open();
                        string Query = "insert into UsersInfoDataBase (email,firstname,lastname, username,password,role,HighScore,GamesPlayed) values('" + this.Email.Text + "','" + this.FirstName.Text + "','" + this.LastName.Text + "','" + this.Username.Text + "','" + this.Password.Text + "','User','0','0');";
                        SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                        SDA.SelectCommand.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Welcome! \nPlease try to login into ur account now.", "Register Succesfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        signin myform = new signin();
                        myform.ShowDialog();
                        this.Close();
                    }

                }
            }
        }

        private void signup_Load(object sender, EventArgs e){
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Size = this.Size.Width == 400 ? new Size(1000, 200) : new Size(1920, 1080);

        }
    }
}

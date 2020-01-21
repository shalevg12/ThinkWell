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

namespace WindowsFormsApp2
{
    public partial class ChangeInfo : Form
    {
        public ChangeInfo()
        {
            InitializeComponent();
        }
        bool ChangeUsername = false;

        private void label5_Click(object sender, EventArgs e)
        {
            RegMenu myform = new RegMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (NUsername.Text == "")
                {
                    MessageBox.Show("Invalid!", "ok", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool UsernameExists = false;
                    SqlConnection con = new SqlConnection(@"Data Source = MATAN - PC; Initial Catalog = master; Integrated Security = True");
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select Username From UsersInfoDataBase where Username='" + NUsername.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        UsernameExists = true;
                    }
                    if (UsernameExists)
                    {
                        MessageBox.Show("Error! \nUsername is Taken!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Username Available!", "ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChangeUsername = true;
                    }
                    con.Close();
                }
            }
        }
        private void ChangeInfo_Load(object sender, EventArgs e)
        {
           
            SqlConnection con1 = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
            DataTable dt = new DataTable();
            string userRole = string.Empty;
            con1.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("Select * from UsersInfoDataBase where Username='" + (UserInformation.CurrentLoggedInUser) + "'", con1);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                label2.Text = UserInformation.CurrentLoggedInUser;
                label6.Text = (myReader["Email"].ToString());

            }
            con1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ChangeUsername == true)
            {
                SqlConnection con = new SqlConnection(@"Data Source = MATAN - PC; Initial Catalog = master; Integrated Security = True");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[UsersInfoDataBase] SET [Username] = '" + NUsername.Text + "' WHERE Username='" + UserInformation.CurrentLoggedInUser + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                bool userRated = false;
                SqlDataAdapter da1 = new SqlDataAdapter("Select Username from RateTab where Username ='" + UserInformation.CurrentLoggedInUser + "'", con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if (dt1.Rows.Count >= 1)
                {
                    userRated = true;
                }
                if (userRated)
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE [dbo].[RateTab] SET [Username] = '" + NUsername.Text + "' WHERE Username='" + UserInformation.CurrentLoggedInUser + "'", con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Changed Rating Accordingly");
                }
                MessageBox.Show("Changed Information Successfully");
                UserInformation.CurrentLoggedInUser = NUsername.Text;
                SqlConnection con1 = new SqlConnection(@"Data Source = MATAN - PC; Initial Catalog = master; Integrated Security = True");
                DataTable dt = new DataTable();
                con1.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Select * from UsersInfoDataBase where Username='" + (UserInformation.CurrentLoggedInUser) + "'", con1);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    label2.Text = UserInformation.CurrentLoggedInUser;
                    label6.Text = (myReader["Email"].ToString());

                }
                con1.Close();
                ChangeUsername = false;
            }
            else
            {
                MessageBox.Show("Please Check if username is available first !", "ok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


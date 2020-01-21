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
    public partial class RateUs : Form{
        public RateUs(){
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e){

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e){

        }

        private void label7_Click(object sender, EventArgs e){
            RegMenu myform = new RegMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e){
            bool FlagRated = false, UsernameExists = false;
            SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
            int rate = 0;
            SqlDataAdapter da = new SqlDataAdapter("Select Username From RateTab where Username='" + UserInformation.CurrentLoggedInUser + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1){
                UsernameExists = true;
            }
            if (radioButton1.Checked){
                rate = 1;
                con.Open();
                if (UsernameExists == false){
                    string Query = "insert into RateTab (Username , Rating) values('" + UserInformation.CurrentLoggedInUser + "','" + rate + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                }
                if (UsernameExists == true){
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[RateTab] SET [Rating] = '" + rate + "'Where Username='" + UserInformation.CurrentLoggedInUser + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                FlagRated = true;
            }
            if (radioButton2.Checked){
                rate = 2;
                con.Open();
                if (UsernameExists == false){
                    string Query = "insert into RateTab (Username , Rating) values('" + UserInformation.CurrentLoggedInUser + "','" + rate + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                }
                if (UsernameExists == true){
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[RateTab] SET [Rating] = '" + rate + "'Where Username='" + UserInformation.CurrentLoggedInUser + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                FlagRated = true;
            }
            if (radioButton3.Checked){
                rate = 3;
                con.Open();
                if (UsernameExists == false){
                    string Query = "insert into RateTab (Username , Rating) values('" + UserInformation.CurrentLoggedInUser + "','" + rate + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                }
                if (UsernameExists == true){
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[RateTab] SET [Rating] = '" + rate + "'Where Username='" + UserInformation.CurrentLoggedInUser + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                FlagRated = true;
            }
            if (radioButton4.Checked){
                rate = 4;
                con.Open();
                if (UsernameExists == false){
                    string Query = "insert into RateTab (Username , Rating) values('" + UserInformation.CurrentLoggedInUser + "','" + rate + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                }
                if (UsernameExists == true){
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[RateTab] SET [Rating] = '" + rate + "'Where Username='" + UserInformation.CurrentLoggedInUser + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                FlagRated = true;
            }
            if (radioButton5.Checked){
                rate = 5;
                con.Open();
                if (UsernameExists == false){
                    string Query = "insert into RateTab (Username , Rating) values('" + UserInformation.CurrentLoggedInUser + "','" + rate + "')";
                    SqlDataAdapter SDA = new SqlDataAdapter(Query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    con.Close();
                }
                if (UsernameExists == true){
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[RateTab] SET [Rating] = '" + rate + "'Where Username='" + UserInformation.CurrentLoggedInUser + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                FlagRated = true;
            }
            if(!radioButton1.Checked && !radioButton2.Checked){
                if(!radioButton3.Checked && !radioButton4.Checked){
                    if (!radioButton5.Checked)  
                        MessageBox.Show("No Rating given!");
                }
            }
            if(FlagRated == true){
                MessageBox.Show("Thanks For Rating Us!");
                RegMenu myform = new RegMenu();
                this.Hide();
                myform.ShowDialog();
                this.Close();
            }
        }

        private void RateUs_Load(object sender, EventArgs e){

        }
    }
}

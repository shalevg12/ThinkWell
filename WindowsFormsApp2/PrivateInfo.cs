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
    public partial class PrivateInfo : Form{
        public PrivateInfo(){
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e){
            RegMenu myform = new RegMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }

        private void PrivateInfo_Load(object sender, EventArgs e){
            string Idcheck = string.Empty;
            SqlConnection con1 = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
            DataTable dt = new DataTable();
            string userRole = string.Empty;
            con1.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("Select * from UsersInfoDataBase where Username='" + (UserInformation.CurrentLoggedInUser) + "'", con1);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read()){
                UserName.Text = UserInformation.CurrentLoggedInUser;
                Em.Text = (myReader["Email"].ToString());
                FName.Text = (myReader["FirstName"].ToString());
                LName.Text = (myReader["LastName"].ToString());
                HS.Text = (myReader["HighScore"].ToString());
                GP.Text = (myReader["GamesPlayed"].ToString());
                userRole = (myReader["Role"].ToString());
                Idcheck = (myReader["AccountNumber"].ToString());

            }
            con1.Close();
        }
    }
}

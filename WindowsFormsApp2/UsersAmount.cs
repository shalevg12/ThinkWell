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
    public partial class UsersAmount : Form
    {
        public UsersAmount()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
        protected override void OnLoad(EventArgs e)
        {
            var filter = string.Empty;
            var status = string.Empty;
            var users = string.Empty;
            var total = string.Empty;
            filter = "Admin     ";
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Role,Username,[FirstName],[LastName],Email from UsersInfoDataBase Where Role='" + filter + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            int str = dt.Rows.Count;
            status = Convert.ToString(str);
            label3.Text = status;

            filter = "User      ";
            //con.Open();
            SqlCommand cmd1 = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Role,Username,[FirstName],[LastName],Email from UsersInfoDataBase Where Role='" + filter + "'";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            int str1 = dt1.Rows.Count;
            users = Convert.ToString(str1);
            label4.Text = users;
            total = Convert.ToString(str + str1);
            label6.Text = total;
            base.OnLoad(e);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            adMenu myform = new adMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }

        private void UsersAmount_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class ChangePermissions : Form {
        SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");

        public ChangePermissions(){
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e){
            var filter = string.Empty;
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

            filter = "User      ";
            //con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Role,Username,[FirstName],[LastName],Email from UsersInfoDataBase Where Role='" + filter + "'";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter(cmd);
            da1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            int str1 = dt1.Rows.Count;
            base.OnLoad(e);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e){
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView2.Rows[index];
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            RoleOf = selectedRow.Cells[0].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            RoleOf = selectedRow.Cells[0].Value.ToString();
        }

        private void label4_Click(object sender, EventArgs e){
            adMenu myform = new adMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        static string RoleOf = string.Empty;
        private void button1_Click(object sender, EventArgs e){
            if (MessageBox.Show("Please Confirm Changing User To Admin :", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes){
                if (RoleOf == "User      "){
                    var changeInto = string.Empty;
                    changeInto = "Admin     ";
                    SqlConnection con = new SqlConnection(@"Data Source = MATAN - PC; Initial Catalog = master; Integrated Security = True");
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[UsersInfoDataBase] SET [Role] = '" + changeInto + "' WHERE Username='" + textBox1.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("User Account Changed To Admin Successfully!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var filter = string.Empty;
                    filter = "Admin     ";
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Role,Username,[FirstName],[LastName],Email from UsersInfoDataBase Where Role='" + filter + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //int str = dt.Rows.Count;

                    filter = "User      ";
                    //con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Role,Username,[FirstName],[LastName],Email from UsersInfoDataBase Where Role='" + filter + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    da1.Fill(dt1);
                    dataGridView2.DataSource = dt1;
                    //int str1 = dt1.Rows.Count;
                }
                else
                    MessageBox.Show("Account is Already an Admin!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e){
            if (MessageBox.Show("Please Confirm Admin To User :", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes){
                if (RoleOf == "Admin     "){
                    if (textBox1.Text == UserInformation.CurrentLoggedInUser)
                        MessageBox.Show("Cannot Change '" + textBox1.Text + "' as it is being used!'", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    var changeInto = string.Empty;
                    changeInto = "User      ";
                    SqlConnection con = new SqlConnection(@"Data Source = MATAN - PC; Initial Catalog = master; Integrated Security = True");
                    SqlCommand cmd = new SqlCommand("UPDATE [dbo].[UsersInfoDataBase] SET [Role] = '" + changeInto + "' WHERE Username='" + textBox1.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Admin Account Changed To User Successfully!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var filter = string.Empty;
                    filter = "Admin     ";
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Role,Username,[FirstName],[LastName],Email from UsersInfoDataBase Where Role='" + filter + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    //int str = dt.Rows.Count;

                    filter = "User      ";
                    //con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select Role,Username,[FirstName],[LastName],Email from UsersInfoDataBase Where Role='" + filter + "'";
                    cmd.ExecuteNonQuery();
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    da1.Fill(dt1);
                    dataGridView2.DataSource = dt1;
                    //int str1 = dt1.Rows.Count;
                }
                else
                    MessageBox.Show("Account is Already a Registered User!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangePermissions_Load(object sender, EventArgs e){

        }
    }
}

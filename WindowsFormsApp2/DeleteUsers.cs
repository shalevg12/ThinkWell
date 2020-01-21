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
    public partial class DeleteUsers : Form{
        SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
        public DeleteUsers(){
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e){
            var status = string.Empty;
            var filter = string.Empty;
            filter = "User      ";
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
            base.OnLoad(e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e){
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e){
            //con.Open;
            if (textBox1.Text == "")
                MessageBox.Show("Invalid User");
            else{
                if (MessageBox.Show("Please Confirm Account Deletion :", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes){
                    String query = "DELETE FROM UsersInfoDataBase where Username ='" + textBox1.Text + "'";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("User Account Deleted Successfully!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var status = string.Empty;
                    var filter = string.Empty;
                    filter = "User      ";
                    //con.Open();
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
                }
            }
        }

        private void label1_Click(object sender, EventArgs e){
            adMenu myform = new adMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }

        private void DeleteUsers_Load(object sender, EventArgs e){

        }
    }
}

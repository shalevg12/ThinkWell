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
    public partial class EditTop10 : Form{
        public EditTop10()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");


        private void label1_Click(object sender, EventArgs e)
        {
            adMenu myform = new adMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }

        private void EditTop10_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from TopTen";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            this.dataGridView1.Sort(this.dataGridView1.Columns["HighScore"], ListSortDirection.Descending);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Invalid User");
            else
            {
                if (MessageBox.Show("Please Confirm Score Deletion :", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    String query = "DELETE FROM TopTen where Username ='" + textBox1.Text + "'";
                    SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                    SDA.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Score Deleted Successfully!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Delete User Account completely? ", "Message", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DeleteUsers myform = new DeleteUsers();
                        this.Hide();
                        myform.ShowDialog();
                        this.Close();
                    }
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "Select * from TopTen";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}

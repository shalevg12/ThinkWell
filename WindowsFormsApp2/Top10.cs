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
    public partial class Top10 : Form
    {
        public Top10()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");

        private void Top10_Load(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {
            RegMenu myform = new RegMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
    }
}

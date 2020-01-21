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
    public partial class AvgRating : Form{
        public AvgRating(){
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
        protected override void OnLoad(EventArgs e){
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Username,Rating from RateTab";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            int Raters = dt.Rows.Count;
            float sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i){
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
            }
            label2.Text = Convert.ToString(sum / Raters);
            base.OnLoad(e);
        }

        private void AvgRating_Load(object sender, EventArgs e){

        }

        private void label3_Click(object sender, EventArgs e){
            adMenu myform = new adMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
    }
}

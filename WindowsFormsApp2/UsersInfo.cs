﻿using System;
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
    public partial class UsersInfo : Form
    {
        public UsersInfo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            adMenu myform = new adMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }

        private void UsersInfo_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
        protected override void OnLoad(EventArgs e)
        {
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
            base.OnLoad(e);

            con.Close();
        }
    }
}

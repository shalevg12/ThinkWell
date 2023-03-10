using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2{

    public partial class Form1 : Form{
        public Form1(){
            InitializeComponent();
        }

        //signin
        private void button1_Click(object sender, EventArgs e)
        {
            signin myForm = new signin();
            this.Hide();
            myForm.ShowDialog();
        }
        //signup
        private void button3_Click(object sender, EventArgs e)
        {
            signup myForm = new signup();
            this.Hide();
            myForm.ShowDialog();
        }
        //play as guest
        private void button2_Click(object sender, EventArgs e)
        {
            menuGuest myForm = new menuGuest();
            this.Hide();
            myForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e){
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Size = this.Size.Width == 400 ? new Size(1000, 200) : new Size(1920, 1080);
        }
    }

    internal class UserInformation
    {
        public static string CurrentLoggedInUser
        {
            get;
            set;
        }
        public static bool IsAdmin = false;
    }
}

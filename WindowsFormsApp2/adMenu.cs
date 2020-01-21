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
    public partial class adMenu : Form{
        public adMenu(){
            InitializeComponent();
        }
        //הגדלת מסך
        private void adMenu_Load(object sender, EventArgs e){
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Size = this.Size.Width == 400 ? new Size(1000, 200) : new Size(1920, 1080);
        }
        //exit
        private void button2_Click(object sender, EventArgs e){
            RegMenu myform = new RegMenu();
            this.Hide();
            myform.ShowDialog();
        }
        //sound
        private void button9_Click(object sender, EventArgs e){

        }
        //Admin Details
        private void AdmInfo_Click(object sender, EventArgs e){
            AdminDetails myform = new AdminDetails();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //Users Info
        private void UsersInfo_Click(object sender, EventArgs e){
            UsersInfo myForm = new UsersInfo();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
        //Change Permissions
        private void button3_Click(object sender, EventArgs e){
            ChangePermissions myform = new ChangePermissions();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //Delete Users
        private void button1_Click(object sender, EventArgs e){
            DeleteUsers myform = new DeleteUsers();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //Users Amount
        private void button4_Click(object sender, EventArgs e){
            UsersAmount myform = new UsersAmount();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //Edit Instructions
        private void button5_Click(object sender, EventArgs e){
            EditInstructions myform = new EditInstructions();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //Avg Rating
        private void button6_Click(object sender, EventArgs e){
            AvgRating myform = new AvgRating();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //edit score
        private void button7_Click(object sender, EventArgs e){
            EditTop10 myform = new EditTop10();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //Recommendations
        private void button8_Click(object sender, EventArgs e){

        }
        //switch user
        private void button14_Click(object sender, EventArgs e){
            signin myform = new signin();
            this.Hide();
            myform.ShowDialog();
        }
        //logout
        private void button15_Click(object sender, EventArgs e){
            Form1 myform = new Form1();
            this.Hide();
            myform.ShowDialog();
        }
    }
}

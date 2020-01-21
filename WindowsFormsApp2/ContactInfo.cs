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
    public partial class ContactInfo : Form{
        public ContactInfo(){
            InitializeComponent();
        }
        private void ContactInfo_Load(object sender, EventArgs e){
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Size = this.Size.Width == 400 ? new Size(1000, 200) : new Size(1920, 1080);
        }
        //exit
        private void button2_Click(object sender, EventArgs e){
            this.Close();
        }
        //sound
        private void button1_Click(object sender, EventArgs e){

        }
        //back
        private void button3_Click(object sender, EventArgs e){
            menuGuest myForm = new menuGuest();
            this.Hide();
            myForm.ShowDialog();
        }
    }
}

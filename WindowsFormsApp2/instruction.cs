using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2{
    public partial class instruction : Form{
        public instruction(){
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e){
            StreamReader sr = new StreamReader("Instructions.txt", true);
            textBox1.Text = sr.ReadToEnd();
            sr.Close();
            base.OnLoad(e);
        }
        //exit
        private void button1_Click(object sender, EventArgs e){
            this.Close();
        }
        //sound
        private void button2_Click(object sender, EventArgs e){

        }
        //back
        private void button3_Click(object sender, EventArgs e){
            menuGuest myForm = new menuGuest();
            this.Hide();
            myForm.ShowDialog();
        }
        //instruction
        private void textBox1_TextChanged(object sender, EventArgs e){

        }

        private void instruction_Load(object sender, EventArgs e){
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Size = this.Size.Width == 400 ? new Size(1000, 200) : new Size(1920, 1080);
        }
    }
}

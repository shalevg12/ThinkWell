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
    public partial class EditInstructions : Form{
        public EditInstructions(){
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e){
            StreamReader sr = new StreamReader("Instructions.txt", true);
            textBox1.Text = sr.ReadToEnd();
            sr.Close();
            base.OnLoad(e);
        }

        private void EditInstructions_Load(object sender, EventArgs e) { 
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Size = this.Size.Width == 400 ? new Size(1000, 200) : new Size(1920, 1080);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter("Instructions.txt");
            sr.Write(textBox1.Text);
            MessageBox.Show("Saved Changes!");
            sr.Close();
        }
        //exit
        private void button1_Click(object sender, EventArgs e){
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e){

        }
        //back
        private void button3_Click(object sender, EventArgs e){
            adMenu myform = new adMenu();
            this.Hide();
            myform.ShowDialog();
        }
        //sound
        private void button4_Click(object sender, EventArgs e){

        }
    }
}

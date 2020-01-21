using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2{
    public partial class RegMenu : Form{
        public RegMenu(){
            InitializeComponent();
            SqlConnection con1 = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
            SqlDataReader myReader = null;
            con1.Open();
            SqlCommand myCommand = new SqlCommand("Select * from UsersInfoDataBase where Username='" + (UserInformation.CurrentLoggedInUser) + "'", con1);
            myReader = myCommand.ExecuteReader();

            string userRole = string.Empty;
            while (myReader.Read())
            {
                userRole = (myReader["Role"].ToString());
            }
            if (userRole == "Admin     ") UserInformation.IsAdmin = true;
            if (UserInformation.IsAdmin == false) button13.Hide();
            con1.Close();
        }

        private void RegMenu_Load(object sender, EventArgs e){
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
        //instractions
        private void button3_Click(object sender, EventArgs e){
            instructionReg myForm = new instructionReg();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
        //about
        private void button4_Click(object sender, EventArgs e){
            aboutReg myForm = new aboutReg();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
        //contact
        private void button5_Click(object sender, EventArgs e){
            ContactInfoReg myForm = new ContactInfoReg();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
        //rating
        private void button6_Click(object sender, EventArgs e){
            RateUs myform = new RateUs();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //best
        private void button7_Click(object sender, EventArgs e){
            Top10 myform = new Top10();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //maraton
        private void button8_Click(object sender, EventArgs e){

        }
        //achievements
        private void button9_Click(object sender, EventArgs e){
            PrivateInfo myForm = new PrivateInfo();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
        //change info
        private void button10_Click(object sender, EventArgs e){
            ChangeInfo myform = new ChangeInfo();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //המלצות
        private void button11_Click(object sender, EventArgs e){

        }
        //start game
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        IntPtr appWin1;

        private void button12_Click(object sender, EventArgs e){
            ProcessStartInfo ps1 = new ProcessStartInfo(@"C:\Users\matan\OneDrive\שולחן העבודה\Think_well_4Players\ThinkWell_2019.exe");
            ps1.WindowStyle = ProcessWindowStyle.Maximized;
            Process p1 = Process.Start(ps1);
            this.Hide();
            Thread.Sleep(1000); // Allow the process to open it's window
            appWin1 = p1.MainWindowHandle;
            //Put it into this form
            SetParent(appWin1, this.Handle);
            //Move the window to overlay it on this window
            MoveWindow(appWin1, 0, 0, this.Width / 2, this.Height, true);
            this.Show();
            this.TopMost = false;
            SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select GamesPlayed from UsersInfoDataBase Where Username= '" + UserInformation.CurrentLoggedInUser + "'", con);
            con.Open();
            int GP = (int)cmd.ExecuteScalar();
            int GPU = GP + 1;
            con.Close();
            cmd = new SqlCommand("UPDATE [dbo].[UsersInfoDataBase] SET [GamesPlayed] = '" + GPU + "' WHERE Username='" + UserInformation.CurrentLoggedInUser + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button13_Click(object sender, EventArgs e){
            adMenu myform = new adMenu();
            this.Hide();
            myform.ShowDialog();
            this.Close();
        }
        //swich user
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

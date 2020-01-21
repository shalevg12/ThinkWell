using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2{
    public partial class menuGuest : Form{
        public menuGuest(){
            InitializeComponent();
        }
        private void menuGuest_Load(object sender, EventArgs e){
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Size = this.Size.Width == 400 ? new Size(1000, 200) : new Size(1920, 1080);
        }
        //exit
        private void button2_Click(object sender, EventArgs e){
            /*Form1 myForm = new Form1();
            this.Hide();
            myForm.ShowDialog();*/
            this.Close();
        }
        //sound
        private void button1_Click(object sender, EventArgs e){

        }
        //instruction
        private void button3_Click(object sender, EventArgs e){
            instruction myForm = new instruction();
            this.Hide();
            myForm.ShowDialog();
        }
        //about
        private void button4_Click(object sender, EventArgs e){
            about myForm = new about();
            this.Hide();
            myForm.ShowDialog();
        }
        //contact
        private void button5_Click(object sender, EventArgs e){
            ContactInfo myForm = new ContactInfo();
            this.Hide();
            myForm.ShowDialog();
        }
        //start game

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        IntPtr appWin1;

        private void button6_Click(object sender, EventArgs e){
            ProcessStartInfo ps1 = new ProcessStartInfo(@"C:\Users\matan\OneDrive\שולחן העבודה\Think_well_4Players\ThinkWell_2019.exe");
            ps1.WindowStyle = ProcessWindowStyle.Maximized;
            Process p1 = Process.Start(ps1);
            this.Hide();
            Thread.Sleep(1000); // Allow the process to open it's window
            appWin1 = p1.MainWindowHandle;
            this.Show();
            this.TopMost = false;
            //Put it into this form
            SetParent(appWin1, this.Handle);
            //Move the window to overlay it on this window
            MoveWindow(appWin1, 0, 0, this.Width / 2, this.Height, true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2{
    public partial class PassRecovery : Form{
        string randomCode;
        public static string to;
        public PassRecovery(){
            InitializeComponent();
        }
       
        private void PassRecovery_Load(object sender, EventArgs e){

        }

        private void button2_Click(object sender, EventArgs e){
            signin myform = new signin();
            this.Hide();
            myform.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e){
            SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Username from UsersInfoDataBase Where Username= '" + UserName.Text + "' and Email= '" + EmailBox.Text + "'", con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1){
                string from, pass, messageBody;
                Random rand = new Random();
                randomCode = (rand.Next(999999)).ToString();
                MailMessage message = new MailMessage();
                to = (EmailBox.Text).ToString();
                from = "thinkwellsceproject@gmail.com";
                pass = "Harel123";
                messageBody = "Your reset code is " + randomCode;
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "Password Recover- ThinkWell";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try{
                    smtp.Send(message);
                    MessageBox.Show("Code sent succesfully!");
                }
                catch (Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("No Account found", "ok", MessageBoxButtons.OK, MessageBoxIcon.Error);
            con.Close();
            dt.Clear();
        }

        private void button3_Click_1(object sender, EventArgs e){
            if (randomCode == (ResetPass.Text).ToString()){
                SqlConnection con = new SqlConnection(@"Data Source=MATAN-PC;Initial Catalog=master;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[UsersInfoDataBase] SET [Password] = '" + ResetPass.Text + " WHERE Username='" + UserName.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reset Successfully");
                signin myForm = new signin();
                this.Hide();
                myForm.ShowDialog();
                this.Close();
            }
            else
                MessageBox.Show("Wrong Code!");
        }

        private void UserName_TextChanged(object sender, EventArgs e){

        }
    }
}

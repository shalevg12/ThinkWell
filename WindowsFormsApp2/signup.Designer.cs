namespace WindowsFormsApp2
{
    partial class signup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(signup));
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Username = new System.Windows.Forms.TextBox();
            this.FirstName = new System.Windows.Forms.TextBox();
            this.LastName = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.Transparent;
            this.button3.Location = new System.Drawing.Point(88, 36);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 114);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(242, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 99);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.CadetBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(400, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 99);
            this.button2.TabIndex = 7;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button4.Location = new System.Drawing.Point(878, 767);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(167, 48);
            this.button4.TabIndex = 8;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Username
            // 
            this.Username.BackColor = System.Drawing.Color.Gold;
            this.Username.Location = new System.Drawing.Point(878, 319);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(342, 26);
            this.Username.TabIndex = 9;
            // 
            // FirstName
            // 
            this.FirstName.BackColor = System.Drawing.Color.Gold;
            this.FirstName.Location = new System.Drawing.Point(878, 411);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(342, 26);
            this.FirstName.TabIndex = 10;
            // 
            // LastName
            // 
            this.LastName.BackColor = System.Drawing.Color.Gold;
            this.LastName.Location = new System.Drawing.Point(878, 492);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(342, 26);
            this.LastName.TabIndex = 11;
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.Gold;
            this.Email.Location = new System.Drawing.Point(878, 589);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(342, 26);
            this.Email.TabIndex = 12;
            // 
            // Password
            // 
            this.Password.BackColor = System.Drawing.Color.Gold;
            this.Password.Location = new System.Drawing.Point(878, 678);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(342, 26);
            this.Password.TabIndex = 13;
            // 
            // signup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1416, 836);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.FirstName);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Name = "signup";
            this.Load += new System.EventHandler(this.signup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Username;
        private System.Windows.Forms.TextBox FirstName;
        private System.Windows.Forms.TextBox LastName;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox Password;
    }
}
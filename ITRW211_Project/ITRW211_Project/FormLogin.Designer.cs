namespace ITRW211_Project
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelForgot = new System.Windows.Forms.Label();
            this.labelRegister = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(149, 67);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(232, 20);
            this.textBoxUser.TabIndex = 0;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(149, 93);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(232, 20);
            this.textBoxPass.TabIndex = 1;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.White;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Location = new System.Drawing.Point(236, 131);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(145, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.White;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(85, 131);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(145, 23);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(72, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(76, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password: ";
            // 
            // labelForgot
            // 
            this.labelForgot.AutoSize = true;
            this.labelForgot.BackColor = System.Drawing.Color.Transparent;
            this.labelForgot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForgot.ForeColor = System.Drawing.Color.LightPink;
            this.labelForgot.Location = new System.Drawing.Point(12, 323);
            this.labelForgot.Name = "labelForgot";
            this.labelForgot.Size = new System.Drawing.Size(88, 15);
            this.labelForgot.TabIndex = 10;
            this.labelForgot.Text = "Forgot details?";
            this.labelForgot.Click += new System.EventHandler(this.labelForgot_Click);
            // 
            // labelRegister
            // 
            this.labelRegister.AutoSize = true;
            this.labelRegister.BackColor = System.Drawing.Color.Transparent;
            this.labelRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegister.ForeColor = System.Drawing.Color.LightPink;
            this.labelRegister.Location = new System.Drawing.Point(398, 323);
            this.labelRegister.Name = "labelRegister";
            this.labelRegister.Size = new System.Drawing.Size(53, 15);
            this.labelRegister.TabIndex = 11;
            this.labelRegister.Text = "Register";
            this.labelRegister.Click += new System.EventHandler(this.labelRegister_Click);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.BackColor = System.Drawing.Color.Transparent;
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.White;
            this.labelInfo.Location = new System.Drawing.Point(12, 298);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 15);
            this.labelInfo.TabIndex = 12;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(463, 347);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelRegister);
            this.Controls.Add(this.labelForgot);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxUser);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(479, 386);
            this.MinimumSize = new System.Drawing.Size(479, 386);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Article Reader - Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelForgot;
        private System.Windows.Forms.Label labelRegister;
        private System.Windows.Forms.Label labelInfo;
    }
}
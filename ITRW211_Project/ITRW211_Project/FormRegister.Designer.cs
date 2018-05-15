namespace ITRW211_Project
{
    partial class FormRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegister));
            this.buttonRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassCheck = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmailCheck = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.textBoxQuestion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.White;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Location = new System.Drawing.Point(379, 286);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(72, 23);
            this.buttonRegister.TabIndex = 27;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Teal;
            this.label3.Location = new System.Drawing.Point(64, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Username:";
            // 
            // textBoxUser
            // 
            this.textBoxUser.Location = new System.Drawing.Point(138, 64);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(261, 20);
            this.textBoxUser.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Teal;
            this.label4.Location = new System.Drawing.Point(68, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Teal;
            this.label5.Location = new System.Drawing.Point(90, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Email:";
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(138, 90);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(261, 20);
            this.textBoxPass.TabIndex = 20;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(138, 12);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(261, 20);
            this.textBoxEmail.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Teal;
            this.label1.Location = new System.Drawing.Point(37, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "Verify Password:";
            // 
            // textBoxPassCheck
            // 
            this.textBoxPassCheck.Location = new System.Drawing.Point(138, 116);
            this.textBoxPassCheck.Name = "textBoxPassCheck";
            this.textBoxPassCheck.PasswordChar = '*';
            this.textBoxPassCheck.Size = new System.Drawing.Size(261, 20);
            this.textBoxPassCheck.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Teal;
            this.label2.Location = new System.Drawing.Point(58, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Verify Email:";
            // 
            // textBoxEmailCheck
            // 
            this.textBoxEmailCheck.Location = new System.Drawing.Point(138, 38);
            this.textBoxEmailCheck.Name = "textBoxEmailCheck";
            this.textBoxEmailCheck.Size = new System.Drawing.Size(261, 20);
            this.textBoxEmailCheck.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.LightPink;
            this.label6.Location = new System.Drawing.Point(12, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(340, 15);
            this.label6.TabIndex = 32;
            this.label6.Text = "Please provide your email address, username and password.";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.BackColor = System.Drawing.Color.Transparent;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResult.ForeColor = System.Drawing.Color.White;
            this.labelResult.Location = new System.Drawing.Point(12, 308);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(0, 15);
            this.labelResult.TabIndex = 33;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.White;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Location = new System.Drawing.Point(379, 315);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(72, 23);
            this.buttonBack.TabIndex = 34;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(94, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Answer:";
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.Location = new System.Drawing.Point(150, 168);
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(249, 20);
            this.textBoxAnswer.TabIndex = 40;
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.BackColor = System.Drawing.Color.Transparent;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.ForeColor = System.Drawing.Color.White;
            this.labelQuestion.Location = new System.Drawing.Point(39, 143);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(105, 15);
            this.labelQuestion.TabIndex = 39;
            this.labelQuestion.Text = "Security Question:";
            // 
            // textBoxQuestion
            // 
            this.textBoxQuestion.Location = new System.Drawing.Point(150, 142);
            this.textBoxQuestion.Name = "textBoxQuestion";
            this.textBoxQuestion.Size = new System.Drawing.Size(249, 20);
            this.textBoxQuestion.TabIndex = 42;
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(463, 347);
            this.Controls.Add(this.textBoxQuestion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxEmailCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPassCheck);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxEmail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(479, 386);
            this.MinimumSize = new System.Drawing.Size(479, 386);
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Article Reader - Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRegister_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassCheck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmailCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox textBoxQuestion;
    }
}
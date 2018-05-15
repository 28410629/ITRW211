using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITRW211_Project
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string passT = textBoxPass.Text;
            string userT = textBoxUser.Text;
            if (!string.IsNullOrWhiteSpace(userT))
            {
                if (!string.IsNullOrWhiteSpace(passT))
                {
                    DatabaseCommands commands = new DatabaseCommands();
                    if (commands.checkLogin(userT, passT) == 0)
                    {
                        labelInfo.Text = "Login failed";
                    }
                    else
                    {
                        FormMain formMain = new FormMain(this,userT);
                        this.Hide();
                        textBoxPass.Text = "";
                        textBoxUser.Text = "";
                        formMain.Show();
                    }
                }
                else
                {
                    labelInfo.Text = "Please enter a password.";
                }
            }
            else
            {
                labelInfo.Text = "Please enter a username.";
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            FormRegister formMain = new FormRegister(this);
            this.Hide();
            textBoxPass.Text = "";
            textBoxUser.Text = "";
            formMain.Show();
        }

        private void labelForgot_Click(object sender, EventArgs e)
        {
            FormForgot formMain = new FormForgot(this);
            this.Hide();
            textBoxPass.Text = "";
            textBoxUser.Text = "";
            formMain.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBoxUser.Focus();
        }
    }
}

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
    public partial class FormForgot : Form
    {
        Form main;
        public FormForgot(Form main)
        {
            InitializeComponent();
            this.main = main;
            this.label4.Text = "Please provide email address upon registration,\nto reset either password or username.";
        }

        private void FormForgot_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonForgotU_Click(object sender, EventArgs e)
        {
            /*string passT = textBoxPass.Text;
            string userT = textBoxUser.Text;
            if (!string.IsNullOrWhiteSpace(userT))
            {
                if (!string.IsNullOrWhiteSpace(passT))
                {
                    DatabaseCommands commands = new DatabaseCommands();
                    if (commands.checkUser(userT, Hash(passT)) == 0)
                    {
                        labelInfo.Text = "Login failed";
                    }
                    else
                    {
                        FormMain formMain = new FormMain(this, userT);
                        this.Hide();
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
            }*/
        }

        private void FormForgot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonBoth_Click(object sender, EventArgs e)
        {
            buttonForgotU_Click(sender, e);
            buttonForgotP_Click(sender, e);
        }

        private void buttonForgotP_Click(object sender, EventArgs e)
        {
            /*string passT = textBoxPass.Text;
            string userT = textBoxUser.Text;
            if (!string.IsNullOrWhiteSpace(userT))
            {
                if (!string.IsNullOrWhiteSpace(passT))
                {
                    DatabaseCommands commands = new DatabaseCommands();
                    if (commands.checkUser(userT, Hash(passT)) == 0)
                    {
                        labelInfo.Text = "Login failed";
                    }
                    else
                    {
                        FormMain formMain = new FormMain(this, userT);
                        this.Hide();
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
            }*/
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            main.Show();
        }
    }
}

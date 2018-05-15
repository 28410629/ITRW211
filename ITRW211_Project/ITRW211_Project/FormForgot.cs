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

        private void buttonForgotU_Click(object sender, EventArgs e)
        {
            DatabaseCommands databaseCommands = new DatabaseCommands();
            if (databaseCommands.checkEmail(textBoxEmail.Text) == 0)
            {
                labelResult.Text = "Email does not exist in database.";
            }
            else
            {
                if (databaseCommands.checkUser(textBoxUser.Text) == 0)
                {
                    if (databaseCommands.checkQuestion(textBoxEmail.Text, textBoxAnswer.Text) == 0)
                    {
                        labelResult.Text = "Incorrect security answer.";
                    }
                    else
                    {
                        labelResult.Text = databaseCommands.insertUser(textBoxEmail.Text, textBoxUser.Text);
                    }
                }
                else
                {
                    labelResult.Text = "Username exists, please use another.";
                }
            }
        }

        private void FormForgot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonForgotP_Click(object sender, EventArgs e)
        {
            DatabaseCommands databaseCommands = new DatabaseCommands();
            if (databaseCommands.checkEmail(textBoxEmail.Text) == 0)
            {
                labelResult.Text = "Email does not exist in database.";
            }
            else
            {
                if (databaseCommands.checkQuestion(textBoxEmail.Text, textBoxAnswer.Text) == 0)
                {
                    labelResult.Text = "Incorrect security answer.";
                }
                else
                {
                    labelResult.Text = databaseCommands.insertPass(textBoxEmail.Text, textBoxPass.Text);
                }
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            main.Show();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            DatabaseCommands commands = new DatabaseCommands();
            labelQuestion.Text = commands.getQuestion(textBoxEmail.Text);
        }

        private void labelShowHidePass_Click(object sender, EventArgs e)
        {
            if (labelShowHidePass.Text == "Show")
            {
                labelShowHidePass.Text = "Hide";
                textBoxPass.PasswordChar = '\0';
            }
            else
            {
                labelShowHidePass.Text = "Show";
                textBoxPass.PasswordChar = '*';
            }
        }
    }
}

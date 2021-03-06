﻿using System;
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
    public partial class FormRegister : Form
    {
        Form main;
        public FormRegister(Form main)
        {
            InitializeComponent();
            this.main = main;
        }

        private void FormRegister_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            main.Show();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if(textBoxUser.Text.Contains("\'") || textBoxUser.Text.Contains("\"") || textBoxPass.Text.Contains("\'") || textBoxPass.Text.Contains("\"") || textBoxEmail.Text.Contains("\'") || textBoxEmail.Text.Contains("\""))
            {
                labelResult.Text = "The use of invalid characters: \" or \'.";
            }
            else
            {
                if (textBoxEmail.Text == textBoxEmailCheck.Text && textBoxEmail.Text.Contains("@") && textBoxEmail.Text.Contains(".") && !string.IsNullOrWhiteSpace(textBoxEmail.Text))
                {
                    if (textBoxPass.Text == textBoxPassCheck.Text && !string.IsNullOrWhiteSpace(textBoxPass.Text))
                    {
                        DatabaseCommands databaseCommands = new DatabaseCommands();
                        if (databaseCommands.checkUser(textBoxUser.Text) == 0)
                        {
                            if (!string.IsNullOrWhiteSpace(textBoxUser.Text))
                            {
                                if (textBoxQuestion.Text.Length < 47)
                                {
                                    labelResult.Text = databaseCommands.newUser(textBoxEmail.Text, textBoxUser.Text, textBoxPass.Text, textBoxQuestion.Text, textBoxAnswer.Text);
                                }
                                else
                                {
                                    labelResult.Text = "Please make security question shorter.";
                                }
                            }
                            else
                            {
                                labelResult.Text = "Username is whitespace/null, please enter username.";
                            }
                        }
                        else
                        {
                            labelResult.Text = "Username exists, please use another one.";
                        }
                    }
                    else
                    {
                        labelResult.Text = "Passwords do not match or is whitespace/null.";
                    }
                }
                else
                {
                    labelResult.Text = "Invalid email.";
                }
            }
        }

        private void labelShowHidePass_Click(object sender, EventArgs e)
        {
            if (labelShowHidePass.Text == "Show")
            {
                labelShowHidePass.Text = "Hide";
                textBoxPass.PasswordChar = '\0';
                textBoxPassCheck.PasswordChar = '\0';
            }
            else
            {
                labelShowHidePass.Text = "Show";
                textBoxPass.PasswordChar = '*';
                textBoxPassCheck.PasswordChar = '*';
            }
        }
    }
}

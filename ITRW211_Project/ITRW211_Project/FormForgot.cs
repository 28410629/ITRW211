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
            DatabaseCommands databaseCommands = new DatabaseCommands();
            if (databaseCommands.checkEmail(textBoxEmail.Text) == 0)
            {
                labelResult.Text = "Email does not exist in database.";
            }
            else
            {
                labelResult.Text = databaseCommands.insertUser(textBoxEmail.Text, textBoxUser.Text);
            }
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
            DatabaseCommands databaseCommands = new DatabaseCommands();
            if(databaseCommands.checkEmail(textBoxEmail.Text) == 0)
            {
                labelResult.Text = "Email does not exist in database.";
            }
            else
            {
                labelResult.Text = databaseCommands.insertPass(textBoxEmail.Text, textBoxPass.Text);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            main.Show();
        }
    }
}

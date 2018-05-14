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

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool found = false;
            for (int i = 0; i < length; i++)
            {
                
            }
            if (found)
            {
                string dbPassword = "";
                if (Hash(textBoxPass.Text) == dbPassword)
                {
                    FormMain formMain = new FormMain(this, textBoxUser.Text);
                    this.Hide();
                    formMain.Show();
                }
            }
        }
    }
}

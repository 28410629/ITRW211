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
    public partial class SiteLauncherCount : Form
    {
        private Form mainForm;
        string username;

        public SiteLauncherCount(Form mainForm,string username)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.username = username;
        }

        private void buttonArsTechnica_Click(object sender, EventArgs e)
        {
            ViewReadCount newForm = new ViewReadCount("Ars Technica",username);
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }

        private void buttonHackaday_Click(object sender, EventArgs e)
        {
            ViewReadCount newForm = new ViewReadCount("Hackaday",username);
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }

        private void buttonAppleInsider_Click(object sender, EventArgs e)
        {
            ViewReadCount newForm = new ViewReadCount("Apple Insider",username);
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }

        private void labelExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

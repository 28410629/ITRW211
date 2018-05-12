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

        public SiteLauncherCount(Form mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void buttonArsTechnica_Click(object sender, EventArgs e)
        {
            ViewReadCount newForm = new ViewReadCount();
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }

        private void buttonHackaday_Click(object sender, EventArgs e)
        {
            FormHackData newForm = new FormHackData();
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }

        private void buttonAppleInsider_Click(object sender, EventArgs e)
        {
            FormAppleData newForm = new FormAppleData();
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }
    }
}

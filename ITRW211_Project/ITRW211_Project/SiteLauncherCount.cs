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
            ViewReadCount newForm = new ViewReadCount("Ars Technica");
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }

        private void buttonHackaday_Click(object sender, EventArgs e)
        {
            ViewReadCount newForm = new ViewReadCount("Hackaday");
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }

        private void buttonAppleInsider_Click(object sender, EventArgs e)
        {
            ViewReadCount newForm = new ViewReadCount("Apple Insider");
            newForm.MdiParent = mainForm;
            newForm.Show();
            Close();
        }
    }
}

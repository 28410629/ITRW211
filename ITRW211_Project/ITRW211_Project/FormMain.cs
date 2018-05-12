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
    public partial class FormMain : Form
    {
        string theme = "light";
        public FormMain()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a project for ITRW211\n\nDevelopers:\nCoenraad Human 28410629\nPieter Brand\nSavannah Fritze","About", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void openLauncherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SiteLauncher newLauncher = new SiteLauncher(this);
            newLauncher.MdiParent = this;
            newLauncher.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SiteLauncher newLauncher = new SiteLauncher(this);
            newLauncher.MdiParent = this;
            newLauncher.Show();
        }

        private void readArticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiteLauncherCount newLauncher = new SiteLauncherCount(this);
            newLauncher.MdiParent = this;
            newLauncher.Show();
        }

    }
}

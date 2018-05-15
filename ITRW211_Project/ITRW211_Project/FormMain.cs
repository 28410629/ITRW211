using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ITRW211_Project
{
    public partial class FormMain : Form
    {
        Form main;
        string user;

        public FormMain(Form main, string user)
        {
            InitializeComponent();
            this.main = main;
            this.user = user;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a group project for ITRW211.\n\nDevelopers:\nCoenraad Human 28410629\nSavannah Fritze 29158710","About", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void openLauncherToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SiteLauncher newLauncher = new SiteLauncher(this,user);
            newLauncher.MdiParent = this;
            newLauncher.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SiteLauncher newLauncher = new SiteLauncher(this,user);
            newLauncher.MdiParent = this;
            newLauncher.Show();
        }

        private void readArticlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SiteLauncherCount newLauncher = new SiteLauncherCount(this,user);
            newLauncher.MdiParent = this;
            newLauncher.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.Show();

            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/coenraadhuman/ITRW211_Project");
        }
    }
}

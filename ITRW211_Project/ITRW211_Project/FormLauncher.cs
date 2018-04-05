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
    public partial class FormLauncher : Form
    {
        private Form newMain;

        public FormLauncher(Form newMain)
        {
            InitializeComponent();
            this.newMain = newMain;
        }

        private void ArsTechnicaClick(object sender, EventArgs e)
        {
            FormArsTechnica newArs = new FormArsTechnica(newMain);
            newArs.MdiParent = newMain;
            newArs.Show();
            Close();
        }

        private void buttonBoredPanda_Click(object sender, EventArgs e)
        {
            FormBoredPanda newBored = new FormBoredPanda();
            newBored.MdiParent = newMain;
            newBored.Show();
            Close();
        }

        private void buttonHackaday_Click(object sender, EventArgs e)
        {
            FormHackaday newHack = new FormHackaday();
            newHack.MdiParent = newMain;
            newHack.Show();
            Close();
        }
    }
}
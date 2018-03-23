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
        public FormMain()
        {
            InitializeComponent();
        }

        private void ArsTechnicaClick(object sender, EventArgs e)
        {
            FormArsTechnica newArs = new FormArsTechnica();
            newArs.MdiParent = this;
            newArs.Show();
        }

        private void buttonBoredPanda_Click(object sender, EventArgs e)
        {
            FormBoredPanda newBored = new FormBoredPanda();
            newBored.MdiParent = this;
            newBored.Show();
        }

        private void buttonHackaday_Click(object sender, EventArgs e)
        {
            
            FormHackaday newHack = new FormHackaday();
            newHack.MdiParent = this;
            newHack.Show();
        }
    }
}

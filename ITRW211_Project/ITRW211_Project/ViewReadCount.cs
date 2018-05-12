using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ITRW211_Project
{
    public partial class ViewReadCount : Form
    {
        public ViewReadCount()
        {
            InitializeComponent();
        }

        private void FormArsData_Load(object sender, EventArgs e)
        {
            using (OleDbConnection arsDB = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                arsDB.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM ARSTECHNICA",arsDB);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "list");
                dataGridView.DataSource = dataSet;
                dataGridView.DataMember = "list";
                arsDB.Close();
            }
        }
    }
}

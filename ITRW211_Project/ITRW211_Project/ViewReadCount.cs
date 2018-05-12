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

/**
 * Coenraad Human 28410629
 */

namespace ITRW211_Project
{
    public partial class ViewReadCount : Form
    {
        string website;
        public ViewReadCount(string website)
        {
            InitializeComponent();
            if (website == "Ars Technica")
            {
                Text = "View count for articles of Ars Technica : ";
            }
            else if (website == "Hackaday")
            {
                Text = "View count for articles of Hackaday : ";
            }
            else
            {
                Text = "View count for articles of Apple Insider : ";
            }
            this.website = website;
        }
        private void FormArsData_Load(object sender, EventArgs e)
        {
            if (website == "Ars Technica")
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM ARSTECHNICA", database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    dataGridView.DataSource = dataSet;
                    dataGridView.DataMember = "list";
                    database.Close();
                    dataGridView.AutoResizeColumns();
                }
            }
            else if (website == "Hackaday")
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM HACKADAY", database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    dataGridView.DataSource = dataSet;
                    dataGridView.DataMember = "list";
                    database.Close();
                    dataGridView.AutoResizeColumns();
                }
            }
            else
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM APPLEINSIDER", database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    dataGridView.DataSource = dataSet;
                    dataGridView.DataMember = "list";
                    database.Close();
                    dataGridView.AutoResizeColumns();
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            FormArsData_Load(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (website == "Ars Technica")
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM ARSTECHNICA", database);
                    OleDbCommand command = new OleDbCommand(String.Format("DELETE FROM ARSTECHNICA"), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                    database.Open();
                }
            }
            else if (website == "Hackaday")
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM HACKADAY", database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    dataGridView.DataSource = dataSet;
                    dataGridView.DataMember = "list";
                    database.Close();
                    dataGridView.AutoResizeColumns();
                }
            }
            else
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM APPLEINSIDER", database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    dataGridView.DataSource = dataSet;
                    dataGridView.DataMember = "list";
                    database.Close();
                    dataGridView.AutoResizeColumns();
                }
            }
            FormArsData_Load(sender, e);
        }
    }
}

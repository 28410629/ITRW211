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
        string username;
        public ViewReadCount(string website, string username)
        {
            InitializeComponent();
            if (website == "Ars Technica")
            {
                Text = "View count for articles of Ars Technica : ";
            }
            else
            {
                Text = "View count for articles of Apple Insider : ";
            }
            this.website = website;
            this.username = username;
        }
        private void FormArsData_Load(object sender, EventArgs e)
        {
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                string adapterString;
                if (website == "Ars Technica")
                {
                    adapterString = String.Format(@"SELECT FIRSTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT FROM ARSTECHNICA WHERE [USER] = '{0}'", username);
                }
                else
                {
                    adapterString = String.Format(@"SELECT FIRSTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT FROM APPLEINSIDER WHERE [USER] = '{0}'", username);
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(adapterString, database);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "list");
                dataGridView.DataSource = dataSet;
                dataGridView.DataMember = "list";
                database.Close();
                dataGridView.AutoResizeColumns();
            } 
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            FormArsData_Load(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                string adapterString;
                string commandString;
                if (website == "Ars Technica")
                {
                    adapterString = @"SELECT * FROM ARSTECHNICA";
                    commandString = String.Format(@"DELETE FROM ARSTECHNICA WHERE [USER] = '{0}'", username);
                }
                else
                {
                    adapterString = @"SELECT * FROM APPLEINSIDER";
                    commandString = String.Format(@"DELETE FROM APPLEINSIDER WHERE [USER] = '{0}'", username);
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(adapterString, database);
                OleDbCommand command = new OleDbCommand(String.Format(commandString), database);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                database.Close();
                database.Open();
            }
            FormArsData_Load(sender, e);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                database.Open();
                string adapterString;
                string commandString;
                if (website == "Ars Technica")
                {
                    adapterString = @"SELECT * FROM ARSTECHNICA";
                    commandString = String.Format("UPDATE ARSTECHNICA SET VIEWCOUNT = '0' WHERE [USER] = '{0}'", username);
                }
                else
                {
                    adapterString = @"SELECT * FROM APPLEINSIDER";
                    commandString = String.Format("UPDATE APPLEINSIDER SET VIEWCOUNT = '0' WHERE [USER] = '{0}'", username);
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(adapterString, database);
                OleDbCommand command = new OleDbCommand(String.Format(commandString), database);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                database.Close();
                database.Open();
            }
            FormArsData_Load(sender, e);
        }
    }
}

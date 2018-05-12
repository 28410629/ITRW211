using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ITRW211_Project
{
    public class DatabaseCommands
    {
        public void add(string[] arr, string website)
        {
            string articleAbstract = arr[4];
            string articleName = arr[2];
            while (articleAbstract.Contains("\""))
            {
                articleAbstract = articleAbstract.Replace("\"", "");
            }
            while (articleAbstract.Contains("\'"))
            {
                articleAbstract = articleAbstract.Replace("\'", "");
            }
            while (articleName.Contains("\""))
            {
                articleName = articleName.Replace("\"", "");
            }
            while (articleName.Contains("\'"))
            {
                articleName = articleName.Replace("\'", "");
            }
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                if(website == "Ars Technica")
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM ARSTECHNICA", database);
                    OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO ARSTECHNICA (LASTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES({0}, {1}, '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], articleAbstract), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                else if (website == "Hackaday")
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM HACKADAY", database);
                    OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO HACKADAY (LASTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES({0}, {1}, '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], articleAbstract), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                else
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM APPLEINSIDER", database);
                    OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO APPLEINSIDER (LASTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES({0}, {1}, '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], articleAbstract), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
            }
        }
        public void update(string[] arr, string website)
        {
            string articleName = arr[2];
            while (articleName.Contains("\""))
            {
                articleName = articleName.Replace("\"", "");
            }
            while (articleName.Contains("\'"))
            {
                articleName = articleName.Replace("\'", "");
            }

        }
    }
}

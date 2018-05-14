﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace ITRW211_Project
{
    public class DatabaseCommands
    {
        public string[] check(string[] arr)
        {
            string articleAbstract = arr[4];
            string articleName = arr[2];
            string author = arr[3];
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
            while (articleName.Contains(":"))
            {
                articleName = articleName.Replace(":", "");
            }
            while (articleAbstract.Contains(":"))
            {
                articleAbstract = articleAbstract.Replace(":", "");
            }
            while (author.Contains("\""))
            {
                author = author.Replace("\"", "");
            }
            while (author.Contains("\'"))
            {
                author = author.Replace("\'", "");
            }
            arr[4] = articleAbstract;
            arr[2] = articleName;
            arr[3] = author;
            return arr;
        }

        public void add(string[] arr, string website)
        {
            arr = check(arr);
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                if (website == "Ars Technica")
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM ARSTECHNICA", database);
                    OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO ARSTECHNICA (FIRSTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], arr[4]), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                else if (website == "Hackaday")
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM HACKADAY", database);
                    OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO HACKADAY (FISRTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], arr[4]), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                else
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM APPLEINSIDER", database);
                    OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO APPLEINSIDER (FIRSTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], arr[4]), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
            }
        }
        public void update(string[] arr, string website)
        {
            arr = check(arr);
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                if (website == "Ars Technica")
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM ARSTECHNICA", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE ARSTECHNICA SET VIEWCOUNT = {0} WHERE ARTICLE = '{1}'", arr[10], arr[2]), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                else if (website == "Hackaday")
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM HACKADAY", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE HACKADAY SET VIEWCOUNT = {0} WHERE ARTICLE = '{1}'", arr[10], arr[2]), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                else
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM APPLEINSIDER", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE APPLEINSIDER SET VIEWCOUNT = {0} WHERE ARTICLE = '{1}'", arr[10], arr[2]), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
            }
        }
    }
}

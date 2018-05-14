using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace ITRW211_Project
{
    public class DatabaseCommands
    {
        string adapterS;
        string commandS;

        public string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public string[] check(string[] arr)
        {
            while (arr[4].Contains("\""))
            {
                arr[4] = arr[4].Replace("\"", "");
            }
            while (arr[4].Contains("\'"))
            {
                arr[4] = arr[4].Replace("\'", "");
            }
            while (arr[2].Contains("\""))
            {
                arr[2] = arr[2].Replace("\"", "");
            }
            while (arr[2].Contains("\'"))
            {
                arr[2] = arr[2].Replace("\'", "");
            }
            while (arr[2].Contains(":"))
            {
                arr[2] = arr[2].Replace(":", "");
            }
            while (arr[4].Contains(":"))
            {
                arr[4] = arr[4].Replace(":", "");
            }
            while (arr[3].Contains("\""))
            {
                arr[3] = arr[3].Replace("\"", "");
            }
            while (arr[3].Contains("\'"))
            {
                arr[3] = arr[3].Replace("\'", "");
            }
            return arr;
        }

        public void add(string[] arr, string website)
        {
            arr = check(arr);
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                if (website == "Ars Technica")
                {
                    adapterS = @"SELECT * FROM ARSTECHNICA";
                    commandS = String.Format("INSERT INTO ARSTECHNICA (FIRSTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], arr[4]);
                    
                }
                else if (website == "Hackaday")
                {
                    adapterS = @"SELECT * FROM HACKADAY";
                    commandS = String.Format("INSERT INTO HACKADAY (FISRTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], arr[4]);
                }
                else
                {
                    adapterS = @"SELECT * FROM APPLEINSIDER";
                    commandS = String.Format("INSERT INTO APPLEINSIDER (FIRSTDATE,VIEWCOUNT,ARTICLE,AUTHOR,ABSTRACT) VALUES('{0}', '{1}', '{2}', '{3}', '{4}')", DateTime.Today.Date.ToString().Remove(10), arr[10], arr[2], arr[3], arr[4]);
                }
                database.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(adapterS, database);
                OleDbCommand command = new OleDbCommand(commandS, database);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                database.Close();
            }
        }
        public void update(string[] arr, string website)
        {
            arr = check(arr);
            using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.DatabaseConnectionString))
            {
                if (website == "Ars Technica")
                {
                    adapterS = @"SELECT * FROM ARSTECHNICA";
                    commandS = String.Format("UPDATE ARSTECHNICA SET VIEWCOUNT = {0} WHERE ARTICLE = '{1}'", arr[10], arr[2]);
                }
                else if (website == "Hackaday")
                {
                    adapterS = @"SELECT * FROM HACKADAY";
                    commandS = String.Format("UPDATE HACKADAY SET VIEWCOUNT = {0} WHERE ARTICLE = '{1}'", arr[10], arr[2]);
                }
                else
                {
                    adapterS = @"SELECT * FROM APPLEINSIDER";
                    commandS = String.Format("UPDATE APPLEINSIDER SET VIEWCOUNT = {0} WHERE ARTICLE = '{1}'", arr[10], arr[2]);
                }
                database.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(adapterS, database);
                OleDbCommand command = new OleDbCommand(commandS, database);
                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                database.Close();
            }
        }

        public int checkLogin(string user, string pass)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.AccountsConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM LOGINDETAILS WHERE USER = '{0}' AND PASS = '{1}'",user,Hash(pass)), database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    database.Close();
                    return dataSet.Tables[0].Rows.Count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int checkUser(string user)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.AccountsConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM LOGINDETAILS WHERE [USER] = '{0}'", user), database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    database.Close();
                    return dataSet.Tables[0].Rows.Count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int checkEmail(string email)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.AccountsConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(String.Format("SELECT * FROM LOGINDETAILS WHERE [EMAIL] = '{0}'", email), database);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "list");
                    database.Close();
                    return dataSet.Tables[0].Rows.Count;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string insertPass(string email, string pass)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.AccountsConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM LOGINDETAILS", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGINDETAILS SET PASS = '{0}' WHERE EMAIL = '{1}'", Hash(pass), email), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                return "Updated successfully password.";
            }
            catch (Exception)
            {
                return "There was an error updating new password.";
            }
        }

        public string insertUser(string email, string user)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.AccountsConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM LOGINDETAILS", database);
                    OleDbCommand command = new OleDbCommand(String.Format("UPDATE LOGINDETAILS SET [USER] = '{0}' WHERE EMAIL = '{1}'", user, email), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                return "Updated successfully username.";
            }
            catch (Exception)
            {
                return "There was an error updating new username.";
            }
        }

        public string newUser(string email, string user, string pass)
        {
            try
            {
                using (OleDbConnection database = new OleDbConnection(Properties.Settings.Default.AccountsConnectionString))
                {
                    database.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(@"SELECT * FROM LOGINDETAILS", database);
                    OleDbCommand command = new OleDbCommand(String.Format("INSERT INTO LOGINDETAILS ([USER] , PASS , EMAIL) VALUES ('{0}', '{1}', '{2}')", user, Hash(pass), email), database);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    database.Close();
                }
                return "User account created successfully.";
            }
            catch (Exception)
            {
                return "There was an error registering new account.";
            }
        }
    }
}

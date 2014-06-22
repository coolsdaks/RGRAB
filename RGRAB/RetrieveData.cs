using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;

namespace RGRAB
{
    class RetrieveData
    {

        public Double[] getSubSidyRates(string valMonth, string valYear)
        {

                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                SQLiteDataReader sqlite_datareader;
                double valueSubRate = 0.00;
                double valueunSubRate = 0.00;
                Double[] myArray = new Double[2];

                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

                // open the connection:
                sqlite_conn.Open();
            try
            {
                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT Subsidized,NonSubsidized FROM SubValue where Month = '" + valMonth + "' and Year = '"+ valYear +"'; ";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    valueSubRate = Convert.ToDouble(sqlite_datareader.GetString(0));
                    valueunSubRate = Convert.ToDouble(sqlite_datareader.GetString(1));
                }
                myArray[0] = valueSubRate;
                myArray[1] = valueunSubRate;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }

            return myArray;
  
        }
        public static string getReading(string valFlat, string valYear, string valMonth)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            string valUnit = "";

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT Reading_Unit FROM Gas_Reading where Reading_Month = '" + valMonth + "' and Reading_Year = '" + valYear + "' and Flat_No = '" + valFlat + "'; ";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                valUnit = sqlite_datareader.GetString(0);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();

            return (valUnit);
        }
        public static double calcConsumedUnit(double Unit1, double Unit2)
        {
            double diffUnit = 0.0;
            diffUnit = Unit2 - Unit1;

            return (diffUnit);
        }
        public static string Retrieve_Unit(string tempFlatNo, string tempRD)
        {
            //string valueFlatNo = tempFlatNo;
            //string valueDate = tempRD;
            string tempUnit = "";
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT Reading_Unit FROM Gas_Reading where Flat_No = '" + tempFlatNo + "' and Reading_Date = '" + tempRD + "'; ";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                tempUnit = sqlite_datareader.GetString(0);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();

            return (tempUnit);
        }
        public static string getMonth(int valMonth)
        {
            string rdMonth = "";
            switch (valMonth)
            {
                case 1: rdMonth = "January"; break;
                case 2: rdMonth = "February"; break;
                case 3: rdMonth = "March"; break;
                case 4: rdMonth = "April"; break;
                case 5: rdMonth = "May"; break;
                case 6: rdMonth = "June"; break;
                case 7: rdMonth = "July"; break;
                case 8: rdMonth = "August"; break;
                case 9: rdMonth = "September"; break;
                case 10: rdMonth = "October"; break;
                case 11: rdMonth = "November"; break;
                case 12: rdMonth = "December"; break;
            }

            return (rdMonth);
        }
        public static double calculateAmount(double Sub, double unSub, double addUnit, double nonUnit)
        {
            double valueAmount = 0.0;

            valueAmount = ((Sub * nonUnit * 2.6) + (unSub * addUnit * 2.6));

            return(valueAmount);
        }

        public static string Retrieve_LastRD(string tempFlatNo, string tempMonth, string tempYear)
        {
            string tempDate = "";
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT Reading_Date FROM Gas_Reading where Flat_No = '" + tempFlatNo + "' and Reading_Month = '" + tempMonth + "' and Reading_Year = '" + tempYear + "'; ";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                tempDate = sqlite_datareader.GetString(0);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();

            return (tempDate);
        }
    }
}

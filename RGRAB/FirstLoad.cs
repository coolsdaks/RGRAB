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
    class FirstLoad
    {
        public static List<string> Retrieve_fl()
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            List<string> listFlatNo = new List<string>();

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT Flat_No FROM Resident_Detail order by Flat_No asc";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                String result = sqlite_datareader.GetString(0);
                listFlatNo.Add(result);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();

            return (listFlatNo);
        }

        public List<Invoice_Retrieve> getInvoiceDetail(string tempMonth, string tempYear)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            List<Invoice_Retrieve> invoiceRetList = new List<Invoice_Retrieve>();
            
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");
                try
                {
                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "Select ID.Flat_No,RD.Name,RD.SubSidy_Status,ID.Current_Date, ID.Current_Unit, ID.Last_Date, ID.Last_Unit, ID.Subsidy_Unit, ID.NonSubsidy_Unit, ID.Span,ID.Unit, ID.Invoice_Amount  from Invoice_Detail as ID, Resident_detail as RD where ID.Reading_Month = '" + tempMonth + "' and ID.Reading_Year = '" + tempYear + "' and ID.Flat_No = RD.Flat_no;";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                Invoice_Retrieve invRet = null;

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    //Move the values to the corresponding fields
                    invRet = new Invoice_Retrieve();
                    invRet.FlatNo = sqlite_datareader.GetString(0);
                    invRet.Name = sqlite_datareader.GetString(1);
                    invRet.SubStatus = sqlite_datareader.GetString(2);
                    invRet.CurrentDate = sqlite_datareader.GetString(3);
                    invRet.CurrentUnit = sqlite_datareader.GetString(4);
                    invRet.LastDate = sqlite_datareader.GetString(5);
                    invRet.LastUnit = sqlite_datareader.GetString(6);
                    invRet.SubsidyUnit = sqlite_datareader.GetString(7);
                    invRet.NonSubsidyUnit = sqlite_datareader.GetString(8);
                    invRet.Span = sqlite_datareader.GetString(9);
                    invRet.Unit = sqlite_datareader.GetString(10);
                    invRet.Amount = sqlite_datareader.GetString(11);
                    invoiceRetList.Add(invRet);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }
         
            return (invoiceRetList);

        }


        public List<ConsumptionDetail> getConsumption()
        {
            
            double usage = 0.00;
            string valueMonth = "";
            DateTime tempYear;
            string calcYear = "";

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            List<ConsumptionDetail> consumptionList = new List<ConsumptionDetail>();
            
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");
                try
                {
                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "Select rd.Flat_No, rd.Name, rd.Total_Units, gr.Reading_Month,gr.Reading_Year from Resident_Detail rd, Gas_Reading gr where rd.Flat_No = gr.Flat_No and rd.Total_units = gr.Reading_Unit;";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                ConsumptionDetail consump = null;

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    //Move the values to the corresponding fields
                    consump = new ConsumptionDetail();
                    string valueFlatNo = consump.FlatNo = sqlite_datareader.GetString(0);
                    consump.Name = sqlite_datareader.GetString(1);
                    usage = Convert.ToDouble(sqlite_datareader.GetString(2));
                    valueMonth = sqlite_datareader.GetString(3);
                    string valYear = sqlite_datareader.GetString(4);

                    int valMonth = Convert.ToDateTime("01-" + valueMonth + "-2011").Month;
                    
                    if ((valMonth == 3) && (valYear == "2014"))
                    {
                        valMonth = 4;
                    }

                    if ((valMonth >= 1) && (valMonth <= 3))
                    {
                        tempYear = DateTime.Today.AddYears(-1);
                        calcYear = tempYear.Year.ToString();
                    }
                    else if ((valMonth >= 4) && (valMonth <= 12))
                    {
                        calcYear = DateTime.Now.Year.ToString();
                    }

                    double baseUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, calcYear, "March"));
                    double currentUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, valYear, valueMonth));

                    double diffUnit = RetrieveData.calcConsumedUnit(baseUnit, currentUnit);

                    double tempUnit = Math.Round(((diffUnit * 2.6) / 14),0);

                    string totalConsumption = consump.Consumption = Convert.ToString(tempUnit);

                    consumptionList.Add(consump);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }

                return (consumptionList);

        }

        public List<DefaulterDetail> getDefaulter(string tempMonth)
        {
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            List<DefaulterDetail> defaulterList = new List<DefaulterDetail>();

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");
            try
            {
                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT id.Flat_No, rd.Name, id.Invoice_Amount from Invoice_detail id, Resident_Detail rd where id.Reading_Month = '" + tempMonth + "' and id.Paid_Amount is null and id.Flat_No =  rd.Flat_No";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                DefaulterDetail defaulter = null;

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    //Move the values to the corresponding fields
                    defaulter = new DefaulterDetail();
                    defaulter.FlatNo = sqlite_datareader.GetString(0);
                    defaulter.Name = sqlite_datareader.GetString(1);
                    defaulter.Amount = sqlite_datareader.GetString(2);

                    defaulterList.Add(defaulter);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }

            return (defaulterList);

        }
  }
}

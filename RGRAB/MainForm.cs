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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnOptions_Click(object sender, EventArgs e)
         {
             string senderValue = "options";
             Security passForm = new Security(senderValue);
             passForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteCommand sqlite_cmd1;
            SQLiteDataReader sqlite_datareader;
            //SQLiteDataReader sqlite_datareader1;
            DateTime tempYear;
            string calcYear = "";
            //string valueMonth = "";

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=GasDb.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd1 = sqlite_conn.CreateCommand();

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Let the SQLiteCommand object know our SQL-Query:
                sqlite_cmd.CommandText = "SELECT gr.Flat_No,gr.Reading_Unit, gr.Reading_Month from Gas_reading gr INNER JOIN (SELECT max(Reading_Unit) as maxunit, Flat_No from Gas_Reading GROUP BY Flat_No) tgr on gr.Flat_No = tgr.Flat_No and gr.Reading_Unit = tgr.maxunit GROUP BY gr.Flat_No";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {

                    string valueFlatNo = sqlite_datareader.GetString(0);
                    string valueUnit = sqlite_datareader.GetString(1);
                    string valueMonth = sqlite_datareader.GetString(2);
                    
                    // Let the SQLiteCommand object know our SQL-Query:
                    sqlite_cmd1.CommandText = "UPDATE Resident_Detail SET Total_Units = '" + valueUnit + "' where Flat_No  = '" + valueFlatNo + "';";

                    // Now lets execute the SQL ;D
                    sqlite_cmd1.ExecuteNonQuery();

                    //Code to decide the subsidy status of the resident
                    int valMonth = Convert.ToDateTime("01-" + valueMonth + "-2011").Month; 
                    string currentMonth = RetrieveData.getMonth(valMonth);
                    string valYear = DateTime.Now.Year.ToString();


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
                    if (diffUnit > 64)
                    {
                        // Let the SQLiteCommand object know our SQL-Query:
                        sqlite_cmd1.CommandText = "UPDATE Resident_Detail SET Subsidy_Status = 'UnSubsidized' where Flat_No  = '" + valueFlatNo + "';";

                        // Now lets execute the SQL ;D
                        sqlite_cmd1.ExecuteNonQuery();
                    }
                 }
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Total Consumption updated for all Residents");

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
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            string senderValue = "database";
            Security passForm = new Security(senderValue);
            passForm.Show();
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            DataInput dataForm = new DataInput();
            dataForm.Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            BillingForm billForm = new BillingForm();
            billForm.Show();
        }

        private void clkCloseMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }
    }
}

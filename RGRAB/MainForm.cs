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

        private void button3_Click(object sender, EventArgs e)
         {
            Security passform = new Security();
            passform.Show(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteCommand sqlite_cmd1;
            SQLiteDataReader sqlite_datareader;
            DateTime tempYear;
            string calcYear = "";

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
                //sqlite_cmd.CommandText = "Select Distinct(Flat_No) from Resident_Detail;";
                sqlite_cmd.CommandText = "SELECT max(Reading_Unit), Flat_No from Gas_Reading GROUP BY Flat_No ORDER BY Flat_No;";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {

                    string valueUnit = sqlite_datareader.GetString(0);
                    string valueFlatNo = sqlite_datareader.GetString(1);


                    // Let the SQLiteCommand object know our SQL-Query:
                    sqlite_cmd1.CommandText = "UPDATE Resident_Detail SET Total_Units = '" + valueUnit + "' where Flat_No  = '" + valueFlatNo + "';";

                    // Now lets execute the SQL ;D
                    sqlite_cmd1.ExecuteNonQuery();

                    //Code to decide the subsidy status of the resident
                    int valMonth = DateTime.Today.Month;
                    //int tempMonth = Convert.ToInt32(valMonth);
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
                    double currentUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, valYear, currentMonth));

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

        private void button5_Click(object sender, EventArgs e)
        {
            Security passform = new Security();
            passform.Show(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataInput form1 = new DataInput();
            form1.Show();
        }

        private void btnBilling_Click(object sender, EventArgs e)
        {
            BillingForm form4 = new BillingForm();
            form4.Show();
        }

        private void clkCloseMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

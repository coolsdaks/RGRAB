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
using System.Data.OleDb;


namespace RGRAB
{
    public partial class DataInput : Form
    {
        public DataInput()
        {
            InitializeComponent();
            List<string> listFlatNo = FirstLoad.Retrieve_fl();
            for (int i = 0; i < listFlatNo.Count; i++) // Loop through List with for
            {
                selFlatNo.Items.Add(listFlatNo[i]);
            }
        }
        private void clkSubmit_Click(object sender, EventArgs e)
        {
            string valueFlatNo = selFlatNo.Text;
            string valueMonth = selMonth.Text;
            string valueDate = dateTimePicker1.Text;
            string valueUnit = untInput.Text;
            string currentYear = DateTime.Now.Year.ToString();

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            if (valueFlatNo == "")
            {
                MessageBox.Show("Please select Flat");
                return;
            }
            else if (valueMonth == "")
            {
                MessageBox.Show("Please select Month");
                return;
            }
            else if (valueUnit == "")
            {
                MessageBox.Show("Please enter the reading unit to be updated");
                return;
            }

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=GasDb.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            try
            {
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "INSERT Into Gas_Reading (Flat_No,Reading_Year,Reading_Month,Reading_Date,Reading_Unit) values ('" + valueFlatNo + "','"+ currentYear +"','" + valueMonth + "','" + valueDate + "','" + valueUnit + "')";

                // And execute this again ;D
                sqlite_cmd.ExecuteNonQuery();

                // We are ready, now lets cleanup and close our connection:
                MessageBox.Show("Reading updated successfully for '" + valueFlatNo + "'");

            }
            catch (Exception ex)
            {
                string except1 = ex.Message.ToString();
                if (except1 == ("columns Flat_No, Reading_Year, Reading_Month are not unique"))
                {
                    DialogResult dialogResult = MessageBox.Show("Reading exists for '" + valueFlatNo + "' for the month of '" + valueMonth + "'. Update Reading?","Warning!!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // First lets build a SQL-Query again:
                        sqlite_cmd.CommandText = "UPDATE Gas_Reading SET Reading_Date = '" + valueDate + "',Reading_Unit =  '" + valueUnit + "' where Flat_No = '" + valueFlatNo + "' and Reading_Month = '" + valueMonth + "' and Reading_Year = '" + currentYear + "'";

                        // And execute this again ;D
                        sqlite_cmd.ExecuteNonQuery();

                        MessageBox.Show("Reading updated successfully for '" + valueFlatNo + "'");
                        selFlatNo_SelectedIndexChanged_1(this, null);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }                    
                }
                else
                {
                    MessageBox.Show(except1);
                    return;
                }
            }
            finally
            {
                sqlite_conn.Close();
                selFlatNo_SelectedIndexChanged_1(this, null);
            }
        }

        private void clkClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selFlatNo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string valueFlatNo = selFlatNo.Text;
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=GasDb.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            //Query to build up the maximun units consumed by the resident along with the details.
            //sqlite_cmd.CommandText = "SELECT Name,Subsidy_Status,Total_Units FROM Resident_Detail where Flat_No = '" + valueFlatNo + "' ";
            sqlite_cmd.CommandText = "SELECT RD.Name,RD.Subsidy_Status,max(GR. Reading_Unit) FROM Resident_Detail as RD, Gas_Reading as GR where RD.Flat_No = '" + valueFlatNo + "' and GR.Flat_No = RD.Flat_No group by RD.Flat_No;";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                string Name = sqlite_datareader.GetString(0);
                currentResident.Text = Name;
                string SubStatus = sqlite_datareader.GetString(1);
                subStatus.Text = SubStatus;
                string valueUnits = sqlite_datareader.GetString(2);
                textConsumption.Text = valueUnits;
            }
            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }

        private void btchImport_Click(object sender, EventArgs e)
        {

            string strFilePath = textFilePath.Text;
            string valueMonth = selMonth1.Text;
            string currentYear = yearText.Text;

            DateTime now = DateTime.Today;
            string valueDate = now.GetDateTimeFormats('d')[0];

            if (strFilePath == "")
            {
                MessageBox.Show("Please select the Reading Data file to be imported!");
                return;
            }
            else if (currentYear == "")
            {
                MessageBox.Show("Please select the year for reading import!");
                return;
            }
            else if (valueMonth == "")
            {
                MessageBox.Show("Please select the month for reading import!");
                return;
            }

            // Waiting / hour glass 
            Cursor.Current = Cursors.WaitCursor;
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
            string myexceldataquery = "select * from [Reading$]";
            //timer1.Enabled = true;

            //create our connection strings
            string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + strFilePath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            //series of commands to bulk copy data from the excel file into our sql table
            OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
            OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
            oledbconn.Open();
            OleDbDataReader dr = oledbcmd.ExecuteReader();
            try
            {
                    string FlatNo = "";
                    string Unit = "";

                    while (dr.Read())
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                        FlatNo = valid(dr, 0);
                        Unit = valid(dr, 1);
                        //Insert a new row for the flat and month reading
                        sqlite_cmd.CommandText = "INSERT Into Gas_Reading (Flat_No,Reading_Year,Reading_Month,Reading_Date,Reading_Unit) values ('" + FlatNo + "','"+ currentYear +"','" + valueMonth + "','" + valueDate + "','" + Unit + "')";
                        //Execute the query
                        sqlite_cmd.ExecuteNonQuery();
                    }
            }
            catch (Exception ex)
            {
                string except1 = ex.Message.ToString();
                if (except1 == ("columns Flat_No, Reading_Year, Reading_Month are not unique"))
                {
                    MessageBox.Show("Data already exists for the given month");
                    return;
                }
                else
                {
                    MessageBox.Show(ex.Message.ToString());
                    return;
                }
            }
            finally
            {
               oledbconn.Close();
               sqlite_conn.Close();
            }
        }

        private void clkReset_Click(object sender, EventArgs e)
        {
            List<string> listFlatNo = FirstLoad.Retrieve_fl();
            for (int i = 0; i < listFlatNo.Count; i++) // Loop through List with for
            {
                selFlatNo.Items.Add(listFlatNo[i]);
            }
            selFlatNo.Text = "";
            currentResident.Text = "";
            subStatus.Text = "";
            selMonth.Text = "";
            untInput.Text = "";
            textConsumption.Text = "";
        }
        
        //if any columns are found null then they are replaced by zero
        protected string valid(OleDbDataReader myreader, int stval)
        
        {
            object val = myreader[stval];
            if (val != DBNull.Value)
                return val.ToString();
            else
                return Convert.ToString(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            importProgress.Increment(10);
            if (importProgress.Value == 100)
            {
                timer1.Enabled = false;
                // Back to normal 
                Cursor.Current = Cursors.Default; 
                MessageBox.Show("Reading Data imported successfully for the month chosen!");

            }
        }

        private void selFile_Click(object sender, EventArgs e)
        {
            string strFilePath = "";

            OpenFileDialog fDialog = new OpenFileDialog();
            //MessageBox.Show("Please ensure the detail file is in XLS Format!!");
            fDialog.Title = "Select Reading Input file";
            fDialog.Filter = "(*.xls)|*.xls";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = fDialog.FileName.ToString();
                textFilePath.Text = strFilePath;
            }
        }

   }
}


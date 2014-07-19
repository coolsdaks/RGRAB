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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            List<string> listFlatNo = FirstLoad.Retrieve_fl();
            for (int i = 0; i < listFlatNo.Count; i++) // Loop through List with for
            {
                selFlatNo.Items.Add(listFlatNo[i]);
            }
        }
        private void subMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string mnthValue = subMonth.SelectedItem.ToString();
            string currentYear = DateTime.Now.Year.ToString();
            RetrieveData retrieveSubsidyRates = new RetrieveData();
            Double[] subRateArr = retrieveSubsidyRates.getSubSidyRates(mnthValue, currentYear);
            subText.Text = subRateArr[0].ToString();
            unsubText.Text = subRateArr[1].ToString();
            yearText.Text = currentYear;
        }

        private void clkCloseOptions_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updSubsidy_Click(object sender, EventArgs e)
        {
            string temp1 = subText.Text;
            string temp2 = unsubText.Text;
            string mnthValue = subMonth.Text;
            double subValue = Convert.ToDouble(temp1);
            double unsubValue = Convert.ToDouble(temp2);
            string currentYear = yearText.Text;


            // We use these three SQLite objects:
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            //SQLiteParameter param;
            
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "INSERT Into SubValue (Year, Month, Subsidized, NonSubsidized) values('" + currentYear + "', '" + mnthValue + "', '" + subValue + "','" + unsubValue + "')";

                // And execute this again ;D
                sqlite_cmd.ExecuteNonQuery();

                MessageBox.Show("Subsidy Values updated successfully for '" + mnthValue + "','" + currentYear + "'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string except1 = ex.Message.ToString();
                if (except1 == ("columns Year, Month are not unique"))
                {
                    DialogResult dialogResult = MessageBox.Show("Data exists for the month of '" + mnthValue + "','" + currentYear + "'. Update Reading?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // First lets build a SQL-Query again:
                        sqlite_cmd.CommandText = "UPDATE SubValue SET Subsidized = '" + subValue + "',NonSubsidized =  '" + unsubValue + "' where Year = '" + currentYear + "' and Month = '" + mnthValue + "'";

                        // And execute this again ;D
                        sqlite_cmd.ExecuteNonQuery();

                        MessageBox.Show("Subsidy Values updated successfully for '" + mnthValue + "','" + currentYear + "'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //selFlatNo_SelectedIndexChanged_1(this, null);
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
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }
        }

        private void selFlatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueFlatNo = selFlatNo.Text;
            futureResident.Text = "";
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
            sqlite_cmd.CommandText = "SELECT Name,Subsidy_Status FROM Resident_Detail where Flat_No = '" + valueFlatNo + "' ";

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
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }

        private void updResidentName_Click(object sender, EventArgs e)
        {
            
                string valueName = futureResident.Text;
                string valueFlatNo = selFlatNo.Text;
                string valueSubsidy = subStatus.Text;
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;

                if (valueName == "")
                {
                    MessageBox.Show("Please enter the Future Resident Name. Copy the Current Resident (name) in case name change is not needed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();
                try
                {
                    // First lets build a SQL-Query again:
                    sqlite_cmd.CommandText = "UPDATE Resident_Detail SET Name = '" + valueName + "',Subsidy_Status = '" + valueSubsidy + "' where Flat_No = '" + valueFlatNo + "' ";

                    // And execute this again ;D
                    sqlite_cmd.ExecuteNonQuery();

                    MessageBox.Show("Details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    // We are ready, now lets cleanup and close our connection:
                    sqlite_conn.Close();
                }   

        }

        private void yearText_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mnthValue = subMonth.SelectedItem.ToString();
            string currentYear = yearText.Text;
            subText.Text = "";
            unsubText.Text = "";
            RetrieveData retrieveSubsidyRates = new RetrieveData();
            Double[] subRateArr = retrieveSubsidyRates.getSubSidyRates(mnthValue, currentYear);
            subText.Text = subRateArr[0].ToString();
            unsubText.Text = subRateArr[1].ToString();
            yearText.Text = currentYear;
          
        }

        private void subText_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && subText.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void unsubText_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && unsubText.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void futureResident_KeyPress(object sender, KeyPressEventArgs e)
        {

            char ch = e.KeyChar;

            if (!char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

    }
}

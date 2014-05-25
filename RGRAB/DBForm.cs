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
    public partial class DBForm : Form
    {
        public DBForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Define the Variables
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            string currentYear = DateTime.Now.Year.ToString();
            Cursor.Current = Cursors.WaitCursor;
            sqlite_conn = new SQLiteConnection("Data Source=GasDB.db;Version=3;New=True;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                // Creating the subsidy table first
                //sqlite_cmd.CommandText = "CREATE TABLE SubValue (id integer PRIMARY KEY, Month varchar(10) NOT NULL, Subsidized double, NonSubsidized double);";
                sqlite_cmd.CommandText = "CREATE TABLE SubValue (Year Varchar(04) NOT NULL, Month varchar(10) NOT NULL, Subsidized double, NonSubsidized double, PRIMARY KEY(Year,Month));";


                // Now lets execute the SQL ;D
                sqlite_cmd.ExecuteNonQuery();

                //Entering Initial data for Subsidy table
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('"+ currentYear +"', 'January', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'February', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'March', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'April', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'May', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'June', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'July', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'August', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'September', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'October', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'November', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = "INSERT INTO SubValue (Year, Month, Subsidized, NonSubsidized) VALUES ('" + currentYear + "', 'December', 0.00, 0.00);";
                sqlite_cmd.ExecuteNonQuery();

                //Creating the Resident information table
                sqlite_cmd.CommandText = "CREATE TABLE Resident_Detail (Flat_No varchar(10) PRIMARY KEY NOT NULL, Name varchar(200), Subsidy_Status varchar(10),Total_Units double);";
                //Execute the sql
                sqlite_cmd.ExecuteNonQuery();

                //Creating the reading input table
                sqlite_cmd.CommandText = "CREATE TABLE Gas_Reading (Flat_No varchar(10) NOT NULL, Reading_Year varchar(04) NOT NULL, Reading_Month varchar(10) NOT NULL, Reading_Date date, Reading_Unit double, PRIMARY KEY (Flat_No, Reading_Year, Reading_Month), FOREIGN KEY(Flat_No) REFERENCES Resident_Detail(Flat_No));";
                //Execute the query
                sqlite_cmd.ExecuteNonQuery();

                //Creating the reading input table
                sqlite_cmd.CommandText = "CREATE TABLE Invoice_Detail (Flat_No varchar(10) NOT NULL, Reading_Year varchar(04) NOT NULL, Reading_Month varchar(10) NOT NULL, Current_Date date, Current_Unit double,Last_Date date, Last_Unit double,Subsidy_Unit double, NonSubsidy_Unit double, Span varchar(02),Unit double, Invoice_Date date, Paid_Date date, Invoice_Amount double, Paid_Amount double, PRIMARY KEY (Flat_No, Reading_Year, Reading_Month), FOREIGN KEY(Flat_No) REFERENCES Resident_Detail(Flat_No));";
                //Execute the query
                sqlite_cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
                Cursor.Current = Cursors.Default;
                MessageBox.Show("All Databases successfully created");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void initImport_Click(object sender, EventArgs e)
        {
            string strFilePath ="";

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            OpenFileDialog fDialog = new OpenFileDialog();
            MessageBox.Show("Please ensure the detail file is in XLS Format!!");
            fDialog.Title = "Select Resident Detail file";
            fDialog.Filter = "(*.xls)|*.xls";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                strFilePath = fDialog.FileName.ToString();
            }
            string ssqltable = "Resident_Detail";
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different
            string myexceldataquery = "select FlatNo,Name,SubsidyStatus,TotalUnits from [Detail$]";
            //timer1.Enabled = true;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

               //create our connection strings
                string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + strFilePath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                
                // create a new database connection:
                sqlite_conn = new SQLiteConnection("Data Source=GasDB.db;Version=3;New=False;Compress=True;");  
                          
                // open the connection:
                sqlite_conn.Open();

                // create a new SQL command:
                sqlite_cmd = sqlite_conn.CreateCommand();

                //execute a query to erase any previous data from our destination table
                sqlite_cmd.CommandText = "delete from '" + ssqltable + "'";

                // Now lets execute the SQL ;D
                sqlite_cmd.ExecuteNonQuery();

                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();

                while (dr.Read())
                {
                    timer1.Enabled = true;
                    timer1.Start();
                    string FlatNo = dr.GetString(0);
                    string Name = dr.GetString(1);
                    string Status = dr.GetString(2);

                    sqlite_cmd.CommandText = "INSERT INTO Resident_Detail (Flat_No, Name,Subsidy_Status,Total_Units) VALUES ('"+ FlatNo +"', '"+ Name +"','"+ Status +"',0.00);";
                    sqlite_cmd.ExecuteNonQuery();
                }

                oledbconn.Close();
                sqlite_conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
           }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(10);
            if (progressBar1.Value > 90)
            {
                timer1.Enabled = false;
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Resident Details successfully Updated");

            }
        }

        }
    }
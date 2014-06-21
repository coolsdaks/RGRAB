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
    public partial class DefaulterReportForm : Form
    {
        public DefaulterReportForm()
        {
            InitializeComponent();
            ReportForm rptForm = new ReportForm();
            string tempMonth = rptForm.defaultMonth.Text;
            
            loadDefaultReport(tempMonth);
        }
        
        private void loadDefaultReport(string valMonth)
        {


            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            //SQLiteDataReader sqlite_datareader;
            DataTable dt = new DataTable();
            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=GasDb.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT id.Flat_No as FlatNo, rd.Name as ResidentName, id.Invoice_Amount as BillAmount from Invoice_detail id, Resident_Detail rd where id.Reading_Month = '"+valMonth+"' and id.Paid_Amount is null and id.Flat_No =  rd.Flat_No";


            SQLiteDataAdapter db = new SQLiteDataAdapter(sqlite_cmd);
            db.Fill(dt);
            //// Now the SQLiteCommand object can give us a DataReader-Object:
            //sqlite_datareader = sqlite_cmd.ExecuteReader();

            dataGridView1.DataSource = dt;
            //dataGridView1.DataBind();

            //// The SQLiteDataReader allows us to run through the result lines:
            //while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            //{
            //    // Print out the content of the text field:
            //    DataSet ds = new DataSet();
            //    DataGrid dt = new DataGrid();

            //    String result = sqlite_datareader.GetString(0);
            //}

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

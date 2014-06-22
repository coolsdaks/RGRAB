using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;



namespace RGRAB
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        int itemCount = 0;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rptConsumptionReport_Click(object sender, EventArgs e)
        {
            ConsumptionPrint();
        }

        public void ConsumptionPrint()
        {

            PrintDocument pdoc = new PrintDocument();
            PrintDialog pd = new PrintDialog();
            PrinterSettings ps = new PrinterSettings();

            pd.Document = pdoc;
            pdoc.DefaultPageSettings.Margins.Bottom = 0;
            pdoc.DefaultPageSettings.Margins.Left = 0;
            pdoc.DefaultPageSettings.Margins.Right = 0;
            pdoc.DefaultPageSettings.Margins.Top = 0;

            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
                result = pp.ShowDialog();
                if (result == DialogResult.OK)
                {
                pdoc.Print();
                }
            }
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {

            //string valueMonth = subBatchMonth.Text;
            string currentYear = DateTime.Now.Year.ToString();
            string underLine = "-------------------------------------------------------------------";

            int itemCounter = 0;

            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            SolidBrush brush = new SolidBrush(Color.Black);
            e.PageSettings.PaperSize = new PaperSize("A4", 850, 1100);
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            //float fontHeight = font.GetHeight();

            int startX = 100;
            int startY = 25;
            int OffsetY = 20;
            DateTime today = DateTime.Today;
            string Today = today.ToString("MM/dd/yyyy"); // As String

            graphics.DrawString("Mont Vert Seville CHS Gas Consumption Report", new Font("Courier New", 16, FontStyle.Bold), brush, startX, startY + OffsetY);

            OffsetY = OffsetY + 30;
            graphics.DrawString("Date:" + Today, font, brush, startX, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);

            OffsetY = OffsetY + 30;
            graphics.DrawString("Flat No", new Font("Courier New", 12, FontStyle.Bold), brush, startX, startY + OffsetY);
            graphics.DrawString("Resident Name", new Font("Courier New", 12, FontStyle.Bold), brush, (startX + 170), startY + OffsetY);
            graphics.DrawString("Consumption (Cylinder Units)", new Font("Courier New", 12, FontStyle.Bold), brush, (startX + 400), startY + OffsetY);

            FirstLoad fstLoad = new FirstLoad();
            List<ConsumptionDetail> consumptionList = fstLoad.getConsumption();
            ConsumptionDetail consumptionDet;

            for (int i = itemCount; i < consumptionList.Count; i++) // Loop through List with for
            {
                if (itemCount < consumptionList.Count)
                {
                    consumptionDet = consumptionList[i];

                    string flatNo = consumptionDet.FlatNo;
                    string residentName = consumptionDet.Name;
                    string consumption = consumptionDet.Consumption;

                    OffsetY = OffsetY + 30;
                    graphics.DrawString(flatNo, font, brush, (startX + 10), startY + OffsetY);
                    graphics.DrawString(residentName, font, brush, (startX + 150), startY + OffsetY);
                    graphics.DrawString(consumption, font, brush, (startX + 475), startY + OffsetY);

                    OffsetY = OffsetY + 15;

                    itemCounter++;
                    itemCount++;

                    if ((itemCounter == 50) && (itemCount < consumptionList.Count))
                    {
                        e.HasMorePages = true;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }

                }
            }
        }

        private void rptDefaulterReport_Click(object sender, EventArgs e)
        {
            string valMonth = defaultMonth.Text;
            if (valMonth == "")
            {
                MessageBox.Show("Please select the month for generating defaulter report");
                return;
            }
            DefaulterReportForm defaultForm = new DefaulterReportForm(valMonth);
            defaultForm.Show();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            string valueDate = dateTimePicker1.Text;
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
            sqlite_cmd.CommandText = "Select Sum(Paid_Amount) from Invoice_Detail where Paid_Date = '"+ valueDate +"';; ";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                // Print out the content of the text field:
                textCollection.Text = sqlite_datareader.GetString(0);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }
    }
}

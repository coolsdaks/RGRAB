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
    public partial class BillingForm : Form
    {
        public BillingForm()
        {
            InitializeComponent();
            List<string> listFlatNo = FirstLoad.Retrieve_fl();
            for (int i = 0; i < listFlatNo.Count; i++) // Loop through List with for
            {
                selFlatNo.Items.Add(listFlatNo[i]);
            }
        }
        private void clkCloseInput_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selFlatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueFlatNo = selFlatNo.Text;
            clkReset_Click(this, null);
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=GasDb.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT RD.Name,RD.Subsidy_Status, GR.Reading_Date FROM Resident_Detail as RD, Gas_Reading as GR where RD.Flat_No = '" + valueFlatNo + "' and RD.Flat_No = GR.Flat_No; ";

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
                String tempRD = sqlite_datareader.GetString(2);
                lastRD.Items.Add(tempRD);
                currentRD.Items.Add(tempRD);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }

        private void lastRD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tempUnit = "";
            string valueFlatNo = selFlatNo.Text;
            string valueDate = lastRD.Text;
            tempUnit = RetrieveData.Retrieve_Unit(valueFlatNo, valueDate);
            lastUnit.Text = tempUnit;

        }
        private void currentRD_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tempUnit = "";
            string valueFlatNo = selFlatNo.Text;
            string valueDate = currentRD.Text;

            tempUnit = RetrieveData.Retrieve_Unit(valueFlatNo, valueDate);
            currentUnit.Text = tempUnit;
        }
        private void clkCalculate_Click(object sender, EventArgs e)
        {
            string valueFlatNo = selFlatNo.Text;
            string valueDate = currentRD.Text;
            string calcYear = "";
            DateTime tempYear;
            double addUnit = 0.0;
            double nonUnit = 0.0;
            double calcAmount = 0.0;
            double valuePenalty = Convert.ToDouble(penaltyText.Text);
            double valueSub = 0.0;
            double valueunSub = 0.0;

            DateTime minValue = Convert.ToDateTime(lastRD.Text).Date;
            DateTime maxValue = Convert.ToDateTime(currentRD.Text).Date;
            string currentYear = DateTime.Now.Year.ToString();


            TimeSpan diff = maxValue - minValue;
            string span = diff.TotalDays.ToString();
            textUsage.Text = span;

            string valueMonth = DateTime.Parse(valueDate).Month.ToString();
            string valueYear = DateTime.Parse(valueDate).Year.ToString();
            int tempMonth = Convert.ToInt32(valueMonth);
            int prevMonth1 = 0;
            string currentMonth = RetrieveData.getMonth(tempMonth);
            //Get previous month from the reading Month
            if (tempMonth == 1)
            {
                prevMonth1 = 12;
            }
            else
            {
                prevMonth1 = tempMonth - 1;
            }

            string prevMonth = RetrieveData.getMonth(prevMonth1);

            RetrieveData retrieveSubsidyRates = new RetrieveData();
            Double[] subRateArr = retrieveSubsidyRates.getSubSidyRates(currentMonth, currentYear);
            valueSub = subRateArr[0];
            valueunSub = subRateArr[1];
            //publish the rates on the form 
            textSubsidyRate.Text = subRateArr[0].ToString();
            textNonSubsidyRate.Text = subRateArr[1].ToString();
   
            if ((tempMonth >= 1) && (tempMonth <= 3))
            {
                tempYear = DateTime.Today.AddYears(-1);
                calcYear = tempYear.Year.ToString();
            }
            else if ((tempMonth >= 4) && (tempMonth <=12))
            {
                calcYear = DateTime.Now.Year.ToString();
            }

                    //Get the previous Month of the current reading Month
                    //DateTime tempMonth1 = DateTime.Today.AddMonths(-1); 
                    //DateTime tempMonth1 = DateTime.rdMonth.AddMonths(-1);

            //Get baseline units for consumption calculation
            double baseUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, calcYear, "March"));
            double currentUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, valueYear, currentMonth));
            double prevUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, valueYear, prevMonth));

            double diffUnit = RetrieveData.calcConsumedUnit(baseUnit, currentUnit);
            double usageUnit = currentUnit - prevUnit;
            textUnits.Text = usageUnit.ToString("0.00");
            double maxUnit = baseUnit + 64;

            if (diffUnit > 64)
            {
                addUnit = (currentUnit - maxUnit);
                nonsubUnits.Text = addUnit.ToString("0.00");
                nonUnit = (maxUnit - prevUnit);
                subUnits.Text = nonUnit.ToString("0.00");
            }
            else 
            {
                addUnit = 0.0;
                nonsubUnits.Text = Convert.ToString("0.00");
                nonUnit = (currentUnit - prevUnit);
                subUnits.Text = nonUnit.ToString("0.00");
            }

            calcAmount = RetrieveData.calculateAmount(valueSub, valueunSub, addUnit, nonUnit);
            valueAmount.Text = calcAmount.ToString("0.00");
            double totalAmount = calcAmount + valuePenalty;
            valueTotalAmount.Text = totalAmount.ToString("0.00");

        }

        private void clkBatchCalculate_Click(object sender, EventArgs e)
        {
            string valueMonth = subBatchMonth.Text;
            string currentYear = DateTime.Now.Year.ToString();
            string calcYear = "";
            DateTime tempYear;
            int prevMonth = 0;
            int currMonth = 0;

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=GasDb.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "SELECT Flat_No, Reading_Date, Reading_Unit FROM Gas_Reading where Reading_Month = '" + valueMonth + "' and Reading_Year = '" + currentYear + "';";

                // Now the SQLiteCommand object can give us a DataReader-Object:
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                // The SQLiteDataReader allows us to run through the result lines:
                while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
                {
                    //code for batch calculate
                    string valueFlatNo = sqlite_datareader.GetString(0);
                    string valueDate = sqlite_datareader.GetString(1);
                    string valueUnit = sqlite_datareader.GetString(2);

                    //calculate the previous month
                    currMonth = DateTime.Parse(valueDate).Month;
                    //Get previous month from the reading Month
                    if (currMonth == 1)
                    {
                        prevMonth = 12;
                    }
                    else
                    {
                        prevMonth = currMonth - 1;
                    }

                    string preMonth = RetrieveData.getMonth(prevMonth);

                    if ((currMonth >= 1) && (currMonth <= 3))
                    {
                        tempYear = DateTime.Today.AddYears(-1);
                        calcYear = tempYear.Year.ToString();
                    }
                    else if ((currMonth >= 4) && (currMonth <= 12))
                    {
                        calcYear = DateTime.Now.Year.ToString();
                    }

                }
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

        private void clkGenerateInvoice_Click(object sender, EventArgs e)
        {
            print();
        }
        public void print()
        {
            PrintDocument pdoc = null;
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);


            PaperSize psize = new PaperSize("A4", 827, 1170);
            //ps.DefaultPageSettings.PaperSize = psize;

            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height = 820;
            //pdoc.DefaultPageSettings.PaperSize.Width = 520;
            pdoc.DefaultPageSettings.Margins.Bottom = 0;
            pdoc.DefaultPageSettings.Margins.Left = 0;
            pdoc.DefaultPageSettings.Margins.Right = 0;
            pdoc.DefaultPageSettings.Margins.Top = 0;
            pdoc.DefaultPageSettings.Landscape = true;

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

            DateTime today = DateTime.Today;
            string Today = today.ToString("MM/dd/yyyy"); // As String
            string FlatNo = selFlatNo.Text;
            string ResidentName = currentResident.Text;
            string SubsidyStatus = subStatus.Text;
            string LastRdDate = lastRD.Text;
            string CurrentRdDate = currentRD.Text;
            string LastUnit = lastUnit.Text;
            string CurrentUnit = currentUnit.Text;
            string SubRate = textSubsidyRate.Text;
            string NonSubRate = textNonSubsidyRate.Text;
            string SubUnit = subUnits.Text;
            string NonSubUnit = nonsubUnits.Text;
            string Span = textUsage.Text;
            string Penalty = penaltyText.Text;
            string Units = textUnits.Text;
            string Amount = valueAmount.Text;
            string TotalAmount = valueTotalAmount.Text;
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            string underLine = "-----------------------------------------------------";

            float fontHeight = font.GetHeight();
            
            int startX = 50;
            int startX1 = 600;
            int startY = 25;
            int OffsetY = 20;
            int OffsetX = 220;
            graphics.DrawString("   Mont Vert Seville CHS Gas Receipt", new Font("Courier New", 14, FontStyle.Bold),new SolidBrush(Color.DarkBlue), startX, startY + OffsetY);
            graphics.DrawString("   Mont Vert Seville CHS Gas Receipt", new Font("Courier New", 14, FontStyle.Bold), new SolidBrush(Color.DarkBlue), startX1, startY + OffsetY);
            
            OffsetY = OffsetY + 30;
            graphics.DrawString("Date:" + Today, new Font("Courier New", 10),new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString("Date:" + Today, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);
            
            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString("Flat No :" + FlatNo,new Font("Courier New", 10),new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString("Flat No :" + FlatNo, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            graphics.DrawString("Subsidy Status :" + SubsidyStatus, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Subsidy Status :" + SubsidyStatus, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 15;
            graphics.DrawString("Name :" + ResidentName, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString("Name :" + ResidentName, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            OffsetY = OffsetY + 15;
            String Society = "Mont Vert Seville, Wakad"; 
            graphics.DrawString(Society, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString(Society, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString("Last Rd Date :" + LastRdDate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX , startY + OffsetY);
            graphics.DrawString("Last Rd Date :" + LastRdDate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            graphics.DrawString("Current Rd Date :" + CurrentRdDate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Current Rd Date :" + CurrentRdDate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 15;
            graphics.DrawString("Last Rd Unit :" + LastUnit, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString("Last Rd Unit :" + LastUnit, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            graphics.DrawString("Current Rd Unit :" + CurrentUnit, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Current Rd Unit :" + CurrentUnit, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1 + OffsetX, startY + OffsetY);
            
            OffsetY = OffsetY + 15;
            graphics.DrawString("Subsidized Unit :" + SubUnit, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString("Subsidized Unit :" + SubUnit, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            graphics.DrawString("Non Subsidized Unit :" + NonSubUnit, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Non Subsidized Unit :" + NonSubUnit, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1 + OffsetX, startY + OffsetY);
            
            OffsetY = OffsetY + 15;
            graphics.DrawString("Subsidized Rate :" + SubRate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString("Subsidized Rate :" + SubRate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            graphics.DrawString("Non Subsidized Rate :" + NonSubRate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Non Subsidized Rate :" + NonSubRate, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1 + OffsetX, startY + OffsetY);
            
            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);
            
            OffsetY = OffsetY + 10;
            graphics.DrawString("Usage Days :" + Span, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString("Usage Days :" + Span, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);
            
            graphics.DrawString("Penalty Amount :" + Penalty, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Penalty Amount :" + Penalty, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 15;
            graphics.DrawString("Usage Units :" + Units, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString("Usage Units :" + Units, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

            graphics.DrawString("Amount :" + Amount, new Font("Courier New", 10), new SolidBrush(Color.Black), startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Amount :" + Amount, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 20;
            graphics.DrawString("Total Amount :" + TotalAmount, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.Black), startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Total Amount :" + TotalAmount, new Font("Courier New", 11, FontStyle.Bold), new SolidBrush(Color.Black), startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX, startY + OffsetY);
            graphics.DrawString(underLine, new Font("Courier New", 10), new SolidBrush(Color.Black), startX1, startY + OffsetY);

         
        }

        private void clkReset_Click(object sender, EventArgs e)
        {
            lastRD.Items.Clear();
            currentRD.Items.Clear();
            selFlatNo.Text = "";
            currentResident.Text = "";
            subStatus.Text = "";
            lastRD.Text = "";
            currentRD.Text = "";
            lastUnit.Text = "";
            currentUnit.Text = "";
            textSubsidyRate.Text = "";
            textNonSubsidyRate.Text = "";
            subUnits.Text = "";
            nonsubUnits.Text = "";
            textUsage.Text = "";
            penaltyText.Text = "0.00";
            textUnits.Text = "";
            valueAmount.Text = "";
            valueTotalAmount.Text = "";
        }
    }
}

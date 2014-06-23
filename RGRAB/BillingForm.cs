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
            textBillMonth.Enabled = false;
            List<string> listFlatNo = FirstLoad.Retrieve_fl();
            for (int i = 0; i < listFlatNo.Count; i++) // Loop through List with for
            {
                selFlatNo.Items.Add(listFlatNo[i]);
                textFlatNo.Items.Add(listFlatNo[i]);
            }
        }
        int itemCount = 0;

        private void selFlatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueFlatNo = selFlatNo.Text;
            clkReset_Click(this, null);
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
            string rdYear = "";
            DateTime tempYear;
            double addUnit = 0.0;
            double nonUnit = 0.0;
            double calcAmount = 0.0;
            double valuePenalty = Convert.ToDouble(penaltyText.Text);
            double valueSub = 0.0;
            double valueunSub = 0.0;
            DateTime today = DateTime.Today;
            string Today = today.ToString("MM/dd/yyyy"); // As String

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
                tempYear = DateTime.Today.AddYears(-1);
                rdYear = tempYear.Year.ToString();
            }
            else
            {
                prevMonth1 = tempMonth - 1;
                rdYear = DateTime.Now.Year.ToString();
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

            string prevDate = RetrieveData.Retrieve_LastRD(valueFlatNo, prevMonth, rdYear);
            //Get baseline units for consumption calculation
            double baseUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, calcYear, "March"));
            double currentUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, valueYear, currentMonth));
            double prevUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, valueYear, prevMonth));
            string currUnit = currentUnit.ToString("0.00");
            string preUnit = prevUnit.ToString("0.00");


            double diffUnit = RetrieveData.calcConsumedUnit(baseUnit, currentUnit);
            double usageUnit = currentUnit - prevUnit;
            textUnits.Text = usageUnit.ToString("0.00");
            double maxUnit = baseUnit + 64;

            if (diffUnit > 64 && prevUnit < maxUnit)
            {
                addUnit = (currentUnit - maxUnit);
                nonsubUnits.Text = addUnit.ToString("0.00");
                nonUnit = (maxUnit - prevUnit);
                subUnits.Text = nonUnit.ToString("0.00");
            }
            else if (diffUnit > 64 && prevUnit > maxUnit)
            {
                addUnit = (currentUnit - prevUnit);
                nonsubUnits.Text = addUnit.ToString("0.00");
                nonUnit = 0.0;
                subUnits.Text = nonUnit.ToString("0.00");
            }
            else if (diffUnit < 64)
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

            //This code has been commented. This inserted a row in Invoide Detail tablwe for indivisal bill calculation.

            //SQLiteConnection sqlite_conn;
            //SQLiteCommand sqlite_cmd;

            //// create a new database connection:
            //sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            //// open the connection:
            //sqlite_conn.Open();

            //// create a new SQL command:
            //sqlite_cmd = sqlite_conn.CreateCommand();
            //try
            //{
            //    // First lets build a SQL-Query again:
            //    //sqlite_cmd.CommandText = "INSERT INTO Invoice_Detail (Flat_No, Reading_Year, Reading_Month, Current_Date, Current_Unit, Last_Date, Last_Unit,Subsidy_Unit, NonSubsidy_Unit, Span,Unit, Invoice_Date, Invoice_Amount) values ('" + valueFlatNo + "','" + currentYear + "', '" + currentMonth + "', '" + valueDate + "', '" + currUnit + "', '" + prevDate + "','" + preUnit + "', '" + subUnits.Text + "', '" + nonsubUnits.Text + "','" + span + "', '" + textUnits.Text + "','" + Today + "','" + valueTotalAmount.Text + "');";
            //    //Execute the query
            //    //sqlite_cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    string errMessage = ex.Message;
            //    if (errMessage == "columns Flat_No, Reading_Year, Reading_Month are not unique")
            //    {
            //        MessageBox.Show("Bill has already been calculated for '"+ valueFlatNo +"'", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show(ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //finally
            //{
            //    // We are ready, now lets cleanup and close our connection:
            //    sqlite_conn.Close();
            //}
        }

        private void clkBatchCalculate_Click(object sender, EventArgs e)
        {
            string valueMonth = subBatchMonth.Text;
            string currentYear = DateTime.Now.Year.ToString();
            string calcYear = "";
            DateTime tempYear;
            string rdYear = "";
            int prevMonth = 0;
            int currMonth = 0;
            double addUnit = 0.0;
            double nonUnit = 0.0;
            double calcAmount = 0.0;
            double valueSub = 0.0;
            double valueunSub = 0.0;
            DateTime today = DateTime.Today;
            string Today = today.ToString("MM/dd/yyyy"); // As String

            if (valueMonth == "")
            {
                MessageBox.Show("Please select the month for Batch Invoicing", "Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteCommand sqlite_cmd1;
            SQLiteDataReader sqlite_datareader;

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd1 = sqlite_conn.CreateCommand();

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
                        tempYear = DateTime.Today.AddYears(-1);
                        rdYear = tempYear.Year.ToString();
                    }
                    else
                    {
                        prevMonth = currMonth - 1;
                        rdYear = DateTime.Now.Year.ToString();
                    }

                    string preMonth = RetrieveData.getMonth(prevMonth);
                    string currentMonth = RetrieveData.getMonth(currMonth);


                    if ((currMonth >= 1) && (currMonth <= 3))
                    {
                        tempYear = DateTime.Today.AddYears(-1);
                        calcYear = tempYear.Year.ToString();
                    }
                    else if ((currMonth >= 4) && (currMonth <= 12))
                    {
                        calcYear = DateTime.Now.Year.ToString();
                    }

                    //code to determine the previous month reading date
                    string prevDate = RetrieveData.Retrieve_LastRD(valueFlatNo, preMonth, rdYear);
                    DateTime minValue = Convert.ToDateTime(prevDate).Date;
                    DateTime maxValue = Convert.ToDateTime(valueDate).Date;
                    TimeSpan diff = maxValue - minValue;
                    string span = diff.TotalDays.ToString();

                    double baseUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, calcYear, "March"));
                    double currentUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo,currentYear,currentMonth));
                    double prevUnit = Convert.ToDouble(RetrieveData.getReading(valueFlatNo, rdYear, preMonth));


                    RetrieveData retrieveSubsidyRates = new RetrieveData();
                    Double[] subRateArr = retrieveSubsidyRates.getSubSidyRates(currentMonth, currentYear);
                    valueSub = subRateArr[0];
                    valueunSub = subRateArr[1];

                    double diffUnit = RetrieveData.calcConsumedUnit(baseUnit, currentUnit);
                    double usageUnit = Math.Round((currentUnit - prevUnit),2);
                    double maxUnit = baseUnit + 64;

                    if (diffUnit > 64 && prevUnit < maxUnit)
                    {
                        addUnit = Math.Round((currentUnit - maxUnit),2);
                        nonUnit = Math.Round((maxUnit - prevUnit),2);
                    }
                    else if (diffUnit > 64 && prevUnit > maxUnit)
                    {
                        addUnit = Math.Round((currentUnit - prevUnit),2);
                        nonUnit = 0.0;
                    }
                    else if (diffUnit < 64)
                    {
                        addUnit = 0.0;
                        nonUnit = Math.Round((currentUnit - prevUnit),2);
                    }

                    calcAmount = RetrieveData.calculateAmount(valueSub, valueunSub, addUnit, nonUnit);
                    double totalAmount = Math.Round(calcAmount, 2);
                    
                    // First lets build a SQL-Query again:
                    sqlite_cmd1.CommandText = "INSERT INTO Invoice_Detail (Flat_No, Reading_Year, Reading_Month, Current_Date, Current_Unit, Last_Date, Last_Unit,Subsidy_Unit, NonSubsidy_Unit, Span,Unit, Invoice_Date, Invoice_Amount) values ('" + valueFlatNo + "','" + currentYear + "', '" + currentMonth + "', '" + valueDate + "', '" + currentUnit + "', '"+ prevDate +"','" + prevUnit + "', '" + nonUnit + "', '" + addUnit + "','" + span + "', '" + usageUnit + "','" + Today + "','"+ totalAmount +"');";
                    //Execute the query
                    sqlite_cmd1.ExecuteNonQuery();
                }
                
                MessageBox.Show("Invoice Data succeessfully calculated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }
        }
        
        private void clkBatchGenerateInvoice_Click(object sender, EventArgs e)
        {
            string valueMonth = subBatchMonth.Text;
            string currentYear = DateTime.Now.Year.ToString();
            Double rowCount = 0;

            if (valueMonth == "")
            {
                MessageBox.Show("Please select the month for Batch Invoicing", "Warning!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
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
            sqlite_cmd.CommandText = "SELECT Count(*) FROM Invoice_Detail where Reading_Month = '" + valueMonth + "' and Reading_Year = '" + currentYear + "';";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                rowCount = Convert.ToDouble(sqlite_datareader.GetString(0));
            }
            
            if (rowCount == 0)
            {
                MessageBox.Show("No Data found for the selected month '" + valueMonth + "'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                // We are ready, now lets cleanup and close our connection
                sqlite_conn.Close();
                print();
            }
            
        }
        private void clkGenerateInvoice_Click(object sender, EventArgs e)
        {
            //Calls the logic to print the individual invoice
            IndividualPrint();
        }
        public void print()
        {
 
                PrintDocument pdoc = new PrintDocument();
                PrintDialog pd = new PrintDialog();
                PrinterSettings ps = new PrinterSettings();

                pd.Document = pdoc;
                pdoc.DefaultPageSettings.Margins.Bottom = 0;
                pdoc.DefaultPageSettings.Margins.Left = 0;
                pdoc.DefaultPageSettings.Margins.Right = 0;
                pdoc.DefaultPageSettings.Margins.Top = 0;
                pdoc.DefaultPageSettings.Landscape = true;

                pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

                DialogResult result = pd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //PrintPreviewDialog pp = new PrintPreviewDialog();
                    //pp.Document = pdoc;
                    //result = pp.ShowDialog();
                    //if (result == DialogResult.OK)
                    //{
                        pdoc.Print();
                    //}
                }
        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {

            string valueMonth = subBatchMonth.Text;
            string currentYear = DateTime.Now.Year.ToString();
            string underLine = "-----------------------------------------------------";
            string seperator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~TEAR ALONG THIS EDGE~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            String Society = "Mont Vert Seville, Wakad";
            string valueSub = "0.00";
            string valueNonSub = "0.00";
            int itemCounter = 0;

            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            SolidBrush brush = new SolidBrush(Color.Black);
            e.PageSettings.PaperSize = new PaperSize("A4", 850, 1100);
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            //float fontHeight = font.GetHeight();
           
            int startX = 50;
            int startX1 = 600;
            int startZ = 0;
            int startY = 25;
            int OffsetY = 20;
            int OffsetX = 220;

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
            sqlite_cmd.CommandText = "SELECT Subsidized, NonSubsidized FROM SubValue where Month = '" + valueMonth + "' and Year = '" + currentYear + "';";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read()) // Read() returns true if there is still a result line to read
            {
                valueSub = sqlite_datareader.GetString(0);
                valueNonSub = sqlite_datareader.GetString(1);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();

            FirstLoad fstLoad = new FirstLoad();
            List<Invoice_Retrieve> invoiceDetList = fstLoad.getInvoiceDetail(valueMonth, currentYear);
            Invoice_Retrieve invoiceDet;

            for (int i = itemCount; i < invoiceDetList.Count; i++) // Loop through List with for
            {
                if (itemCount < invoiceDetList.Count)
                {
                    invoiceDet = invoiceDetList[i];
                    DateTime today = DateTime.Today;
                    string Today = today.ToString("MM/dd/yyyy"); // As String
                    string flatNo = invoiceDet.FlatNo;
                    string residentName = invoiceDet.Name;
                    string subsidyStatus = invoiceDet.SubStatus;
                    string lastRdDate = invoiceDet.LastDate;
                    string currentRdDate = invoiceDet.CurrentDate;
                    string lastUnit = invoiceDet.LastUnit;
                    string currentUnit = invoiceDet.CurrentUnit;
                    string subRate = valueSub;
                    string nonSubRate = valueNonSub;
                    string subUnit = invoiceDet.SubsidyUnit;
                    string nonSubUnit = invoiceDet.NonSubsidyUnit;
                    string span = invoiceDet.Span;
                    string penalty = "0.00";
                    string units = invoiceDet.Unit;
                    string amount = invoiceDet.Amount;
                    string totalAmount = invoiceDet.Amount;

                    graphics.DrawString("   Mont Vert Seville CHS Gas Receipt", new Font("Courier New", 14, FontStyle.Bold), brush, startX, startY + OffsetY);
                    graphics.DrawString("   Mont Vert Seville CHS Gas Receipt", new Font("Courier New", 14, FontStyle.Bold), brush, startX1, startY + OffsetY);

                    OffsetY = OffsetY + 30;
                    graphics.DrawString("Date:" + Today, font, brush, startX, startY + OffsetY);
                    graphics.DrawString("Date:" + Today, font, brush, startX1, startY + OffsetY);

                    OffsetY = OffsetY + 10;
                    graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);
                    graphics.DrawString(underLine, font, brush, startX1, startY + OffsetY);

                    OffsetY = OffsetY + 10;
                    graphics.DrawString("Flat No :" + flatNo, new Font("Courier New", 10, FontStyle.Bold), brush, startX, startY + OffsetY);
                    graphics.DrawString("Flat No :" + flatNo, new Font("Courier New", 10, FontStyle.Bold), brush, startX1, startY + OffsetY);

                    graphics.DrawString("Subsidy Status :" + subsidyStatus, new Font("Courier New", 10, FontStyle.Bold), brush, startX + OffsetX, startY + OffsetY);
                    graphics.DrawString("Subsidy Status :" + subsidyStatus, new Font("Courier New", 10, FontStyle.Bold), brush, startX1 + OffsetX, startY + OffsetY);

                    OffsetY = OffsetY + 15;
                    graphics.DrawString("Name :" + residentName, font, brush, startX, startY + OffsetY);
                    graphics.DrawString("Name :" + residentName, font, brush, startX1, startY + OffsetY);

                    OffsetY = OffsetY + 15;

                    graphics.DrawString(Society, font, brush, startX, startY + OffsetY);
                    graphics.DrawString(Society, font, brush, startX1, startY + OffsetY);

                    OffsetY = OffsetY + 10;
                    graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);
                    graphics.DrawString(underLine, font, brush, startX1, startY + OffsetY);

                    OffsetY = OffsetY + 10;
                    graphics.DrawString("Last Rd Date :" + lastRdDate, font, brush, startX, startY + OffsetY);
                    graphics.DrawString("Last Rd Date :" + lastRdDate, font, brush, startX1, startY + OffsetY);

                    graphics.DrawString("Current Rd Date :" + currentRdDate, font, brush, startX + OffsetX, startY + OffsetY);
                    graphics.DrawString("Current Rd Date :" + currentRdDate, font, brush, startX1 + OffsetX, startY + OffsetY);

                    OffsetY = OffsetY + 15;
                    graphics.DrawString("Last Rd Unit :" + lastUnit, font, brush, startX, startY + OffsetY);
                    graphics.DrawString("Last Rd Unit :" + lastUnit, font, brush, startX1, startY + OffsetY);

                    graphics.DrawString("Current Rd Unit :" + currentUnit, font, brush, startX + OffsetX, startY + OffsetY);
                    graphics.DrawString("Current Rd Unit :" + currentUnit, font, brush, startX1 + OffsetX, startY + OffsetY);

                    OffsetY = OffsetY + 15;
                    graphics.DrawString("Subsidized Unit :" + subUnit, font, brush, startX, startY + OffsetY);
                    graphics.DrawString("Subsidized Unit :" + subUnit, font, brush, startX1, startY + OffsetY);

                    graphics.DrawString("Non Subsidized Unit :" + nonSubUnit, font, brush, startX + OffsetX, startY + OffsetY);
                    graphics.DrawString("Non Subsidized Unit :" + nonSubUnit, font, brush, startX1 + OffsetX, startY + OffsetY);

                    OffsetY = OffsetY + 15;
                    graphics.DrawString("Subsidized Rate :" + subRate, font, brush, startX, startY + OffsetY);
                    graphics.DrawString("Subsidized Rate :" + subRate, font, brush, startX1, startY + OffsetY);

                    graphics.DrawString("Non Subsidized Rate :" + nonSubRate, font, brush, startX + OffsetX, startY + OffsetY);
                    graphics.DrawString("Non Subsidized Rate :" + nonSubRate, font, brush, startX1 + OffsetX, startY + OffsetY);

                    OffsetY = OffsetY + 10;
                    graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);
                    graphics.DrawString(underLine, font, brush, startX1, startY + OffsetY);

                    OffsetY = OffsetY + 10;
                    graphics.DrawString("Usage Days :" + span, font, brush, startX, startY + OffsetY);
                    graphics.DrawString("Usage Days :" + span, font, brush, startX1, startY + OffsetY);

                    graphics.DrawString("Penalty Amount :" + penalty, font, brush, startX + OffsetX, startY + OffsetY);
                    graphics.DrawString("Penalty Amount :" + penalty, font, brush, startX1 + OffsetX, startY + OffsetY);

                    OffsetY = OffsetY + 15;
                    graphics.DrawString("Usage Units :" + units, font, brush, startX, startY + OffsetY);
                    graphics.DrawString("Usage Units :" + units, font, brush, startX1, startY + OffsetY);

                    graphics.DrawString("Amount :" + amount, font, brush, startX + OffsetX, startY + OffsetY);
                    graphics.DrawString("Amount :" + amount, font, brush, startX1 + OffsetX, startY + OffsetY);

                    OffsetY = OffsetY + 20;
                    graphics.DrawString("Total Amount :" + totalAmount, new Font("Courier New", 11, FontStyle.Bold), brush, startX + OffsetX, startY + OffsetY);
                    graphics.DrawString("Total Amount :" + totalAmount, new Font("Courier New", 11, FontStyle.Bold), brush, startX1 + OffsetX, startY + OffsetY);

                    OffsetY = OffsetY + 10;
                    graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);
                    graphics.DrawString(underLine, font, brush, startX1, startY + OffsetY);

                    OffsetY = OffsetY + 20;
                    graphics.DrawString(seperator, font, brush, startZ, startY + OffsetY);

                    OffsetY = OffsetY + 20;
                    itemCounter++;
                    itemCount++;

                    if ((itemCounter == 3) && (itemCount < invoiceDetList.Count))
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


        public void IndividualPrint()
        {

            PrintDocument pindividualdoc = new PrintDocument();
            PrintDialog pd = new PrintDialog();
            PrinterSettings ps = new PrinterSettings();

            pd.Document = pindividualdoc;
            pindividualdoc.DefaultPageSettings.Margins.Bottom = 0;
            pindividualdoc.DefaultPageSettings.Margins.Left = 0;
            pindividualdoc.DefaultPageSettings.Margins.Right = 0;
            pindividualdoc.DefaultPageSettings.Margins.Top = 0;
            pindividualdoc.DefaultPageSettings.Landscape = true;

            pindividualdoc.PrintPage += new PrintPageEventHandler(pindividualdoc_PrintPage);

            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pindividualdoc;
                result = pp.ShowDialog();
                if (result == DialogResult.OK)
                {
                pindividualdoc.Print();
                }
            }
        }


        void pindividualdoc_PrintPage(object sender, PrintPageEventArgs e)
        {

            string underLine = "-----------------------------------------------------";
            string seperator = "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~TEAR ALONG THIS EDGE~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~";
            String Society = "Mont Vert Seville, Wakad";
            DateTime today = DateTime.Today;
            string Today = today.ToString("MM/dd/yyyy");
            string flatNo = selFlatNo.Text;
            string residentName = currentResident.Text;
            string subsidyStatus = subStatus.Text;
            string lastRdDate = lastRD.Text;
            string currentRdDate = currentRD.Text;
            string lastUnits = lastUnit.Text;
            string currentUnits = currentUnit.Text;
            string subRate = textSubsidyRate.Text;
            string nonSubRate = textNonSubsidyRate.Text;
            string subUnit = subUnits.Text;
            string nonSubUnit = nonsubUnits.Text;
            string span = textUsage.Text;
            string penalty = penaltyText.Text;
            string units = textUnits.Text;
            string amount = valueAmount.Text;
            string totalAmount = valueTotalAmount.Text;

            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            SolidBrush brush = new SolidBrush(Color.Black);
            e.PageSettings.PaperSize = new PaperSize("A4", 850, 1100);
            float pageWidth = e.PageSettings.PrintableArea.Width;
            float pageHeight = e.PageSettings.PrintableArea.Height;

            int startX = 50;
            int startX1 = 600;
            int startZ = 0;
            int startY = 25;
            int OffsetY = 20;
            int OffsetX = 220;

            graphics.DrawString("   Mont Vert Seville CHS Gas Receipt", new Font("Courier New", 14, FontStyle.Bold), brush, startX, startY + OffsetY);
            graphics.DrawString("   Mont Vert Seville CHS Gas Receipt", new Font("Courier New", 14, FontStyle.Bold), brush, startX1, startY + OffsetY);

            OffsetY = OffsetY + 30;
            graphics.DrawString("Date:" + Today, font, brush, startX, startY + OffsetY);
            graphics.DrawString("Date:" + Today, font, brush, startX1, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);
            graphics.DrawString(underLine, font, brush, startX1, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString("Flat No :" + flatNo, new Font("Courier New", 10, FontStyle.Bold), brush, startX, startY + OffsetY);
            graphics.DrawString("Flat No :" + flatNo, new Font("Courier New", 10, FontStyle.Bold), brush, startX1, startY + OffsetY);

            graphics.DrawString("Subsidy Status :" + subsidyStatus, new Font("Courier New", 10, FontStyle.Bold), brush, startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Subsidy Status :" + subsidyStatus, new Font("Courier New", 10, FontStyle.Bold), brush, startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 15;
            graphics.DrawString("Name :" + residentName, font, brush, startX, startY + OffsetY);
            graphics.DrawString("Name :" + residentName, font, brush, startX1, startY + OffsetY);

            OffsetY = OffsetY + 15;

            graphics.DrawString(Society, font, brush, startX, startY + OffsetY);
            graphics.DrawString(Society, font, brush, startX1, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);
            graphics.DrawString(underLine, font, brush, startX1, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString("Last Rd Date :" + lastRdDate, font, brush, startX, startY + OffsetY);
            graphics.DrawString("Last Rd Date :" + lastRdDate, font, brush, startX1, startY + OffsetY);

            graphics.DrawString("Current Rd Date :" + currentRdDate, font, brush, startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Current Rd Date :" + currentRdDate, font, brush, startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 15;
            graphics.DrawString("Last Rd Unit :" + lastUnits, font, brush, startX, startY + OffsetY);
            graphics.DrawString("Last Rd Unit :" + lastUnits, font, brush, startX1, startY + OffsetY);

            graphics.DrawString("Current Rd Unit :" + currentUnits, font, brush, startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Current Rd Unit :" + currentUnits, font, brush, startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 15;
            graphics.DrawString("Subsidized Unit :" + subUnit, font, brush, startX, startY + OffsetY);
            graphics.DrawString("Subsidized Unit :" + subUnit, font, brush, startX1, startY + OffsetY);

            graphics.DrawString("Non Subsidized Unit :" + nonSubUnit, font, brush, startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Non Subsidized Unit :" + nonSubUnit, font, brush, startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 15;
            graphics.DrawString("Subsidized Rate :" + subRate, font, brush, startX, startY + OffsetY);
            graphics.DrawString("Subsidized Rate :" + subRate, font, brush, startX1, startY + OffsetY);

            graphics.DrawString("Non Subsidized Rate :" + nonSubRate, font, brush, startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Non Subsidized Rate :" + nonSubRate, font, brush, startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);
            graphics.DrawString(underLine, font, brush, startX1, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString("Usage Days :" + span, font, brush, startX, startY + OffsetY);
            graphics.DrawString("Usage Days :" + span, font, brush, startX1, startY + OffsetY);

            graphics.DrawString("Penalty Amount :" + penalty, font, brush, startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Penalty Amount :" + penalty, font, brush, startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 15;
            graphics.DrawString("Usage Units :" + units, font, brush, startX, startY + OffsetY);
            graphics.DrawString("Usage Units :" + units, font, brush, startX1, startY + OffsetY);

            graphics.DrawString("Amount :" + amount, font, brush, startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Amount :" + amount, font, brush, startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 20;
            graphics.DrawString("Total Amount :" + totalAmount, new Font("Courier New", 11, FontStyle.Bold), brush, startX + OffsetX, startY + OffsetY);
            graphics.DrawString("Total Amount :" + totalAmount, new Font("Courier New", 11, FontStyle.Bold), brush, startX1 + OffsetX, startY + OffsetY);

            OffsetY = OffsetY + 10;
            graphics.DrawString(underLine, font, brush, startX, startY + OffsetY);
            graphics.DrawString(underLine, font, brush, startX1, startY + OffsetY);

            OffsetY = OffsetY + 20;
            graphics.DrawString(seperator, font, brush, startZ, startY + OffsetY);

            OffsetY = OffsetY + 20;
            
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

        private void textBillMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueFlatNo = textFlatNo.Text;
            string valueMonth = textBillMonth.Text;
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader;
            textInvoiceAmount.Text = "";

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();

            // First lets build a SQL-Query again:
            sqlite_cmd.CommandText = "SELECT Invoice_Amount FROM Invoice_Detail where Flat_No = '" + valueFlatNo + "' and Reading_Month = '" + valueMonth + "'; ";

            // Now the SQLiteCommand object can give us a DataReader-Object:
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            // The SQLiteDataReader allows us to run through the result lines:
            while (sqlite_datareader.Read()) 
            {
                // Print out the content of the text field:
                textInvoiceAmount.Text = sqlite_datareader.GetString(0);
            }

            // We are ready, now lets cleanup and close our connection:
            sqlite_conn.Close();
        }

        private void textFlatNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBillMonth.Enabled = true;          
        }

        private void updPayment_Click(object sender, EventArgs e)
        {
            string valueFlatNo = textFlatNo.Text;
            string valueMonth = textBillMonth.Text;
            string valueAmount = textPaidAmount.Text;
            DateTime today = DateTime.Today;
            string Today = today.ToString("MM/dd/yyyy");

            if (valueAmount == "")
            {
                MessageBox.Show("Please enter the paid amount", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            textInvoiceAmount.Text = "";

            // create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=C:\\RGRAB\\Application\\GasDB.db;Version=3;New=False;Compress=True;");

            // open the connection:
            sqlite_conn.Open();

            // create a new SQL command:
            sqlite_cmd = sqlite_conn.CreateCommand();
            try
            {
                // First lets build a SQL-Query again:
                sqlite_cmd.CommandText = "Update Invoice_Detail SET Paid_Date = '" + Today + "', Paid_Amount= '" + valueAmount + "' where Flat_No = '" + valueFlatNo + "' and Reading_Month = '" + valueMonth + "';";
                //Execute the query
                sqlite_cmd.ExecuteNonQuery();

                MessageBox.Show("Payment details updated successfully for Flat No '" + valueFlatNo + "'", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // We are ready, now lets cleanup and close our connection:
                sqlite_conn.Close();
            }
        }

        private void penaltyText_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && penaltyText.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textPaidAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && textPaidAmount.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void clkCloseBilling_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

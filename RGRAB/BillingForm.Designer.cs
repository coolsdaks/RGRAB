namespace RGRAB
{
    partial class BillingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.subBatchMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.currentResident = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selFlatNo = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textSubsidyRate = new System.Windows.Forms.TextBox();
            this.subUnits = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nonsubUnits = new System.Windows.Forms.TextBox();
            this.textNonSubsidyRate = new System.Windows.Forms.TextBox();
            this.clkReset = new System.Windows.Forms.Button();
            this.clkGenerateInvoice = new System.Windows.Forms.Button();
            this.clkCalculate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.valueTotalAmount = new System.Windows.Forms.TextBox();
            this.valueAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textUnits = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.penaltyText = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textUsage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.currentUnit = new System.Windows.Forms.TextBox();
            this.lastUnit = new System.Windows.Forms.TextBox();
            this.currentRD = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lastRD = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.subStatus = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clkBatchGenerateInvoice = new System.Windows.Forms.Button();
            this.clkBatchCalculate = new System.Windows.Forms.Button();
            this.clkCloseInput = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // subBatchMonth
            // 
            this.subBatchMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subBatchMonth.FormattingEnabled = true;
            this.subBatchMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.subBatchMonth.Location = new System.Drawing.Point(268, 23);
            this.subBatchMonth.Name = "subBatchMonth";
            this.subBatchMonth.Size = new System.Drawing.Size(142, 21);
            this.subBatchMonth.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(126, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Billing Month. : ";
            // 
            // currentResident
            // 
            this.currentResident.Location = new System.Drawing.Point(246, 51);
            this.currentResident.Name = "currentResident";
            this.currentResident.ReadOnly = true;
            this.currentResident.Size = new System.Drawing.Size(303, 20);
            this.currentResident.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Resident Name. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Flat No. :";
            // 
            // selFlatNo
            // 
            this.selFlatNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selFlatNo.FormattingEnabled = true;
            this.selFlatNo.Location = new System.Drawing.Point(246, 14);
            this.selFlatNo.Name = "selFlatNo";
            this.selFlatNo.Size = new System.Drawing.Size(142, 21);
            this.selFlatNo.TabIndex = 9;
            this.selFlatNo.SelectedIndexChanged += new System.EventHandler(this.selFlatNo_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.clkReset);
            this.groupBox1.Controls.Add(this.clkGenerateInvoice);
            this.groupBox1.Controls.Add(this.clkCalculate);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.currentUnit);
            this.groupBox1.Controls.Add(this.lastUnit);
            this.groupBox1.Controls.Add(this.currentRD);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lastRD);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.subStatus);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.currentResident);
            this.groupBox1.Controls.Add(this.selFlatNo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 422);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Individual Billing";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.textSubsidyRate);
            this.groupBox4.Controls.Add(this.subUnits);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.nonsubUnits);
            this.groupBox4.Controls.Add(this.textNonSubsidyRate);
            this.groupBox4.Location = new System.Drawing.Point(25, 194);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(595, 79);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gas Consumption";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(342, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(111, 16);
            this.label18.TabIndex = 36;
            this.label18.Text = "SubSidy Rate :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(66, 49);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(143, 16);
            this.label17.TabIndex = 35;
            this.label17.Text = "Non SubSidy Rate :";
            // 
            // textSubsidyRate
            // 
            this.textSubsidyRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSubsidyRate.Location = new System.Drawing.Point(459, 48);
            this.textSubsidyRate.Name = "textSubsidyRate";
            this.textSubsidyRate.Size = new System.Drawing.Size(64, 20);
            this.textSubsidyRate.TabIndex = 34;
            // 
            // subUnits
            // 
            this.subUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subUnits.Location = new System.Drawing.Point(460, 19);
            this.subUnits.Name = "subUnits";
            this.subUnits.Size = new System.Drawing.Size(64, 20);
            this.subUnits.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(339, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Subsidy Units  : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(57, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "Non - Subsidy Units : ";
            // 
            // nonsubUnits
            // 
            this.nonsubUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nonsubUnits.Location = new System.Drawing.Point(221, 16);
            this.nonsubUnits.Name = "nonsubUnits";
            this.nonsubUnits.Size = new System.Drawing.Size(64, 20);
            this.nonsubUnits.TabIndex = 25;
            // 
            // textNonSubsidyRate
            // 
            this.textNonSubsidyRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNonSubsidyRate.Location = new System.Drawing.Point(221, 48);
            this.textNonSubsidyRate.Name = "textNonSubsidyRate";
            this.textNonSubsidyRate.Size = new System.Drawing.Size(64, 20);
            this.textNonSubsidyRate.TabIndex = 33;
            // 
            // clkReset
            // 
            this.clkReset.Location = new System.Drawing.Point(454, 390);
            this.clkReset.Name = "clkReset";
            this.clkReset.Size = new System.Drawing.Size(94, 26);
            this.clkReset.TabIndex = 30;
            this.clkReset.Text = "Reset";
            this.clkReset.UseVisualStyleBackColor = true;
            this.clkReset.Click += new System.EventHandler(this.clkReset_Click);
            // 
            // clkGenerateInvoice
            // 
            this.clkGenerateInvoice.Location = new System.Drawing.Point(259, 390);
            this.clkGenerateInvoice.Name = "clkGenerateInvoice";
            this.clkGenerateInvoice.Size = new System.Drawing.Size(117, 26);
            this.clkGenerateInvoice.TabIndex = 29;
            this.clkGenerateInvoice.Text = "Generate Invoice";
            this.clkGenerateInvoice.UseVisualStyleBackColor = true;
            this.clkGenerateInvoice.Click += new System.EventHandler(this.clkGenerateInvoice_Click);
            // 
            // clkCalculate
            // 
            this.clkCalculate.Location = new System.Drawing.Point(87, 390);
            this.clkCalculate.Name = "clkCalculate";
            this.clkCalculate.Size = new System.Drawing.Size(94, 26);
            this.clkCalculate.TabIndex = 28;
            this.clkCalculate.Text = "Calculate";
            this.clkCalculate.UseVisualStyleBackColor = true;
            this.clkCalculate.Click += new System.EventHandler(this.clkCalculate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.valueTotalAmount);
            this.groupBox3.Controls.Add(this.valueAmount);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.textUnits);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.penaltyText);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.textUsage);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(25, 279);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(595, 105);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoice Amount";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(343, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 16);
            this.label16.TabIndex = 37;
            this.label16.Text = "Total Amount  :";
            // 
            // valueTotalAmount
            // 
            this.valueTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueTotalAmount.Location = new System.Drawing.Point(460, 79);
            this.valueTotalAmount.Name = "valueTotalAmount";
            this.valueTotalAmount.Size = new System.Drawing.Size(64, 20);
            this.valueTotalAmount.TabIndex = 36;
            // 
            // valueAmount
            // 
            this.valueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valueAmount.Location = new System.Drawing.Point(460, 46);
            this.valueAmount.Name = "valueAmount";
            this.valueAmount.Size = new System.Drawing.Size(64, 20);
            this.valueAmount.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(383, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 16);
            this.label15.TabIndex = 34;
            this.label15.Text = "Amount  : ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(317, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 16);
            this.label14.TabIndex = 32;
            this.label14.Text = "Kgs";
            // 
            // textUnits
            // 
            this.textUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUnits.Location = new System.Drawing.Point(221, 45);
            this.textUnits.Name = "textUnits";
            this.textUnits.Size = new System.Drawing.Size(64, 20);
            this.textUnits.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(132, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 16);
            this.label13.TabIndex = 30;
            this.label13.Text = "Gas Units :";
            // 
            // penaltyText
            // 
            this.penaltyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.penaltyText.Location = new System.Drawing.Point(460, 12);
            this.penaltyText.Name = "penaltyText";
            this.penaltyText.Size = new System.Drawing.Size(64, 20);
            this.penaltyText.TabIndex = 29;
            this.penaltyText.Text = "0.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(320, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "Penalty Charges  : ";
            // 
            // textUsage
            // 
            this.textUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsage.Location = new System.Drawing.Point(221, 12);
            this.textUsage.Name = "textUsage";
            this.textUsage.Size = new System.Drawing.Size(64, 20);
            this.textUsage.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(113, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 16);
            this.label11.TabIndex = 24;
            this.label11.Text = "Usage Days :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(380, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Meter Value :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(380, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Meter Value :";
            // 
            // currentUnit
            // 
            this.currentUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentUnit.Location = new System.Drawing.Point(485, 167);
            this.currentUnit.Name = "currentUnit";
            this.currentUnit.Size = new System.Drawing.Size(64, 20);
            this.currentUnit.TabIndex = 20;
            // 
            // lastUnit
            // 
            this.lastUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastUnit.Location = new System.Drawing.Point(485, 131);
            this.lastUnit.Name = "lastUnit";
            this.lastUnit.Size = new System.Drawing.Size(64, 20);
            this.lastUnit.TabIndex = 19;
            // 
            // currentRD
            // 
            this.currentRD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRD.FormattingEnabled = true;
            this.currentRD.Location = new System.Drawing.Point(246, 165);
            this.currentRD.Name = "currentRD";
            this.currentRD.Size = new System.Drawing.Size(92, 21);
            this.currentRD.TabIndex = 18;
            this.currentRD.SelectedIndexChanged += new System.EventHandler(this.currentRD_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(75, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Current Reading Date :";
            // 
            // lastRD
            // 
            this.lastRD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastRD.FormattingEnabled = true;
            this.lastRD.Location = new System.Drawing.Point(246, 130);
            this.lastRD.Name = "lastRD";
            this.lastRD.Size = new System.Drawing.Size(92, 21);
            this.lastRD.TabIndex = 16;
            this.lastRD.SelectedIndexChanged += new System.EventHandler(this.lastRD_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(95, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Last Reading Date :";
            // 
            // subStatus
            // 
            this.subStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subStatus.Location = new System.Drawing.Point(246, 91);
            this.subStatus.Name = "subStatus";
            this.subStatus.ReadOnly = true;
            this.subStatus.Size = new System.Drawing.Size(142, 20);
            this.subStatus.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(121, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Subsidy Status :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clkBatchGenerateInvoice);
            this.groupBox2.Controls.Add(this.clkBatchCalculate);
            this.groupBox2.Controls.Add(this.subBatchMonth);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 452);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(635, 115);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Batch Billing";
            // 
            // clkBatchGenerateInvoice
            // 
            this.clkBatchGenerateInvoice.Location = new System.Drawing.Point(259, 58);
            this.clkBatchGenerateInvoice.Name = "clkBatchGenerateInvoice";
            this.clkBatchGenerateInvoice.Size = new System.Drawing.Size(117, 40);
            this.clkBatchGenerateInvoice.TabIndex = 30;
            this.clkBatchGenerateInvoice.Text = "Generate Invoice";
            this.clkBatchGenerateInvoice.UseVisualStyleBackColor = true;
            // 
            // clkBatchCalculate
            // 
            this.clkBatchCalculate.Location = new System.Drawing.Point(87, 58);
            this.clkBatchCalculate.Name = "clkBatchCalculate";
            this.clkBatchCalculate.Size = new System.Drawing.Size(94, 40);
            this.clkBatchCalculate.TabIndex = 29;
            this.clkBatchCalculate.Text = "Calculate";
            this.clkBatchCalculate.UseVisualStyleBackColor = true;
            this.clkBatchCalculate.Click += new System.EventHandler(this.clkBatchCalculate_Click);
            // 
            // clkCloseInput
            // 
            this.clkCloseInput.Location = new System.Drawing.Point(243, 573);
            this.clkCloseInput.Name = "clkCloseInput";
            this.clkCloseInput.Size = new System.Drawing.Size(168, 32);
            this.clkCloseInput.TabIndex = 18;
            this.clkCloseInput.Text = "Close";
            this.clkCloseInput.UseVisualStyleBackColor = true;
            this.clkCloseInput.Click += new System.EventHandler(this.clkCloseInput_Click);
            // 
            // BillingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 617);
            this.Controls.Add(this.clkCloseInput);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "BillingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Billing Form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox subBatchMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox currentResident;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selFlatNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button clkCloseInput;
        private System.Windows.Forms.TextBox subStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox currentUnit;
        private System.Windows.Forms.TextBox lastUnit;
        private System.Windows.Forms.ComboBox currentRD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox lastRD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox subUnits;
        private System.Windows.Forms.TextBox nonsubUnits;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button clkCalculate;
        private System.Windows.Forms.TextBox penaltyText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textUsage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button clkReset;
        private System.Windows.Forms.Button clkGenerateInvoice;
        private System.Windows.Forms.TextBox valueTotalAmount;
        private System.Windows.Forms.TextBox valueAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textNonSubsidyRate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textUnits;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textSubsidyRate;
        private System.Windows.Forms.Button clkBatchGenerateInvoice;
        private System.Windows.Forms.Button clkBatchCalculate;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
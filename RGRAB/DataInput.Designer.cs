namespace RGRAB
{
    partial class DataInput
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataInput));
            this.label1 = new System.Windows.Forms.Label();
            this.selFlatNo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentResident = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.selMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.untInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.yearText = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.selFile = new System.Windows.Forms.Button();
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.importProgress = new System.Windows.Forms.ProgressBar();
            this.btchImport = new System.Windows.Forms.Button();
            this.selMonth1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.clkCloseInput = new System.Windows.Forms.Button();
            this.clkSubmit = new System.Windows.Forms.Button();
            this.clkReset = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.textConsumption = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(205, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flat No :";
            // 
            // selFlatNo
            // 
            this.selFlatNo.FormattingEnabled = true;
            this.selFlatNo.Location = new System.Drawing.Point(329, 45);
            this.selFlatNo.Name = "selFlatNo";
            this.selFlatNo.Size = new System.Drawing.Size(142, 21);
            this.selFlatNo.TabIndex = 1;
            this.selFlatNo.TabStop = false;
            this.selFlatNo.SelectedIndexChanged += new System.EventHandler(this.selFlatNo_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current Resident Name. :";
            // 
            // currentResident
            // 
            this.currentResident.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentResident.Location = new System.Drawing.Point(329, 85);
            this.currentResident.Name = "currentResident";
            this.currentResident.ReadOnly = true;
            this.currentResident.Size = new System.Drawing.Size(333, 20);
            this.currentResident.TabIndex = 7;
            this.currentResident.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(152, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Subsidy Status :";
            // 
            // subStatus
            // 
            this.subStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subStatus.Location = new System.Drawing.Point(329, 124);
            this.subStatus.Name = "subStatus";
            this.subStatus.ReadOnly = true;
            this.subStatus.Size = new System.Drawing.Size(142, 20);
            this.subStatus.TabIndex = 9;
            this.subStatus.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(166, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Select Month :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(159, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Reading Date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(329, 242);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(142, 20);
            this.dateTimePicker1.TabIndex = 12;
            this.dateTimePicker1.TabStop = false;
            // 
            // selMonth
            // 
            this.selMonth.FormattingEnabled = true;
            this.selMonth.Items.AddRange(new object[] {
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
            this.selMonth.Location = new System.Drawing.Point(329, 202);
            this.selMonth.Name = "selMonth";
            this.selMonth.Size = new System.Drawing.Size(142, 21);
            this.selMonth.TabIndex = 13;
            this.selMonth.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(152, 279);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Reading Value :";
            // 
            // untInput
            // 
            this.untInput.Location = new System.Drawing.Point(329, 281);
            this.untInput.Name = "untInput";
            this.untInput.Size = new System.Drawing.Size(141, 20);
            this.untInput.TabIndex = 1;
            this.untInput.TabStop = false;
            this.untInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.untInput_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.yearText);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.selFile);
            this.groupBox1.Controls.Add(this.textFilePath);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.importProgress);
            this.groupBox1.Controls.Add(this.btchImport);
            this.groupBox1.Controls.Add(this.selMonth1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(48, 371);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 166);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   Batch Import Reading";
            // 
            // yearText
            // 
            this.yearText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearText.FormattingEnabled = true;
            this.yearText.Items.AddRange(new object[] {
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020"});
            this.yearText.Location = new System.Drawing.Point(162, 52);
            this.yearText.Name = "yearText";
            this.yearText.Size = new System.Drawing.Size(124, 21);
            this.yearText.TabIndex = 26;
            this.yearText.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(57, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "Select Year :";
            // 
            // selFile
            // 
            this.selFile.Location = new System.Drawing.Point(511, 22);
            this.selFile.Name = "selFile";
            this.selFile.Size = new System.Drawing.Size(102, 22);
            this.selFile.TabIndex = 24;
            this.selFile.TabStop = false;
            this.selFile.Text = "Select File";
            this.selFile.UseVisualStyleBackColor = true;
            this.selFile.Click += new System.EventHandler(this.selFile_Click);
            // 
            // textFilePath
            // 
            this.textFilePath.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFilePath.Location = new System.Drawing.Point(162, 24);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.ReadOnly = true;
            this.textFilePath.Size = new System.Drawing.Size(338, 20);
            this.textFilePath.TabIndex = 23;
            this.textFilePath.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(18, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Reading Unit File :";
            // 
            // importProgress
            // 
            this.importProgress.Location = new System.Drawing.Point(159, 135);
            this.importProgress.Name = "importProgress";
            this.importProgress.Size = new System.Drawing.Size(454, 19);
            this.importProgress.TabIndex = 21;
            // 
            // btchImport
            // 
            this.btchImport.BackColor = System.Drawing.Color.LightGray;
            this.btchImport.Cursor = System.Windows.Forms.Cursors.Default;
            this.btchImport.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btchImport.Image = global::RGRAB.Properties.Resources.Import;
            this.btchImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btchImport.Location = new System.Drawing.Point(315, 50);
            this.btchImport.Name = "btchImport";
            this.btchImport.Size = new System.Drawing.Size(298, 69);
            this.btchImport.TabIndex = 4;
            this.btchImport.TabStop = false;
            this.btchImport.Text = "        Batch Import Reading Data";
            this.btchImport.UseVisualStyleBackColor = false;
            this.btchImport.Click += new System.EventHandler(this.btchImport_Click);
            // 
            // selMonth1
            // 
            this.selMonth1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selMonth1.FormattingEnabled = true;
            this.selMonth1.Items.AddRange(new object[] {
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
            this.selMonth1.Location = new System.Drawing.Point(162, 80);
            this.selMonth1.Name = "selMonth1";
            this.selMonth1.Size = new System.Drawing.Size(124, 21);
            this.selMonth1.TabIndex = 15;
            this.selMonth1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(49, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Select Month :";
            // 
            // clkCloseInput
            // 
            this.clkCloseInput.Location = new System.Drawing.Point(289, 543);
            this.clkCloseInput.Name = "clkCloseInput";
            this.clkCloseInput.Size = new System.Drawing.Size(168, 32);
            this.clkCloseInput.TabIndex = 5;
            this.clkCloseInput.TabStop = false;
            this.clkCloseInput.Text = "Close";
            this.clkCloseInput.UseVisualStyleBackColor = true;
            this.clkCloseInput.Click += new System.EventHandler(this.clkClose_Click);
            // 
            // clkSubmit
            // 
            this.clkSubmit.Location = new System.Drawing.Point(208, 325);
            this.clkSubmit.Name = "clkSubmit";
            this.clkSubmit.Size = new System.Drawing.Size(136, 23);
            this.clkSubmit.TabIndex = 2;
            this.clkSubmit.TabStop = false;
            this.clkSubmit.Text = "Submit";
            this.clkSubmit.UseVisualStyleBackColor = true;
            this.clkSubmit.Click += new System.EventHandler(this.clkSubmit_Click);
            // 
            // clkReset
            // 
            this.clkReset.Location = new System.Drawing.Point(391, 325);
            this.clkReset.Name = "clkReset";
            this.clkReset.Size = new System.Drawing.Size(136, 23);
            this.clkReset.TabIndex = 3;
            this.clkReset.TabStop = false;
            this.clkReset.Text = "Reset";
            this.clkReset.UseVisualStyleBackColor = true;
            this.clkReset.Click += new System.EventHandler(this.clkReset_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(119, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Consumption Status :";
            // 
            // textConsumption
            // 
            this.textConsumption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textConsumption.Location = new System.Drawing.Point(329, 163);
            this.textConsumption.Name = "textConsumption";
            this.textConsumption.ReadOnly = true;
            this.textConsumption.Size = new System.Drawing.Size(142, 20);
            this.textConsumption.TabIndex = 22;
            this.textConsumption.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(484, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Units";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RGRAB.Properties.Resources.Input1;
            this.pictureBox1.Location = new System.Drawing.Point(21, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 68);
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(162, 108);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(124, 20);
            this.dateTimePicker2.TabIndex = 27;
            this.dateTimePicker2.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(42, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "Reading Date :";
            // 
            // DataInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 587);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textConsumption);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.clkReset);
            this.Controls.Add(this.clkSubmit);
            this.Controls.Add(this.clkCloseInput);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.untInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.selMonth);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.subStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentResident);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selFlatNo);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(760, 626);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 626);
            this.Name = "DataInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reading Input";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selFlatNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currentResident;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox subStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox selMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox untInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button clkCloseInput;
        private System.Windows.Forms.Button clkSubmit;
        private System.Windows.Forms.Button clkReset;
        private System.Windows.Forms.ComboBox selMonth1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btchImport;
        private System.Windows.Forms.ProgressBar importProgress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button selFile;
        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textConsumption;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox yearText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
    }
}
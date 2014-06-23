namespace RGRAB
{
    partial class OptionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.subStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.updResidentName = new System.Windows.Forms.Button();
            this.currentResident = new System.Windows.Forms.TextBox();
            this.futureResident = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.selFlatNo = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.yearText = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.updSubsidy = new System.Windows.Forms.Button();
            this.unsubText = new System.Windows.Forms.TextBox();
            this.subText = new System.Windows.Forms.TextBox();
            this.subMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clkCloseOptions = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.subStatus);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.updResidentName);
            this.groupBox1.Controls.Add(this.currentResident);
            this.groupBox1.Controls.Add(this.futureResident);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.selFlatNo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(34, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(566, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resident Name and Subsidy Status Update";
            // 
            // subStatus
            // 
            this.subStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subStatus.FormattingEnabled = true;
            this.subStatus.Items.AddRange(new object[] {
            "Subsidized",
            "UnSubsidized"});
            this.subStatus.Location = new System.Drawing.Point(242, 141);
            this.subStatus.Name = "subStatus";
            this.subStatus.Size = new System.Drawing.Size(186, 21);
            this.subStatus.TabIndex = 11;
            this.subStatus.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(90, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Subsidy Status :";
            // 
            // updResidentName
            // 
            this.updResidentName.Location = new System.Drawing.Point(242, 171);
            this.updResidentName.Name = "updResidentName";
            this.updResidentName.Size = new System.Drawing.Size(187, 36);
            this.updResidentName.TabIndex = 2;
            this.updResidentName.TabStop = false;
            this.updResidentName.Text = "Update Details";
            this.updResidentName.UseVisualStyleBackColor = true;
            this.updResidentName.Click += new System.EventHandler(this.updResidentName_Click);
            // 
            // currentResident
            // 
            this.currentResident.Location = new System.Drawing.Point(241, 58);
            this.currentResident.Name = "currentResident";
            this.currentResident.ReadOnly = true;
            this.currentResident.Size = new System.Drawing.Size(303, 20);
            this.currentResident.TabIndex = 5;
            this.currentResident.TabStop = false;
            // 
            // futureResident
            // 
            this.futureResident.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.futureResident.Location = new System.Drawing.Point(241, 100);
            this.futureResident.Name = "futureResident";
            this.futureResident.Size = new System.Drawing.Size(303, 20);
            this.futureResident.TabIndex = 1;
            this.futureResident.TabStop = false;
            this.futureResident.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.futureResident_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Future Resident Name. :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Resident Name. :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Flat No. :";
            // 
            // selFlatNo
            // 
            this.selFlatNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selFlatNo.FormattingEnabled = true;
            this.selFlatNo.Location = new System.Drawing.Point(241, 19);
            this.selFlatNo.Name = "selFlatNo";
            this.selFlatNo.Size = new System.Drawing.Size(142, 21);
            this.selFlatNo.TabIndex = 0;
            this.selFlatNo.TabStop = false;
            this.selFlatNo.SelectedIndexChanged += new System.EventHandler(this.selFlatNo_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox2.Controls.Add(this.yearText);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.updSubsidy);
            this.groupBox2.Controls.Add(this.unsubText);
            this.groupBox2.Controls.Add(this.subText);
            this.groupBox2.Controls.Add(this.subMonth);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(34, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 216);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Subsidy Value Update";
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
            this.yearText.Location = new System.Drawing.Point(241, 56);
            this.yearText.Name = "yearText";
            this.yearText.Size = new System.Drawing.Size(141, 21);
            this.yearText.TabIndex = 12;
            this.yearText.TabStop = false;
            this.yearText.SelectedIndexChanged += new System.EventHandler(this.yearText_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(97, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Subsidy Year. : ";
            // 
            // updSubsidy
            // 
            this.updSubsidy.Location = new System.Drawing.Point(241, 166);
            this.updSubsidy.Name = "updSubsidy";
            this.updSubsidy.Size = new System.Drawing.Size(187, 36);
            this.updSubsidy.TabIndex = 5;
            this.updSubsidy.TabStop = false;
            this.updSubsidy.Text = "Update Subsidy Value";
            this.updSubsidy.UseVisualStyleBackColor = true;
            this.updSubsidy.Click += new System.EventHandler(this.updSubsidy_Click);
            // 
            // unsubText
            // 
            this.unsubText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unsubText.Location = new System.Drawing.Point(241, 134);
            this.unsubText.Name = "unsubText";
            this.unsubText.Size = new System.Drawing.Size(142, 20);
            this.unsubText.TabIndex = 4;
            this.unsubText.TabStop = false;
            this.unsubText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.unsubText_KeyPress);
            // 
            // subText
            // 
            this.subText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subText.Location = new System.Drawing.Point(241, 95);
            this.subText.Name = "subText";
            this.subText.Size = new System.Drawing.Size(142, 20);
            this.subText.TabIndex = 3;
            this.subText.TabStop = false;
            this.subText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.subText_KeyPress);
            // 
            // subMonth
            // 
            this.subMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subMonth.FormattingEnabled = true;
            this.subMonth.Items.AddRange(new object[] {
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
            this.subMonth.Location = new System.Drawing.Point(241, 16);
            this.subMonth.Name = "subMonth";
            this.subMonth.Size = new System.Drawing.Size(142, 21);
            this.subMonth.TabIndex = 6;
            this.subMonth.TabStop = false;
            this.subMonth.SelectedIndexChanged += new System.EventHandler(this.subMonth_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(89, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Subsidy Month. : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(71, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Subsidized Value :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(52, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "UnSubsidized Value :";
            // 
            // clkCloseOptions
            // 
            this.clkCloseOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clkCloseOptions.Location = new System.Drawing.Point(226, 571);
            this.clkCloseOptions.Name = "clkCloseOptions";
            this.clkCloseOptions.Size = new System.Drawing.Size(187, 28);
            this.clkCloseOptions.TabIndex = 6;
            this.clkCloseOptions.TabStop = false;
            this.clkCloseOptions.Text = "Close";
            this.clkCloseOptions.UseVisualStyleBackColor = true;
            this.clkCloseOptions.Click += new System.EventHandler(this.clkCloseOptions_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RGRAB.Properties.Resources.Options1;
            this.pictureBox1.Location = new System.Drawing.Point(34, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 73);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(244, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(151, 25);
            this.label9.TabIndex = 13;
            this.label9.Text = "Data Options";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(639, 611);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.clkCloseOptions);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(655, 650);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(655, 650);
            this.Name = "OptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options Module";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox currentResident;
        private System.Windows.Forms.TextBox futureResident;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selFlatNo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox subMonth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button updResidentName;
        private System.Windows.Forms.Button updSubsidy;
        private System.Windows.Forms.TextBox unsubText;
        private System.Windows.Forms.TextBox subText;
        private System.Windows.Forms.Button clkCloseOptions;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox subStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox yearText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
    }
}
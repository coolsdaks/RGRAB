namespace RGRAB
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clkCloseMain = new System.Windows.Forms.Button();
            this.RGRABLogo = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDatabase = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnBilling = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RGRABLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(200, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 79);
            this.label1.TabIndex = 6;
            this.label1.Text = "RGRAB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(348, 402);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Arijit Bhattacharyya ©";
            // 
            // clkCloseMain
            // 
            this.clkCloseMain.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clkCloseMain.Location = new System.Drawing.Point(142, 364);
            this.clkCloseMain.Name = "clkCloseMain";
            this.clkCloseMain.Size = new System.Drawing.Size(200, 35);
            this.clkCloseMain.TabIndex = 1;
            this.clkCloseMain.Text = "Exit Program";
            this.clkCloseMain.UseVisualStyleBackColor = true;
            this.clkCloseMain.Click += new System.EventHandler(this.clkCloseMain_Click);
            // 
            // RGRABLogo
            // 
            this.RGRABLogo.Image = global::RGRAB.Properties.Resources.RGRAB_Logo;
            this.RGRABLogo.Location = new System.Drawing.Point(71, 12);
            this.RGRABLogo.Name = "RGRABLogo";
            this.RGRABLogo.Size = new System.Drawing.Size(123, 122);
            this.RGRABLogo.TabIndex = 9;
            this.RGRABLogo.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.btnUpdate.Image = global::RGRAB.Properties.Resources.Update;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUpdate.Location = new System.Drawing.Point(257, 299);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(200, 40);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = " Data Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDatabase
            // 
            this.btnDatabase.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.btnDatabase.Image = global::RGRAB.Properties.Resources.Database;
            this.btnDatabase.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDatabase.Location = new System.Drawing.Point(26, 299);
            this.btnDatabase.Name = "btnDatabase";
            this.btnDatabase.Size = new System.Drawing.Size(200, 40);
            this.btnDatabase.TabIndex = 4;
            this.btnDatabase.TabStop = false;
            this.btnDatabase.Text = "    Database Module";
            this.btnDatabase.UseVisualStyleBackColor = true;
            this.btnDatabase.Click += new System.EventHandler(this.btnDatabase_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.btnReport.Image = global::RGRAB.Properties.Resources.Reporting;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnReport.Location = new System.Drawing.Point(26, 231);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(200, 40);
            this.btnReport.TabIndex = 3;
            this.btnReport.TabStop = false;
            this.btnReport.Text = "      Reporting Module";
            this.btnReport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.btnOptions.Image = global::RGRAB.Properties.Resources.Options;
            this.btnOptions.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOptions.Location = new System.Drawing.Point(257, 231);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(200, 40);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.TabStop = false;
            this.btnOptions.Text = "    Options Module";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnBilling
            // 
            this.btnBilling.BackgroundImage = global::RGRAB.Properties.Resources.Billing;
            this.btnBilling.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBilling.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.btnBilling.Location = new System.Drawing.Point(257, 163);
            this.btnBilling.Name = "btnBilling";
            this.btnBilling.Size = new System.Drawing.Size(200, 40);
            this.btnBilling.TabIndex = 1;
            this.btnBilling.TabStop = false;
            this.btnBilling.Text = "    Billing Module";
            this.btnBilling.UseVisualStyleBackColor = true;
            this.btnBilling.Click += new System.EventHandler(this.btnBilling_Click);
            // 
            // btnInput
            // 
            this.btnInput.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInput.Image = global::RGRAB.Properties.Resources.Input;
            this.btnInput.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnInput.Location = new System.Drawing.Point(26, 163);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(200, 40);
            this.btnInput.TabIndex = 0;
            this.btnInput.TabStop = false;
            this.btnInput.Text = "Input Module";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // MainForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(484, 421);
            this.Controls.Add(this.RGRABLogo);
            this.Controls.Add(this.clkCloseMain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDatabase);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnBilling);
            this.Controls.Add(this.btnInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 460);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 460);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Module";
            ((System.ComponentModel.ISupportInitialize)(this.RGRABLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnBilling;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnDatabase;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clkCloseMain;
        private System.Windows.Forms.PictureBox RGRABLogo;
    }
}


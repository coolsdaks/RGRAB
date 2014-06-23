namespace RGRAB
{
    partial class Security
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Security));
            this.clkSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // clkSubmit
            // 
            this.clkSubmit.Location = new System.Drawing.Point(62, 74);
            this.clkSubmit.MaximumSize = new System.Drawing.Size(75, 30);
            this.clkSubmit.MinimumSize = new System.Drawing.Size(75, 30);
            this.clkSubmit.Name = "clkSubmit";
            this.clkSubmit.Size = new System.Drawing.Size(75, 30);
            this.clkSubmit.TabIndex = 2;
            this.clkSubmit.TabStop = false;
            this.clkSubmit.Text = "Submit";
            this.clkSubmit.UseVisualStyleBackColor = true;
            this.clkSubmit.Click += new System.EventHandler(this.clkSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Admin Password";
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(16, 39);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(167, 20);
            this.textPassword.TabIndex = 1;
            this.textPassword.TabStop = false;
            // 
            // Security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 117);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clkSubmit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(214, 156);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(214, 156);
            this.Name = "Security";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clkSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPassword;
    }
}
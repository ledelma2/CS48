namespace CreateDBGUI
{
    partial class Form1
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
            this.Filename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PrimeData = new System.Windows.Forms.ListBox();
            this.SecData = new System.Windows.Forms.ListBox();
            this.CustDisplay = new System.Windows.Forms.Button();
            this.BikeDisp = new System.Windows.Forms.Button();
            this.DispRent = new System.Windows.Forms.Button();
            this.ReturnRental = new System.Windows.Forms.Button();
            this.StartRental = new System.Windows.Forms.Button();
            this.RentalDuration = new System.Windows.Forms.TextBox();
            this.BikeIDs = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Filename
            // 
            this.Filename.AccessibleDescription = "Filename.mdf";
            this.Filename.Location = new System.Drawing.Point(241, 204);
            this.Filename.Name = "Filename";
            this.Filename.Size = new System.Drawing.Size(160, 20);
            this.Filename.TabIndex = 0;
            this.Filename.Text = "BikeHike.mdf";
            this.Filename.TextChanged += new System.EventHandler(this.Filename_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(183, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filename:";
            // 
            // PrimeData
            // 
            this.PrimeData.FormattingEnabled = true;
            this.PrimeData.Location = new System.Drawing.Point(408, 12);
            this.PrimeData.Name = "PrimeData";
            this.PrimeData.Size = new System.Drawing.Size(234, 225);
            this.PrimeData.TabIndex = 2;
            this.PrimeData.SelectedIndexChanged += new System.EventHandler(this.PrimeData_SelectedIndexChanged);
            // 
            // SecData
            // 
            this.SecData.FormattingEnabled = true;
            this.SecData.Location = new System.Drawing.Point(166, 12);
            this.SecData.Name = "SecData";
            this.SecData.Size = new System.Drawing.Size(235, 134);
            this.SecData.TabIndex = 3;
            // 
            // CustDisplay
            // 
            this.CustDisplay.Location = new System.Drawing.Point(12, 12);
            this.CustDisplay.Name = "CustDisplay";
            this.CustDisplay.Size = new System.Drawing.Size(125, 25);
            this.CustDisplay.TabIndex = 4;
            this.CustDisplay.Text = "Display Customers";
            this.CustDisplay.UseVisualStyleBackColor = true;
            this.CustDisplay.Click += new System.EventHandler(this.CustDisplay_Click);
            // 
            // BikeDisp
            // 
            this.BikeDisp.Location = new System.Drawing.Point(12, 43);
            this.BikeDisp.Name = "BikeDisp";
            this.BikeDisp.Size = new System.Drawing.Size(125, 25);
            this.BikeDisp.TabIndex = 5;
            this.BikeDisp.Text = "Display Bikes";
            this.BikeDisp.UseVisualStyleBackColor = true;
            this.BikeDisp.Click += new System.EventHandler(this.BikeDisp_Click);
            // 
            // DispRent
            // 
            this.DispRent.Location = new System.Drawing.Point(12, 74);
            this.DispRent.Name = "DispRent";
            this.DispRent.Size = new System.Drawing.Size(125, 25);
            this.DispRent.TabIndex = 6;
            this.DispRent.Text = "Display Rentals";
            this.DispRent.UseVisualStyleBackColor = true;
            this.DispRent.Click += new System.EventHandler(this.DispRent_Click);
            // 
            // ReturnRental
            // 
            this.ReturnRental.Location = new System.Drawing.Point(12, 105);
            this.ReturnRental.Name = "ReturnRental";
            this.ReturnRental.Size = new System.Drawing.Size(125, 25);
            this.ReturnRental.TabIndex = 7;
            this.ReturnRental.Text = "Return Rental";
            this.ReturnRental.UseVisualStyleBackColor = true;
            this.ReturnRental.Click += new System.EventHandler(this.ReturnRental_Click);
            // 
            // StartRental
            // 
            this.StartRental.Location = new System.Drawing.Point(12, 136);
            this.StartRental.Name = "StartRental";
            this.StartRental.Size = new System.Drawing.Size(125, 25);
            this.StartRental.TabIndex = 8;
            this.StartRental.Text = "Start Rental";
            this.StartRental.UseVisualStyleBackColor = true;
            this.StartRental.Click += new System.EventHandler(this.StartRental_Click);
            // 
            // RentalDuration
            // 
            this.RentalDuration.Location = new System.Drawing.Point(301, 178);
            this.RentalDuration.Name = "RentalDuration";
            this.RentalDuration.Size = new System.Drawing.Size(100, 20);
            this.RentalDuration.TabIndex = 9;
            // 
            // BikeIDs
            // 
            this.BikeIDs.Location = new System.Drawing.Point(301, 152);
            this.BikeIDs.Name = "BikeIDs";
            this.BikeIDs.Size = new System.Drawing.Size(100, 20);
            this.BikeIDs.TabIndex = 10;
            this.BikeIDs.Text = "ex. 1,2,3...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(243, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bike ID\'s:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(163, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Expected Rental Duration:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(661, 255);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BikeIDs);
            this.Controls.Add(this.RentalDuration);
            this.Controls.Add(this.StartRental);
            this.Controls.Add(this.ReturnRental);
            this.Controls.Add(this.DispRent);
            this.Controls.Add(this.BikeDisp);
            this.Controls.Add(this.CustDisplay);
            this.Controls.Add(this.SecData);
            this.Controls.Add(this.PrimeData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Filename);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Filename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox PrimeData;
        private System.Windows.Forms.ListBox SecData;
        private System.Windows.Forms.Button CustDisplay;
        private System.Windows.Forms.Button BikeDisp;
        private System.Windows.Forms.Button DispRent;
        private System.Windows.Forms.Button ReturnRental;
        private System.Windows.Forms.Button StartRental;
        private System.Windows.Forms.TextBox RentalDuration;
        private System.Windows.Forms.TextBox BikeIDs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}


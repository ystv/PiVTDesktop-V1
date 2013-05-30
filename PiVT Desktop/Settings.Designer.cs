namespace PiVT_Desktop
{
    partial class Settings
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
            this.lblHost = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.lblport = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnGoDoStuff = new System.Windows.Forms.Button();
            this.cbSerialTally = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(36, 30);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 13);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host:";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(71, 27);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(190, 20);
            this.tbHost.TabIndex = 1;
            // 
            // lblport
            // 
            this.lblport.AutoSize = true;
            this.lblport.Location = new System.Drawing.Point(39, 58);
            this.lblport.Name = "lblport";
            this.lblport.Size = new System.Drawing.Size(29, 13);
            this.lblport.TabIndex = 2;
            this.lblport.Text = "Port:";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(71, 55);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(100, 20);
            this.tbPort.TabIndex = 3;
            // 
            // btnGoDoStuff
            // 
            this.btnGoDoStuff.Location = new System.Drawing.Point(236, 120);
            this.btnGoDoStuff.Name = "btnGoDoStuff";
            this.btnGoDoStuff.Size = new System.Drawing.Size(85, 39);
            this.btnGoDoStuff.TabIndex = 4;
            this.btnGoDoStuff.Text = "OK";
            this.btnGoDoStuff.UseVisualStyleBackColor = true;
            this.btnGoDoStuff.Click += new System.EventHandler(this.btnGoDoStuff_Click);
            // 
            // cbSerialTally
            // 
            this.cbSerialTally.AutoSize = true;
            this.cbSerialTally.Location = new System.Drawing.Point(42, 93);
            this.cbSerialTally.Name = "cbSerialTally";
            this.cbSerialTally.Size = new System.Drawing.Size(113, 17);
            this.cbSerialTally.TabIndex = 6;
            this.cbSerialTally.Text = "Enable Serial Tally";
            this.cbSerialTally.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 171);
            this.Controls.Add(this.cbSerialTally);
            this.Controls.Add(this.btnGoDoStuff);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lblport);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.lblHost);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label lblport;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnGoDoStuff;
        private System.Windows.Forms.CheckBox cbSerialTally;
    }
}
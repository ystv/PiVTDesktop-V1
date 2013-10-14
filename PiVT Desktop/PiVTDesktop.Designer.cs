namespace PiVT_Desktop
{
    partial class PiVTDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PiVTDesktop));
            this.dgvVideos = new System.Windows.Forms.DataGridView();
            this.Video = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Played = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblStat = new System.Windows.Forms.Label();
            this.svrStatus = new System.Windows.Forms.Label();
            this.lblplaying = new System.Windows.Forms.Label();
            this.playtitle = new System.Windows.Forms.Label();
            this.btnResetPlay = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.cbContPlay = new System.Windows.Forms.CheckBox();
            this.SecRemaining = new System.Windows.Forms.Label();
            this.cbLoop = new System.Windows.Forms.CheckBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cbLoopItem = new System.Windows.Forms.CheckBox();
            this.spCB = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.savePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.namePlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.newPlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvVideos
            // 
            this.dgvVideos.AllowUserToAddRows = false;
            this.dgvVideos.AllowUserToDeleteRows = false;
            this.dgvVideos.AllowUserToResizeColumns = false;
            this.dgvVideos.AllowUserToResizeRows = false;
            this.dgvVideos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVideos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Video,
            this.Duration,
            this.Played});
            this.dgvVideos.Location = new System.Drawing.Point(12, 85);
            this.dgvVideos.Name = "dgvVideos";
            this.dgvVideos.ReadOnly = true;
            this.dgvVideos.RowHeadersVisible = false;
            this.dgvVideos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVideos.Size = new System.Drawing.Size(305, 338);
            this.dgvVideos.TabIndex = 0;
            this.dgvVideos.SelectionChanged += new System.EventHandler(this.dgvVideos_SelectionChanged);
            // 
            // Video
            // 
            this.Video.HeaderText = "Video";
            this.Video.Name = "Video";
            this.Video.ReadOnly = true;
            this.Video.Width = 200;
            // 
            // Duration
            // 
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            this.Duration.Width = 50;
            // 
            // Played
            // 
            this.Played.HeaderText = "Played";
            this.Played.Name = "Played";
            this.Played.ReadOnly = true;
            this.Played.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Played.Width = 50;
            // 
            // btnPlay
            // 
            this.btnPlay.Enabled = false;
            this.btnPlay.Location = new System.Drawing.Point(366, 85);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(106, 50);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(478, 85);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(106, 50);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.Location = new System.Drawing.Point(416, 332);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(74, 13);
            this.lblStat.TabIndex = 3;
            this.lblStat.Text = "Server Status:";
            // 
            // svrStatus
            // 
            this.svrStatus.AutoSize = true;
            this.svrStatus.Location = new System.Drawing.Point(500, 332);
            this.svrStatus.Name = "svrStatus";
            this.svrStatus.Size = new System.Drawing.Size(79, 13);
            this.svrStatus.TabIndex = 4;
            this.svrStatus.Text = "Not Connected";
            // 
            // lblplaying
            // 
            this.lblplaying.AutoSize = true;
            this.lblplaying.Location = new System.Drawing.Point(402, 354);
            this.lblplaying.Name = "lblplaying";
            this.lblplaying.Size = new System.Drawing.Size(88, 13);
            this.lblplaying.TabIndex = 5;
            this.lblplaying.Text = "Currently Playing:";
            // 
            // playtitle
            // 
            this.playtitle.AutoSize = true;
            this.playtitle.Location = new System.Drawing.Point(500, 354);
            this.playtitle.Name = "playtitle";
            this.playtitle.Size = new System.Drawing.Size(44, 13);
            this.playtitle.TabIndex = 6;
            this.playtitle.Text = "Nothing";
            // 
            // btnResetPlay
            // 
            this.btnResetPlay.Location = new System.Drawing.Point(12, 55);
            this.btnResetPlay.Name = "btnResetPlay";
            this.btnResetPlay.Size = new System.Drawing.Size(256, 24);
            this.btnResetPlay.TabIndex = 7;
            this.btnResetPlay.Text = "Reset Play Column";
            this.btnResetPlay.UseVisualStyleBackColor = true;
            this.btnResetPlay.Click += new System.EventHandler(this.btnResetPlay_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(702, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlaylistToolStripMenuItem,
            this.toolStripSeparator3,
            this.openPlaylistToolStripMenuItem,
            this.toolStripSeparator1,
            this.savePlaylistToolStripMenuItem,
            this.namePlaylistToolStripMenuItem,
            this.toolStripSeparator2,
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPlaylistToolStripMenuItem
            // 
            this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
            this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openPlaylistToolStripMenuItem.Text = "Open Playlist...";
            this.openPlaylistToolStripMenuItem.Click += new System.EventHandler(this.openPlaylistToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiConnect});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // tsmiConnect
            // 
            this.tsmiConnect.Name = "tsmiConnect";
            this.tsmiConnect.Size = new System.Drawing.Size(119, 22);
            this.tsmiConnect.Text = "Connect";
            this.tsmiConnect.Click += new System.EventHandler(this.tsmiConnect_Click);
            // 
            // cbContPlay
            // 
            this.cbContPlay.AutoSize = true;
            this.cbContPlay.Location = new System.Drawing.Point(419, 176);
            this.cbContPlay.Name = "cbContPlay";
            this.cbContPlay.Size = new System.Drawing.Size(115, 17);
            this.cbContPlay.TabIndex = 9;
            this.cbContPlay.Text = "Auto-play next item";
            this.cbContPlay.UseVisualStyleBackColor = true;
            this.cbContPlay.CheckedChanged += new System.EventHandler(this.cbContPlay_CheckedChanged);
            // 
            // SecRemaining
            // 
            this.SecRemaining.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SecRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 95F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecRemaining.Location = new System.Drawing.Point(323, 199);
            this.SecRemaining.Name = "SecRemaining";
            this.SecRemaining.Size = new System.Drawing.Size(379, 133);
            this.SecRemaining.TabIndex = 10;
            this.SecRemaining.Text = "12";
            this.SecRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SecRemaining.Visible = false;
            // 
            // cbLoop
            // 
            this.cbLoop.AutoSize = true;
            this.cbLoop.Location = new System.Drawing.Point(419, 199);
            this.cbLoop.Name = "cbLoop";
            this.cbLoop.Size = new System.Drawing.Size(85, 17);
            this.cbLoop.TabIndex = 11;
            this.cbLoop.Text = "Loop Playlist";
            this.cbLoop.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(101, 434);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(60, 37);
            this.btnUp.TabIndex = 12;
            this.btnUp.Text = "Move Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(167, 434);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(60, 37);
            this.btnDown.TabIndex = 13;
            this.btnDown.Text = "Move Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.Filter = "XML Playlist (*.xml*)|*.xml*";
            this.openFileDialog1.InitialDirectory = ".";
            this.openFileDialog1.Title = "Open Playlist File";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // cbLoopItem
            // 
            this.cbLoopItem.AutoSize = true;
            this.cbLoopItem.Location = new System.Drawing.Point(419, 153);
            this.cbLoopItem.Name = "cbLoopItem";
            this.cbLoopItem.Size = new System.Drawing.Size(96, 17);
            this.cbLoopItem.TabIndex = 14;
            this.cbLoopItem.Text = "Loop This Item";
            this.cbLoopItem.UseVisualStyleBackColor = true;
            this.cbLoopItem.CheckedChanged += new System.EventHandler(this.cbLoopItem_CheckedChanged);
            // 
            // spCB
            // 
            this.spCB.FormattingEnabled = true;
            this.spCB.Location = new System.Drawing.Point(12, 14);
            this.spCB.Name = "spCB";
            this.spCB.Size = new System.Drawing.Size(77, 21);
            this.spCB.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.spCB);
            this.groupBox1.Location = new System.Drawing.Point(344, 381);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 89);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Tally";
            this.groupBox1.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(212, 60);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 25;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(193, 60);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 24;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(176, 60);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(157, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 22;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(210, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(16, 16);
            this.panel4.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(192, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(16, 16);
            this.panel3.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(173, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 16);
            this.panel2.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(155, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(16, 16);
            this.panel1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "1    2    3    4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 16;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(233, 434);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(60, 37);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // savePlaylistToolStripMenuItem
            // 
            this.savePlaylistToolStripMenuItem.Enabled = false;
            this.savePlaylistToolStripMenuItem.Name = "savePlaylistToolStripMenuItem";
            this.savePlaylistToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.savePlaylistToolStripMenuItem.Text = "Save Playlist";
            this.savePlaylistToolStripMenuItem.Click += new System.EventHandler(this.savePlaylistToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // namePlaylistToolStripMenuItem
            // 
            this.namePlaylistToolStripMenuItem.Name = "namePlaylistToolStripMenuItem";
            this.namePlaylistToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.namePlaylistToolStripMenuItem.Text = "Save Playlist As...";
            this.namePlaylistToolStripMenuItem.Click += new System.EventHandler(this.namePlaylistToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML Playlist (*.xml*)|*.xml*";
            this.saveFileDialog1.InitialDirectory = ".";
            this.saveFileDialog1.Title = "Save Playlist File";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // newPlaylistToolStripMenuItem
            // 
            this.newPlaylistToolStripMenuItem.Name = "newPlaylistToolStripMenuItem";
            this.newPlaylistToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.newPlaylistToolStripMenuItem.Text = "New Playlist";
            this.newPlaylistToolStripMenuItem.Click += new System.EventHandler(this.newPlaylistToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // PiVTDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 475);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbLoopItem);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.cbLoop);
            this.Controls.Add(this.SecRemaining);
            this.Controls.Add(this.cbContPlay);
            this.Controls.Add(this.btnResetPlay);
            this.Controls.Add(this.playtitle);
            this.Controls.Add(this.lblplaying);
            this.Controls.Add(this.svrStatus);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.dgvVideos);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PiVTDesktop";
            this.Text = "PiVT Desktop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PiVTDesktop_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVideos;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.Label svrStatus;
        private System.Windows.Forms.Label lblplaying;
        private System.Windows.Forms.Label playtitle;
        private System.Windows.Forms.Button btnResetPlay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiConnect;
        private System.Windows.Forms.CheckBox cbContPlay;
        private System.Windows.Forms.Label SecRemaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn Video;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Played;
        private System.Windows.Forms.CheckBox cbLoop;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ToolStripMenuItem openPlaylistToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox cbLoopItem;
        private System.Windows.Forms.ComboBox spCB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem savePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem namePlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem newPlaylistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}


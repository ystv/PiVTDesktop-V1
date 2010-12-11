namespace XineNet_Desktop
{
    partial class XineNetDesktop
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.lblStat.Location = new System.Drawing.Point(377, 362);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(74, 13);
            this.lblStat.TabIndex = 3;
            this.lblStat.Text = "Server Status:";
            // 
            // svrStatus
            // 
            this.svrStatus.AutoSize = true;
            this.svrStatus.Location = new System.Drawing.Point(461, 362);
            this.svrStatus.Name = "svrStatus";
            this.svrStatus.Size = new System.Drawing.Size(79, 13);
            this.svrStatus.TabIndex = 4;
            this.svrStatus.Text = "Not Connected";
            // 
            // lblplaying
            // 
            this.lblplaying.AutoSize = true;
            this.lblplaying.Location = new System.Drawing.Point(363, 384);
            this.lblplaying.Name = "lblplaying";
            this.lblplaying.Size = new System.Drawing.Size(88, 13);
            this.lblplaying.TabIndex = 5;
            this.lblplaying.Text = "Currently Playing:";
            // 
            // playtitle
            // 
            this.playtitle.AutoSize = true;
            this.playtitle.Location = new System.Drawing.Point(461, 384);
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
            this.openPlaylistToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openPlaylistToolStripMenuItem
            // 
            this.openPlaylistToolStripMenuItem.Name = "openPlaylistToolStripMenuItem";
            this.openPlaylistToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openPlaylistToolStripMenuItem.Text = "Open Playlist";
            this.openPlaylistToolStripMenuItem.Click += new System.EventHandler(this.openPlaylistToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.settingsToolStripMenuItem.Text = "settings";
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
            this.cbContPlay.Location = new System.Drawing.Point(419, 156);
            this.cbContPlay.Name = "cbContPlay";
            this.cbContPlay.Size = new System.Drawing.Size(115, 17);
            this.cbContPlay.TabIndex = 9;
            this.cbContPlay.Text = "Play Whole Playlist";
            this.cbContPlay.UseVisualStyleBackColor = true;
            this.cbContPlay.CheckedChanged += new System.EventHandler(this.cbContPlay_CheckedChanged);
            // 
            // SecRemaining
            // 
            this.SecRemaining.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SecRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecRemaining.Location = new System.Drawing.Point(323, 199);
            this.SecRemaining.Name = "SecRemaining";
            this.SecRemaining.Size = new System.Drawing.Size(367, 133);
            this.SecRemaining.TabIndex = 10;
            this.SecRemaining.Text = "12";
            this.SecRemaining.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SecRemaining.Visible = false;
            // 
            // cbLoop
            // 
            this.cbLoop.AutoSize = true;
            this.cbLoop.Location = new System.Drawing.Point(488, 179);
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
            this.openFileDialog1.InitialDirectory = ".";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // cbLoopItem
            // 
            this.cbLoopItem.AutoSize = true;
            this.cbLoopItem.Location = new System.Drawing.Point(540, 156);
            this.cbLoopItem.Name = "cbLoopItem";
            this.cbLoopItem.Size = new System.Drawing.Size(96, 17);
            this.cbLoopItem.TabIndex = 14;
            this.cbLoopItem.Text = "Loop This Item";
            this.cbLoopItem.UseVisualStyleBackColor = true;
            this.cbLoopItem.CheckedChanged += new System.EventHandler(this.cbLoopItem_CheckedChanged);
            // 
            // XineNetDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 475);
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
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "XineNetDesktop";
            this.Text = "XineNet Desktop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.XineNetDesktop_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVideos)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}


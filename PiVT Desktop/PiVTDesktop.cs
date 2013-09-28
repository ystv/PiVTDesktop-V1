﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiVT_Desktop
{
    public partial class PiVTDesktop : Form
    {
        PiVTControl playserver;
        System.Timers.Timer RemainingTimer;
        int playingindex = -1;
        PlayListLoader playlist;
        SerialTally tally;
        public PiVTDesktop()
        {
            InitializeComponent();
            groupBox1.Visible = Properties.Settings.Default.EnableTally;

            //set up timerl
            RemainingTimer = new System.Timers.Timer(1000);
            RemainingTimer.Enabled = false;
            RemainingTimer.AutoReset = true;
            RemainingTimer.Elapsed += new System.Timers.ElapsedEventHandler(timerElapsed);

            playserver = new PiVTControl(Properties.Settings.Default.Server, Properties.Settings.Default.Port);
            playserver.connectionStatusChanged += new connectionStatusChangedHandler(updateconnstat);
            playserver.playerStatusChanged += new playerStatusChangedHandler(updateplaystat);
            updateconnectbox();

            playserver.getStatus();
            cbLoop.Enabled = cbContPlay.Checked;

            tally = new SerialTally();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 0; i < ports.Length; i++)
            {
                spCB.Items.Add(ports[i]);
            }
            if (spCB.Items.Count > 0)
                spCB.SelectedIndex = 0;
            else
                button1.Enabled = false;
            tally.statusevt += new StatusChanged(tally_statusevt);
        }

        void tally_statusevt()
        {
            this.Invoke((MethodInvoker)delegate
            {
                updateTally();
            });
        }

        void PlaylistChange(string filename)
        {
            playlist = new PlayListLoader(filename);
            dgvVideos.Rows.Clear();
            foreach (PLItem pli in playlist.playlist)
            {
                int rowid = dgvVideos.Rows.Add();
                dgvVideos.Rows[rowid].Cells[0].Value = pli.getFilename();
                dgvVideos.Rows[rowid].Cells[1].Value = pli.getLength().ToString();
                dgvVideos.Rows[rowid].Cells[2].Value = false;
            }
        }

        void PlaylistRefresh() //reloads data grid, not from file.Use after reordering.
        {
            int selected = dgvVideos.SelectedCells[0].RowIndex;
            dgvVideos.Rows.Clear();
            foreach (PLItem pli in playlist.playlist)
            {
                int rowid = dgvVideos.Rows.Add();
                dgvVideos.Rows[rowid].Cells[0].Value = pli.getFilename();
                dgvVideos.Rows[rowid].Cells[1].Value = pli.getLength().ToString();
                dgvVideos.Rows[rowid].Cells[2].Value = false;
                dgvVideos.Rows[rowid].Cells[2].Selected = false;
            }

            if (selected == dgvVideos.Rows.Count)
            {
                selected--;
            }

            dgvVideos.Rows[selected].Selected = true;
        }

        void updateconnstat(object sender, EventArgs e)
        {
            updateconnectbox();
        }

        void updateplaystat(object sender, EventArgs e)
        {
            updateplayingstatus();
        }

        void updateSettings(object sender, EventArgs e)
        {
            playserver.stopreading();
            playserver.connect(Properties.Settings.Default.Server, Properties.Settings.Default.Port);
            groupBox1.Visible = Properties.Settings.Default.EnableTally;
            playserver.getStatus();
        }

        void updateconnectbox()
        {
            if (playserver.connected)
            {
                svrStatus.Text = "Connected to " + Properties.Settings.Default.Server;
                tsmiConnect.Enabled = false;
            }
            else
            {
                svrStatus.Text = "Not Connected";
                tsmiConnect.Enabled = true;
            }
            updateplayingstatus();
        }

        void updateplayingstatus()
        {
            if (playserver.connected)
            {
                #region Big Ugly Methodinvoker named minv
                MethodInvoker minv = new MethodInvoker(delegate()
                {
                    btnPlay.Enabled = true;
                    btnStop.Enabled = true;
                    lblplaying.Visible = true;
                    playtitle.Visible = true;
                    if (playserver.playing)
                    {
                        if (playingindex > -1)
                        {
                            RemainingTimer.Enabled = true;
                            RemainingTimer.Start();
                            setupSecRemaining();
                        }
                        playtitle.Text = playserver.currentvideo;

                        //see if the playing video matches one on out list:
                        foreach (DataGridViewRow row in dgvVideos.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == playserver.currentvideo)
                            {
                                playingindex = row.Index;

                                // Update length if available
                                if (playserver.currentlength != 0)
                                {
                                    dgvVideos.Rows[playingindex].Cells[1].Value = playserver.currentlength.ToString();
                                    playserver.currentlength = 0;
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        //not playing
                        RemainingTimer.Stop();
                        RemainingTimer.Enabled = false;
                        SecRemaining.Visible = false;
                        playtitle.Text = "None";
                        if (playingindex > -1)
                        {
                            TimeSpan secrem = TimeSpan.ParseExact(SecRemaining.Text, @"mm\:ss", System.Globalization.CultureInfo.CurrentCulture);
                            if (secrem > TimeSpan.FromSeconds(0) && RemainingTimer.Enabled) //checks if the timer hasn't finished counting down yet
                            {
                                //correct field in grid
                                int gridnum = int.Parse(dgvVideos.Rows[playingindex].Cells[1].Value.ToString());
                                gridnum -= (int)secrem.TotalSeconds;
                                dgvVideos.Rows[playingindex].Cells[1].Value = gridnum.ToString();
                            }
                            dgvVideos.Rows[playingindex].Cells[2].Value = true;
                            int nextselected = 0;
                            if (cbLoopItem.Checked && !cbContPlay.Checked)
                            {
                                nextselected = playingindex;
                            }
                            else if (dgvVideos.RowCount > (playingindex + 1))
                            {
                                nextselected = playingindex + 1;
                            }
                            dgvVideos.Rows[dgvVideos.SelectedCells[0].RowIndex].Selected = false;
                            dgvVideos.Rows[nextselected].Selected = true;
                            playingindex = -1;
                            //this needs a touch of explanation:
                            //either cbLoopItem is checked and cbContPlay is not checked, so we play again
                            //or continuous play is checked and it's not the first item,
                            //or continuous play is checked and it's on loop.
                            //this results in it only restarting the list if it's on loop.
                            if ((cbLoopItem.Checked && !cbContPlay.Checked) || (cbContPlay.Checked && dgvVideos.SelectedCells[0].RowIndex != 0) ||(cbContPlay.Checked && cbLoop.Checked))
                            {
                                playserver.playvid(dgvVideos.Rows[dgvVideos.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                                playingindex = dgvVideos.SelectedCells[0].RowIndex;
                                setupSecRemaining();
                            }
                        }
                    }
                });
                #endregion
                #region the bit that calls the method invoker
                if (InvokeRequired)
                {
                    Invoke(minv);
                }
                else
                {
                    minv();
                }
                #endregion
            }
            else
            {
                lblplaying.Visible = false;
                playtitle.Visible = false;
                btnPlay.Enabled = false;
                btnStop.Enabled = false;
                SecRemaining.Visible = false;
            }
        }

        private void setupSecRemaining()
        {
            if (playingindex > -1)
            {
                Color textcol = Color.Green;
                TimeSpan secrem = TimeSpan.FromSeconds(playserver.lengthremaining);
                if (secrem > TimeSpan.FromSeconds(5) && secrem <= TimeSpan.FromSeconds(10))
                {
                    textcol = Color.Orange;
                }
                else if (secrem <= TimeSpan.FromSeconds(5))
                {
                    textcol = Color.Red;
                }
                SecRemaining.Text = secrem.ToString(@"mm\:ss");
                SecRemaining.ForeColor = textcol;
                SecRemaining.Visible = true;
            }
        }

        private void play() 
        {
            if (dgvVideos.Rows.Count > 0)
            {
                playserver.playvid(dgvVideos.Rows[dgvVideos.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
                playingindex = dgvVideos.SelectedCells[0].RowIndex;
                setupSecRemaining();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            play();
        }

        private void btnResetPlay_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvVideos.Rows)
            {
                row.Cells[2].Value = false;
            }
        }

        private void PiVTDesktop_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(playserver.connected)
                playserver.stopreading();//(hopefully) kills socket thread
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            playingindex = -1; //so it doesn't get marked as completed
            playserver.stopvid();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings box = new Settings();
            box.settingsChanged += new settingsChangedHandler(updateSettings);
            box.Show();
        }

        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            playserver.connect(Properties.Settings.Default.Server, Properties.Settings.Default.Port);
            playserver.getStatus();
        }

        private void timerElapsed(object sender, EventArgs e)
        {
            string sr = SecRemaining.Text;
            
            TimeSpan secrem = TimeSpan.ParseExact(SecRemaining.Text, @"mm\:ss", System.Globalization.CultureInfo.CurrentCulture);
            Color textcol = Color.Green;
            if (secrem.TotalSeconds > 0)
                secrem = secrem.Subtract(TimeSpan.FromSeconds(1));
            else
            {
                if (playingindex > -1)
                {
                    int len = int.Parse(dgvVideos.Rows[playingindex].Cells[1].Value.ToString());
                    len++;
                    Invoke(new MethodInvoker(delegate()
                    {
                        dgvVideos.Rows[playingindex].Cells[1].Value = len.ToString();
                    }));
                }
            }
            if (secrem > TimeSpan.FromSeconds(5) && secrem <= TimeSpan.FromSeconds(10))
            {
                textcol = Color.Orange;
            }
            else if (secrem <= TimeSpan.FromSeconds(5))
            {
                textcol = Color.Red;
            }
            if (SecRemaining.InvokeRequired)
            {
                SecRemaining.Invoke(new MethodInvoker(delegate() { SecRemaining.Text = secrem.ToString(@"mm\:ss"); SecRemaining.ForeColor = textcol; }));
            }
            else
            {
                SecRemaining.Text = secrem.ToString(@"mm\:ss");
                SecRemaining.ForeColor = textcol;
            }
        }

        private void cbContPlay_CheckedChanged(object sender, EventArgs e)
        {
            cbLoop.Enabled = cbContPlay.Checked;
            cbLoopItem.Enabled = !cbContPlay.Checked;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (dgvVideos.Rows.Count > 0 && dgvVideos.SelectedRows[0].Index > 0)
            {
                int selected = dgvVideos.SelectedRows[0].Index;
                playlist.moveup(selected);
                dgvVideos.Rows[selected].Selected = false;
                dgvVideos.Rows[selected - 1].Selected = true;
                PlaylistRefresh();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            //doing this via the PlayListLoader object so it can potentialy save the changes
            if (dgvVideos.Rows.Count > 0 && dgvVideos.SelectedRows[0].Index < dgvVideos.Rows.Count - 1)
            {
                int selected = dgvVideos.SelectedRows[0].Index;
                playlist.movedown(selected);
                dgvVideos.Rows[selected].Selected = false;
                dgvVideos.Rows[selected + 1].Selected = true;
                PlaylistRefresh();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvVideos.Rows.Count > 0 && dgvVideos.SelectedRows[0].Index < dgvVideos.Rows.Count)
            {
                int selected = dgvVideos.SelectedRows[0].Index;
                playlist.delete(selected);
                PlaylistRefresh();
            }
        }

        private void openPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TODO: ask the user for the playlist
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            PlaylistChange(openFileDialog1.FileName);
        }

        private void cbLoopItem_CheckedChanged(object sender, EventArgs e)
        {
            cbContPlay.Enabled = !cbContPlay.Checked;
            
        }

        private void updateTally()
        {
            if (!tally.connected())
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                label1.Visible = false;
            }
            else
            {
                label1.Visible = true;
                panel1.Visible = true;
                panel2.Visible = true;
                panel3.Visible = true;
                panel4.Visible = true;
                panel1.BackColor = Color.Red;
                panel2.BackColor = Color.Red;
                panel3.BackColor = Color.Red;
                panel4.BackColor = Color.Red;
                if (tally.getTally(1))
                    panel1.BackColor = Color.Green;
                if (tally.getTally(2))
                    panel2.BackColor = Color.Green;
                if (tally.getTally(3))
                    panel3.BackColor = Color.Green;
                if (tally.getTally(4))
                    panel4.BackColor = Color.Green;
            }
            if (checkBox1.Checked && tally.getTally(1))
            {
                play();
            }
            if (checkBox2.Checked && tally.getTally(2))
            {
                play();
            }
            if (checkBox3.Checked && tally.getTally(3))
            {
                play();
            }
            if (checkBox4.Checked && tally.getTally(4))
            {
                play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!tally.connected())
            {
                tally.connect((string)spCB.Items[spCB.SelectedIndex]);
                button1.Text = "Disconnect";

            }
            else
            {
                button1.Text = "Connect";
                tally.disconnect();
            }
        }

        private void dgvVideos_SelectionChanged(object sender, EventArgs e)
        {
            //Load selected
            try
            {
                playserver.loadvid(dgvVideos.Rows[dgvVideos.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            }
            catch
            {
                //Doesn't really matter if this fails
            }
        }
    }
}

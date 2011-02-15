using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XineNet_Desktop
{
    public partial class XineNetDesktop : Form
    {
        XNDConfig conf;
        XineNetControl playserver;
        System.Timers.Timer RemainingTimer;
        int playingindex = -1;
        PlayListLoader playlist;
        SerialTally tally;
        public XineNetDesktop()
        {
            InitializeComponent();
            conf = new XNDConfig();
            //set up timer
            RemainingTimer = new System.Timers.Timer(1000);
            RemainingTimer.Enabled = false;
            RemainingTimer.AutoReset = true;
            RemainingTimer.Elapsed += new System.Timers.ElapsedEventHandler(timerElapsed);
            playserver = new XineNetControl(conf.serverhost, conf.serverport);
            playserver.connectionStatusChanged += new connectionStatusChangedHandler(updateconnstat);
            playserver.playerStatusChanged += new playerStatusChangedHandler(updateplaystat);
            updateconnectbox();

            playserver.getStatus();
            cbLoop.Visible = cbContPlay.Checked;

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
            playserver.connect(conf.serverhost, conf.serverport);
        }

        void updateconnectbox()
        {
            if (playserver.connected)
            {
                svrStatus.Text = "Connected to " + conf.serverhost;
                tsmiConnect.Enabled = false;
            }
            else
            {
                svrStatus.Text = "Not Connected";
                tsmiConnect.Enabled = true;
            }
            //now update the playing bit because it might be hidden.
            updateplayingstatus();
        }

        void updateplayingstatus()
        {
            if (playserver.connected)
            {
                #region Big Ugly Methodinvoker named minv
                MethodInvoker minv = new MethodInvoker(delegate()
                {
                    lblplaying.Visible = true;
                    playtitle.Visible = true;
                    if (playserver.playing)
                    {
                        if (playingindex > -1)
                        {
                            RemainingTimer.Enabled = true;
                            RemainingTimer.Start();
                            SecRemaining.Visible = true;
                        }
                        playtitle.Text = playserver.currentvideo;

                        //see if the playing video matches one on out list:
                        foreach (DataGridViewRow row in dgvVideos.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == playserver.currentvideo)
                            {
                                playingindex = row.Index;
                                break;
                            }
                        }
                        btnStop.Enabled = true;
                        btnPlay.Enabled = false;
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
                            int secrem = int.Parse(SecRemaining.Text);
                            if (secrem > 0 && RemainingTimer.Enabled) //checks if the timer hasn't finished counting down yet
                            {
                                //correct field in grid
                                int gridnum = int.Parse(dgvVideos.Rows[playingindex].Cells[1].Value.ToString());
                                gridnum -= secrem;
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
                        btnStop.Enabled = false;
                        btnPlay.Enabled = true;
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
            }
        }

        private void setupSecRemaining()
        {
            if (playingindex > -1)
            {
                Color textcol = Color.Green;
                int secrem = int.Parse(dgvVideos.Rows[dgvVideos.SelectedCells[0].RowIndex].Cells[1].Value.ToString());
                if (secrem > 5 && secrem <= 10)
                {
                    textcol = Color.Orange;
                }
                else if (secrem <= 5)
                {
                    textcol = Color.Red;
                }
                SecRemaining.Text = secrem.ToString();
                SecRemaining.ForeColor = textcol;
            }
        }

        private void play() 
        {
            if (dgvVideos.Rows.Count > 0 && !playserver.playing)
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

        private void XineNetDesktop_FormClosed(object sender, FormClosedEventArgs e)
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
            Settings box = new Settings(conf);
            box.settingsChanged += new settingsChangedHandler(updateSettings);
            box.Show();
        }

        private void tsmiConnect_Click(object sender, EventArgs e)
        {
            playserver.connect(conf.serverhost,conf.serverport);
        }

        private void timerElapsed(object sender, EventArgs e)
        {
            int secrem = int.Parse(SecRemaining.Text);
            Color textcol = Color.Green;
            if (secrem > 0)
                secrem--;
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
            if (secrem > 5 && secrem <= 10)
            {
                textcol = Color.Orange;
            }
            else if (secrem <= 5)
            {
                textcol = Color.Red;
            }
            if (SecRemaining.InvokeRequired)
            {
                SecRemaining.Invoke(new MethodInvoker(delegate() { SecRemaining.Text = secrem.ToString(); SecRemaining.ForeColor = textcol; }));
            }
            else
            {
                SecRemaining.Text = secrem.ToString();
                SecRemaining.ForeColor = textcol;
            }
        }

        private void cbContPlay_CheckedChanged(object sender, EventArgs e)
        {
            cbLoop.Visible = cbContPlay.Checked;
            cbLoopItem.Visible = !cbContPlay.Checked;
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
            cbContPlay.Visible = !cbContPlay.Checked;
            
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

    }
}

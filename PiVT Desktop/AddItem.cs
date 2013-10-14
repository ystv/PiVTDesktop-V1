using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiVT_Desktop
{
    public delegate void playlistChangedHandler(object sender, EventArgs e);
    public partial class AddItem : Form
    {
        public event playlistChangedHandler playlistChanged;

        PlayListLoader playlist;

        List<PLItem> newitems;

        PiVTControl playserver;

        public AddItem(ref PlayListLoader playlist, ref PiVTControl playserver)
        {
            newitems = new List<PLItem>();
            this.playlist = playlist;
            InitializeComponent();
            ddItem.Items.Clear();

            this.playserver = playserver;
            playserver.fileUpdate += new fileUpdateHandler(updateFileList);
            playserver.listfiles();
        }

        ~AddItem()
        {
            playserver.fileUpdate -= new fileUpdateHandler(updateFileList);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            playlist.addItem(newitems[ddItem.SelectedIndex]);

            if (playlistChanged != null)
            {
                playlistChanged(this, EventArgs.Empty);
            }
            this.Close();
        }

        void updateFileList(object sender, EventArgs e, string filename, int length, bool done)
        {
            if (done)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        lblWait.Visible = false;
                        ddItem.Visible = true;
                    });
                }
                else
                {
                    lblWait.Visible = false;
                }
            }
            else
            {
                newitems.Add(new PLItem(filename, length));

                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        ddItem.Items.Add(filename);
                    });
                }
                else
                {
                    ddItem.Items.Add(filename);
                }
            }
        }

        private void ddItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((string)ddItem.SelectedValue != "")
            {
                btnOK.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
            }
        }
    }
}

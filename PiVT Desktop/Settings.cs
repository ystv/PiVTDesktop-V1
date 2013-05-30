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
    //event handler for when config is updated
    public delegate void settingsChangedHandler(object sender, EventArgs e);
    public partial class Settings : Form
    {
        public event settingsChangedHandler settingsChanged;
        public Settings()
        {
            InitializeComponent();
            tbHost.Text = Properties.Settings.Default.Server;
            tbPort.Text = Properties.Settings.Default.Port.ToString();
        }

        private void btnGoDoStuff_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Server = tbHost.Text;
            Properties.Settings.Default.Port = int.Parse(tbPort.Text);
            Properties.Settings.Default.EnableTally = cbSerialTally.Checked;
            Properties.Settings.Default.Save();
            settingsChanged(this, EventArgs.Empty); //throw event to tell client to update
            this.Close();
        }
    }
}

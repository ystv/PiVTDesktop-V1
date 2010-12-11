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
    //event handler for when config is updated
    public delegate void settingsChangedHandler(object sender, EventArgs e);
    public partial class Settings : Form
    {
        XNDConfig conf;
        public event settingsChangedHandler settingsChanged;
        public Settings(XNDConfig conf)
        {
            InitializeComponent();
            this.conf = conf;
            tbHost.Text = conf.serverhost;
            tbPort.Text = conf.serverport.ToString();
        }

        private void btnGoDoStuff_Click(object sender, EventArgs e)
        {
            conf.serverhost = tbHost.Text;
            conf.serverport = int.Parse(tbPort.Text);
            settingsChanged(this, EventArgs.Empty); //throw event to tell client to update
            this.Close();
        }
    }
}

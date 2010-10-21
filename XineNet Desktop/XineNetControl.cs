using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace XineNet_Desktop
{

    //begin pile of event handlers
    public delegate void connectionStatusChangedHandler(object sender, EventArgs e);
    public delegate void playerStatusChangedHandler(object sender, EventArgs e);
    //end pile of event handlers

    class XineNetControl
    {
        TcpClient connection = null;
        NetworkStream constream;
        public bool connected = false;
        public bool playing = false;
        public string currentvideo = "";

        Thread readerthread;
        //begin pile of events
        public event connectionStatusChangedHandler connectionStatusChanged;
        public event playerStatusChangedHandler playerStatusChanged;
        //end pile of events

        public void playvid(string video) {
            if (connected)
            {
                StreamWriter sw = new StreamWriter(constream);
                sw.WriteLine("p " + video);
                sw.Flush();
            }
        }

        public void getStatus()
        {
            if (connected)
            {
                StreamWriter sw = new StreamWriter(constream);
                sw.WriteLine("?");
                sw.Flush();
            }
        }

        public void stopvid()
        {
            StreamWriter sw = new StreamWriter(constream);
            if (connected)
            {
                sw.WriteLine("s");
                sw.Flush();
            }
        }

        public XineNetControl(string host, int port)
        {
            connect(host,port);
           
        }

        public void connect(string host,int port)
        {
            if (!connected)
            {
                try
                {
                    TcpClient tmp = new TcpClient(host, port);
                    if (tmp.Connected)
                    {
                        connection = tmp;
                    }
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show("Grr... Exception trying to connect to xine-net. " + ex.ToString());
                    //ok, it failed. Meh.

                }
                if (connection == null)
                {
                    //bugger. Not connected.
                }
                else
                {
                    connected = connection.Connected;
                    constream = connection.GetStream();
                    readerthread = new Thread(linereader);
                    readerthread.Start();
                    if (connectionStatusChanged != null)
                    {
                        connectionStatusChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public void stopreading()
        {
            //abort the thread. Note thread doesn't actually close until the stream closes.
            readerthread.Abort();
            constream.Close();
        }

        //handles messages starting with STAT
        void handlestat(string msg)
        {
            string[] chunks = msg.Split(' ');
            switch (chunks[1])
            {
                case "Playing":
                    playing = true;
                    currentvideo = chunks[2].TrimStart('\'').TrimEnd('\'');
                    playerStatusChanged(this, EventArgs.Empty);
                    break;
                case "Stopped":
                    playing = false;
                    currentvideo = "";
                    playerStatusChanged(this, EventArgs.Empty);
                    break;
            }
        }

        //something to monitor the socket and read linesz
        void linereader()
        {
            StreamReader sr = new StreamReader(constream);
            while(true) {
                string line = sr.ReadLine();
                string[] chunks;
                if (line != null)
                    chunks = line.Split(' ');
                else
                {
                    return;
                }
                switch (chunks[0])
                {
                    case "Welcome":
                        continue;
                        break;
                    case "STAT:":
                        handlestat(line);
                        continue;
                        break;
                    case "STOP:":
                        playing = false;
                        playerStatusChanged(this, EventArgs.Empty);
                        break;
                    case "File":
                        if (line.Split(':')[0] == "File not found")
                        {
                            playing = false;
                            playerStatusChanged(this, EventArgs.Empty);
                        }
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show(line);
                        break;
                }
            }
        }

    }
}

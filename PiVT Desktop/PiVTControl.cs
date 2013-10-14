using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace PiVT_Desktop
{

    //begin pile of event handlers
    public delegate void connectionStatusChangedHandler(object sender, EventArgs e);
    public delegate void playerStatusChangedHandler(object sender, EventArgs e);
    public delegate void fileUpdateHandler(object sender, EventArgs e, string filename, int length, bool done);
    //end pile of event handlers

    public class PiVTControl
    {
        TcpClient connection = null;
        NetworkStream constream;
        public bool connected = false;
        public bool playing = false;
        public string currentvideo = "";
        public int currentlength = 0;
        public int lengthremaining = 0;
        public string responsecode = "";

        Thread readerthread;
        //begin pile of events
        public event connectionStatusChangedHandler connectionStatusChanged;
        public event playerStatusChangedHandler playerStatusChanged;
        public event fileUpdateHandler fileUpdate;
        //end pile of events

        public void loadvid(string video)
        {
            if (connected)
            {
                StreamWriter sw = new StreamWriter(constream);
                sw.WriteLine("l " + video);

                try 
                {
                    sw.Flush();
                }
                catch
                {
                    connected = false;
                    connectionStatusChanged(this, EventArgs.Empty);
                }
            }
        }

        public void unloadvid()
        {
            if (connected)
            {
                StreamWriter sw = new StreamWriter(constream);
                sw.WriteLine("u");

                try
                {
                    sw.Flush();
                }
                catch
                {
                    connected = false;
                    connectionStatusChanged(this, EventArgs.Empty);
                }
            }
        }

        public void playvid(string video) {
            if (connected)
            {
                StreamWriter sw = new StreamWriter(constream);
                sw.WriteLine("p " + video);
                try
                {
                    sw.Flush();
                }
                catch
                {
                    connected = false;
                    connectionStatusChanged(this, EventArgs.Empty);
                }
            }
        }

        public void getStatus()
        {
            if (connected)
            {
                StreamWriter sw = new StreamWriter(constream);
                sw.WriteLine("i");

                try
                {
                    sw.Flush();
                }
                catch
                {
                    connected = false;
                    connectionStatusChanged(this, EventArgs.Empty);
                }
            }
        }

        public void stopvid()
        {
            StreamWriter sw = new StreamWriter(constream);
            if (connected)
            {
                sw.WriteLine("s");

                try
                {
                    sw.Flush();
                }
                catch
                {
                    connected = false;
                    connectionStatusChanged(this, EventArgs.Empty);
                }
            }
        }

        public void listfiles()
        {
            StreamWriter sw = new StreamWriter(constream);
            if (connected)
            {
                sw.WriteLine("g");

                try
                {
                    sw.Flush();
                }
                catch
                {
                    connected = false;
                    connectionStatusChanged(this, EventArgs.Empty);
                }
            }
        }

        public PiVTControl(string host, int port)
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
                catch (Exception)
                {
                    //System.Windows.Forms.MessageBox.Show("Grr... Exception trying to connect to xine-net. " + ex.ToString());
                    //ok, it failed. Meh.

                }
                if (connection == null || !connection.Connected)
                {
                    //bugger. Not connected.
                    connected = false;
                    if (connectionStatusChanged != null)
                    {
                        connectionStatusChanged(this, EventArgs.Empty);
                    }
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
            if (readerthread != null)
            {
                readerthread.Abort();
            }
            if (constream != null)
            {
                constream.Close();
            }
            connected = false;
            if (connectionStatusChanged != null)
            {
                connectionStatusChanged(this, EventArgs.Empty);
            }
        }

        //handles messages starting with 200
        void handlestat(string msg)
        {
            string[] chunks = msg.Split(' ');
            switch (chunks[1].TrimEnd(','))
            {
                case "Playing":
                    playing = true;

                    currentvideo = chunks[2].TrimEnd(',');
                    chunks = msg.Split(',')[2].Split(' ');
                    lengthremaining = Convert.ToInt16(chunks[1]);
                    playerStatusChanged(this, EventArgs.Empty);
                    break;
                case "Stopped":
                    playing = false;
                    currentvideo = "";
                    playerStatusChanged(this, EventArgs.Empty);
                    break;
            }
        }

        //something to monitor the socket and read lines
        void linereader()
        {
            StreamReader sr = new StreamReader(constream);
            while(true) {
                string line = sr.ReadLine();
                string[] chunks;
                if (line != null)
                {
                    line = line.TrimStart('\0');
                    chunks = line.Split(' ');
                }
                else
                {
                    return;
                }
                responsecode = chunks[0];
                switch (chunks[0])
                {
                    case "Welcome":
                        break;
                    case "200":
                        handlestat(line);
                        break;
                    case "202":
                        playing = true;
                        currentvideo = chunks[2];
                        currentlength = Convert.ToInt16(chunks[3]);
                        lengthremaining = currentlength;
                        if (playerStatusChanged != null)
                        {
                            playerStatusChanged(this, EventArgs.Empty);
                        }
                        break;
                    case "204":
                        playing = false;
                        if (playerStatusChanged != null)
                        {
                            playerStatusChanged(this, EventArgs.Empty);
                        }
                        break;
                    case "205":
                        if ("205 File listing complete" == line)
                        {
                            if (fileUpdate != null)
                            {
                                fileUpdate(this, EventArgs.Empty, "", 0, true);
                            }
                        }
                        else
                        {
                            playing = true;
                            currentvideo = chunks[2];
                            currentlength = Convert.ToInt16(chunks[3]);
                            lengthremaining = Convert.ToInt16(chunks[3]);
                            if (playerStatusChanged != null)
                            {
                                playerStatusChanged(this, EventArgs.Empty);
                            }
                        }
                        break;
                    case "206":
                        string file = chunks[1];
                        int length = Convert.ToInt16(chunks[2]);

                        if (fileUpdate != null)
                        {
                            fileUpdate(this, EventArgs.Empty, file, length, false);
                        }
                        break;
                    case "404":
                        playing = false;
                        System.Windows.Forms.MessageBox.Show("Could not find " + chunks[2]);
                        if (playerStatusChanged != null)
                        {
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

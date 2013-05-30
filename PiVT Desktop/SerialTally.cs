using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
namespace PiVT_Desktop
{

    public delegate void ConnectStatusChange();
    public delegate void StatusChanged();

    class SerialTally
    {

        public event StatusChanged statusevt;
        System.IO.Ports.SerialPort serialport;
        string port = "com1";
        int[] status = new int[4];
        public SerialTally()
        {
            serialport = new System.IO.Ports.SerialPort();
            for (int i = 0; i < 4; i++)
            {
                status[i] = 0;
            }
        }

        ~SerialTally()
        {
            if (serialport.IsOpen)
                serialport.Close();
        }

        public void connect(string portname)
        {
            serialport.PortName = portname;
            serialport.BaudRate = 9600;
            serialport.Open();
            serialport.DataReceived += new SerialDataReceivedEventHandler(DataReceviedHandler);
            //send a character to get current status
            serialport.Write(" ");
        }

        public bool connected()
        {
            return serialport.IsOpen;
        }

        public void disconnect()
        {
            serialport.Close();
            serialport = new System.IO.Ports.SerialPort(); //ready for another connect
            statusevt(); //causes clients to re-check status to see it's disconnected.
        }

        public void connect()
        {
            connect(port);
        }

        public bool getTally(int num) {
            if(num > 4)
                return false;
            return (status[num - 1] == 1);
        }

        private void DataReceviedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();
            while (sp.BytesToRead > 0)
            {
                data += sp.ReadExisting();
            }
            for (int i = 0; i < data.Length; i++)
            {
                if(data[i] != '\n' && data[i] != '\r')
                    status[i] = int.Parse(data[i].ToString());
            }
            statusevt();
            //System.Windows.Forms.MessageBox.Show(status[0].ToString() + status[1].ToString() + status[2].ToString() + status[3].ToString());
        }

    }
}

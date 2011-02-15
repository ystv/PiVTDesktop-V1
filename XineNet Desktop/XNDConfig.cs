    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace XineNet_Desktop
{
    public class XNDConfig
    {
        public string serverhost = "ystvstrm3.york.ac.uk";
        public int serverport = 9815;
        XmlTextReader configreader;
        string configpath = "XNDConfig.xml";

        public XNDConfig()
        {
            try
            {
                configpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "YSTV", "XineNet Desktop");
                configreader = new XmlTextReader(Path.Combine(configpath,"XDNConfig.xml"));
                while (configreader.Read())
                {
                    switch (configreader.Name)
                    {
                        case "serverhost":
                            serverhost = configreader.ReadString();
                            break;
                        case "serverport":
                            serverport = int.Parse(configreader.ReadString());
                            break;
                    }
                }
                configreader.Close();
            } catch(System.IO.FileNotFoundException ex) {
                //our config file does not exist. Oops. Let's just use defaults.
                return;
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                //our config file does not exist. Oops. Let's just use defaults.
                return;
            }


        }

        ~XNDConfig()
        {
            if(!System.IO.Directory.Exists(configpath)) {
                System.IO.Directory.CreateDirectory(configpath);
            }

            XmlTextWriter configwriter = new XmlTextWriter(Path.Combine(configpath, "XDNConfig.xml"), null);
            configwriter.WriteStartDocument();
            configwriter.WriteStartElement("XNDConfig");
            configwriter.WriteStartElement("serverhost");
            configwriter.WriteString(serverhost);
            configwriter.WriteEndElement();
            configwriter.WriteStartElement("serverport");
            configwriter.WriteString(serverport.ToString());
            configwriter.WriteEndElement();
            configwriter.WriteEndElement();
            configwriter.WriteEndDocument();
            configwriter.Close();
        }

    }
}

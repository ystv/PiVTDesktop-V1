using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XineNet_Desktop
{
    class PlayListLoader
    {
        string plname;
        int needle; //used by  find
        XmlTextReader plreader;
        public List<PLItem> playlist;
        public PlayListLoader(string plname)
        {
            this.plname = plname;
            string name = "";
            int len = 0;
            playlist = new List<PLItem>();
            try
            {
                //either call with a file name, or with just the pl name. I havn't decided which yet.
                if (plname.EndsWith(".xml"))
                {
                    plreader = new XmlTextReader(plname);
                }
                else
                {
                    plreader = new XmlTextReader(plname + ".xml");
                }
                int count = 0;
                while (plreader.Read())
                {
                    switch (plreader.Name)
                    {
                        case "item":
                            if (!plreader.IsStartElement())
                            {
                                playlist.Add(new PLItem(name, len,count++));
                            }
                            else
                            {
                                name = "";
                                len = 0;

                            }
                            break;
                        case "filename":
                            name = plreader.ReadString();
                            break;
                        case "length":
                            len = int.Parse(plreader.ReadString());
                            break;
                    }
                }
                plreader.Close();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                //no file. OOps.
                System.Windows.Forms.MessageBox.Show("Playlist file " + plname + ".xml not found.");
                return;
            }
        }
        void addItem(PLItem item)
        {
            item.position = playlist.Count;
            playlist.Add(item);
        }
        ~PlayListLoader()
        {
            //write back to xml file in case of changes
            XmlTextWriter configwriter;
            if(plname.EndsWith(".xml"))
                configwriter = new XmlTextWriter(plname, null);
            else 
                configwriter = new XmlTextWriter(plname + ".xml", null);
            configwriter.WriteStartDocument();
            configwriter.WriteStartElement("playlist");
            foreach (PLItem pli in playlist)
            {
                configwriter.WriteStartElement("item");
                configwriter.WriteStartElement("filename");
                configwriter.WriteString(pli.getFilename());
                configwriter.WriteEndElement();
                configwriter.WriteStartElement("length");
                configwriter.WriteString(pli.getLength().ToString());
                configwriter.WriteEndElement();
                configwriter.WriteEndElement();
            }

            configwriter.WriteEndElement();
            configwriter.WriteEndDocument();
            configwriter.Close();
        }

        public void moveup(int pos)
        {
            if (pos > 0)
            {
                PLItem a = playlist.ElementAt(GetIndexByPosition(pos));
                PLItem b = playlist.ElementAt(GetIndexByPosition(pos-1));
                int holder = a.position;
                a.position = b.position;
                b.position = holder;
                playlist.Sort(comparebypos);
            }
        }

        public void movedown(int pos)
        {
            if (pos < playlist.Count-1)
            {
                PLItem a = playlist.ElementAt(GetIndexByPosition(pos));
                PLItem b = playlist.ElementAt(GetIndexByPosition(pos + 1));
                int holder = a.position;
                a.position = b.position;
                b.position = holder;
                playlist.Sort(comparebypos);
            }
        }

        private static int comparebypos(PLItem a, PLItem b)
        {
            if (b.position > a.position)
                return -1;
            else if (a.position > b.position)
                return 1;
            else
                return 0;
        }

        int GetIndexByPosition(int pos)
        {
            needle = pos;
            int res = playlist.FindIndex(matchespos);
            return res;
        }
        private bool matchespos(PLItem p)
        {
            return p.position == needle;
        }
    }
}

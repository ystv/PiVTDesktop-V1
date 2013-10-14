using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiVT_Desktop
{
    public class PLItem
    {
        string filename;
        int length;
        public int position;
        public PLItem(string file, int length, int pos = 0)
        {
            this.filename = file;
            this.length = length;
            this.position = pos;
        }

        public string getFilename()
        {
            return filename;
        }
        public int getLength()
        {
            return length;
        }
        public int updateLength(int newlen)
        {
            return length = newlen;
        }
    }
}

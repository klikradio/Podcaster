using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KLIK.Business
{
    class KLIKCommandWriteFile : IKLIKCommand
    {
        public string strPath;
        public string strContents;

        public KLIKCommandWriteFile() { }

        public KLIKCommandWriteFile(string strPath, string strContents)
        {
            this.strPath = strPath;
            this.strContents = strContents;
        }

        public void RunCommand()
        {
            StreamWriter sw = new StreamWriter(strPath);
            sw.Write(strContents);
            sw.Close();
        }
    }
}

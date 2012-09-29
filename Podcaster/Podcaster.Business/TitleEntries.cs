using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Podcaster.Core;

namespace Podcaster.Business
{
    public class TitleEntries : List<SongPlayed>
    {
        /// <summary>
        /// Convert this into an XML file that our podcast rerun monitor will read
        /// </summary>
        /// <param name="strFilePath">File path to save to</param>
        public void SaveXMLFile(string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath);

            sw.WriteLine("<KLIK>");
            foreach (SongPlayed te in this)
            {
                sw.WriteLine("<Song time=\"" + te.TimeFromBeginning.ToString() + "\" artist=\"" + te.Artist + "\" title=\"" + te.Title + "\" />");
            }
            sw.WriteLine("</KLIK>");
            sw.Close();
        }
    }
}

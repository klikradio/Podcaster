using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

using Podcaster.Utilities;

namespace Podcaster.Core
{
    /// <summary>
    /// Represents a podcast episode
    /// </summary>
    public abstract class PodcastInfo
    {
        /// <summary>
        /// The show this podcast will belong to
        /// </summary>
        public ShowInfo kShow;
        /// <summary>
        /// Title of this episode in the feed
        /// </summary>
        public string strTitle;
        /// <summary>
        /// Description of the episode in the feed
        /// </summary>
        public string strDescription;
        /// <summary>
        /// DateTime that this show started
        /// </summary>
        public DateTime dStarted;
        /// <summary>
        /// DateTime that this show ended
        /// </summary>
        public DateTime dEnded;

        /// <summary>
        /// Parse variables for a variety of needs
        /// </summary>
        /// <param name="strString">String to parse</param>
        /// <returns>Parsed string</returns>
        public string ParseVariables(string strString)
        {
            return ParseVariables(strString, false);
        }

        /// <summary>
        /// Parse variables for a variety of needs
        /// </summary>
        /// <param name="strFileName">String to parse</param>
        /// <returns>Parsed string</returns>
        public string ParseVariables(string strFileName, bool bFileName)
        {
            if (bFileName)
            {
                strFileName = strFileName.Replace("%s", PodcasterUtilities.MakeSafeFileName(kShow.strName));
                strFileName = strFileName.Replace("%t", PodcasterUtilities.MakeSafeFileName(strTitle));
            }
            else
            {
                strFileName = strFileName.Replace("%s", kShow.strName);
                strFileName = strFileName.Replace("%t", strTitle);
            }
            strFileName = strFileName.Replace("%i", kShow.nID.ToString());
            strFileName = strFileName.Replace("%y", DateTime.Now.Year.ToString());
            strFileName = strFileName.Replace("%m", DateTime.Now.Month.ToString());
            strFileName = strFileName.Replace("%d", DateTime.Now.Day.ToString());
            strFileName = strFileName.Replace("%c", DateTime.Now.DayOfYear.ToString());
            strFileName = strFileName.Replace("%h", DateTime.Now.Hour.ToString());
            strFileName = strFileName.Replace("%n", DateTime.Now.Minute.ToString());
            strFileName = strFileName.Replace("%x", DateTime.Now.Second.ToString());

            return strFileName;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podcaster.Business
{
    /// <summary>
    /// Represents a single listener. (Deprecated, soon to be deleted.)
    /// </summary>
    public class KLIKListener
    {
        public string IPAddress = "";
        public string UserAgent = "";
        public int SecondsConnected = 0;
        public int ServerID = 0;
        public DateTime TuneInTime;

        /// <summary>
        /// Is the given KLIKListener equal to this listener?
        /// </summary>
        /// <param name="that">The listener to check</param>
        /// <returns>True if equal, false if not</returns>
        public bool Equals(KLIKListener that)
        {
            return (this.IPAddress.Equals(that.IPAddress) &&
                    this.UserAgent.Equals(that.UserAgent));
        }

        /// <summary>
        /// Converts a KLIKListener to a fairly nice string
        /// </summary>
        /// <returns>A formatted string</returns>
        public override string ToString()
        {
            return IPAddress + " (" + UserAgent + ") - " + SecondsConnected.ToString() + " seconds since " + TuneInTime.ToLongTimeString() + " - " + ServerID.ToString();
        }
    }
}

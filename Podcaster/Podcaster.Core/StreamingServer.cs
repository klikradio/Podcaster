using System;
using Podcaster.Utilities;

namespace Podcaster.Core
{
    [Serializable]
    public abstract class StreamingServer
    {
        /// <summary>
        /// Server host name
        /// </summary>
        public string strHostname;
        /// <summary>
        /// Server port number
        /// </summary>
        public int nPort;
        /// <summary>
        /// Administrative username
        /// </summary>
        public string strUsername;
        /// <summary>
        /// Administrative password
        /// </summary>
        public string strPassword;

        /// <summary>
        /// Update a song on this server
        /// </summary>
        /// <param name="strArtist">Artist of the song</param>
        /// <param name="strTitle">Title of the song</param>
        public abstract void UpdateSong(string strArtist, string strTitle);
    }
}

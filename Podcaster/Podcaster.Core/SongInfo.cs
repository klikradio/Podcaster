using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podcaster.Core
{
    public class SongInfo
    {
        /// <summary>
        /// Artist of song at this time index
        /// </summary>
        public readonly string Artist;

        /// <summary>
        /// Title of song at this time index
        /// </summary>
        public readonly string Title;

        /// <summary>
        /// The source of this song entry (e.g. radio automation software, user input, plug-in, etc.)
        /// </summary>
        public readonly string strSource;

        /// <summary>
        /// Create a SongInfo class
        /// </summary>
        /// <param name="strArtist">Artist of the song</param>
        /// <param name="strTitle">Title of the song</param>
        public SongInfo(string strArtist, string strTitle)
        {
            this.Artist = strArtist;
            this.Title = strTitle;
        }

        /// <summary>
        /// Create a SongInfo class
        /// </summary>
        /// <param name="strArtist">Artist of the song</param>
        /// <param name="strTitle">Title of the song</param>
        /// <param name="strSource">Source of the song data</param>
        public SongInfo(string strArtist, string strTitle, string strSource)
            : this(strArtist, strTitle)
        {
            this.strSource = strSource;
        }
    }
}

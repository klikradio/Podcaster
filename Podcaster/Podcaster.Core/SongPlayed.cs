using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Podcaster.Core
{
    public class SongPlayed : SongInfo
    {
        /// <summary>
        /// Number of seconds from beginning of podcast
        /// </summary>
        public readonly double TimeFromBeginning;

        /// <summary>
        /// Construct a KLIKTitleEntry
        /// </summary>
        /// <param name="kp">Podcast this song is being played in</param>
        /// <param name="TimeStarted">Time the song started</param>
        /// <param name="strArtist">Artist</param>
        /// <param name="strTitle">Title</param>
        /// <param name="strSource">Source of this song entry</param>
        public SongPlayed(PodcastInfo kp, DateTime TimeStarted, string strArtist, string strTitle, string strSource) : base(strArtist, strTitle, strSource)
        {
            TimeFromBeginning = TimeStarted.Subtract(kp.dStarted).TotalSeconds;
        }

        /// <summary>
        /// Construct a SongPlayed
        /// </summary>
        /// <param name="kp">Podcast this song was played in</param>
        /// <param name="TimeStarted">Time this song was played</param>
        /// <param name="si">Song info for the song that was played</param>
        public SongPlayed(PodcastInfo kp, DateTime TimeStarted, SongInfo si) : this(kp, TimeStarted, si.Artist, si.Title, si.strSource) { }
    }
}

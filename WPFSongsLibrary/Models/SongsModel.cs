using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSongsLibrary.Models
{
    /// <summary>
    /// Model for Songs. Domain Object
    /// </summary>
    public class SongsModel
    {

        #region Propertie(s)

        /// <summary>
        /// Gets or sets the song title.
        /// </summary>
        /// <value>
        /// The song title.
        /// </value>
        public string SongTitle
        {
            get { return songTitle; }
            set { songTitle = value; }
        }

        /// <summary>
        /// Gets or sets the name of the artist.
        /// </summary>
        /// <value>
        /// The name of the artist.
        /// </value>
        public string ArtistName
        {
            get { return artistName; }
            set { artistName = value; }
        }

        #endregion

        #region Field(s)        
        /// <summary>
        /// The song title
        /// </summary>
        private string songTitle;

        /// <summary>
        /// The artist name
        /// </summary>
        private string artistName;
        #endregion

    }
}

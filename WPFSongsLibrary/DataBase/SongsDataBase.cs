using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSongsLibrary.DataBase
{
    /// <summary>
    /// Collection of Songs
    /// </summary>
    public class SongsDataBase
    {
        #region Members
        Random _random = new Random();
        string[] _artists = { "Metallica", "Elvis Presley", "Madonna", "The Beatles", "The Rolling Stones", "Abba" };
        string[] _songTitles = { "Islands in the Stream", "Imagine", "Living on a Prayer", "Enter Sandman", "A Little Less Conversation", "Wonderful World" };
        #endregion

        #region Properties        
        /// <summary>
        /// Gets the name of the get random artist.
        /// </summary>
        /// <value>
        /// The name of the get random artist.
        /// </value>
        public string GetRandomArtistName
        {
            get
            {
                return _artists[_random.Next(_artists.Length)];
            }
        }

        /// <summary>
        /// Gets the get random song title.
        /// </summary>
        /// <value>
        /// The get random song title.
        /// </value>
        public string GetRandomSongTitle
        {
            get
            {
                return _songTitles[_random.Next(_songTitles.Length)];
            }
        }
        #endregion
    }

}

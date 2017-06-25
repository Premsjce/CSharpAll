using System.Collections.ObjectModel;
using System.Windows.Input;
using WPFSongsLibrary.Commands;
using WPFSongsLibrary.DataBase;
using WPFSongsLibrary.Models;

namespace WPFSongsLibrary.ViewModels
{
    /// <summary>
    /// Vide model for Songs
    /// </summary>
    /// <seealso cref="WPFSongsLibrary.ViewModels.BaseViewModel" />
    public class SongsViewModel : BaseViewModel
    {
        #region Constructor(s)        
        /// <summary>
        /// Initializes a new instance of the <see cref="SongsViewModel"/> class.
        /// </summary>
        public SongsViewModel()
        {
            sdb = new SongsDataBase();
            _songs = new ObservableCollection<SongsModel>();
            //Initializing some data
            for(int i = 0; i < 5; i++)
            {
                sm = new SongsModel();
                sm.ArtistName = sdb.GetRandomArtistName;
                sm.SongTitle = sdb.GetRandomSongTitle;
                _songs.Add(sm);
            }           
                        
        }
        #endregion

        #region Private Mehod(s)              
        /// <summary>
        /// Determines whether this instance [can update artist button be clicked].
        /// </summary>
        /// <returns></returns>
        private bool CanAddArtistButtonBeClicked()
        {
            return true;
        }

        /// <summary>
        /// Called when [update artist button clicked].
        /// </summary>
        private void OnAddArtistButtonClicked()
        {
            sm = new SongsModel();
            sm.ArtistName = sdb.GetRandomArtistName;
            sm.SongTitle = sdb.GetRandomSongTitle;
            _songs.Add(sm);
        }

        /// <summary>
        /// Determines whether this instance [can update album artists clicked].
        /// </summary>
        /// <returns></returns>
        private bool CanUpdateAlbumArtistsBeClicked()
        {
            return true;
        }

        /// <summary>
        /// Called when [update album artists clicked].
        /// </summary>
        private void OnUpdateAlbumArtistsClicked()
        {
            if (_songs == null)
            {
                return;
            }

            foreach (var song in _songs)
            {
                song.ArtistName = sdb.GetRandomArtistName;
            }
                
        }


        /// <summary>
        /// Determines whether this instance [can update songs title be clicked].
        /// </summary>
        private bool CanUpdateSongsTitleBeClicked()
        {
            return true;
        }


        /// <summary>
        /// Updates the songs title clicked.
        /// </summary>
        private void UpdateSongsTitleClicked()
        {
            if (_songs == null)
                return;

            foreach (var song in _songs)
            {
                song.SongTitle = sdb.GetRandomSongTitle;
            }
        }

        #endregion

        #region Propertie(s)        
        /// <summary>
        /// Gets or sets the name of the artist.
        /// </summary>
        /// <value>
        /// The name of the artist.
        /// </value>
        public string ArtistName
        {
            get
            {
                return artistname;
            }
            set
            {
                artistname = value;
                RaisePropertyChanged(Constants.ArtistName);
            }
        }

        /// <summary>
        /// Gets or sets the song title.
        /// </summary>
        /// <value>
        /// The song title.
        /// </value>
        public string SongTitle
        {
            get
            {
                return songTitle;
            }
            set
            {
                songTitle = value;
                RaisePropertyChanged(Constants.SongTitle);
            }
        }

        /// <summary>
        /// Gets or sets the name of the update artist.
        /// </summary>
        /// <value>
        /// The name of the update artist.
        /// </value>
        public ICommand AddAlbumArtist
        {
            get
            {
                return new RelayCommand(OnAddArtistButtonClicked, CanAddArtistButtonBeClicked);
            }
        }

        public ICommand UpdateAlbumArtists
        {
            get
            {
                return new RelayCommand(OnUpdateAlbumArtistsClicked, CanUpdateAlbumArtistsBeClicked);
            }
        }

        /// <summary>
        /// Gets the update song titles.
        /// </summary>
        /// <value>
        /// The update song titles.
        /// </value>
        public ICommand UpdateSongTitles
        {
            get
            {
                return new RelayCommand(UpdateSongsTitleClicked, CanUpdateSongsTitleBeClicked);
            }
        }


        /// <summary>
        /// Gets or sets the songs.
        /// </summary>
        /// <value>
        /// The songs.
        /// </value>
        public ObservableCollection<SongsModel> Songs
        {
            get
            {
                return _songs;
            }
            set
            {
                _songs = value;
                
            }
        }

        #endregion

        #region Field(s)                
        /// <summary>
        /// The songs
        /// </summary>
        private SongsModel songs;


        /// <summary>
        /// The artistname
        /// </summary>
        private string artistname;

        /// <summary>
        /// The song title
        /// </summary>
        private string songTitle;

        /// <summary>
        /// The _songs
        /// </summary>
        private ObservableCollection<SongsModel> _songs;

        /// <summary>
        /// songs data base
        /// </summary>
        private SongsDataBase sdb;

        /// <summary>
        /// songs model
        /// </summary>
        private SongsModel sm;

        #endregion

    }
}

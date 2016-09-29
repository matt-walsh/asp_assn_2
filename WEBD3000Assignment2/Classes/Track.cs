using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBD3000Assignment2
{
    public class Track
    {
        private int trackId;
        private string trackName;
        private string albumName;
        private string artist;
        private string genre;
        private int milliseconds;
        private int bytes;
        private string mediaType;
        private int popularity;
        private double price;

        #region Properties

        public string TrackName
        {
            get { return trackName; }
            set { trackName = value; }
        }

        public string AlbumName
        {
            get { return albumName; }
            set { albumName = value; }
        }

        public string Artist
        {
            get { return artist; }
            set { artist = value; }
        }

        public string Genre
        {
            get { return genre; }
            set { genre = value; }
        }

        public int Milliseconds
        {
            get { return milliseconds; }
            set { milliseconds = value; }
        }

        public int Bytes
        {
            get { return bytes; }
            set { bytes = value; }
        }

        public string MediaType
        {
            get { return mediaType; }
            set { mediaType = value; }
        }

        public int Popularity
        {
            get { return popularity; }
            set { popularity = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        #endregion

        #region Constructor

        public Track(int trackId, string trackName, string albumName, string artist, string genre,
                    int milliseconds, int bytes, string mediaType, int popularity, double price)
        {
            this.trackId = trackId;
            this.trackName = trackName;
            this.albumName = albumName;
            this.artist = artist;
            this.genre = genre;
            this.milliseconds = milliseconds;
            this.bytes = bytes;
            this.mediaType = mediaType;
            this.popularity = popularity;
            this.price = price;
        }

        #endregion

        public int GetTrackId()
        {
            return this.trackId;
        }
    }
}
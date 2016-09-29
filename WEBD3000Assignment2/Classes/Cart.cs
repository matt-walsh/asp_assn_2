using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBD3000Assignment2
{
    public class Cart
    {
        private List<Track> trackList;

        #region Constructor

        public Cart()
        {
            this.trackList = new List<Track>();
        }

        #endregion

        #region CRUD
        public List<Track> SelectTracks()
        {
            return this.trackList;
        }

        public Track SelectTrack(int trackId)
        {
            return null;
        }

        public void InsertTrack(Track track)
        {
            bool duplicate = false;

            foreach (Track userTrack in trackList)
            {
                if (userTrack.TrackName == track.TrackName)
                {
                    duplicate = true;
                }
            }

            if (!duplicate)
            {
                this.trackList.Add(track);
            }
        }

        public void UpdateTrack(Track track)
        {

        }

        public void DeleteTrack(int listId)
        {
            this.trackList.RemoveAt(listId);
        }
        #endregion

        #region Helpers

        public double CalculateSubTotal()
        {
            double subtotal = 0;
            foreach (Track track in trackList)
            {
                subtotal += track.Price;
            }

            return subtotal;
        }

        public double CalculateTax()
        {
            double tax = 0;
            tax = CalculateSubTotal() * 0.15;
            return tax;
        }

        public double CalculateTotal()
        {
            double total = 0;
            total = CalculateSubTotal() + CalculateTax();
            return total;
        }

        #endregion
    }
}
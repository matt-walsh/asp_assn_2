using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Threading;

namespace WEBD3000Assignment2
{
    /// <summary>
    /// Summary description for PopularityTracker
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class PopularityTracker : System.Web.Services.WebService
    {
        private SqlConnection chinookDatabaseConnection;
        #region Database Methods
        private void ConnectToDatabase()
        {
            chinookDatabaseConnection = new SqlConnection("Data Source=WIN-OA9TV4LURBG\\SQLEXPRESS;Initial Catalog=Chinook;Integrated Security=True;Asynchronous Processing=true");
        }
        #endregion

        #region Vote Casting Metohds
        [WebMethod]
        public void VoteFor(int trackId)
        {
            if (this.chinookDatabaseConnection == null)
            {
                this.ConnectToDatabase();
            }

            chinookDatabaseConnection.Open();
            SqlParameter trackIdParam = new SqlParameter("@TrackId", SqlDbType.Int);
            trackIdParam.Value = trackId;

            SqlCommand sqlQueryToExecute = new SqlCommand("UPDATE Track SET Popularity = Popularity + 1 WHERE TrackId = " + trackId, chinookDatabaseConnection);
            
            sqlQueryToExecute.BeginExecuteNonQuery();

            Thread.Sleep(1000);
            chinookDatabaseConnection.Close();

        }

        [WebMethod]
        public void VoteAgainst(int trackId)
        {
            if (this.chinookDatabaseConnection == null)
            {
                this.ConnectToDatabase();
            }

            chinookDatabaseConnection.Open();
            SqlParameter trackIdParam = new SqlParameter("@TrackId", SqlDbType.Int);
            trackIdParam.Value = trackId;

            if (this.chinookDatabaseConnection == null)
            {
                this.ConnectToDatabase();
            }

            SqlCommand sqlQueryToExecute = new SqlCommand("UPDATE Track SET Popularity = Popularity - 1 WHERE TrackId = " + trackId, chinookDatabaseConnection);

            sqlQueryToExecute.BeginExecuteNonQuery();

            Thread.Sleep(1000);
            chinookDatabaseConnection.Close();
        }
        #endregion

        #region Vote Tracking Methods
        [WebMethod]
        public int GetTrackVotes(int trackId)
        {
            int totalPopularity = 0;

            if (this.chinookDatabaseConnection == null)
            {
                this.ConnectToDatabase();
            }

            chinookDatabaseConnection.Open();
            int trackIdParam = trackId;

            SqlCommand sqlQueryToExecute = new SqlCommand("SELECT Popularity FROM Track WHERE TrackId=" + trackId, chinookDatabaseConnection);
            IAsyncResult asyncResults = sqlQueryToExecute.BeginExecuteReader();
            SqlDataReader dataReader = sqlQueryToExecute.EndExecuteReader(asyncResults);
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    totalPopularity += (int)dataReader.GetInt32(0);
                }
            }

            Thread.Sleep(1000);
            chinookDatabaseConnection.Close();

            return totalPopularity;
        }

        [WebMethod]
        public int GetAlbumVotes(int albumId)
        {
            int totalPopularity = 0;

            if (this.chinookDatabaseConnection == null)
            {
                this.ConnectToDatabase();
            }

            chinookDatabaseConnection.Open();
            int albumIdParam = albumId;

            SqlCommand sqlQueryToExecute = new SqlCommand("SELECT Popularity FROM Track WHERE AlbumId=" + albumIdParam, chinookDatabaseConnection);
            IAsyncResult asyncResults = sqlQueryToExecute.BeginExecuteReader();
            SqlDataReader dataReader = sqlQueryToExecute.EndExecuteReader(asyncResults);
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    totalPopularity += (int)dataReader.GetInt32(0);
                }
            }

            Thread.Sleep(1000);
            chinookDatabaseConnection.Close();
            return totalPopularity;
        }

        [WebMethod]
        public int GetArtistVotes(int artistId)
        {
            int totalPopularity = 0;

            if (this.chinookDatabaseConnection == null)
            {
                this.ConnectToDatabase();
            }

            chinookDatabaseConnection.Open();
            int albumIdParam = artistId;

            SqlCommand sqlQueryToExecute = new SqlCommand("SELECT Track.Popularity FROM Track INNER JOIN  Album ON Track.AlbumId = Album.AlbumId INNER JOIN " +
                                                          "Artist ON Album.ArtistId = Artist.ArtistId WHERE Album.ArtistId = " + 
                                                          albumIdParam, chinookDatabaseConnection);
            IAsyncResult asyncResults = sqlQueryToExecute.BeginExecuteReader();
            SqlDataReader dataReader = sqlQueryToExecute.EndExecuteReader(asyncResults);
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    totalPopularity += (int)dataReader.GetInt32(0);
                }
            }

            Thread.Sleep(1000);
            chinookDatabaseConnection.Close();
            return totalPopularity;
        }

        [WebMethod]
        public int GetGenreVotes(int genreId)
        {
            int totalPopularity = 0;

            if (this.chinookDatabaseConnection == null)
            {
                this.ConnectToDatabase();
            }

            chinookDatabaseConnection.Open();
            int genreIdParam = genreId;

            SqlCommand sqlQueryToExecute = new SqlCommand("SELECT Popularity FROM Track WHERE GenreId=" + genreIdParam, chinookDatabaseConnection);
            IAsyncResult asyncResults = sqlQueryToExecute.BeginExecuteReader();
            SqlDataReader dataReader = sqlQueryToExecute.EndExecuteReader(asyncResults);
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    totalPopularity += (int)dataReader.GetInt32(0);
                }
            }

            Thread.Sleep(1000);
            chinookDatabaseConnection.Close();
            return totalPopularity;
        }
        #endregion


    }
}

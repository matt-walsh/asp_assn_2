using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ValueAddedComponents;

namespace WEBD3000Assignment2.WebPages
{
    public partial class cart : System.Web.UI.Page
    {
        Cart userCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["sessionCart"] != null)
            {
                userCart = (Cart)Session["sessionCart"];
            }
            else
            {
                userCart = new Cart();
            }

            UpdatePage();

        }

        protected void shoppingCartGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int listId = this.shoppingCartGridView.SelectedRow.DataItemIndex;

            if (Session["sessionCart"] != null)
            {
                userCart = (Cart)Session["sessionCart"];
            }
            else
            {
                userCart = new Cart();
            }

            //Delete the selected track
            userCart.DeleteTrack(listId);

            //Save cart back to session
            Session["sessionCart"] = userCart;

            UpdatePage();

        }

        private void UpdatePage()
        {
            //Calculate Totals
            this.subtotalLabel.Text = userCart.CalculateSubTotal().ToString("C");
            this.taxLabel.Text = userCart.CalculateTax().ToString("C");
            this.totalLabel.Text = userCart.CalculateTotal().ToString("C");

            //Bind cart data to grid view
            this.shoppingCartGridView.DataSource = userCart.SelectTracks();
            this.shoppingCartGridView.DataBind();
        }

        protected void downloadButton_Click(object sender, EventArgs e)
        {
            List<Results> results = new List<Results>();

            if (Session["sessionCart"] != null)
            {
                userCart = (Cart)Session["sessionCart"];
            }
            else
            {
                userCart = new Cart();
            }

            //Add header row to results list
            string row = "|    TRACK ID    |    TRACK NAME    |   ALBUM NAME   |    ARTIST   |   GENRE  |   MILLISECONDS   |    BYTES   |" +
                         "    MEDIA TYPE    |     POPULARITY    |     PRICE     |";
            results.Add(new Results(row));

            //add each track to results list
            foreach (Track track in userCart.SelectTracks())
            {
                row = "|    " + track.GetTrackId() + "    |    " + track.TrackName + "    |   " + track.AlbumName + "   |    " + track.Artist + "   |   " + track.Genre + "  |   " +
                        track.Milliseconds + "   |    " + track.Bytes + "   |    " + track.MediaType + "    |     " + track.Popularity + "    |     " + track.Price + "     |";

                results.Add(new Results(row));
            }
            results.Add(new Results("Sub-Total: " + userCart.CalculateSubTotal().ToString("C")));
            results.Add(new Results("Total Tax: " + userCart.CalculateTax().ToString("C")));
            results.Add(new Results("Total: " + userCart.CalculateTotal().ToString("C")));
            //Write to new file
            ManageResults downloadResults = new ManageResults("c:\\Test");
            downloadResults.WriteOutput(results);
        }

        protected void uploadButton_Click(object sender, EventArgs e)
        {
            ManageResults uploadResults = new ManageResults("c:\\Test");
            

            Cart loadedCart = new Cart();

            foreach (Results result in uploadResults.ReadOutput())
            {
                //Ignore the header line
                if (!result.Line.StartsWith("|TRACK"))
                {
                    string[] trackInfo = result.Line.Split('|');

                    //ignore the total lines
                    if (trackInfo.Length > 1)
                    {
                        //Load track into cart
                        int trackId = int.Parse(trackInfo[1]);
                        string trackName = trackInfo[2];
                        string albumName = trackInfo[3];
                        string artistName = trackInfo[4];
                        string genre = trackInfo[5];
                        int milliseconds = int.Parse(trackInfo[6]);
                        int bytes = int.Parse(trackInfo[7]);
                        string mediaType = trackInfo[8];
                        int popularity = int.Parse(trackInfo[9]);
                        double price = double.Parse(trackInfo[10]);

                        Track newTrack = new Track(trackId, trackName, albumName,artistName,genre,milliseconds,bytes,mediaType,popularity,price);
                        loadedCart.InsertTrack(newTrack);
                    }  
                }
            }

            //Save the new cart
            Session["sessionCart"] = loadedCart;
            this.userCart = loadedCart;

            //update page
            UpdatePage();

        }


    }
}
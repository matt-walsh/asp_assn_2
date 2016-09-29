using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBD3000Assignment2.WebPages
{
    public partial class Tracks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void trackListView_SelectedIndexChanged(object sender, EventArgs e)
        {            
            //Retreive Track info and store in track object
            GridViewRow selectedTrack = this.trackListView.SelectedRow;

            string trackName = selectedTrack.Cells[0].Text;
            string albumName = selectedTrack.Cells[1].Text;
            string artist = selectedTrack.Cells[2].Text;
            string genre = selectedTrack.Cells[3].Text;
            string composer = selectedTrack.Cells[4].Text;
            int miliseconds = int.Parse(selectedTrack.Cells[5].Text);
            int bytes = int.Parse(selectedTrack.Cells[6].Text);
            string mediaType = selectedTrack.Cells[7].Text;
            int popularity = int.Parse(selectedTrack.Cells[8].Text);
            double price = double.Parse(selectedTrack.Cells[9].Text);

            //Get index of selected track
            int trackId = selectedTrack.DataItemIndex;

            Track trackToAdd = new Track(trackId, trackName, albumName, artist, genre, miliseconds, bytes, mediaType, popularity, price);

            //Add the track to the cart object
            Cart tempCart;

            //Detect if cart has been initialized yet or not
            if (Session["sessionCart"] != null)
            {
                tempCart = (Cart)Session["sessionCart"];
            }
            else
            {
                tempCart = new Cart();
            }

            tempCart.InsertTrack(trackToAdd);

            //Save cart back to session
            Session["sessionCart"] = tempCart;

            //Redirect to Cart page
            Response.Redirect("CartPage.aspx");
        }
    }
}
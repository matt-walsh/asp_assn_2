using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBD3000Assignment2.PopularityService;

namespace WEBD3000Assignment2.WebPages
{
    public partial class PopularityPage : System.Web.UI.Page
    {
        PopularityTrackerSoapClient popularityStats;

        protected void Page_Load(object sender, EventArgs e)
        {
            popularityStats = new PopularityTrackerSoapClient();
        }

        protected void albumDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.titleLabel.Text = "Album: " + this.albumDropDown.SelectedItem;
            this.popularityLabel.Text ="Popularity: " + popularityStats.GetAlbumVotes(int.Parse(this.albumDropDown.SelectedValue));
        }

        protected void artistDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.titleLabel.Text = "Artist: " + this.artistDropDown.SelectedItem;
            this.popularityLabel.Text ="Popularity: " + popularityStats.GetArtistVotes(int.Parse(this.artistDropDown.SelectedValue));        
}

        protected void genreDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.titleLabel.Text = "Genre: " + this.genreDropDown.SelectedItem;
            this.popularityLabel.Text ="Popularity: " + popularityStats.GetGenreVotes(int.Parse(this.genreDropDown.SelectedValue));
        }
    }
}
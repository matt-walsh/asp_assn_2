using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WEBD3000Assignment2.PopularityService;

namespace WEBD3000Assignment2.WebPages
{
    public partial class VotePage : System.Web.UI.Page
    {
        string trackId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.voteDetailsView.SelectedValue != null)
            {
                trackId = this.voteDetailsView.SelectedValue.ToString();
            }
        }

        protected void voteUpButton_Click(object sender, EventArgs e)
        {
            PopularityTrackerSoapClient popTrack = new PopularityTrackerSoapClient();

            popTrack.VoteFor(int.Parse(trackId));

            Response.Redirect("TracksPage.aspx");

        }

        protected void voteDownButton_Click(object sender, EventArgs e)
        {
            PopularityTrackerSoapClient popTrack = new PopularityTrackerSoapClient();

            popTrack.VoteAgainst(int.Parse(trackId));
        }
    }
}
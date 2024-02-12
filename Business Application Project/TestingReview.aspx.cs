using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Business_Application_Project
{
    public partial class TestingReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Call method to populate rental history data
                PopulateRentalHistory();
            }
        }

        protected void PopulateRentalHistory()
        {
            // Retrieve rental history data from the database
            string userEmail = ((User)Session["CurrentUser"]).Email;
            DataTable rentalHistory = RatingReview.GetRentalHistory(userEmail);

            // Bind the data to the Repeater control
            rptHistory.DataSource = rentalHistory;
            rptHistory.DataBind();
        }

        protected void RateButton_Command(object sender, CommandEventArgs e)
        {
            // Get the bike ID from the command argument
            string bikeId = e.CommandArgument.ToString();

            // Redirect to the appropriate page based on whether the user has reviewed the bike
            Response.Redirect(RatingReview.HasUserReviewed(((User)Session["CurrentUser"]).Email, bikeId) ?
                $"EditReview.aspx?bikeId={bikeId}" :
                $"RateForm.aspx?bikeId={bikeId}");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btnView = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnView.NamingContainer;
            HiddenField hfBikeId = (HiddenField)item.FindControl("hf_BikeId");
            string bikeId = hfBikeId.Value;

            Response.Redirect($"ProductDetails.aspx?ProdId={bikeId}");
        }




    }
}


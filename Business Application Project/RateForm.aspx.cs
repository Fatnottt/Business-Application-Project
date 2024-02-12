using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Business_Application_Project
{
    public partial class RateForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the updated review data
            string userEmail = ((User)Session["CurrentUser"]).Email;
            string starsValue = hdRating.Value;
            int stars;
            if (!int.TryParse(starsValue, out stars))
            {
                // Stars value is not valid
                return;
            }

            string comment = txtComment.Text;
            string bikeId = Request.QueryString["bikeId"]; // Get the bike ID from the query string

            // Save rating to database
            RatingReview.SaveRatingToDatabase(userEmail, stars, comment, bikeId);

            // Update the review status for the current user
            RatingReview.UpdateHasReviewedStatus(userEmail, bikeId);

            // Redirect to ReviewsNav page
            Response.Redirect("TestingReview.aspx");
        }







        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestingReview.aspx");
        }
    }
}
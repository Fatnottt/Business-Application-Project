using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class ReviewsNav : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Assuming you have a hardcoded bike ID
            string bikeId = "11"; // Replace with your actual bike ID
            string userEmail = "yatsleo@gmail.com"; // Replace with actual user email

            // Check if the user has reviewed the bike
            bool userHasReviewed = RatingReview.HasUserReviewed(userEmail, bikeId);

            // Create a button for viewing the bike
            Button btnViewBike = new Button();
            btnViewBike.ID = "btnViewBike_" + bikeId;
            btnViewBike.Text = "View Bike";
            btnViewBike.Click += (s, args) => ViewBikeButtonClick(bikeId);

            // Create a button for the bike
            Button btn = new Button();
            btn.ID = "btnRate_" + bikeId;
            btn.Text = userHasReviewed ? "Edit Review" : "Rate";
            btn.Click += (s, args) => RateButtonClick(bikeId, userHasReviewed);

            // Clear existing controls in the placeholder
            phBikeButtons.Controls.Clear();

            // Add the buttons to your UI (e.g., to the placeholder)
            phBikeButtons.Controls.Add(btn);
            phBikeButtons.Controls.Add(btnViewBike);
        }

        private void RateButtonClick(string bikeId, bool userHasReviewed)
        {
            if (userHasReviewed)
            {
                // Redirect to EditReview.aspx for editing the review
                Response.Redirect($"EditReview.aspx?bikeId={bikeId}");
            }
            else
            {
                // Redirect to RateForm.aspx for rating
                Response.Redirect($"RateForm.aspx?bikeId={bikeId}");
            }
        }

        private void ViewBikeButtonClick(string bikeId)
        {
            // Redirect to the bike details page
            Response.Redirect($"ProductDetails.aspx?ProdID={bikeId}");
        }

    }
}
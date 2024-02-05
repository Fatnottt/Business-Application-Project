﻿using System;
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
            string bikeId = "11"; // Replace with your actual bike ID
            string userEmail = "yatsleo@gmail.com"; // Replace with actual user email

            // Check if the user has reviewed the bike
            bool userHasReviewed = RatingReview.HasUserReviewed(userEmail, bikeId);

            // Create a button for the bike
            Button btn = new Button();
            btn.ID = "btnRate_" + bikeId;
            btn.Text = userHasReviewed ? "Edit Review" : "Rate";
            btn.Click += (s, args) => RateButtonClick(bikeId, userHasReviewed);

            // Add the button to your UI (e.g., to a placeholder)
            phBikeButtons.Controls.Add(btn);
        }

        protected void RateButtonClick(string bikeId, bool userHasReviewed)
        {
            if (userHasReviewed)
            {
                // User has already reviewed, redirect to edit review page
                Response.Redirect("EditReview.aspx?BikeId=" + bikeId);
            }
            else
            {
                // User hasn't reviewed, redirect to rate form
                Response.Redirect("RateForm.aspx?BikeId=" + bikeId);
            }
        }

        protected void btn_Rate_Click(object sender, EventArgs e)
        {
            // Access the clicked control
            Control control = (Control)sender;

            if (control is Button rateButton)
            {
                // Access the Product ID from the CommandArgument
                string productId = rateButton.CommandArgument;

                // Redirect to RateForm.aspx for rating
                Response.Redirect($"RateForm.aspx?productId={productId}");
            }
            else if (control is HyperLink ratingsLink)
            {
                // Access the Product ID from the NavigateUrl
                string productId = ratingsLink.NavigateUrl.Split('=').Last();

                // Redirect to ViewRatings.aspx for viewing ratings
                Response.Redirect($"ViewRatings.aspx?product={productId}");
            }
        }



    }
}
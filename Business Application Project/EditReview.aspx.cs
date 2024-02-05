using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Business_Application_Project
{
    public partial class EditReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the existing review data based on the user's email and bike ID
                string userEmail = "yatsleo@gmail.com"; // Replace with the actual user email
                string bikeId = "11"; // Replace with the actual bike ID

                DataTable existingReview = RatingReview.GetReviewsFromDatabase(bikeId);

                // Check if there is an existing review
                if (existingReview.Rows.Count > 0)
                {
                    // Display bike details
                    lbl_Category.Text = "Mountain Bike"; // You can replace these with actual details
                    lbl_Brand.Text = "Brand XYZ"; // Replace with actual brand details

                    // Display existing rating stars
                    int stars = Convert.ToInt32(existingReview.Rows[0]["Stars"]);
                    DisplayExistingRating(stars);

                    // Display existing comment
                    txtComment.Text = existingReview.Rows[0]["Comment"].ToString();
                }
            }
        }

        private void DisplayExistingRating(int stars)
        {
            // Clear existing stars in the placeholder
            phStars.Controls.Clear();

            // Assuming stars are displayed as checked based on the existing rating
            for (int i = 1; i <= 5; i++)
            {
                // Create a new LiteralControl for each checked star
                phStars.Controls.Add(new LiteralControl($"<span class='star{(i <= stars ? " checked" : "")}' id='star_{i}' onclick='setRating({i})'>&#9733;</span>"));
            }
        }


        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get the updated review data
            int stars = Convert.ToInt32(hdRating.Value); // Assuming hdRating is your hidden field
            string comment = txtComment.Text;

            // Update the review in the database
            RatingReview.UpdateReviewInDatabase("yatsleo@gmail.com", "11", stars, comment);

            // Redirect to a confirmation or another page
            Response.Redirect("RatingProdView.aspx");
        }
    }
}
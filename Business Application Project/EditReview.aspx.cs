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
                string bikeId = "3"; // Replace with the actual bike ID

                DataTable existingReview = RatingReview.GetReviewsFromDatabase(bikeId);

                // Check if there is an existing review
                if (existingReview.Rows.Count > 0)
                {

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
            // Retrieve the existing review data to compare with the updated data
            DataTable existingReview = RatingReview.GetReviewsFromDatabase("3"); // Assuming bikeId is hardcoded as "11"

            if (existingReview.Rows.Count > 0)
            {
                int previousStars = Convert.ToInt32(existingReview.Rows[0]["Stars"]); // Retrieve the previous stars from the database
                string comment = txtComment.Text;

                // Get the updated review data
                int currentStars;
                if (!string.IsNullOrEmpty(hdRating.Value) && int.TryParse(hdRating.Value, out currentStars))
                {
                    // Stars value has been modified, use the updated value
                }
                else
                {
                    // Stars value has not been modified, use the previous value
                    currentStars = previousStars;
                }

                // Update the review in the database
                RatingReview.UpdateReviewInDatabase("yatsleo@gmail.com", "3", currentStars, comment);

                // Redirect to a confirmation or another page
                Response.Redirect("ProductDetails.aspx?ProdID=3");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewsNav.aspx");
        }
    }
}
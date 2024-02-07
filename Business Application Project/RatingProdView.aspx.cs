using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Business_Application_Project
{
    public partial class RatingProdView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Assuming you have a hardcoded bike ID for testing
                string bikeId = "11"; // Replace with your actual bike ID


                // Load reviews for the bike
                DataTable reviewsTable = RatingReview.GetReviewsFromDatabase(bikeId);

                // Display the number of reviews
                lbl_ReviewCount.Text = reviewsTable.Rows.Count + " Reviews";

                // Bind reviews to the Repeater control
                rptReviews.DataSource = reviewsTable;
                rptReviews.DataBind();
            }
        }

        protected string GetStarIcons(object stars)
        {
            if (stars != null && stars != DBNull.Value)
            {
                int starCount = Convert.ToInt32(stars);

                string starIcons = "";
                for (int i = 0; i < starCount; i++)
                {
                    starIcons += "&#9733;"; // Unicode character for a star
                }

                return starIcons;
            }

            return "";
        }



    }


}
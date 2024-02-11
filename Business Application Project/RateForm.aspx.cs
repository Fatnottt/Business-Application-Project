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
            // Call JavaScript function to validate the form
            string script = "validateStars();";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidateForm", script, true);

            // Get the updated review data
            string starsValue = hdRating.Value;
            int stars;
            if (!int.TryParse(starsValue, out stars))
            {
                // Stars value is not valid
                return;
            }

            string comment = txtComment.Text;
            string bikeId = "3"; // Replace this with the actual bike ID

            // Save rating to database
            RatingReview.SaveRatingToDatabase(stars, comment, bikeId);

            // Redirect to ReviewsNav page
            Response.Redirect("ReviewsNav.aspx");
        }




        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReviewsNav.aspx");
        }
    }
}
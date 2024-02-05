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

            int stars = Convert.ToInt32(hdRating.Value); // Assuming hdRating is your hidden field
            string comment = txtComment.Text;

            // Save rating to the database with default email
            RatingReview.SaveRatingToDatabase(stars, comment);

            // Redirect to a confirmation or another page
            Response.Redirect("RatingProdView.aspx");
        }


    }
}
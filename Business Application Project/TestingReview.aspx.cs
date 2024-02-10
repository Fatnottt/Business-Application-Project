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
            // Handle button click event (e.g., redirect to rate/edit page)
            string historyId = e.CommandArgument.ToString();
            // Perform necessary actions based on the button click
        }
    }
}

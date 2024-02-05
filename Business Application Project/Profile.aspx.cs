using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Update labels with session information for testing purposes
            User currentUser = Session["CurrentUser"] as User;
            UserEmailLabel.Text = $"User Email in Session: {currentUser?.Email ?? "Not available"}";
            SessionInfoLabel.Text = $"Is CurrentUser in Session: {currentUser != null}";
        }
    }
}
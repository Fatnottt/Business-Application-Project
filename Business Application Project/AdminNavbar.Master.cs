using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class AdminNavbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User currentUser = Session["CurrentUser"] as User;
            UpdateNavigationMenu();
        }
        private void UpdateNavigationMenu()
        {
            User currentUser = Session["CurrentUser"] as User;

            if (currentUser != null)
            {
                // User is logged in

                CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                TextInfo textInfo = cultureInfo.TextInfo;
                string capitalizedUserName = textInfo.ToTitleCase(currentUser.Name.ToLower());

                SignUpLink.InnerHtml = "<a href=\"javascript:void(0);\"><span>" + "Welcome, " + capitalizedUserName + "!" + "</span> <i class=\"bi bi-chevron-down dropdown-indicator\"></i></a><ul><li><a href=\"Profile.aspx\">Profile</a></li><li><a href=\"Logout.aspx\">Logout</a></li></ul>";
            }
            else
            {
                // User is not logged in
                SignUpLink.InnerHtml = "<a href=\"javascript:void(0);\"><span>Sign Up</span> <i class=\"bi bi-chevron-down dropdown-indicator\"></i></a><ul><li><a href=\"SignUp.aspx\">Sign Up</a></li><li><a href=\"Login.aspx\">Login</a></li></ul>";

            }

        }
    }
}
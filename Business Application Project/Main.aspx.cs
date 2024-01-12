﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class Main : System.Web.UI.Page
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
                SignUpLink.InnerHtml = "<a href=\"#\"><span>" + "Welcome, " + currentUser.Name + "!" + "</span> <i class=\"bi bi-chevron-down dropdown-indicator\"></i></a><ul><li><a href=\"Profile.aspx\">Logout</a></li></ul>";
            }
            else
            {
                // User is not logged in
                SignUpLink.InnerHtml = "<a href=\"#\"><span>Sign Up</span> <i class=\"bi bi-chevron-down dropdown-indicator\"></i></a><ul><li><a href=\"SignUp.aspx\">Sign Up</a></li><li><a href=\"Login.aspx\">Login</a></li></ul>";
            }

        }
    }
}
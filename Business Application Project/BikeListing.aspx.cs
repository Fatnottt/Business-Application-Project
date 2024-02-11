using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class BikeListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ddlBikeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = ddlBikeCategory.SelectedValue;
            if (selectedCategory == "urban")
            {
                ddlSubCategory.Visible = true;
                ddlSubCategory.Items.Clear();
                ddlSubCategory.Items.Add(new ListItem("City Bike", "city"));
                ddlSubCategory.Items.Add(new ListItem("Dutch Bike", "dutch"));
                ddlSubCategory.Items.Add(new ListItem("Single Speed Bike", "single_speed"));
            }
            else if (selectedCategory == "special")
            {
                ddlSubCategory.Visible = true;
                ddlSubCategory.Items.Clear();
                ddlSubCategory.Items.Add(new ListItem("Folding Bike", "folding"));
                ddlSubCategory.Items.Add(new ListItem("Recumbent Bike", "recumbent"));
                ddlSubCategory.Items.Add(new ListItem("Tandem Bike", "tandem"));
                ddlSubCategory.Items.Add(new ListItem("Longtail Bike", "longtail"));
                ddlSubCategory.Items.Add(new ListItem("Scooter", "scooter"));
            }
            else
            {
                ddlSubCategory.Visible = false;
            }
        }
    }
}
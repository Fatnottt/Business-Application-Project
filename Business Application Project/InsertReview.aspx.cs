using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class InsertReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            int result = 0;

            //UPDATED! extract info from textbox and save into a string variable
            String ProductID = tb_Product_ID.Text;
            String Review = tb_Review.Text;


            // if rbl_Rating is selected, the SelectedIndex will be more than -1
            string rating = null;
            if (rbl_Rating.SelectedIndex > -1)
            {
                rating = rbl_Rating.SelectedItem.Text;
            }

            Review review = new Review(tb_Product_ID.Text, rating, tb_Review.Text);
            result = review.ReviewInsert();

            if (result > 0)
            {
                Response.Write("<script>alert('Submit successful');</script>");
            }
            else
            {
                Response.Write("<script>alert('Submit NOT successful');</script>");
            }

        }
        protected void btn_ViewReview_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewReview.aspx");
        }
    }
    
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class ReviewDetails : System.Web.UI.Page
    {
        Product product = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindReviews();
            }
        }
        private void bindReviews()
        {
            List<Review> reviews = Review.getReviewAll();
            this.gvHistory.DataSource = reviews;
            this.gvHistory.DataBind();
        }

        protected void gvHistory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHistory.EditIndex = e.NewEditIndex;
            bindReviews();
        }

        protected void gvHistory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Review review = new Review();
            GridViewRow row = (GridViewRow)gvHistory.Rows[e.RowIndex];
            string id = gvHistory.DataKeys[e.RowIndex].Value.ToString();
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string trating = ((TextBox)row.Cells[1].Controls[0]).Text;
            string treview = ((TextBox)row.Cells[2].Controls[0]).Text;


            result = review.ReviewUpdate(tid, trating, treview);

            if (result > 0)
            {
                Response.Write("<script>alert('Review updated successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Review NOT updated');</script>");
            }

            gvHistory.EditIndex = -1;
            bindReviews();

        }

        protected void gvHistory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHistory.EditIndex = -1;
            bindReviews();
        }
    }
}

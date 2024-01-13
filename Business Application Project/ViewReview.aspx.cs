using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
                bind();
            }
        }
        private void bind()
        {
            List<Product> listOfProducts = product.getProductAll();
            this.gvHistory.DataSource = listOfProducts;
            this.gvHistory.DataBind();
        }

        protected void gvHistory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHistory.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvHistory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            GridViewRow row = (GridViewRow)gvHistory.Rows[e.RowIndex];
            string id = gvHistory.DataKeys[e.RowIndex].Value.ToString();
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            string trating = ((TextBox)row.Cells[1].Controls[0]).Text;
            string treview = ((TextBox)row.Cells[2].Controls[0]).Text;


            //result = prod.ProductUpdate(tid, trating, treview);
            //if (result > 0)
            //{
            //    Response.Write("<script>alert('Review updated successfully!');</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('Review NOT updated');</script>");
            //}
            //gvHistory.EditIndex = -1;
            //bind();

        }

        protected void gvHistory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHistory.EditIndex = -1;
            bind();
        }
    }
}

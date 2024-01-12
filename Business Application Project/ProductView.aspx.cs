using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class ProductView : System.Web.UI.Page
    {
        Product product = new Product();
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Explain what is IsPostBack
            if (!IsPostBack)
            {
                bind();
            }
        }

        private void bind()
        {
            List<Product> listOfProducts = product.getProductAll();
            this.gvProduct.DataSource = listOfProducts;
            this.gvProduct.DataBind();
        }

        protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row.
            GridViewRow row = gvProduct.SelectedRow;

            // Get Product ID from the selected row, which is the 
            // first row, i.e. index 0.
            string prodID = row.Cells[0].Text;

            // Redirect to next page, with the Product Id added to the URL,
            // e.g. ProductDetails.aspx?ProdID=1
            Response.Redirect("ProductDetails.aspx?ProdID=" + prodID);

        }

        protected void btn_AddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductInsert.aspx");
        }

        protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            string categoryID = gvProduct.DataKeys[e.RowIndex].Value.ToString();
            result = prod.ProductDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Product Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product Removal NOT successfully');</script>");
            }

            Response.Redirect("ProductView.aspx");

        }

        protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProduct.EditIndex = e.NewEditIndex;
            bind();
        }

        protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            Product prod = new Product();
            GridViewRow row = (GridViewRow)gvProduct.Rows[e.RowIndex];
            string id = gvProduct.DataKeys[e.RowIndex].Value.ToString();
            string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
            //string tname = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tprice = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tcategory = ((TextBox)row.Cells[2].Controls[0]).Text;
            string tbrand = ((TextBox)row.Cells[3].Controls[0]).Text;
            string tmodel = ((TextBox)row.Cells[4].Controls[0]).Text;
            string taddress = ((TextBox)row.Cells[5].Controls[0]).Text;

            result = prod.ProductUpdate(tid, decimal.Parse(tprice), tcategory, tbrand, tmodel, taddress);
            if (result > 0)
            {
                Response.Write("<script>alert('Product updated successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product NOT updated');</script>");
            }
            gvProduct.EditIndex = -1;
            bind();

        }

        protected void gvProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvProduct.EditIndex = -1;
            bind();
        }
    }
}
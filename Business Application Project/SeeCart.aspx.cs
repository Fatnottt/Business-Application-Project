using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class SeeCart : System.Web.UI.Page
    {
        ShoppingCart shoppingcart = new ShoppingCart();
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
            // Retrieve the shopping cart data
            List<ShoppingCart> listOfShoppingCarts = shoppingcart.getShoppingCartAll();

            // Bind the data to the GridView
            this.gvShoppingCart.DataSource = listOfShoppingCarts;
            this.gvShoppingCart.DataBind();
        }

        protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Add any additional handling or debugging here
                try
                {
                    // Example: Output the value of Brand for each row
                    string brand = DataBinder.Eval(e.Row.DataItem, "Brand").ToString();
                    Debug.WriteLine($"Brand for this row: {brand}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error during row data binding: {ex.Message}");
                }
            }
        }


        protected void gvShoppingCart_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected row.
            GridViewRow row = gvShoppingCart.SelectedRow;

            // Get cart ID from the selected row, which is the 
            // first row, i.e. index 0.
            string cartID = row.Cells[0].Text;

            // Assuming the Product ID is in the second cell, i.e. index 1.
            string prodID = row.Cells[1].Text;

            // Redirect to next page, with the Product Id added to the URL,
            // e.g. ProductDetails.aspx?ProdID=1
            Response.Redirect("ProductDetails.aspx?ProdID=" + prodID);
        }


      

        protected void btn_Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductView.aspx");
        }

        protected void gvShoppingCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int result = 0;
            ShoppingCart cart = new ShoppingCart();
            string categoryID = gvShoppingCart.DataKeys[e.RowIndex].Value.ToString();
            result = cart.ShoppingCartDelete(categoryID);

            if (result > 0)
            {
                Response.Write("<script>alert('Product Remove successfully');</script>");
            }
            else
            {
                Response.Write("<script>alert('Product Removal NOT successfully');</script>");
            }

            Response.Redirect("SeeCart.aspx");

        }

        protected void gvShoppingCart_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShoppingCart.EditIndex = e.NewEditIndex;
            bind();
        }


        protected void gvShoppingCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            // Get the currently selected row.
            GridViewRow row = gvShoppingCart.SelectedRow;

            // Get Product ID from the selected row, which is the 
            // first row, i.e. index 0.
            string cartID = row.Cells[0].Text;

            // Assuming the Product ID is in the second cell, i.e. index 1.
            string prodID = row.Cells[1].Text;

            // Redirect to next page, with the Product Id added to the URL,
            // e.g. ProductDetails.aspx?ProdID=1
            Response.Redirect("EditCart.aspx?CartID=" + cartID);

            //int result = 0;
            //ShoppingCart cart = new ShoppingCart();
            //GridViewRow row = gvShoppingCart.Rows[e.RowIndex];
            //string cartID = gvShoppingCart.DataKeys[e.RowIndex].Value.ToString();

            //// Change the type of tdate from string to DateTime
            //DateTime tdatein;
            //DateTime tdateout;
            //if (DateTime.TryParse(((TextBox)row.Cells[7].Controls[0]).Text, out tdatein) && DateTime.TryParse(((TextBox)row.Cells[8].Controls[0]).Text, out tdateout))
            ////if (DateTime.TryParse(dr["Datein"].ToString(), out datein) && DateTime.TryParse(dr["Dateout"].ToString(), out dateout))
            //{
            //    // Update only the Date field
            //    result = cart.ShoppingCartUpdateDate(cartID, tdatein, tdateout);
            //}
            //else
            //{
            //    // Handle the case where date parsing fails
            //    Response.Write("<script>alert('Invalid date format');</script>");
            //    return; // Do not proceed with the update if date parsing fails
            //}

            //if (result > 0)
            //{
            //    Response.Write("<script>alert('Date updated successfully');</script>");
            //}
            //else
            //{
            //    Response.Write("<script>alert('Date NOT updated');</script>");
            //}

            //gvShoppingCart.EditIndex = -1;
            //bind();
        }


        
        protected void gvShoppingCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShoppingCart.EditIndex = -1;
            bind();
        }

        protected void gvShoppingCart_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
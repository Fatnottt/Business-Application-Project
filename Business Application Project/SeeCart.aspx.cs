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
                //USE FOR TESTING PURPOSES
                //Session["CurrentUser"] = new User { Email = "yatsleo@gmail.com", Name = "yatsleo", Role = "test role" };

                //add exception for if user doesnt exist
                if (Session["CurrentUser"] is User)
                {
                    User CurrentUser = (User)Session["CurrentUser"];
                }

                bind();
            }
        }


        private void bind()
        {
            //USE FOR TESTING PURPOSES
            User currentUser = Session["CurrentUser"] as User;

            // Retrieve the shopping cart data
            List<ShoppingCart> listOfShoppingCarts = shoppingcart.getShoppingCartAll(currentUser.Email);

            // Bind the data to the GridView
            this.gvShoppingCart.DataSource = listOfShoppingCarts;
            this.gvShoppingCart.DataBind();

            // Calculate and set the total price for each item
            foreach (GridViewRow row in gvShoppingCart.Rows)
            {
                try
                {
                    // Convert the text in the cell to a decimal, handling any potential FormatException
                    decimal unitPrice;
                    if (decimal.TryParse(row.Cells[7].Text.Replace("$", ""), out unitPrice))
                    {
                        // Conversion succeeded, continue with further calculations
                        DateTime datein = Convert.ToDateTime(row.Cells[9].Text);
                        DateTime dateout = Convert.ToDateTime(row.Cells[10].Text);

                        // Calculate total price
                        decimal totalPrice = CalculateTotalPrice(unitPrice, datein, dateout);

                        // Find and update the Label control for the total price in the current row
                        Label lblTotalPrice = (Label)row.FindControl("lblTotalPrice");
                        lblTotalPrice.Text = totalPrice.ToString("C");

                        // Update the TotalPrice field in the current row's data source (optional)
                        ((ShoppingCart)row.DataItem).TotalPrice = totalPrice;
                    }
                    else
                    {
                        // Handle the case where conversion fails
                        Debug.WriteLine("Unable to parse unit price for row " + row.RowIndex);
                    }
                }
                catch (FormatException ex)
                {
                    // Log the error for further investigation
                    Debug.WriteLine($"Error converting unit price to decimal: {ex.Message}");
                    // You may also choose to handle this error gracefully, such as setting a default value for unitPrice
                }
            }
        }



        protected decimal CalculateTotalPrice(decimal unitPrice, DateTime datein, DateTime dateout)
        {
            // Calculate the number of days
            int days = (dateout - datein).Days;

            // Calculate and return the total price
            return unitPrice * days;
        }




        //protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        try
        //        {



        //            // Calculate the total price for the current item
        //            decimal unitPrice = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Unit_Price"));
        //            DateTime datein = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Datein"));
        //            DateTime dateout = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "Dateout"));
        //            decimal totalPrice = CalculateTotalPrice(unitPrice, datein, dateout);

        //            // Find the Label control for the total price in the current row
        //            Label lblTotalPrice = (Label)e.Row.FindControl("lblTotalPrice");
        //            if (lblTotalPrice != null)
        //            {
        //                // Set the text of the total price label
        //                lblTotalPrice.Text = totalPrice.ToString("C");
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle any exceptions or errors
        //            Debug.WriteLine($"Error calculating total price: {ex.Message}");
        //        }
        //    }
        //}

        protected void gvShoppingCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvShoppingCart.EditIndex != e.Row.RowIndex)
            {
                CalculateTotalPriceForRow(e.Row);
            }
            else if (e.Row.RowType == DataControlRowType.DataRow && gvShoppingCart.EditIndex == e.Row.RowIndex)
            {
                SetTextBoxTextMode(e.Row);
            }
        }

        private void CalculateTotalPriceForRow(GridViewRow row)
        {
            try
            {
                // Retrieve data from the current row
                decimal unitPrice = Convert.ToDecimal(DataBinder.Eval(row.DataItem, "Unit_Price"));
                DateTime datein = Convert.ToDateTime(DataBinder.Eval(row.DataItem, "Datein"));
                DateTime dateout = Convert.ToDateTime(DataBinder.Eval(row.DataItem, "Dateout"));

                // Calculate total price
                decimal totalPrice = CalculateTotalPrice(unitPrice, datein, dateout);

                // Find and update the Label control for the total price in the current row
                Label lblTotalPrice = (Label)row.FindControl("lblTotalPrice");
                lblTotalPrice.Text = totalPrice.ToString("C");

                // Update the TotalPrice field in the current row's data source (optional)
                ((ShoppingCart)row.DataItem).TotalPrice = totalPrice;
            }
            catch (Exception ex)
            {
                // Handle any exceptions or errors
                Debug.WriteLine($"Error calculating total price: {ex.Message}");
            }
        }

        private void SetTextBoxTextMode(GridViewRow row)
        {
            try
            {
                // Find the TextBox controls for Datein and Dateout
                TextBox txt_Datein = (TextBox)row.FindControl("txt_Datein");
                TextBox txt_Dateout = (TextBox)row.FindControl("txt_Dateout");

                // Set the TextMode of the TextBox controls to Date
                txt_Datein.TextMode = TextBoxMode.Date;
                txt_Dateout.TextMode = TextBoxMode.Date;
            }
            catch (Exception ex)
            {
                // Handle any exceptions or errors
                Debug.WriteLine($"Error setting TextBox text mode: {ex.Message}");
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
            // Set the EditIndex only for the current row
            gvShoppingCart.EditIndex = e.NewEditIndex;

            // Rebind the GridView to reflect the changes
            bind();

            // Find the GridViewRow for the edited row
            GridViewRow row = gvShoppingCart.Rows[e.NewEditIndex];

            // Loop through each cell in the row
            for (int i = 0; i < row.Cells.Count; i++)
            {
                // Find the edit control in each cell
                Control ctrl = row.Cells[i].Controls[0];

                // Check if the control is a TextBox
                if (ctrl is TextBox)
                {
                    TextBox txtBox = (TextBox)ctrl;

                    // Check if the TextBox is for Datein or Dateout
                    if (txtBox.ID != "txt_Datein" && txtBox.ID != "txt_Dateout")
                    {
                        // Disable the TextBox for non-editable fields
                        txtBox.Enabled = false;
                    }
                }
            }
        }



        //protected void gvShoppingCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int result = 0;
        //    ShoppingCart cart = new ShoppingCart();
        //    GridViewRow row = gvShoppingCart.Rows[e.RowIndex];
        //    string cartId = gvShoppingCart.DataKeys[e.RowIndex].Value.ToString();

        //    DateTime tDatein;
        //    DateTime tDateout;

        //    if (DateTime.TryParse(((TextBox)row.FindControl("txt_Datein")).Text, out tDatein) &&
        //        DateTime.TryParse(((TextBox)row.FindControl("txt_Dateout")).Text, out tDateout))
        //    {
        //        result = cart.ShoppingCartUpdateDate(cartId, tDatein, tDateout);

        //        if (result > 0)
        //        {
        //            Response.Write("<script>alert('Date updated successfully');</script>");
        //        }
        //        else
        //        {
        //            Response.Write("<script>alert('Date not updated');</script>");
        //        }
        //    }

        //    gvShoppingCart.EditIndex = -1;
        //    bind();
        //}

        protected void gvShoppingCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int result = 0;
            ShoppingCart cart = new ShoppingCart();
            GridViewRow row = gvShoppingCart.Rows[e.RowIndex];
            string cartId = gvShoppingCart.DataKeys[e.RowIndex].Value.ToString();

            DateTime tDatein;
            DateTime tDateout;

            if (DateTime.TryParse(((TextBox)row.FindControl("txt_Datein")).Text, out tDatein) &&
                DateTime.TryParse(((TextBox)row.FindControl("txt_Dateout")).Text, out tDateout))
            {
                result = cart.ShoppingCartUpdateDate(cartId, tDatein, tDateout);

                if (result > 0)
                {
                    // Recalculate and update total price
                    CalculateTotalPriceForRow(row);

                    Response.Write("<script>alert('Date updated successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Date not updated');</script>");
                }
            }

            gvShoppingCart.EditIndex = -1;
            bind(); // Rebind the GridView
        }


        protected void gvShoppingCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShoppingCart.EditIndex = -1;
            bind();
        }




        protected void gvShoppingCart_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnCalculateTotalAmount_Click(object sender, EventArgs e)
        {
            decimal totalAmount = 0;

            foreach (GridViewRow row in gvShoppingCart.Rows)
            {
                CheckBox chkSelect = row.FindControl("chkSelect") as CheckBox;

                if (chkSelect != null && chkSelect.Checked)
                {
                    Label lblTotalPrice = row.FindControl("lblTotalPrice") as Label;

                    if (lblTotalPrice != null)
                    {
                        decimal itemTotalPrice;
                        if (decimal.TryParse(lblTotalPrice.Text.Replace("$", ""), out itemTotalPrice))
                        {
                            totalAmount += itemTotalPrice;
                        }
                    }
                }
            }

            lblSelectedTotalAmount.Text = totalAmount.ToString("C");
        }


        //to be linked to payment page
        protected void btnRentNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}
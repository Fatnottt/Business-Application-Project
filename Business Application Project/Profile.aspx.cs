using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Business_Application_Project
{
    public partial class Profile : System.Web.UI.Page
    {
        Product product = new Product();
        public static readonly String IMAGE_FOLDER = "~\\Images\\";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindProductData();
            }

            // Update labels with session information for testing purposes
            User currentUser = Session["CurrentUser"] as User;
            UserEmailLabel.Text = $"User Email in Session: {currentUser?.Email ?? "Not available"}";
            SessionInfoLabel.Text = $"Is CurrentUser in Session: {currentUser != null}";
        }

        private void BindProductData()
        {
            Product product = new Product();
            List<Product> listOfProducts = product.getProductAll();
            rptProducts.DataSource = listOfProducts;
            rptProducts.DataBind();
        }

        protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Product product = (Product)e.Item.DataItem;
                Image img_Product = (Image)e.Item.FindControl("img_Product");

                // Set values for controls
                img_Product.ImageUrl = ResolveUrl(ProductDetails.IMAGE_FOLDER + product.Product_Image);
            }
        }

        protected void rptProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                string productId = e.CommandArgument.ToString();
                // Redirect to product details page with the selected product ID
                Response.Redirect("ProductDetails.aspx?ProdID=" + productId);
            }
        }
    }
}
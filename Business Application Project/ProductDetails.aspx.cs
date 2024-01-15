using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        public static readonly String IMAGE_FOLDER = "~\\Images\\"; //verlyn dh this


        protected void Page_Load(object sender, EventArgs e)
        {
            Product aProd = new Product(); //verlyn dh this

            // Get Product ID from querystring
            string prodID = Request.QueryString["ProdID"].ToString();

            //prodID = aProd.getProduct(prodID); //verlyn's
            Product prod = aProd.getProduct(prodID); //verlyn dh this

            hf_productId.Value = prod.Product_ID;
            //lbl_ProdName.Text = prod.Product_Name;
            lbl_ProdDesc.Text = prod.Product_Desc;
            lbl_Price.Text = prod.Unit_Price.ToString("c");

            //img_Product.ImageUrl = "~\\Images\\" + prod.Product_Image; //verlyn's
            img_Product.ImageUrl = IMAGE_FOLDER + prod.Product_Image; //lh's version verlyn dh this

            lbl_Category.Text = prod.Category;
            lbl_Brand.Text = prod.Brand;
            lbl_Model.Text = prod.Model;
            lbl_Address.Text = prod.Address;

            lbl_ProdID.Text = prodID.ToString(); //verlyn's version is commented

        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {

            Product prod = new Product();
            prod.Product_ID = hf_productId.Value;

            prod.Product_Desc = lbl_ProdDesc.Text;
            prod.Category = lbl_Category.Text;
            prod.Brand = lbl_Brand.Text;
            prod.Model = lbl_Model.Text;
            prod.Address = lbl_Address.Text;


            decimal price = 0; // Give it a default value in case parsing fails
            Decimal.TryParse(lbl_Price.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out price);
            prod.Unit_Price = price;

            //var imageUrl = this.img_Product.ImageUrl.Replace("~\\Images\\", ""); //verlyn's
            var imageUrl = this.img_Product.ImageUrl.Replace(IMAGE_FOLDER, ""); //lh's version verlyn dh this
            prod.Product_Image = imageUrl;

            string iProductID = prod.Product_ID.ToString();
            ShoppingCart.Instance.AddItem(iProductID, prod);

            // YL: Ensuring each user in different browser and computers have their own shopping cart instance.
            var shoppingCart = Session[Constants.SESSION_KEY_SHOPPING_CART] as ProperShoppingCart;
            if (shoppingCart == null)
            {
                shoppingCart = new ProperShoppingCart();
            }
            shoppingCart.AddItem(iProductID, prod);

            Session[Constants.SESSION_KEY_SHOPPING_CART] = shoppingCart;

            Response.Redirect("ViewCart.aspx");

        }
    }
}
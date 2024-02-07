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
        //VERLYN'S 
        public static readonly String IMAGE_FOLDER = "~\\Images\\"; //verlyn dh this


        protected void Page_Load(object sender, EventArgs e)
        {
            Product aProd = new Product(); //verlyn dh this

            // Get Product ID from querystring
            string prodID = Request.QueryString["ProdID"].ToString();

            //prodID = aProd.getProduct(prodID); //verlyn's
            Product prod = aProd.getProduct(prodID); //verlyn dh this

            hf_productID.Value = prod.Product_ID;
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

        } //VERLYN'S


        protected void btn_Add_Click(object sender, EventArgs e)
        {
            // Assuming hf_productId.Value contains the product ID
            string shoppingcartID = hf_shoppingcartID.Value;
            string productID = hf_productID.Value;

            // Assuming txt_Date.Text contains the selected date
            string selectedDateinStr = txt_Datein.Text;
            string selectedDateoutStr = txt_Dateout.Text;

       

            // Parse the selected date string to DateTime
            DateTime selectedDatein;
            DateTime selectedDateout;
            if (DateTime.TryParse(selectedDateinStr, out selectedDatein) && DateTime.TryParse(selectedDateoutStr, out selectedDateout))
            {


                ShoppingCart cart = new ShoppingCart(shoppingcartID, productID, selectedDatein, selectedDateout /*, selectedBrand, selectedModel, selectedCategory, selectedPriceDecimal, selectedDesc, selectedAddress*/);
                int result = cart.ShoppingCartInsert();

                if (result > 0)
                {
                    Response.Write("<script>alert('Insert successful');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Insert NOT successful');</script>");
                }

               
            }
            else
            {
                // Handle the case where date parsing fails
                Response.Write("<script>alert('Invalid date format. Use YYYY-MM-DD.');</script>");
            }

            //// Redirect to the SeeCart page
            //Server.Transfer("SeeCart.aspx");
        }

        protected void btn_SeeCart_Click(object sender, EventArgs e)
        {
            //Re-direct page to “ProductView.aspx”
            Response.Redirect("SeeCart.aspx");
        }

    }
}
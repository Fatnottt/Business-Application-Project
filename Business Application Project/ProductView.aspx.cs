using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Business_Application_Project
{
    public partial class ProductView : System.Web.UI.Page
    {
        Product product = new Product();
        public static readonly String IMAGE_FOLDER = "~\\Images\\";

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    // TODO: Explain what is IsPostBack
        //    if (!IsPostBack)
        //    {
        //        bind();
        //    }
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            //Product aProd = new Product();
            //string prodID = Request.QueryString["ProdID"].ToString();
            //Product prod = aProd.getProduct(prodID);

            //img_Product.ImageUrl = IMAGE_FOLDER + prod.Product_Image;
            //img_Product.ImageUrl = "~\\Images\\" + prod.Product_Image;

            if (!IsPostBack)
            {
                BindProductData();
            }
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




        //private void bind()
        //{
        //    List<Product> listOfProducts = product.getProductAll();
        //    this.gvProduct.DataSource = listOfProducts;
        //    this.gvProduct.DataBind();
        //}

        //protected void gvProduct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Get the currently selected row.
        //    GridViewRow row = gvProduct.SelectedRow;

        //    // Get Product ID from the selected row, which is the 
        //    // first row, i.e. index 0.
        //    string prodID = row.Cells[0].Text;

        //    // Redirect to next page, with the Product Id added to the URL,
        //    // e.g. ProductDetails.aspx?ProdID=1
        //    Response.Redirect("ProductDetails.aspx?ProdID=" + prodID);

        //}

        //protected void btn_AddProduct_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ProductInsert.aspx");
        //}

        //protected void gvProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int result = 0;
        //    Product prod = new Product();
        //    string categoryID = gvProduct.DataKeys[e.RowIndex].Value.ToString();
        //    result = prod.ProductDelete(categoryID);

        //    if (result > 0)
        //    {
        //        Response.Write("<script>alert('Product Remove successfully');</script>");
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Product Removal NOT successfully');</script>");
        //    }

        //    Response.Redirect("ProductView.aspx");

        //}

        //protected void gvProduct_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvProduct.EditIndex = e.NewEditIndex;
        //    bind();
        //}

        //protected void gvProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    int result = 0;
        //    Product prod = new Product();
        //    GridViewRow row = (GridViewRow)gvProduct.Rows[e.RowIndex];
        //    string id = gvProduct.DataKeys[e.RowIndex].Value.ToString();
        //    string tid = ((TextBox)row.Cells[0].Controls[0]).Text;
        //    string tprice = ((TextBox)row.Cells[1].Controls[0]).Text;
        //    string tcategory = ((TextBox)row.Cells[2].Controls[0]).Text;
        //    string tbrand = ((TextBox)row.Cells[3].Controls[0]).Text;
        //    string tmodel = ((TextBox)row.Cells[4].Controls[0]).Text;
        //    string taddress = ((TextBox)row.Cells[5].Controls[0]).Text;

        //    result = prod.ProductUpdate(tid, decimal.Parse(tprice), tcategory, tbrand, tmodel, taddress);
        //    if (result > 0)
        //    {
        //        Response.Write("<script>alert('Product updated successfully');</script>");
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Product NOT updated');</script>");
        //    }
        //    gvProduct.EditIndex = -1;
        //    bind();

        //}

        //protected void gvProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvProduct.EditIndex = -1;
        //    bind();
        //}
    }
}
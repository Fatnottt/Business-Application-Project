﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class ProductInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";

            if (FileUpload1.HasFile == true)
            {
                image = "Images\\" + FileUpload1.FileName;
            }


            Product prod = new Product(tb_Brand.Text, tb_Model.Text,
                tb_Category.Text, decimal.Parse(tb_UnitPrice.Text), tb_ProductDesc.Text, tb_Address.Text, FileUpload1.FileName);
            result = prod.ProductInsert();

            if (result > 0)
            {
                string saveimg = Server.MapPath(" ") + "\\" + image;
                lbl_Result.Text = saveimg.ToString();
                FileUpload1.SaveAs(saveimg);
                //loadProductInfo();
                //loadProduct();
                //clear1();
                Response.Write("<script>alert('Insert successful');</script>");
            }
            else
            {
                Response.Write("<script>alert('Insert NOT successful');</script>");
            }

        }

        protected void btn_ProductView_Click(object sender, EventArgs e)
        {
            //Re-direct page to “ProductView.aspx”
            Response.Redirect("ProductView.aspx");
        }
    }
}
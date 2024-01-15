using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Business_Application_Project
{
    //IEquatable - type-specific to determine the equality of Instances
    public class ShoppingCartItem : IEquatable<ShoppingCartItem>
    {
        public int Quantity { get; set; }

        private string _ItemID;
        public string ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }

        //private string _ItemName;
        //public string Product_Name
        //{
        //    get { return _ItemName; }
        //    set { _ItemName = value; }
        //}

        private string _ItemDesc;
        public string Product_Desc
        {
            get { return _ItemDesc; }
            set { _ItemDesc = value; }

        }

        private decimal _ItemPrice;
        public decimal Product_Price
        {
            get { return _ItemPrice; }
            set { _ItemPrice = value; }
        }

        private string _ItemCategory;
        public string Category
        {
            get { return _ItemCategory; }
            set { _ItemCategory = value; }
        }

        private string _ItemBrand;
        public String Brand
        {
            get { return _ItemBrand; }
            set { _ItemBrand = value; }
        }

        private string _ItemModel;
        public String Model
        {
            get { return _ItemModel; }
            set { _ItemModel = value; }
        }

        private string _ItemAddress;
        public String Address
        {
            get { return _ItemAddress; }
            set { _ItemAddress = value; }
        }

        public decimal TotalPrice
        {
            get { return Product_Price * Quantity; }
        }

        public ShoppingCartItem(string productID)
        {
            this.ItemID = productID;
        }

        public ShoppingCartItem(string productID, Product prod)
        {
            this.ItemID = productID;
            //this.Product_Name = prod.Product_Name;
            this.Product_Desc = prod.Product_Desc;
            this.Product_Price = prod.Unit_Price;
            this.Category = prod.Category;
            this.Brand = prod.Brand;
            this.Model = prod.Model;
            this.Address = prod.Address; ;

        }

        public ShoppingCartItem(string productID, string productDesc, decimal productPrice,string category, string brand, string model, string address)
        {
            this.ItemID = productID;
            //this.Product_Name = productName;
            this.Product_Desc = productDesc;
            this.Product_Price = productPrice;
            this.Category = category;
            this.Brand = brand;
            this.Model = model;
            this.Address = address;

        }

        public bool Equals(ShoppingCartItem anItem)
        {
            return anItem.ItemID == this.ItemID;
        }

        //public bool Equals(ShoppingCartItem product)
        //{
        //    return product.ItemID == this.ItemID;
        //}

    }
}
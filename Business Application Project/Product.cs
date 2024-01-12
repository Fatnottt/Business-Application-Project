using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Business_Application_Project
{
    public class Product
    {

        //Private string _connStr = Properties.Settings.Default.DBConnStr;

        //System.Configuration.ConnectionStringSettings _connStr;
        string _connStr = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;
        private string _prodID = null;
        //private string _prodName = string.Empty;
        private string _prodDesc = ""; // this is another way to specify empty string
        private decimal _unitPrice = 0;
        private string _prodImage = "";
        //private int _stockLevel = 0;
        private string _category = "";
        private string _brand = "";
        private string _model = "";
        private string _address = "";

        // Default constructor
        public Product()
        {
        }

        // Constructor that take in all data required to build a Product object
        public Product(string prodID, string prodDesc,
                       decimal unitPrice, string prodImage, string category, string brand, string model, string address)
        {
            _prodID = prodID;
            //_prodName = prodName;
            _prodDesc = prodDesc;
            _unitPrice = unitPrice;
            _prodImage = prodImage;
            //_stockLevel = stockLevel;
            _category = category;
            _brand = brand;
            _model = model;
            _address = address;
        }

        // Constructor that take in all except product ID
        public Product(string prodDesc,
               decimal unitPrice, string prodImage, string category, string brand, string model, string address)
            : this(null, prodDesc, unitPrice, prodImage, category, brand, model, address)
        {
        }

        // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
        public Product(string prodID)
            : this(prodID, "", 0, "", "", "", "", "")
        {
        }

        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string Product_ID
        {
            get { return _prodID; }
            set { _prodID = value; }
        }
        //public string Product_Name
        //{
        //    get { return _prodName; }
        //    set { _prodName = value; }
        //}
        public string Product_Desc
        {
            get { return _prodDesc; }
            set { _prodDesc = value; }
        }
        public decimal Unit_Price
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }
        public string Product_Image
        {
            get { return _prodImage; }
            set { _prodImage = value; }
        }
        //public int Stock_Level
        //{
        //    get { return _stockLevel; }
        //    set { _stockLevel = value; }
        //}

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public String Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public String Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public String Address
        {
            get { return _address; }
            set { _address = value; }
        }



        //Below as the Class methods for some DB operations. 
        public Product getProduct(string prodID)
        {
            Product prodDetail = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    string queryStr = "SELECT * FROM Products WHERE Product_ID = @ProdID";
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProdID", prodID);

                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            //string prod_Name = dr["Product_Name"].ToString();
                            string prod_Desc = dr["Product_Desc"].ToString();
                            string Prod_Image = dr["Product_Image"].ToString();
                            decimal unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
                            //int stock_Level = int.Parse(dr["Stock_Level"].ToString());
                            string category = dr["Category"].ToString();
                            string brand = dr["Brand"].ToString();
                            string model = dr["Model"].ToString();
                            string address = dr["Address"].ToString();

                            prodDetail = new Product(prodID, /*prod_Name,*/ prod_Desc, unit_Price, Prod_Image, /*stock_Level,*/ brand, model, address, category);
                        }
                        else
                        {
                            prodDetail = null;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException have occurred - {ex}!");
                prodDetail = null;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception have occurred - {ex}!");
                prodDetail = null;
            }


            return prodDetail;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of Products. null if Exception</returns>
        public List<Product> getProductAll()
        {
            List<Product> prodList = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    string queryStr = "SELECT * FROM Products Order By Product_Name";
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            string prod_ID = dr["Product_ID"].ToString();
                            //string prod_Name = dr["Product_Name"].ToString();
                            string prod_Desc = dr["Product_Desc"].ToString();
                            string Prod_Image = dr["Product_Image"].ToString();
                            decimal unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
                            //int stock_Level = int.Parse(dr["Stock_Level"].ToString());
                            string category = dr["Category"].ToString();
                            string brand = dr["Brand"].ToString();
                            string model = dr["Model"].ToString();
                            string address = dr["Address"].ToString();
                            Product a = new Product(prod_ID, /*prod_Name,*/ prod_Desc, unit_Price, Prod_Image, /*stock_Level*/ category, brand, model, address);
                            prodList.Add(a);
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.Write($"An SqlException have occurred - {ex}!");
                prodList = null;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception have occurred - {ex}!");
                prodList = null;
            }

            return prodList;
        }

        public int ProductInsert()
        {

            // string msg = null;
            int result = 0;


            try
            {
                string queryStr = "INSERT INTO Products(Product_ID,Product_Name, Product_Desc, Unit_Price,Product_Image,Stock_Level,Category, Brand, Model, Address)"
                  + " values (@Product_ID,@Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level,@Category, @Brand, @Model, @Address)";
                //+ "values (@Product_ID, @Product_Name, @Product_Desc, @Unit_Price, @Product_Image,@Stock_Level)";

                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
                        //cmd.Parameters.AddWithValue("@Product_Name", this.Product_Name);
                        cmd.Parameters.AddWithValue("@Product_Desc", this.Product_Desc);
                        cmd.Parameters.AddWithValue("@Unit_Price", this.Unit_Price);
                        cmd.Parameters.AddWithValue("@Product_Image", this.Product_Image);
                        //cmd.Parameters.AddWithValue("@Stock_Level", this.Stock_Level);
                        cmd.Parameters.AddWithValue("@Category", this.Category);
                        cmd.Parameters.AddWithValue("@Brand", this.Brand);
                        cmd.Parameters.AddWithValue("@Model", this.Model);
                        cmd.Parameters.AddWithValue("@Address", this.Address);

                        conn.Open();
                        result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException have occurred - {ex}!");
                result = -1;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception have occurred - {ex}!");
                result = -2;
            }
            finally
            {
                // TODO: Executed regardless of whether Exception or not.
            }

            return result;
        }//end Insert

        public int ProductDelete(string ID)
        {
            int nofRow = 0;
            try
            {
                string queryStr = "DELETE FROM Products WHERE Product_ID=@ID";
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        conn.Open();
                        nofRow = cmd.ExecuteNonQuery();
                        //  Response.Write("<script>alert('Delete successful');</script>");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException have occurred - {ex}!");
                nofRow = -1;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception have occurred - {ex}!");
                nofRow = -2;
            }
            return nofRow;
        }//end Delete

        public int ProductUpdate(string pId, decimal pUnitPrice, string pCategory, string pBrand, string pModel, string pAddress)
        {
            int nofRow = 0;
            string queryStr = "UPDATE Products SET" +
                " Unit_Price = @unitPrice, " +
                " Category = @category, " +
                " Brand = @brand, " +
                " Model = @model, " +
                " Address = @address " +
                " WHERE Product_ID = @productID";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        //cmd.Parameters.AddWithValue("@productName", pName);
                        cmd.Parameters.AddWithValue("@unitPrice", pUnitPrice);
                        cmd.Parameters.AddWithValue("@category", pCategory);
                        cmd.Parameters.AddWithValue("@brand", pBrand);
                        cmd.Parameters.AddWithValue("@model", pModel);
                        cmd.Parameters.AddWithValue("@address", pAddress);
                        cmd.Parameters.AddWithValue("@productID", pId);

                        conn.Open();
                        nofRow = 0;
                        nofRow = cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException have occurred - {ex}!");
                nofRow = -1;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception have occurred - {ex}!");
                nofRow = -2;
            }

            return nofRow;
        }//end Update

    }
}


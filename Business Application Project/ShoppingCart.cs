using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Business_Application_Project
{
    public class ShoppingCart
    {

        //Private string _connStr = Properties.Settings.Default.DBConnStr;

        //System.Configuration.ConnectionStringSettings _connStr;
        string _connStr = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
        private string _cartID = null;
        private string _prodID = "";
        private DateTime _datein;
        private DateTime _dateout;

        private string _brand = "";
        private string _model = "";
        private string _category = "";
        private decimal _unitPrice = 0;
        private string _prodDesc = "";
        private string _address = "";

        private string _email = "";
        private string _name = "";
        private string _actualpassword = "";
        private string _repeatpassword = "";
        private string _tokenauth = "";


        // Default constructor
        public ShoppingCart()
        {
        }

        // Constructor that take in all data required to build a Product object
        public ShoppingCart(string cartID, string prodID, string email, DateTime datein, DateTime dateout) //, int quantity , string brand, string model, string category, decimal unitPrice, string prodDesc, string address
        {
            _cartID = cartID;
            _prodID = prodID;
            _datein = datein;
            _dateout = dateout;
            _email = email;

            //_brand = brand;
            //_model = model;
            //_category = category;
            //_unitPrice = unitPrice;
            //_prodDesc = prodDesc;
            //_address = address;
            //_quantity = quantity;

        }

        // Constructor that take in all except cart ID 
        public ShoppingCart(string prodID, string email, DateTime datein, DateTime dateout)
            : this(null, prodID, email, datein, dateout)
        {
        }

        // Constructor that take in only cart ID. The other attributes will be set to 0 or empty.
        public ShoppingCart(string cartID)
            : this(cartID, "", "", DateTime.MinValue, DateTime.MinValue)
        {
        }

        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string ShoppingCart_ID
        {
            get { return _cartID; }
            set { _cartID = value; }
        }
        public string Product_ID
        {
            get { return _prodID; }
            set { _prodID = value; }
        }

        //public string Email
        //{
        //    get { return _email; }
        //    set { _email = value; }
        //}

        public DateTime Datein
        {
            get { return _datein; }
            set { _datein = value; }
        }

        public DateTime Dateout
        {
            get { return _dateout; }
            set { _dateout = value; }
        }


        public string Product_Desc { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public decimal Unit_Price { get; set; }
        public string Address { get; set; }
        public string Product_Image { get; set; }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }


        public decimal TotalPrice { get; set; }

        public ShoppingCart getShoppingCart(string cartID)
        {
            ShoppingCart cartDetail = null;

            
            string queryStr = "SELECT ShoppingCarts.ShoppingCart_ID, " +
                  "ShoppingCarts.Product_ID, " +
                  "ShoppingCarts.Datein, " +
                  "ShoppingCarts.Dateout, " +
                  "Products.Brand, " +
                  "Products.Model, " +
                  "Products.Category, " +
                  "Products.Unit_Price, " +
                  "Products.Product_Desc, " +
                  "Products.Address, " +
                  "Products.Product_Image, " +
                  "Users.Email " +
                  "FROM ShoppingCarts " +
                  "INNER JOIN Products ON ShoppingCarts.Product_ID = Products.Product_ID " +
                  "INNER JOIN Users ON ShoppingCarts.Email = Users.Email " +
                  "WHERE ShoppingCarts.ShoppingCart_ID = @CartID;";


            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    cmd.Parameters.AddWithValue("@CartID", cartID);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            // Retrieve columns from ShoppingCart table
                            string prodID = dr["Product_ID"].ToString();
                            DateTime datein = DateTime.Parse(dr["Datein"].ToString());
                            DateTime dateout = DateTime.Parse(dr["Dateout"].ToString());


                            // Retrieve columns from Products table
                            string brand = dr["Brand"].ToString();
                            string model = dr["Model"].ToString();
                            string category = dr["Category"].ToString();
                            decimal unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
                            string prod_Desc = dr["Product_Desc"].ToString();
                            string address = dr["Address"].ToString();
                            //string Prod_Image = dr["Product_Image"].ToString();

                            // Retrieve columns from Users table
                            string email = dr["Email"].ToString();

                            // Create ShoppingCart object
                            cartDetail = new ShoppingCart(cartID, prodID, email, datein, dateout); //, brand, model, category, unit_Price, prod_Desc, address, prod_Image, quantity
                        }
                    }
                }
            }

            return cartDetail;
        }


        public List<ShoppingCart> getShoppingCartAll(string _email)
        {
            List<ShoppingCart> cartList = new List<ShoppingCart>();

           
            string queryStr = "SELECT ShoppingCarts.ShoppingCart_ID, " +
                  "ShoppingCarts.Product_ID, " +
                  "ShoppingCarts.Datein, " +
                  "ShoppingCarts.Dateout, " +
                  "Products.Brand, " +
                  "Products.Model, " +
                  "Products.Category, " +
                  "Products.Unit_Price, " +
                  "Products.Product_Desc, " +
                  "Products.Address, " +
                  "Products.Product_Image, " +
                  "Users.Email " +
                  "FROM ShoppingCarts " +
                  "INNER JOIN Products ON ShoppingCarts.Product_ID = Products.Product_ID " +
                  "INNER JOIN Users ON ShoppingCarts.Email = Users.Email " +
                  "WHERE ShoppingCarts.Email = @Email " +
                  "ORDER BY ShoppingCarts.Datein";



            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", _email);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            

                            string cart_ID = dr["ShoppingCart_ID"].ToString();
                            string prod_ID = dr["Product_ID"].ToString();
                            string email = dr["Email"].ToString();

                            DateTime datein;
                            DateTime dateout;
                            if (DateTime.TryParse(dr["Datein"].ToString(), out datein) && DateTime.TryParse(dr["Dateout"].ToString(), out dateout))
                            {
                                string brand = dr["Brand"].ToString();
                                string model = dr["Model"].ToString();
                                string category = dr["Category"].ToString();
                                decimal unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
                                string prod_Desc = dr["Product_Desc"].ToString();
                                string address = dr["Address"].ToString();

                                ShoppingCart cart = new ShoppingCart(cart_ID, prod_ID, email, datein, dateout)
                                {
                                    Brand = brand,
                                    Model = model,
                                    Category = category,
                                    Unit_Price = unit_Price,
                                    Product_Desc = prod_Desc,
                                    Address = address
                                };

                                cartList.Add(cart);
                            }
                            else
                            {
                                // Handle the case where date parsing fails
                                // You might want to log an error or take appropriate action
                            }
                        }
                    }
                }
            }

            return cartList;
        }



        public List<int> GetRandomInt()
        {
            var result = new List<int>();


            return result;
        }




        public int ShoppingCartInsert() //string _email
        {
            int result = 0;

            

            string queryStr = "INSERT INTO ShoppingCarts(Product_ID, Email, Datein, Dateout)" + "values(@Product_ID, @Email, @Datein, @Dateout)";
            //string queryStr = "INSERT INTO ShoppingCarts(Product_ID, Date, Brand, Model, Category, Unit_Price, Product_Desc, Address)" + "values(@Product_ID, @Date, @Brand, @Model, @Category, @Unit_Price, @Product_Desc, @Address)";


            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    //cmd.Parameters.AddWithValue("@ShoppingCart_ID", this.ShoppingCart_ID);
                    cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
                    cmd.Parameters.AddWithValue("@Email", this.Email);
                    cmd.Parameters.AddWithValue("@Datein", this.Datein);
                    cmd.Parameters.AddWithValue("@Dateout", this.Dateout);
                    //cmd.Parameters.AddWithValue("@Brand", this.Brand);
                    //cmd.Parameters.AddWithValue("@Model", this.Model);
                    //cmd.Parameters.AddWithValue("@Category", this.Category);
                    //cmd.Parameters.AddWithValue("@Unit_Price", this.Unit_Price);
                    //cmd.Parameters.AddWithValue("@Product_Desc", this.Product_Desc);
                    //cmd.Parameters.AddWithValue("@Address", this.Address);

                    result += cmd.ExecuteNonQuery();
                }
            }

            return result;
        }

        

        public int ShoppingCartDelete(string ID)
        {
            int nofRow = 0;
            try
            {
                string queryStr = "DELETE FROM ShoppingCarts WHERE ShoppingCart_ID=@ID";
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", ID);
                        conn.Open();
                        nofRow = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException has occurred - {ex}!");
                nofRow = -1;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception has occurred - {ex}!");
                nofRow = -2;
            }
            return nofRow;
        }//end Delete



        public int ShoppingCartUpdate(string cId, string cDesc, string cCategory, string cBrand, string cModel, decimal cUnitPrice, string cAddress, DateTime cDatein, DateTime cDateout)
        {
            int nofRow = 0;
            string queryStr = "UPDATE ShoppingCarts SET" +
                " Product_Desc = @productDesc, " +
                " Category = @category, " +
                " Brand = @brand, " +
                " Model = @model, " +
                " Address = @address, " +
                " Unit_Price = @unitPrice, " +
                " Datein = @datein " +
                " Dateout = @dateout " +
                
                " WHERE ShoppingCart_ID = @shoppingcartID";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@productDesc", cDesc);
                        cmd.Parameters.AddWithValue("@category", cCategory);
                        cmd.Parameters.AddWithValue("@brand", cBrand);
                        cmd.Parameters.AddWithValue("@model", cModel);
                        cmd.Parameters.AddWithValue("@address", cAddress);
                        cmd.Parameters.AddWithValue("@unitPrice", cUnitPrice);
                        cmd.Parameters.AddWithValue("@datein", cDatein);
                        cmd.Parameters.AddWithValue("@dateout", cDateout);
                        cmd.Parameters.AddWithValue("@shoppingcartID", cId);

                        conn.Open();
                        nofRow = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException has occurred - {ex}!");
                nofRow = -1;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception has occurred - {ex}!");
                nofRow = -2;
            }

            return nofRow;
        }

        public int ShoppingCartUpdateDate(string cId, DateTime cDatein, DateTime cDateout)
        {
            int nofRow = 0;
            string queryStr = "UPDATE ShoppingCarts SET Datein = @datein, Dateout = @dateout WHERE ShoppingCart_ID = @shoppingcartID";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@datein", cDatein);
                        cmd.Parameters.AddWithValue("@dateout", cDateout);
                        cmd.Parameters.AddWithValue("@shoppingcartID", cId);

                        conn.Open();
                        nofRow = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException has occurred - {ex}!");
                nofRow = -1;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception has occurred - {ex}!");
                nofRow = -2;
            }

            return nofRow;
        }





    }
}
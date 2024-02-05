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
        private DateTime _date;
        private string _brand = "";
        private string _model = "";
        private string _category = "";
        private decimal _unitPrice = 0;
        private string _prodDesc = "";
        private string _address = "";


        //private int _quantity = 0;

        //public static void Main(string[] args)
        //{
        //    ShoppingCart cart = new ShoppingCart("CartId", "ProdId", DateTime.Now);
        //    int insertResult = cart.ShoppingCartInsert();
        //}


        // Default constructor
        public ShoppingCart()
        {
        }

        // Constructor that take in all data required to build a Product object
        public ShoppingCart(string cartID, string prodID, DateTime date) //, int quantity , string brand, string model, string category, decimal unitPrice, string prodDesc, string address
        {
            _cartID = cartID;
            _prodID = prodID;
            _date = date;

            //_brand = brand;
            //_model = model;
            //_category = category;
            //_unitPrice = unitPrice;
            //_prodDesc = prodDesc;
            //_address = address;
            //_quantity = quantity;

        }

        // Constructor that take in all except cart ID 
        public ShoppingCart(string prodID, DateTime date) //, int quantity
            : this(null, prodID, date) //, quantity
        {
        }

        // Constructor that take in only cart ID. The other attributes will be set to 0 or empty.
        public ShoppingCart(string cartID)
            : this(cartID, "", DateTime.MinValue) //, 0
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

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }


        public string Product_Desc { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public decimal Unit_Price { get; set; }
        public string Address { get; set; }
        public string Product_Image { get; set; }

        //public int Quantity
        //{
        //    get { return _quantity; }
        //    set { _quantity = value; }
        //}



        public ShoppingCart getShoppingCart(string cartID)
        {
            ShoppingCart cartDetail = null;

            string queryStr = "SELECT ShoppingCarts.ShoppingCart_ID, ShoppingCarts.Product_ID, Products.Brand, Products.Model, Products.Category, Products.Unit_Price, Products.Product_Desc, Products.Address, Products.Product_Image FROM ShoppingCarts INNER JOIN Products ON ShoppingCarts.Product_ID = Products.Product_ID WHERE ShoppingCarts.ShoppingCart_ID = @CartID;";

            //Quantity,

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
                            DateTime date = DateTime.Parse(dr["Date"].ToString());
                            //int quantity = int.Parse(dr["Quantity"].ToString());

                            // Retrieve columns from Products table
                            string brand = dr["Brand"].ToString();
                            string model = dr["Model"].ToString();
                            string category = dr["Category"].ToString();
                            decimal unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
                            string prod_Desc = dr["Product_Desc"].ToString();
                            string address = dr["Address"].ToString();
                            //string Prod_Image = dr["Product_Image"].ToString();

                            // Create ShoppingCart object
                            cartDetail = new ShoppingCart(cartID, prodID, date); //, brand, model, category, unit_Price, prod_Desc, address, prod_Image, quantity
                        }
                    }
                }
            }

            return cartDetail;
        }

        //public ShoppingCart getShoppingCart(string cartID)
        //{
        //    ShoppingCart cartDetail = null;

        //    //string queryStr = "SELECT ShoppingCarts.ShoppingCart_ID, ShoppingCarts.Product_ID, Products.Brand, Products.Model, Products.Category, Products.Unit_Price, Products.Product_Desc, Products.Address, Products.Product_Image FROM ShoppingCarts INNER JOIN Products ON ShoppingCarts.Product_ID = Products.Product_ID WHERE ShoppingCarts.ShoppingCart_ID = @CartID;";
        //    string queryStr = "SELECT ShoppingCarts.ShoppingCart_ID, ShoppingCarts.Product_ID, ShoppingCarts.Date, Products.Brand, Products.Model, Products.Category, Products.Unit_Price, Products.Product_Desc, Products.Address, Products.Product_Image FROM ShoppingCarts INNER JOIN Products ON ShoppingCarts.Product_ID = Products.Product_ID WHERE ShoppingCarts.ShoppingCart_ID = @CartID";


        //    using (SqlConnection conn = new SqlConnection(_connStr))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(queryStr, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@CartID", cartID);

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read())
        //                {
        //                    // Retrieve columns from ShoppingCart table
        //                    string prodID = dr["Product_ID"].ToString();
        //                    DateTime date = DateTime.Parse(dr["Date"].ToString());

        //                    // Retrieve columns from Products table
        //                    string brand = dr["Brand"].ToString();
        //                    string model = dr["Model"].ToString();
        //                    string category = dr["Category"].ToString();
        //                    decimal unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
        //                    string prod_Desc = dr["Product_Desc"].ToString();
        //                    string address = dr["Address"].ToString();
        //                    string Prod_Image = dr["Product_Image"].ToString();

        //                    // Create ShoppingCart object
        //                    cartDetail = new ShoppingCart(cartID, prodID, date);
        //                }
        //            }
        //        }
        //    }

        //    return cartDetail;
        //}


        //public List<ShoppingCart> getShoppingCartAll()
        //{
        //    List<ShoppingCart> cartList = new List<ShoppingCart>();

        //    //string queryStr = "SELECT ShoppingCarts.ShoppingCart_ID, ShoppingCarts.Product_ID, ShoppingCarts.Date, Products.Brand, Products.Model, Products.Category, Products.Unit_Price, Products.Product_Desc, Products.Address, Products.Product_Image FROM ShoppingCarts INNER JOIN Products ON ShoppingCarts.Product_ID = Products.Product_ID ORDER BY ShoppingCarts.Date";
        //    string queryStr = "SELECT ShoppingCarts.ShoppingCart_ID, ShoppingCarts.Product_ID, ShoppingCarts.Date, Products.Brand, Products.Model, Products.Category, Products.Unit_Price, Products.Product_Desc, Products.Address, Products.Product_Image FROM ShoppingCarts INNER JOIN Products ON ShoppingCarts.Product_ID = Products.Product_ID ORDER BY ShoppingCarts.Date";

        //    using (SqlConnection conn = new SqlConnection(_connStr))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(queryStr, conn))
        //        {
        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                while (dr.Read())
        //                {
        //                    //string cart_ID = dr["ShoppingCart_ID"].ToString();
        //                    string cart_ID = dr["ShoppingCart_ID"].ToString(); // Use the correct column name here

        //                    //string prod_ID = dr["Product_ID"].ToString();

        //                    string prod_ID = dr["Product_ID"].ToString();
        //                    string brand = dr["Brand"].ToString();
        //                    string model = dr["Model"].ToString();
        //                    string category = dr["Category"].ToString();
        //                    decimal unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
        //                    string prod_Desc = dr["Product_Desc"].ToString();
        //                    string address = dr["Address"].ToString();

        //                    DateTime date;
        //                    if (DateTime.TryParse(dr["Date"].ToString(), out date))
        //                    {
        //                        ShoppingCart a = new ShoppingCart(cart_ID, prod_ID, date, brand, model, category, unit_Price, prod_Desc, address);
        //                        cartList.Add(a);
        //                    }
        //                    else
        //                    {
        //                        // Handle the case where date parsing fails
        //                        // You might want to log an error or take appropriate action
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return cartList;
        //}

        public List<ShoppingCart> getShoppingCartAll()
        {
            List<ShoppingCart> cartList = new List<ShoppingCart>();

            string queryStr = "SELECT ShoppingCarts.ShoppingCart_ID, ShoppingCarts.Product_ID, ShoppingCarts.Date, " +
                              "Products.Brand, Products.Model, Products.Category, " +
                              "Products.Unit_Price, Products.Product_Desc, Products.Address, Products.Product_Image " +
                              "FROM ShoppingCarts " +
                              "INNER JOIN Products ON ShoppingCarts.Product_ID = Products.Product_ID " +
                              "ORDER BY ShoppingCarts.Date";

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            string cart_ID = dr["ShoppingCart_ID"].ToString();
                            string prod_ID = dr["Product_ID"].ToString();

                            DateTime date;
                            if (DateTime.TryParse(dr["Date"].ToString(), out date))
                            {
                                string brand = dr["Brand"].ToString();
                                string model = dr["Model"].ToString();
                                string category = dr["Category"].ToString();
                                decimal unit_Price = decimal.Parse(dr["Unit_Price"].ToString());
                                string prod_Desc = dr["Product_Desc"].ToString();
                                string address = dr["Address"].ToString();

                                ShoppingCart cart = new ShoppingCart(cart_ID, prod_ID, date)
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


        //public int ShoppingCartInsert()
        //{
        //    int result = 0;

        //    // Ensure that Cart_ID, Product_ID, and Date are not null
        //    if (string.IsNullOrEmpty(this._cartID) || string.IsNullOrEmpty(this._prodID) || this._date == DateTime.MinValue)
        //    {
        //        // Handle the case where parameters are not set
        //        return -1; // You may choose an appropriate error code
        //    }

        //    string queryStr = "INSERT INTO ShoppingCarts(ShoppingCart_ID, Product_ID, Date) VALUES (@ShoppingCart_ID, @Product_ID, @Date)";

        //    using (SqlConnection conn = new SqlConnection(_connStr))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(queryStr, conn))
        //        {
        //            // Set parameters
        //            cmd.Parameters.AddWithValue("@ShoppingCart_ID", this.ShoppingCart_ID);
        //            cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
        //            cmd.Parameters.AddWithValue("@Date", this.Date);

        //            result += cmd.ExecuteNonQuery();
        //        }
        //    }

        //    return result;
        //}

        public int ShoppingCartInsert()
        {
            int result = 0;

            //if (string.IsNullOrEmpty(this.ShoppingCart_ID) || string.IsNullOrEmpty(this.Product_ID) || this.Date == DateTime.MinValue)
            //{
            //    return -1; // You may choose an appropriate error code
            //}

            //ShoppingCart_ID, @ShoppingCart_ID, 

            string queryStr = "INSERT INTO ShoppingCarts(Product_ID, Date)" + "values(@Product_ID, @Date)";
            //string queryStr = "INSERT INTO ShoppingCarts(Product_ID, Date, Brand, Model, Category, Unit_Price, Product_Desc, Address)" + "values(@Product_ID, @Date, @Brand, @Model, @Category, @Unit_Price, @Product_Desc, @Address)";


            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                {
                    //cmd.Parameters.AddWithValue("@ShoppingCart_ID", this.ShoppingCart_ID);
                    cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
                    cmd.Parameters.AddWithValue("@Date", this.Date);
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

        //public int ShoppingCartInsert()
        //{
        //    int result = 0;

        //    string queryStr = "INSERT INTO ShoppingCarts (Product_ID, Date)" +
        //                      "SELECT @Product_ID, @Date " +
        //                      "FROM Products WHERE Products.Product_ID = @Product_ID";

        //    using (SqlConnection conn = new SqlConnection(_connStr))
        //    {
        //        conn.Open();

        //        using (SqlCommand cmd = new SqlCommand(queryStr, conn))
        //        {
        //            //cmd.Parameters.AddWithValue("@ShoppingCart_ID", this.ShoppingCart_ID);
        //            cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
        //            cmd.Parameters.AddWithValue("@Date", this.Date);

        //            result += cmd.ExecuteNonQuery();
        //        }
        //    }

        //    return result;
        //}



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



        public int ShoppingCartUpdate(string cId, string cDesc, string cCategory, string cBrand, string cModel, decimal cUnitPrice, string cAddress, DateTime cDate)
        {
            int nofRow = 0;
            string queryStr = "UPDATE ShoppingCarts SET" +
                " Product_Desc = @productDesc, " +
                " Category = @category, " +
                " Brand = @brand, " +
                " Model = @model, " +
                " Address = @address, " +
                " Unit_Price = @unitPrice, " +
                " Date = @date " +
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
                        cmd.Parameters.AddWithValue("@date", cDate);
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

        public int ShoppingCartUpdateDate(string cId, DateTime cDate)
        {
            int nofRow = 0;
            string queryStr = "UPDATE ShoppingCarts SET Date = @date WHERE ShoppingCart_ID = @shoppingcartID";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@date", cDate);
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


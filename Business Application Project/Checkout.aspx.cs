using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class Checkout : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

        public string sessionId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                StripeConfiguration.ApiKey = "sk_test_51OjLdBAWp9OZBZFjhsGMzw13yfaSXHHJOEJ3l9cVJgYzQrZbhPxgCLQ0TrjD2cLIflZWbusc7LpKGs0r0InUmFhx00dJorUf3n";

                User currentUser = Session["CurrentUser"] as User;


                List<Dictionary<string, object>> productList = GetCartProducts();


                if (productList != null && productList.Any())
                {
                    var options = new SessionCreateOptions
                    {
                        SuccessUrl = "https://localhost:44313/ThankYou.aspx",
                        CancelUrl = "https://localhost:44313/Checkout.aspx",
                        PaymentMethodTypes = new List<string>
                            {
                                "card",
                            },
                        LineItems = productList.Select(item => new SessionLineItemOptions
                        {
                            Quantity = (int)item["Stock_Level"],
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmount = Convert.ToInt32((decimal)item["Unit_Price"]),
                                Currency = "sgd",
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = item["Product_Name"].ToString(),
                                    Description = item["Product_Desc"].ToString(),
                                }
                            }
                        }).ToList(),
                        Mode = "payment",

                    };

                    var service = new SessionService();
                    Session session = service.Create(options);
                    sessionId = session.Id;
                }
                else
                {
                    Console.WriteLine("Your Cart is Empty");
                }
            }
        }



        public List<Dictionary<string, object>> GetCartProducts()
        {
            List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();

            User currentUser = Session["CurrentUser"] as User;
            string email = "yatsleo@gmail.com";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string getAllProductsQuery = "SELECT sc.*, p.Product_Name, p.Product_Desc, p.Unit_Price, p.Stock_Level " +
                    "FROM ShoppingCarts sc " +
                    "JOIN Products p ON sc.Product_Id = p.Product_Id " +
                    "WHERE sc.Email = @email ";

                using (SqlCommand getAllProductsCommand = new SqlCommand(getAllProductsQuery, connection))
                {
                    getAllProductsCommand.Parameters.AddWithValue("@email", email);

                    using (SqlDataReader reader = getAllProductsCommand.ExecuteReader())
                    {
                        // Process the results here
                        while (reader.Read())
                        {
                            // Access data using reader["ColumnName"]
                            int productId = (int)reader["Product_Id"];
                            string productName = reader["Product_Name"].ToString();
                            string productDesc = reader["Product_Desc"].ToString();
                            decimal unitPrice = (decimal)reader["Unit_Price"] * 100;
                            int stock = (int)reader["Stock_Level"];

                            // Store data in dictionary
                            Dictionary<string, object> rowData = new Dictionary<string, object>
                    {
                        { "Product_Id", productId },
                        { "Product_Name", productName },
                        { "Product_Desc", productDesc },
                        { "Unit_Price", unitPrice },
                        { "Stock_Level", stock },
                    };

                            dataList.Add(rowData);
                        }
                    }
                }
            }

            return dataList;
        }
    }
}

using BikeRental.Models;
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

    public partial class WebForm2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            // Create a product object and assign the values from the text boxes
            Product product = new Product();
            product.Name = Name.Text;
            product.Price = Convert.ToDecimal(Price.Text);
            product.Category = Category.Text;
            product.Description = Description.Text;

            // Create a connection object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikeRentalContext"].ConnectionString);

            // Create a command object
            SqlCommand cmd = new SqlCommand("INSERT INTO Products (Name, Price, Category, Description) VALUES (@Name, @Price, @Category, @Description)", con);

            // Add parameters to the command
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@Category", product.Category);
            cmd.Parameters.AddWithValue("@Description", product.Description);

            // Open the connection
            con.Open();

            // Execute the command
            cmd.ExecuteNonQuery();

            // Close the connection
            con.Close();

            // Redirect to the Product page
            Response.Redirect("Product.aspx");
        }
    }
}
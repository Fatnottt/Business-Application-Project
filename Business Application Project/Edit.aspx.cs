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
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            // Get the product id from the query string
            int id = Convert.ToInt32(Request.QueryString["id"]);

            // Create a product object and assign the values from the text boxes
            Product product = new Product();
            product.Id = id;
            product.Name = Name.Text;
            product.Price = Convert.ToDecimal(Price.Text);
            product.Category = Category.Text;
            product.Description = Description.Text;

            // Create a connection object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikeRentalContext"].ConnectionString);

            // Create a command object
            SqlCommand cmd = new SqlCommand("UPDATE Products SET Name = @Name, Price = @Price, Category = @Category, Description = @Description WHERE Id = @Id", con);

            // Add parameters to the command
            cmd.Parameters.AddWithValue("@Id", product.Id);
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
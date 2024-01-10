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
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            // Get the product id from the query string
            int id = Convert.ToInt32(Request.QueryString["id"]);

            // Create a connection object
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BikeRentalContext"].ConnectionString);

            // Create a command object
            SqlCommand cmd = new SqlCommand("DELETE FROM Products WHERE Id = @Id", con);

            // Add a parameter to the command
            cmd.Parameters.AddWithValue("@Id", id);

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
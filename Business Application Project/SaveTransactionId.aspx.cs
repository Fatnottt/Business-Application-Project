using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Web.Mvc.Controls;
using System.Configuration;
using System.Web.Helpers;
using System.Xml.Linq;

namespace Business_Application_Project
{
    public partial class SaveTransactionId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
                // Retrieve the transaction ID from the request
                string transactionId = Request.Form["transactionId"];
                try
                {
                    // Call a function to save the transaction ID to the database
                    SaveTransactionIdToDatabase(transactionId);
                    // Respond with a success message (if needed)
                    Response.Write("Transaction ID saved successfully.");
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, display an error message, etc.)
                    Response.Write($"Error: {ex.Message}");
                }
            }
        }
            // Function to save the transaction ID to the database
        protected void SaveTransactionIdToDatabase(string transactionId)
        {
            string tableName = "DepositTransactions";

            // Connection string with SQL Server instance name "BikieDB"
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"INSERT INTO {tableName} (PayPalTransactionID) VALUES (@TransactionId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionId", transactionId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
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
    public partial class PayDeposit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = "";
            if (Session["CurrentUser"] != null)
            {
                User currentUser = (User)Session["CurrentUser"];
                email = currentUser.Email;
            }

            if (Request.HttpMethod == "POST")
            {
                // Retrieve the transaction ID from the request
                string transactionId = Request.Form["transactionId"];
                try
                {
                    // Call a function to save the transaction ID to the database
                    SaveTransactionIdToDatabase(transactionId, email);
                    // Respond with a success message (if needed)
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, display an error message, etc.)
                }
            }
        }

        // Function to save the transaction ID to the database
        protected void SaveTransactionIdToDatabase(string transactionId, string email)
        {
            string tableName = "DepositTransactions";
            string statusPaid = "Paid";
            string statusPendingRefund = "Pending Refund";
            string statusRefunded = "Refunded";
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the email already exists in the table
                string checkEmailQuery = $"SELECT COUNT(*) FROM {tableName} WHERE Email = @Email";
                using (SqlCommand checkEmailCommand = new SqlCommand(checkEmailQuery, connection))
                {
                    checkEmailCommand.Parameters.AddWithValue("@Email", email);
                    int existingEmailCount = (int)checkEmailCommand.ExecuteScalar();

                    if (existingEmailCount > 0)
                    {
                        // Email already exists, handle accordingly (throw an exception, update existing record, etc.)
                        throw new Exception("Email already exists in the table.");
                    }
                }

                // If email doesn't exist, proceed with the insertion
                string query = $"INSERT INTO {tableName} (PayPalTransactionID, Email, Status) VALUES (@TransactionId, @Email, @Status)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TransactionId", transactionId);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Status", statusPaid); // Default status is Paid
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

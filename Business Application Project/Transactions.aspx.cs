using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class Transactions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTransactionsGrid();
            }
        }

        private void BindTransactionsGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            string query = "SELECT PayPalTransactionID, Email, Status FROM DepositTransactions";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                GridViewTransactions.DataSource = dataTable;
                GridViewTransactions.DataBind();
            }
        }

        protected void GridViewTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Refund")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string transactionID = GridViewTransactions.DataKeys[rowIndex]["PayPalTransactionID"].ToString();

                // Update the status to "Refunded" in the database
                UpdateTransactionStatus(transactionID, "Refunded");

                // Rebind the GridView to reflect the updated status
                BindTransactionsGrid();
            }
        }

        private void UpdateTransactionStatus(string transactionID, string status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            string updateQuery = "UPDATE DepositTransactions SET Status = @Status WHERE PayPalTransactionID = @TransactionID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@TransactionID", transactionID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
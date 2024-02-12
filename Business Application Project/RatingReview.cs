using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace Business_Application_Project
{
    public class RatingReview
    {
        private static string _connStr = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

        public static void SaveRatingToDatabase(string userEmail, int stars, string comment, string bikeId)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = "INSERT INTO Reviews (User_Email, Bike_ID, Stars, Comment, Review_Date) " +
                               "VALUES (@UserEmail, @BikeId, @Stars, @Comment, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    command.Parameters.AddWithValue("@BikeId", bikeId);
                    command.Parameters.AddWithValue("@Stars", stars);
                    command.Parameters.AddWithValue("@Comment", comment);

                    command.ExecuteNonQuery();
                }
            }
        }



        public static DataTable GetReviewsFromProduct(string productId)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = @"
            SELECT R.Stars, R.Comment, CONVERT(date, R.Review_Date) AS Review_Date, 
                   CASE WHEN U.Name IS NOT NULL THEN U.Name ELSE 'Anonymous' END AS User_Name
            FROM Reviews R
            LEFT JOIN Users U ON R.User_Email = U.Email
            WHERE R.Bike_ID = @ProductId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable reviewsTable = new DataTable();
                    adapter.Fill(reviewsTable);

                    return reviewsTable;
                }
            }
        }

        public static DataTable GetReviewsFromDatabase(string userEmail, string productId)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = @"
            SELECT R.Stars, R.Comment, CONVERT(date, R.Review_Date) AS Review_Date, 
                   CASE WHEN U.Name IS NOT NULL THEN U.Name ELSE 'Anonymous' END AS User_Name
            FROM Reviews R
            LEFT JOIN Users U ON R.User_Email = U.Email
            WHERE R.User_Email = @UserEmail AND R.Bike_ID = @ProductId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    command.Parameters.AddWithValue("@ProductId", productId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable reviewsTable = new DataTable();
                    adapter.Fill(reviewsTable);

                    return reviewsTable;
                }
            }
        }





        public static void UpdateReviewInDatabase(string userEmail, string bikeId, int stars, string comment)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = "UPDATE Reviews SET " +
                               "Stars = @Stars, " +
                               "Comment = @Comment, " +
                               "Review_Date = GETDATE() " +
                               "WHERE User_Email = @UserEmail AND Bike_ID = @BikeId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    command.Parameters.AddWithValue("@BikeId", bikeId);
                    command.Parameters.AddWithValue("@Stars", stars);
                    command.Parameters.AddWithValue("@Comment", comment);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static bool HasUserReviewed(string userEmail, string bikeId)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM Reviews " +
                               "WHERE User_Email = @UserEmail AND Bike_ID = @BikeId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    command.Parameters.AddWithValue("@BikeId", bikeId);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        
        // testingreview
        public static DataTable GetRentalHistory(string userEmail)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = @"SELECT History_Id, Bike_Id, Bike_Name, Start_Date, End_Date, Total_Price
                                 FROM History
                                 WHERE User_Email = @UserEmail";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable historyTable = new DataTable();
                    adapter.Fill(historyTable);

                    // Add HasReviewed column dynamically
                    historyTable.Columns.Add("HasReviewed", typeof(bool));
                    foreach (DataRow row in historyTable.Rows)
                    {
                        string bikeId = row["Bike_Id"].ToString();
                        row["HasReviewed"] = HasUserReviewed(userEmail, bikeId);
                    }

                    return historyTable;
                }
            }
        }

        public static void UpdateHasReviewedStatus(string userEmail, string bikeId)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = "IF EXISTS (SELECT 1 FROM Reviews WHERE User_Email = @UserEmail AND Bike_ID = @BikeId) " +
                               "BEGIN " +
                               "    UPDATE Reviews SET HasReviewed = 1 WHERE User_Email = @UserEmail AND Bike_ID = @BikeId " +
                               "END";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);
                    command.Parameters.AddWithValue("@BikeId", bikeId);

                    command.ExecuteNonQuery();
                }
            }
        }



    }
}
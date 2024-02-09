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

        public static void SaveRatingToDatabase(int stars, string comment, string bikeId)
        {
            string defaultUserEmail = "yatsleo@gmail.com"; // Default user email

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = "INSERT INTO Reviews (User_Email, Bike_ID, Stars, Comment, Review_Date) " +
                               "VALUES (@UserEmail, @BikeId, @Stars, @Comment, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", defaultUserEmail);
                    command.Parameters.AddWithValue("@BikeId", bikeId);
                    command.Parameters.AddWithValue("@Stars", stars);
                    command.Parameters.AddWithValue("@Comment", comment);

                    command.ExecuteNonQuery();
                }
            }
        }


        public static DataTable GetReviewsFromDatabase(string bikeId)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = @"SELECT R.User_Email, R.Stars, R.Comment, CONVERT(date, R.Review_Date) AS Review_Date
                    FROM Reviews R
                    INNER JOIN Products P ON R.Bike_ID = P.Product_Id
                    WHERE R.Bike_ID = @BikeId";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BikeId", bikeId);

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

        // for testing history database in TestingReview.aspx
        public static DataTable GetRentalHistory(string userEmail)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = @"SELECT History_Id, Bike_Id, Bike_Name, Start_Date, End_Date, Total_Price, Bike_Image
                                 FROM History
                                 WHERE User_Email = @UserEmail";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable historyTable = new DataTable();
                    adapter.Fill(historyTable);

                    return historyTable;
                }
            }
        }

    }
}
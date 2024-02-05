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

        public static void SaveRatingToDatabase(int stars, string comment)
        {
            string defaultUserEmail = "yatsleo@gmail.com"; // Default user email
            string defaultBikeId = "11"; // Hardcoded default Bike_ID

            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = "INSERT INTO Reviews (User_Email, Bike_ID, Stars, Comment, Review_Date) " +
                               "VALUES (@UserEmail, @BikeId, @Stars, @Comment, GETDATE())";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", defaultUserEmail);
                    command.Parameters.AddWithValue("@BikeId", defaultBikeId);
                    command.Parameters.AddWithValue("@Stars", stars);
                    command.Parameters.AddWithValue("@Comment", comment);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static DataTable GetReviewsFromDatabase(string bikeId)
        {
            // Retrieve reviews from the database based on the bike ID
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                connection.Open();

                string query = "SELECT User_Email, Stars, Comment FROM Reviews WHERE Bike_ID = @BikeId";
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
    }
}
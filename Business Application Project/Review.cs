using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public class Review
    {
        private static string _connStr = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
        private string _prodID = null;
        private string _rating = "";
        private string _review = "";


        // Default constructor
        public Review()
        {
        }

        // Constructor that take in all data required to build a Product object
        public Review(string prodID, string rating, string review)
        {
            _prodID = prodID;
            _rating = rating;
            _review = review;
        }

        // Constructor that take in all except product ID
        public Review(string rating, string review)
            : this(null, rating, review)
        {
        }

        // Constructor that take in only Product ID. The other attributes will be set to 0 or empty.
        public Review(string prodID)
            : this(prodID, "", "")
        {
        }

        // Get/Set the attributes of the Product object.
        // Note the attribute name (e.g. Product_ID) is same as the actual database field name.
        // This is for ease of referencing.
        public string Product_ID
        {
            get { return _prodID; }
            set { _prodID = value; }
        }
        public string Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public string Reviews
        {
            get { return _review; }
            set { _review = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>List of Products. null if Exception</returns>
        public static List<Review> getReviewAll()
        {
            List<Review> reviewList = new List<Review>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    string queryStr = "SELECT * FROM Reviews ORDER BY [Product ID]";
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            string prod_ID = dr["Product ID"].ToString();
                            string Rating = dr["Rating"].ToString();
                            string Reviews = dr["Comment"].ToString();

                            Review a = new Review(prod_ID, Rating, Reviews);
                            reviewList.Add(a);
                        }
                    }
                }
            }

            catch (SqlException ex)
            {
                Console.Write($"An SqlException have occurred - {ex}!");
                reviewList = null;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception have occurred - {ex}!");
                reviewList = null;
            }

            return reviewList;
        }

        public int ReviewInsert()
        {

            // string msg = null;
            int result = 0;


            try
            {
                string queryStr = "INSERT INTO Reviews([Product ID], Rating, Comment)"
                  + " values (@Product_ID, @Rating, @Comment)";

                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Product_ID", this.Product_ID);
                        cmd.Parameters.AddWithValue("@Rating", this.Rating);
                        cmd.Parameters.AddWithValue("@Comment", this.Reviews);

                        conn.Open();
                        result += cmd.ExecuteNonQuery(); // Returns no. of rows affected. Must be > 0

                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException have occurred - {ex}!");
                result = -1;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception have occurred - {ex}!");
                result = -2;
            }
            finally
            {
                // TODO: Executed regardless of whether Exception or not.
            }

            return result;
        }//end Insert

        public int ReviewUpdate(string pId, string pRating, string pReview)
        {
            int nofRow = 0;
            string queryStr = "UPDATE Reviews SET" +
                              " Rating = @Rating, " +
                              " Comment = @Comment " +
                              " WHERE [Product ID] = @productID"; // Use the correct field name

            try
            {
                using (SqlConnection conn = new SqlConnection(_connStr))
                {
                    using (SqlCommand cmd = new SqlCommand(queryStr, conn))
                    {
                        cmd.Parameters.AddWithValue("@Rating", pRating);
                        cmd.Parameters.AddWithValue("@Comment", pReview);
                        cmd.Parameters.AddWithValue("@productID", pId);

                        conn.Open();
                        nofRow = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Write($"An SqlException has occurred - {ex}!");
                nofRow = -1;
            }
            catch (Exception ex)
            {
                Console.Write($"An Exception has occurred - {ex}!");
                nofRow = -2;
            }

            return nofRow;
        }

    }
}

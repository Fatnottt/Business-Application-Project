using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class BikeListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ddlBikeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = ddlBikeCategory.SelectedValue;
            if (selectedCategory == "Urban")
            {
                ddlSubCategory.Visible = true;
                ddlSubCategory.Items.Clear();
                ddlSubCategory.Items.Add(new ListItem("Specify the subcategory", "Specify the subcategory"));
                ddlSubCategory.Items.Add(new ListItem("City Bike", "City Bike"));
                ddlSubCategory.Items.Add(new ListItem("Dutch Bike", "Dutch Bike"));
                ddlSubCategory.Items.Add(new ListItem("Single Speed Bike", "Single Speed Bike"));
            }
            else if (selectedCategory == "Special")
            {
                ddlSubCategory.Visible = true;
                ddlSubCategory.Items.Clear();
                ddlSubCategory.Items.Add(new ListItem("Specify the subcategory", "Specify the subcategory"));
                ddlSubCategory.Items.Add(new ListItem("Folding Bike", "Folding Bike"));
                ddlSubCategory.Items.Add(new ListItem("Recumbent Bike", "Recumbent Bike"));
                ddlSubCategory.Items.Add(new ListItem("Tandem Bike", "Tandem Bike"));
                ddlSubCategory.Items.Add(new ListItem("Longtail Bike", "Longtail Bike"));
                ddlSubCategory.Items.Add(new ListItem("Scooter", "Scooter"));
            }
        }
        protected void nextcategory_Click(object sender, EventArgs e)
        {
            if (ddlBikeCategory.SelectedIndex > 0 && ddlSubCategory.SelectedIndex > 0)
            {
                // Check if Session["CurrentUser"] is not null
                if (Session["CurrentUser"] != null)
                {
                    // Get the selected values from dropdown lists
                    string category = ddlBikeCategory.SelectedValue;
                    string subcategory = ddlSubCategory.SelectedValue;
                    User currentUser = Session["CurrentUser"] as User;
                    string userEmail = currentUser.Email;

                    try
                    {
                        // Now you can insert these values into your database
                        string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "";
                            int insertedBikeID = 0;

                            // Check if there is a sessioned BikeID
                            if (Session["InsertedBikeID"] != null)
                            {
                                // If there is, update the existing record
                                query = "UPDATE BikeInfo SET Email = @Email, BikeCategory = @Category, BikeSubcategory = @SubCategory WHERE BikeID = @BikeID; SELECT @BikeID;";
                                insertedBikeID = Convert.ToInt32(Session["InsertedBikeID"]);
                            }
                            else
                            {
                                // If not, insert a new record
                                query = "INSERT INTO BikeInfo (Email, BikeCategory, BikeSubcategory) VALUES (@Email, @Category, @SubCategory); SELECT SCOPE_IDENTITY();";
                            }

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Email", userEmail);
                                command.Parameters.AddWithValue("@Category", category);
                                command.Parameters.AddWithValue("@SubCategory", subcategory);
                                if (insertedBikeID > 0)
                                {
                                    command.Parameters.AddWithValue("@BikeID", insertedBikeID);
                                }

                                connection.Open();
                                insertedBikeID = Convert.ToInt32(command.ExecuteScalar());

                                categoryContent.Style["display"] = "none";
                                detailsContent.Style["display"] = "block";

                                // Change the active button to Details
                                categoryButton.Attributes["class"] = "invisible-button";
                                detailsButton.Attributes["class"] = "invisible-button active";

                                // Clear DropDownList values
                                ddlBikeCategory.SelectedIndex = 0;
                                ddlSubCategory.SelectedIndex = 0;

                                // Clear error message
                                errorMessageLabel.Text = "";

                                // Store insertedBikeID in Session for later use
                                Session["InsertedBikeID"] = insertedBikeID;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        errorMessageLabel.Text = "An error occurred: " + ex.Message;
                    }
                }
                else
                {
                    errorMessageLabel.Text = "User session is not available.";
                }
            }
            else
            {
                // Display error message if either dropdown list is not selected
                errorMessageLabel.Text = "Please select both a bike category and subcategory.";
            }
        }


        protected void previousDetails_Click(object sender, EventArgs e)
        {
            categoryContent.Style["display"] = "block";
            detailsContent.Style["display"] = "none";

            // Change the active button to Category
            categoryButton.Attributes["class"] = "invisible-button active";
            detailsButton.Attributes["class"] = "invisible-button";
        }
        protected void nextDetails_Click(object sender, EventArgs e)
        {
            // Do not allow null values for Brand, Model, RecUserHeight, and MaxSeatHeight
            if (string.IsNullOrEmpty(Brand.Text) || string.IsNullOrEmpty(Model.Text) || string.IsNullOrEmpty(ddlRiderHeight.SelectedValue) || string.IsNullOrEmpty(MaxSeatHeight.Text))
            {
                errorMessageLabel2.Text = "Please fill in all the fields.";
                return;
            }
            if (Session["CurrentUser"] != null)
            {
                // Assuming the ID is passed somehow to this page, fetch it
                if (Session["InsertedBikeID"] != null)
                {
                    int bikeID = Convert.ToInt32(Session["InsertedBikeID"]);
                    string brand = Brand.Text;
                    string model = Model.Text;
                    string recHeight = ddlRiderHeight.SelectedValue;
                    string maxSeatHeight = MaxSeatHeight.Text;

                    try
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "UPDATE BikeInfo SET BikeBrand = @BikeBrand, BikeModel = @BikeModel, RecUserHeight = @RecUserHeight, MaxSeatHeight = @MaxSeatHeight WHERE BikeID = @BikeID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BikeID", bikeID);
                                command.Parameters.AddWithValue("@BikeBrand", brand);
                                command.Parameters.AddWithValue("@BikeModel", model);
                                command.Parameters.AddWithValue("@RecUserHeight", recHeight);
                                command.Parameters.AddWithValue("@MaxSeatHeight", maxSeatHeight);

                                connection.Open();
                                command.ExecuteNonQuery();

                                detailsContent.Style["display"] = "none";
                                picturesContent.Style["display"] = "block";

                                // Change the active button to Details
                                detailsButton.Attributes["class"] = "invisible-button";
                                picturesButton.Attributes["class"] = "invisible-button active";

                                // Clear values
                                Brand.Text = "";
                                Model.Text = "";
                                ddlRiderHeight.SelectedIndex = 0;
                                MaxSeatHeight.Text = "";

                                // Clear error message
                                errorMessageLabel2.Text = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessageLabel2.Text = "An error occurred: " + ex.Message;
                    }
                }
                else
                {
                    errorMessageLabel2.Text = "Bike ID is missing.";
                }
            }
            else
            {
                errorMessageLabel2.Text = "User session is not available.";
            }
        }


        protected void previousPictures_Click(object sender, EventArgs e)
        {
            detailsContent.Style["display"] = "block";
            picturesContent.Style["display"] = "none";

            // Change the active button to Details
            detailsButton.Attributes["class"] = "invisible-button active";
            picturesButton.Attributes["class"] = "invisible-button";
        }

        protected void nextPictures_Click(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] != null)
            {
                // Assuming the ID is passed somehow to this page, fetch it
                if (Session["InsertedBikeID"] != null)
                {
                    int bikeID = Convert.ToInt32(Session["InsertedBikeID"]);

                    try
                    {
                        // Check if all three FileUpload controls have files uploaded
                        if (FileUpload1.HasFile && FileUpload2.HasFile && FileUpload3.HasFile)
                        {
                            // Upload and save pictures
                            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                // You may need to adjust this query based on your database schema
                                string query = "UPDATE BikeInfo SET BikePicture1 = @BikePicture1, BikePicture2 = @BikePicture2, BikePicture3 = @BikePicture3 WHERE BikeID = @BikeID";

                                using (SqlCommand command = new SqlCommand(query, connection))
                                {
                                    // Save the uploaded pictures in the "UserBikeImages" folder
                                    string folderPath = Server.MapPath("/Images");   

                                    string picture1FileName = Path.GetFileName(FileUpload1.FileName);
                                    string picture2FileName = Path.GetFileName(FileUpload2.FileName);
                                    string picture3FileName = Path.GetFileName(FileUpload3.FileName);

                                    string picture1Path = Path.Combine(folderPath, picture1FileName);
                                    string picture2Path = Path.Combine(folderPath, picture2FileName);
                                    string picture3Path = Path.Combine(folderPath, picture3FileName);

                                    FileUpload1.SaveAs(picture1Path);
                                    FileUpload2.SaveAs(picture2Path);
                                    FileUpload3.SaveAs(picture3Path);

                                    // Save the uploaded pictures as binary data in the database
                                    byte[] picture1Bytes = File.ReadAllBytes(picture1Path);
                                    byte[] picture2Bytes = File.ReadAllBytes(picture2Path);
                                    byte[] picture3Bytes = File.ReadAllBytes(picture3Path);

                                    command.Parameters.AddWithValue("@BikeID", bikeID);
                                    command.Parameters.AddWithValue("@BikePicture1", picture1Bytes);
                                    command.Parameters.AddWithValue("@BikePicture2", picture2Bytes);
                                    command.Parameters.AddWithValue("@BikePicture3", picture3Bytes);

                                    connection.Open();
                                    command.ExecuteNonQuery();

                                    picturesContent.Style["display"] = "none";
                                    locationContent.Style["display"] = "block";

                                    // Change the active button to Pictures
                                    picturesButton.Attributes["class"] = "invisible-button";
                                    locationButton.Attributes["class"] = "invisible-button active";

                                    // Clear values
                                    FileUpload1.Attributes.Clear();
                                    FileUpload2.Attributes.Clear();
                                    FileUpload3.Attributes.Clear();

                                    // Clear error message
                                    errorMessageLabel3.Text = "";
                                }
                            }
                        }
                        else
                        {
                            // Show error message if any of the FileUpload controls are empty
                            errorMessageLabel3.Text = "Please upload all three pictures.";
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessageLabel3.Text = "An error occurred: " + ex.Message;
                    }
                }
                else
                {
                    errorMessageLabel3.Text = "Bike ID is missing.";
                }
            }
            else
            {
                errorMessageLabel3.Text = "User session is not available.";
            }
        }

        protected void previousLocation_Click(object sender, EventArgs e)
        {
            picturesContent.Style["display"] = "block";
            locationContent.Style["display"] = "none";

            // Change the active button to Pictures
            picturesButton.Attributes["class"] = "invisible-button active";
            locationButton.Attributes["class"] = "invisible-button";
        }

        protected void nextLocation_Click(object sender, EventArgs e)
        {
            // Retrieve input values from TextBox controls
            string streetAddress = StreetAddress.Text.Trim();
            string postalCode = PostalCode.Text.Trim();
            string city = City.Text.Trim();
            string country = Country.Text.Trim();

            // Perform validation
            if (string.IsNullOrEmpty(streetAddress) || string.IsNullOrEmpty(postalCode) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
            {
                // Display error message if any of the required fields are empty
                errorMessageLabel4.Text = "Please fill in all the fields.";
                return;
            }

            // Save location information in the database
            if (Session["CurrentUser"] != null)
            {
                // Assuming the ID is passed somehow to this page, fetch it
                if (Session["InsertedBikeID"] != null)
                {
                    int bikeID = Convert.ToInt32(Session["InsertedBikeID"]);

                    try
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "UPDATE BikeInfo SET BikeLocation = @BikeLocation, BikePostal = @BikePostal, BikeLocality = @BikeLocality, BikePrincipleSubDivision = @BikePrincipleSubDivision WHERE BikeID = @BikeID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@BikeID", bikeID);
                                command.Parameters.AddWithValue("@BikeLocation", streetAddress);
                                command.Parameters.AddWithValue("@BikePostal", postalCode);
                                command.Parameters.AddWithValue("@BikeLocality", city);
                                command.Parameters.AddWithValue("@BikePrincipleSubDivision", country);

                                connection.Open();
                                command.ExecuteNonQuery();

                                locationContent.Style["display"] = "none";
                                pricingContent.Style["display"] = "block";

                                // Change the active button to Pictures
                                locationButton.Attributes["class"] = "invisible-button";
                                pricingButton.Attributes["class"] = "invisible-button active";

                                // Clear values
                                StreetAddress.Text = "";
                                PostalCode.Text = "";
                                City.Text = "";
                                Country.Text = "";

                                // Clear error message
                                errorMessageLabel4.Text = "";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessageLabel4.Text = "An error occurred: " + ex.Message;
                    }
                }
                else
                {
                    errorMessageLabel4.Text = "Bike ID is missing.";
                }
            }
            else
            {
                errorMessageLabel4.Text = "User session is not available.";
            }
        }


        protected void previousPricing_Click(object sender, EventArgs e)
        {
            locationContent.Style["display"] = "block";
            pricingContent.Style["display"] = "none";

            // Change the active button to Location
            locationButton.Attributes["class"] = "invisible-button active";
            pricingButton.Attributes["class"] = "invisible-button";
        }

        protected void finishPricing_Click(object sender, EventArgs e)
        {
            // Retrieve input values from TextBox controls
            string dailyPriceText = DailyPrice.Text.Trim();
            string dailyDiscountText = DailyDiscount.Text.Trim();
            string weeklyDiscountText = WeeklyDiscount.Text.Trim();

            // Perform validation
            if (string.IsNullOrEmpty(dailyPriceText) || string.IsNullOrEmpty(dailyDiscountText) || string.IsNullOrEmpty(weeklyDiscountText))
            {
                // Display error message if daily price is empty
                errorMessageLabel5.Text = "Please enter all fields.";
                return;
            }

            // Save pricing information in the database
            if (Session["CurrentUser"] != null)
            {
                // Assuming the ID is passed somehow to this page, fetch it
                if (Session["InsertedBikeID"] != null)
                {
                    int bikeID = Convert.ToInt32(Session["InsertedBikeID"]);

                    try
                    {
                        string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            string query = "UPDATE BikeInfo SET PricePerDay = @PricePerDay WHERE BikeID = @BikeID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Convert string values to appropriate data types
                                decimal dailyPrice = decimal.Parse(dailyPriceText);
                                decimal dailyDiscount = string.IsNullOrEmpty(dailyDiscountText) ? 0 : decimal.Parse(dailyDiscountText);
                                decimal weeklyDiscount = string.IsNullOrEmpty(weeklyDiscountText) ? 0 : decimal.Parse(weeklyDiscountText);

                                command.Parameters.AddWithValue("@BikeID", bikeID);
                                command.Parameters.AddWithValue("@PricePerDay", dailyPrice);

                                connection.Open();
                                command.ExecuteNonQuery();

                                // Redirect to the next step or perform any other necessary action
                                Response.Redirect("Main.aspx");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessageLabel5.Text = "An error occurred: " + ex.Message;
                    }
                }
                else
                {
                    errorMessageLabel5.Text = "Bike ID is missing.";
                }
            }
            else
            {
                errorMessageLabel5.Text = "User session is not available.";
            }
        }

        protected void CalculateWeeklyPrice(object sender, EventArgs e)
        {
            // Retrieve input values from TextBox controls
            string dailyPriceText = DailyPrice.Text.Trim();
            string dailyDiscountText = DailyDiscount.Text.Trim();
            string weeklyDiscountText = WeeklyDiscount.Text.Trim();

            // Perform validation
            if (string.IsNullOrEmpty(dailyPriceText))
            {
                // Display error message if daily price is empty
                errorMessageLabel5.Text = "Please enter the daily price.";
                return;
            }

            // Convert string values to appropriate data types
            decimal dailyPrice = decimal.Parse(dailyPriceText);
            decimal dailyDiscount = string.IsNullOrEmpty(dailyDiscountText) ? 0 : decimal.Parse(dailyDiscountText);
            decimal weeklyDiscount = string.IsNullOrEmpty(weeklyDiscountText) ? 0 : decimal.Parse(weeklyDiscountText);

            // Calculate the weekly price
            decimal weeklyPrice = CalculateWeeklyPrice(dailyPrice, dailyDiscount, weeklyDiscount);

            // Display the calculated weekly price in weeklyPriceLabel with text
            weeklyPriceLabel.Text = "Weekly Price: " + weeklyPrice.ToString("C");
        }

        // Method to calculate the weekly price based on daily price and discounts
        private decimal CalculateWeeklyPrice(decimal dailyPrice, decimal dailyDiscount, decimal weeklyDiscount)
        {
            // Calculate the discounted daily price
            decimal discountedDailyPrice = dailyPrice - (dailyPrice * dailyDiscount / 100);

            // Calculate the weekly price based on the discounted daily price and weekly discount
            decimal weeklyPrice = discountedDailyPrice * 7 * (1 - weeklyDiscount / 100);

            return weeklyPrice;
        }


    }
}

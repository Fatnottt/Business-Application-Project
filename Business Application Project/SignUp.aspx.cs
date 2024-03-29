﻿using System;
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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Register_Click(object sender, EventArgs e)
        {
            // Get user input from the form
            string name = Name.Text.Trim();
            string email = Email.Text.Trim();
            string password = ActualPassword.Text.Trim();
            string repeatPassword = RepeatPassword.Text.Trim();

            // Validate input (add your validation logic here)
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repeatPassword))
            {
                // Display an error message for incomplete form
                ErrorMessage.Text = "All fields are required.";
                return;
            }

            if (!IsValidEmail(email))
            {
                // Display an error message for invalid email format
                ErrorMessage.Text = "Invalid email format.";
                return;
            }

            if (!IsValidPassword(password))
            {
                // Display an error message for invalid password
                ErrorMessage.Text = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one special character.";
                return;
            }

            if (password != repeatPassword)
            {
                // Display an error message for mismatched passwords
                ErrorMessage.Text = "Passwords do not match.";
                return;
            }

            // Insert data into the database
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check for duplicate email
                string checkDuplicateQuery = "SELECT COUNT(*) FROM [Users] WHERE Email = @Email";
                using (SqlCommand checkCmd = new SqlCommand(checkDuplicateQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    int existingUsersCount = (int)checkCmd.ExecuteScalar();

                    if (existingUsersCount > 0)
                    {
                        // Display an error message for duplicate email
                        ErrorMessage.Text = "Email is already registered.";
                        return;
                    }
                }

                // Check if the user's email is soft-deleted before allowing registration
                string checkDeletedQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND IsDeleted = 1";
                using (SqlCommand checkDeletedCmd = new SqlCommand(checkDeletedQuery, connection))
                {
                    checkDeletedCmd.Parameters.AddWithValue("@Email", email);
                    int deletedUsersCount = (int)checkDeletedCmd.ExecuteScalar();
                    if (deletedUsersCount > 0)
                    {
                        // Handle the case where the user's account is soft-deleted
                        ErrorMessage.Text = "Your account has been deactivated. Please contact support for assistance.";
                        return;
                    }
                }

                // Use parameterized query to prevent SQL injection
                string insertQuery = "INSERT INTO [Users] (Email, Name, ActualPassword, RepeatPassword) VALUES (@Email, @Name, @ActualPassword, @RepeatPassword)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@ActualPassword", password);
                    cmd.Parameters.AddWithValue("@RepeatPassword", repeatPassword);

                    // Execute the query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Registration successful
                        // Insert user's email into UserRoles table
                        string insertUserRoleQuery = "INSERT INTO [UserRoles] (Email) VALUES (@Email)";
                        using (SqlCommand userRoleCmd = new SqlCommand(insertUserRoleQuery, connection))
                        {
                            userRoleCmd.Parameters.AddWithValue("@Email", email);
                            userRoleCmd.ExecuteNonQuery();
                        }

                        // Create a User object and set user information
                        User currentUser = new User { Email = email, Name = name /* Add other properties if needed */ };

                        // Set user information in the session
                        Session["CurrentUser"] = currentUser;
                        // Optionally, you can redirect the user to a confirmation page
                        Response.Redirect("PayDeposit.aspx");
                    }
                    else
                    {
                        // Registration failed
                        // Handle the failure (e.g., display an error message)
                    }
                }
            }
        }
        // Validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool IsValidPassword(string password)
        {
            // Password must be at least 8 characters long, contain at least one uppercase letter,
            // one lowercase letter, and one special character
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }

    }
}
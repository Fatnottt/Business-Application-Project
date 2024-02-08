using Microsoft.Web.Mvc.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Business_Application_Project
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                User currentUser = Session["CurrentUser"] as User;

                if (currentUser != null)
                {
                    // User is logged in
                    // Set user's name and email in the textboxes
                    Name.Text = currentUser.Name;
                    CurrentEmail.Text = currentUser.Email;
                    UserEmailLabel.Text = $"User Email in Session: {currentUser?.Email ?? "Not available"}";
                    SessionInfoLabel.Text = $"Is CurrentUser in Session: {currentUser != null}";
                }
                else
                {
                    // Redirect to login page or handle the case when the user is not logged in
                    Response.Redirect("Login.aspx");
                }
            }

        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            string name = Name.Text.Trim();
            string currentemail = CurrentEmail.Text.Trim();
            string newemail = NewEmail.Text.Trim();

            // Validate input (add your validation logic here)
            if (!string.IsNullOrEmpty(newemail) && !IsValidEmail(newemail))
            {
                // Display an error message for invalid email format
                ErrorMessage1.Text = "Invalid email format.";
                return;
            }


            // Insert data into the database
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if current email exists
                string checkCurrentEmailQuery = "SELECT COUNT(*) FROM [Users] WHERE Email = @currentemail";
                using (SqlCommand checkCmd = new SqlCommand(checkCurrentEmailQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@currentemail", currentemail);

                    int existingUsersCount = (int)checkCmd.ExecuteScalar();

                    // Check if current email does not exist
                    if (existingUsersCount == 0)
                    {
                        // Display an error message for non-existent current email
                        ErrorMessage1.Text = "Current email does not exist.";
                        return;
                    }
                }

                // Check for duplicate email
                if (currentemail != newemail)
                {
                    // Email has changed, check for duplicate email
                    string checkDuplicateQuery = "SELECT COUNT(*) FROM [Users] WHERE Email = @newemail";
                    using (SqlCommand checkCmd = new SqlCommand(checkDuplicateQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@newemail", newemail);

                        int existingUsersCount = (int)checkCmd.ExecuteScalar();

                        // Check if email already exists
                        if (existingUsersCount > 0)
                        {
                            // Display an error message for duplicate email
                            ErrorMessage1.Text = "Email is already registered.";
                            return;
                        }
                    }
                }

                string updateQuery = "UPDATE [Users] SET Name = @Name, Email = @newemail WHERE Email = @currentemail";

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@newemail", newemail);
                    command.Parameters.AddWithValue("@currentemail", currentemail);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Check rowsAffected to determine if the update was successful
                    if (rowsAffected > 0)
                    {
                        // Update successful

                        // Update the name in the current user object in the session
                        User currentUser = Session["CurrentUser"] as User;
                        currentUser.Name = name;

                        // Update the user object in the session
                        Session["CurrentUser"] = currentUser;

                        Response.Redirect(Request.RawUrl, false);
                        Context.ApplicationInstance.CompleteRequest();

                        SuccessMessage1.Text = "User updated successfully!";
                        ErrorMessage1.Text = "";
                    }
                    else
                    {
                        // No rows affected, user not found or no changes made.
                        ErrorMessage1.Text = "User not found or no changes made.";
                        SuccessMessage1.Text = "";
                    }
                }

            }

        }
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

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            string currentpassword = CurrentPassword.Text.Trim();
            string actualpassword = ActualPassword.Text.Trim();
            string repeatpassword = RepeatPassword.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(currentpassword) || string.IsNullOrEmpty(actualpassword) || string.IsNullOrEmpty(repeatpassword))
            {
                // Display an error message for incomplete form
                ErrorMessage2.Text = "All fields are required.";
                return;
            }

            if (!IsValidPassword(actualpassword))
            {
                // Display an error message for invalid password
                ErrorMessage2.Text = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one special character.";
                return;
            }

            // Check if the new password and repeat password match
            if (actualpassword != repeatpassword)
            {
                // Display an error message for mismatched passwords
                ErrorMessage2.Text = "New password and repeat password do not match.";
                return;
            }

            // Check if the current password matches the user's actual password
            User currentUser = Session["CurrentUser"] as User;
            if (currentUser != null && currentUser.ActualPassword != currentpassword)
            {
                // Display an error message for incorrect current password
                ErrorMessage2.Text = "Incorrect current password.";
                return;
            }

            // Update the user's password in the database
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Ensure that the email is not null
                if (currentUser != null && !string.IsNullOrEmpty(currentUser.Email))
                {
                    string updatePasswordQuery = "UPDATE [Users] SET ActualPassword = @ActualPassword WHERE Email = @Email";

                    using (SqlCommand command = new SqlCommand(updatePasswordQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ActualPassword", actualpassword);
                        command.Parameters.AddWithValue("@Email", currentUser.Email);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Password update successful

                            // Update the password in the current user object in the session
                            currentUser.ActualPassword = actualpassword;

                            // Update the user object in the session
                            Session["CurrentUser"] = currentUser;

                            Response.Redirect(Request.RawUrl, false);
                            Context.ApplicationInstance.CompleteRequest();

                            SuccessMessage2.Text = "Password updated successfully!";
                            ErrorMessage2.Text = "";
                        }
                        else
                        {
                            // No rows affected, user not found or no changes made.
                            ErrorMessage2.Text = "User not found or no changes made.";
                            SuccessMessage2.Text = "";
                        }
                    }
                }
                else
                {
                    // Handle the case where the user email is null
                    ErrorMessage2.Text = "User email is missing.";
                    SuccessMessage2.Text = "";
                }
            }
        }



        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();

            // Validate input (add your validation logic here)
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                // Display an error message for incomplete form
                ErrorMessage3.Text = "All fields are required.";
                return;
            }
            if (!IsValidEmail(email))
            {
                // Display an error message for invalid email format
                ErrorMessage3.Text = "Invalid email format.";
                return;
            }

            // Delete data from the database
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if email exists
                string checkEmailQuery = "SELECT COUNT(*) FROM [Users] WHERE Email = @Email";
                using (SqlCommand checkCmd = new SqlCommand(checkEmailQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);

                    int existingUsersCount = (int)checkCmd.ExecuteScalar();

                    // Check if email does not exist
                    if (existingUsersCount == 0)
                    {
                        // Display an error message for non-existent email
                        ErrorMessage3.Text = "Email does not exist.";
                        return;
                    }
                }

                // Check if password is correct
                string checkPasswordQuery = "SELECT COUNT(*) FROM [Users] WHERE Email = @Email AND ActualPassword = @ActualPassword";
                using (SqlCommand checkCmd = new SqlCommand(checkPasswordQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);
                    checkCmd.Parameters.AddWithValue("@ActualPassword", password);

                    int existingUsersCount = (int)checkCmd.ExecuteScalar();

                    // Check if password is incorrect
                    if (existingUsersCount == 0)
                    {
                        // Display an error message for incorrect password
                        ErrorMessage3.Text = "Incorrect password.";
                        return;
                    }
                }

                // Update status in DepositTransactions table to "Pending Refund"
                string updateStatusQuery = "UPDATE DepositTransactions SET Status = @Status WHERE Email = @Email";
                using (SqlCommand updateCmd = new SqlCommand(updateStatusQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@Status", "Pending Refund");
                    updateCmd.Parameters.AddWithValue("@Email", email);
                    updateCmd.ExecuteNonQuery();
                }

                string deleteQuery = "DELETE FROM [Users] WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = command.ExecuteNonQuery();

                    // Check rowsAffected to determine if the delete was successful
                    if (rowsAffected > 0)
                    {
                        // Delete successful
                        SuccessMessage3.Text = "User deleted successfully!";
                        ErrorMessage3.Text = "";
                    }
                    else
                    {
                        // No rows affected, user not found.
                        ErrorMessage3.Text = "User not found.";
                        SuccessMessage3.Text = "";
                    }
                }
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
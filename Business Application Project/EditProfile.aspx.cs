using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Business_Application_Project
{
    public partial class EditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            string name = Name.Text;
            string currentemail = CurrentEmail.Text;
            string newemail = NewEmail.Text;

            // Validate input (add your validation logic here)
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
            string currentpassword = CurrentPassword.Text;
            string actualpassword = ActualPassword.Text;
            string repeatpassword = RepeatPassword.Text;

        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            string email = Email.Text;
            string password = Password.Text;

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
    }
}
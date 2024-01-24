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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is already logged in
                if (Session["CurrentUser"] != null)
                {
                    Response.Redirect("Main.aspx"); // Redirect to the home page or dashboard
                }

                // Check if "Remember Me" is checked
                if (Request.Cookies["RememberMe"] != null && Request.Cookies["RememberMe"]["Email"] != null)
                {
                    string email = Request.Cookies["RememberMe"]["Email"];
                    this.RmbMeCheckbox.Checked = true;
                    Email.Text = email;
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string email = Email.Text.Trim();
            string password = Password.Text.Trim();

            // Validate user input (you may want to add more sophisticated validation)
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
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

            if (Page.IsValid)
            {
                //// Authenticate user against the database
                //if (AuthenticateUser(email, password))
                //{
                //    // Create a user object (you may need to adjust this based on your User class)
                //    User currentUser = new User { Email = email };

                //    // Store user object in session
                //    Session["CurrentUser"] = currentUser;

                //    // Remember Me functionality
                //    if (RmbMeCheckbox.Checked)
                //    {
                //        HttpCookie cookie = new HttpCookie("RememberMe");
                //        cookie["Email"] = email;
                //        cookie.Expires = DateTime.Now.AddDays(30); // Set the expiration date as needed
                //        Response.Cookies.Add(cookie);
                //    }

                //    Response.Redirect("Main.aspx"); // Redirect to the home page or dashboard
                //}
                //else
                //{
                //    ErrorMessage.Text = "Invalid email or password.";
                //}
                if (AuthenticateUser(email, password, out string userName))
                {
                    // Create a user object
                    User currentUser = new User { Email = email, Name = userName };

                    // Store user object in session
                    Session["CurrentUser"] = currentUser;

                    if (RmbMeCheckbox.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("RememberMe");
                        cookie["Email"] = email;
                        cookie.Expires = DateTime.Now.AddDays(30); // Set the expiration date as needed
                        Response.Cookies.Add(cookie);
                    }

                    // Remember Me functionality...
                    Response.Redirect("Main.aspx"); // Redirect to the home page or dashboard
                }
                else
                {
                    ErrorMessage.Text = "Invalid email or password.";
                }
            }
        }

        //private bool AuthenticateUser(string email, string password)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT Email, ActualPassword, Name FROM Users WHERE Email = @Email AND ActualPassword = @Password AND Name = @Name";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Email", email);
        //            command.Parameters.AddWithValue("@Password", password);
        //            command.Parameters.AddWithValue("@Name", Name);

        //            SqlDataReader reader = command.ExecuteReader();
        //            if (reader.Read())
        //            {
        //                // User authenticated, fetch user details
        //                string userName = reader["Name"].ToString();

        //                // Create a user object (you may need to adjust this based on your User class)
        //                User currentUser = new User { Email = email, Name = userName };

        //                // Store user object in session
        //                Session["CurrentUser"] = currentUser;

        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //} 

        private bool AuthenticateUser(string email, string password, out string Name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Email, Name FROM Users WHERE Email = @Email AND ActualPassword = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        Name = reader["Name"].ToString();

                        // Create a user object (you may need to adjust this based on your User class)
                        User currentUser = new User { Email = email, Name = Name };

                        // Store user object in session
                        Session["CurrentUser"] = currentUser;
                        return true;
                    }
                }
            }

            Name = null;
            return false;
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email && addr.Host.Contains(".");
            }
            catch
            {
                return false;
            }
        }
    }
}
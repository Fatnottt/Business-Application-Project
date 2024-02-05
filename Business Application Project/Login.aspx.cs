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
                if (AuthenticateUser(email, password, out string userName, out string userRole))
                {
                    // Create a user object
                    User currentUser = new User { Email = email, Name = userName, Role = userRole };

                    // Store user object in session
                    Session["CurrentUser"] = currentUser;

                    if (RmbMeCheckbox.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("RememberMe");
                        cookie["Email"] = email;
                        cookie.Expires = DateTime.Now.AddDays(30); // Set the expiration date as needed
                        Response.Cookies.Add(cookie);
                    }

                    // Redirect based on user role
                    if (userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        Response.Redirect("AdminMain.aspx"); // Redirect to the admin dashboard
                    }
                    else
                    {
                        Response.Redirect("Main.aspx"); // Redirect to the user dashboard
                    }
                }
                else
                {
                    ErrorMessage.Text = "Invalid email or password.";
                }
            }
        }

        private bool AuthenticateUser(string email, string password, out string userName, out string userRole)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT u.Email, u.Name, r.Role FROM Users u INNER JOIN UserRoles r ON u.Email = r.Email WHERE u.Email = @Email AND u.ActualPassword = @Password";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        userName = reader["Name"].ToString();
                        userRole = reader["Role"].ToString();

                        // Create a user object (you may need to adjust this based on your User class)
                        User currentUser = new User { Email = email, Name = userName, Role = userRole };

                        // Store user object in session
                        Session["CurrentUser"] = currentUser;
                        return true;
                    }
                }
            }

            userName = null;
            userRole = null;
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
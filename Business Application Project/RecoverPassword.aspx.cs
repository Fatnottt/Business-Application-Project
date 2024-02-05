using Microsoft.Web.Mvc.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web.Configuration;
using System.Web.UI;

namespace Business_Application_Project
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        string CS = WebConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
        string GUIDvalue;
        string Uid;

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIDvalue = Request.QueryString["Uid"];

            if (!IsPostBack)
            {
                if (GUIDvalue != null)
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("SELECT TokenAuth FROM Users WHERE TokenAuth = @TokenAuth", con);
                        cmd.Parameters.AddWithValue("@TokenAuth", GUIDvalue);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            Uid = result.ToString();
                        }
                        else
                        {
                            lblMsg.Text = "Your Password Reset Link is Expired or Invalid!";
                            lblMsg.ForeColor = Color.Red;
                            // Debugging: Output values for analysis
                            System.Diagnostics.Debug.WriteLine("Uid: " + Uid);
                            System.Diagnostics.Debug.WriteLine("GUIDvalue: " + GUIDvalue);
                        }
                    }
                }
                else
                {
                    lblMsg.Text = "Your Password Reset Link is Expired or Invalid!";
                    lblMsg.ForeColor = Color.Red;
                }

                if (!string.IsNullOrEmpty(Uid))
                {
                    tbNewPass.Visible = true;
                    tbConfirmPass.Visible = true;
                    lblPassword.Visible = true;
                    lblRetypePass.Visible = true;
                    btRecPass.Visible = true;
                }
            }
        }

        protected void btRecPass_Click(object sender, EventArgs e)
        {

            // Validate input (add your validation logic here)

            if (!IsValidPassword(tbNewPass.Text))
            {
                // Display an error message for invalid password
                ErrorMessage.Text = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one special character.";
                return;
            }

            if (tbNewPass.Text != tbConfirmPass.Text)
            {
                // Display an error message for mismatched passwords
                ErrorMessage.Text = "Passwords do not match.";
                return;
            }

            if (tbNewPass.Text != "" && tbConfirmPass.Text != "" && tbNewPass.Text == tbConfirmPass.Text)
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Users SET ActualPassword = @ActualPassword, RepeatPassword = @RepeatPassword WHERE TokenAuth = @TokenAuth", con);
                    cmd.Parameters.AddWithValue("@ActualPassword", tbNewPass.Text);
                    cmd.Parameters.AddWithValue("@RepeatPassword", tbConfirmPass.Text);
                    cmd.Parameters.AddWithValue("@TokenAuth", GUIDvalue);

                    cmd.ExecuteNonQuery();
                    Response.Redirect("~/Login.aspx");
                }
            }
        }
        private bool IsValidPassword(string password)
        {
            // Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, and one special character
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}

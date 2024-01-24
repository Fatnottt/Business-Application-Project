using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Net;

namespace Business_Application_Project
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btPassRec_Click(object sender, EventArgs e)
        {
            String CS = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Email = @Email", con);
                cmd.Parameters.AddWithValue("@Email", tbEmailId.Text);

                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    String myGUID = Guid.NewGuid().ToString();
                    string email = dt.Rows[0]["Email"].ToString(); // Assuming Email is the first column in your Users table

                    SqlCommand cmd1 = new SqlCommand("UPDATE Users SET TokenAuth = @NewPassword WHERE Email = @Email", con);
                    cmd1.Parameters.AddWithValue("@NewPassword", myGUID); // You may need to hash or process this value based on your application's security requirements
                    cmd1.Parameters.AddWithValue("@Email", email);
                    cmd1.ExecuteNonQuery();


                    // send email
                    String ToEmailAddress = dt.Rows[0]["Email"].ToString();
                    String Username = dt.Rows[0]["Name"].ToString(); // Assuming Name is the second column in your Users table
                    // You can use the new TokenAuth value in the link as needed
                    String EmailBody = $"Hi {Username},<br/><br/> Click the link below to reset your password <br/><br/> https://localhost:44313/RecoverPassword.aspx?Uid={myGUID}"; MailMessage PassRecMail = new MailMessage("yatsleo@gmail.com", ToEmailAddress);
                    PassRecMail.Body = EmailBody;
                    PassRecMail.IsBodyHtml = true;
                    PassRecMail.Subject = "Reset Password";

                    SmtpClient SMTP = new SmtpClient("smtp.gmail.com", 587);
                    SMTP.Credentials = new NetworkCredential()
                    {
                        UserName = "yatsleo@gmail.com",
                        Password = "ksqs yaah ertz cdpi\r\n"
                    };
                    SMTP.EnableSsl = true;
                    SMTP.Send(PassRecMail);

                    lblPassRec.Text = "Check your email to reset your password.";
                    lblPassRec.ForeColor = Color.Green;
                }
                else
                {
                    lblPassRec.Text = "Oops! This email id does not exist in our database.";
                    lblPassRec.ForeColor = Color.Red;
                }
            }
        }

    }
}
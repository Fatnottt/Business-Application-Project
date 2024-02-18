using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System;
using System.Web.Configuration;
using System.Web.UI;

namespace Business_Application_Project
{
    public partial class AdminMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserData();
                BindTransactionsGrid();
                BindBikesData();
            }
        }


        private void BindUserData()
        {
            string constr = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT u.Email, u.Name, u.IsDeleted, ur.Role FROM Users u INNER JOIN UserRoles ur ON u.Email = ur.Email", con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            usersGridView.DataSource = dt;
                            usersGridView.DataBind();
                        }
                    }
                }
            }
        }

        protected void usersGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            usersGridView.EditIndex = e.NewEditIndex;
            BindUserData();
        }

        protected void usersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Retrieve the Email of the user being deleted
            string email = usersGridView.DataKeys[e.RowIndex].Value.ToString();

            // Soft delete the user by updating the IsDeleted column
            string constr = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET IsDeleted = 1 WHERE Email = @Email", con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Update status in DepositTransactions table to "Pending Refund"
            string updateStatusQuery = "UPDATE DepositTransactions SET Status = @Status WHERE Email = @Email";
            using (SqlConnection connection = new SqlConnection(constr))
            {
                using (SqlCommand updateCmd = new SqlCommand(updateStatusQuery, connection))
                {
                    updateCmd.Parameters.AddWithValue("@Status", "Pending Refund");
                    updateCmd.Parameters.AddWithValue("@Email", email);
                    connection.Open();
                    updateCmd.ExecuteNonQuery();
                }
            }

            // Rebind the GridView to reflect the changes
            BindUserData();
        }

        protected void usersGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = usersGridView.Rows[e.RowIndex];
            string oldEmail = usersGridView.DataKeys[e.RowIndex].Value.ToString();
            TextBox txtEmail = (TextBox)row.FindControl("txtEmail");
            TextBox txtName = (TextBox)row.FindControl("txtName");
            DropDownList ddlEditRole = (DropDownList)row.FindControl("ddlEditRole");
            DropDownList ddlEditIsDeleted = (DropDownList)row.FindControl("ddlEditIsDeleted");

            string newEmail = txtEmail.Text;
            string newName = txtName.Text;
            string newRole = ddlEditRole.SelectedValue; // Get the selected role

            bool newIsDeleted = ddlEditIsDeleted.SelectedValue == "True";

            string constr = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Email = @NewEmail, Name = @Name, IsDeleted = @IsDeleted WHERE Email = @OldEmail", con, transaction))
                        {
                            // Update Users table
                            cmd.Parameters.AddWithValue("@NewEmail", newEmail);
                            cmd.Parameters.AddWithValue("@Name", newName);
                            cmd.Parameters.AddWithValue("@IsDeleted", newIsDeleted);
                            cmd.Parameters.AddWithValue("@OldEmail", oldEmail);
                            cmd.ExecuteNonQuery();
                        }

                        // Update UserRoles table
                        using (SqlCommand cmd = new SqlCommand("UPDATE UserRoles SET Email = @NewEmail, Role = @Role WHERE Email = @OldEmail", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NewEmail", newEmail);
                            cmd.Parameters.AddWithValue("@OldEmail", oldEmail);
                            cmd.Parameters.AddWithValue("@Role", newRole);
                            cmd.ExecuteNonQuery();
                        }

                        // Update BikeInfo table
                        using (SqlCommand cmd = new SqlCommand("UPDATE BikeInfo SET Email = @NewEmail WHERE Email = @OldEmail", con, transaction))
                        {
                            cmd.Parameters.AddWithValue("@NewEmail", newEmail);
                            cmd.Parameters.AddWithValue("@OldEmail", oldEmail);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        // Handle the exception
                    }
                }
            }

            usersGridView.EditIndex = -1;
            BindUserData();
        }

        protected void usersGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            usersGridView.EditIndex = -1;
            BindUserData();
        }

        protected void usersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Attach JavaScript function to edit button click event
                LinkButton editButton = e.Row.FindControl("EditButton") as LinkButton;
                if (editButton != null)
                {
                    // Get the row index
                    int rowIndex = e.Row.RowIndex;
                    editButton.Attributes["onclick"] = $"editRow({rowIndex}); return false;";
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) != 0)
            {
                // Show update and cancel buttons in edit mode
                LinkButton updateButton = (LinkButton)e.Row.FindControl("UpdateButton");
                LinkButton cancelButton = (LinkButton)e.Row.FindControl("CancelButton");
                LinkButton editButton = (LinkButton)e.Row.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Row.FindControl("DeleteButton");

                if (updateButton != null)
                    updateButton.Visible = true;

                if (cancelButton != null)
                    cancelButton.Visible = true;

                if (editButton != null)
                    editButton.Visible = false;

                if (deleteButton != null)
                    deleteButton.Visible = false;

                // Populate the DropDownList controls with current values
                DropDownList ddlEditRole = (DropDownList)e.Row.FindControl("ddlEditRole");
                if (ddlEditRole != null)
                    ddlEditRole.SelectedValue = ((DataRowView)e.Row.DataItem)["Role"].ToString();

                DropDownList ddlEditIsDeleted = (DropDownList)e.Row.FindControl("ddlEditIsDeleted");
                if (ddlEditIsDeleted != null)
                    ddlEditIsDeleted.SelectedValue = ((DataRowView)e.Row.DataItem)["IsDeleted"].ToString();
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Show edit and delete buttons in normal mode
                LinkButton updateButton = (LinkButton)e.Row.FindControl("UpdateButton");
                LinkButton cancelButton = (LinkButton)e.Row.FindControl("CancelButton");
                LinkButton editButton = (LinkButton)e.Row.FindControl("EditButton");
                LinkButton deleteButton = (LinkButton)e.Row.FindControl("DeleteButton");

                if (updateButton != null)
                    updateButton.Visible = false;

                if (cancelButton != null)
                    cancelButton.Visible = false;

                if (editButton != null)
                    editButton.Visible = true;

                if (deleteButton != null)
                    deleteButton.Visible = true;
            }
        }

        private void BindTransactionsGrid()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            string query = "SELECT PayPalTransactionID, Email, Status FROM DepositTransactions";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                GridViewTransactions.DataSource = dataTable;
                GridViewTransactions.DataBind();
            }
        }

        protected void GridViewTransactions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Retrieve the status value from the current row
                string status = DataBinder.Eval(e.Row.DataItem, "Status").ToString();

                // Find the "Mark as Refunded" button in the current row
                Button btnMarkRefunded = (Button)e.Row.FindControl("btnMarkRefunded");

                if (status == "Pending Refund")
                {
                    // Show the button if the status is "Pending Refund"
                    btnMarkRefunded.Visible = true;
                }
            }
        }

        protected void GridViewTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Refund")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                string transactionID = GridViewTransactions.DataKeys[rowIndex]["PayPalTransactionID"].ToString();

                // Update the status to "Refunded" in the database
                UpdateTransactionStatus(transactionID, "Refunded");

                // Rebind the GridView to reflect the updated status
                BindTransactionsGrid();
            }
        }

        private void UpdateTransactionStatus(string transactionID, string status)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            string updateQuery = "UPDATE DepositTransactions SET Status = @Status WHERE PayPalTransactionID = @TransactionID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@TransactionID", transactionID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void BindBikesData()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            string query = "SELECT * FROM BikeInfo"; // Adjust query as needed

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    bikesGridView.DataSource = reader;
                    bikesGridView.DataBind();
                }
            }
        }

        protected void bikesGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            bikesGridView.EditIndex = e.NewEditIndex;
            BindBikesData();
        }

        protected void bikesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bikeID = Convert.ToInt32(bikesGridView.DataKeys[e.RowIndex].Value);

            string connectionString = WebConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            string query = "DELETE FROM Bikes WHERE BikeID = @BikeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BikeID", bikeID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            BindBikesData();
        }

        protected void bikesGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["BikieDB"].ConnectionString;
            int bikeID = Convert.ToInt32(bikesGridView.DataKeys[e.RowIndex].Value);
            string email = (bikesGridView.Rows[e.RowIndex].FindControl("lblEmail") as Label).Text;
            string location = (bikesGridView.Rows[e.RowIndex].FindControl("txtLocation") as TextBox).Text;
            string postal = (bikesGridView.Rows[e.RowIndex].FindControl("txtPostal") as TextBox).Text;
            string locality = (bikesGridView.Rows[e.RowIndex].FindControl("txtLocality") as TextBox).Text;
            string principleSubDivision = (bikesGridView.Rows[e.RowIndex].FindControl("txtPrincipleSubDivision") as TextBox).Text;
            decimal pricePerDay = Convert.ToDecimal((bikesGridView.Rows[e.RowIndex].FindControl("txtPricePerDay") as TextBox).Text);
            // Add other fields similarly

            // Retrieve existing picture values from the database
            byte[] existingPicture1Bytes = null;
            byte[] existingPicture2Bytes = null;
            byte[] existingPicture3Bytes = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string selectQuery = "SELECT BikePicture1, BikePicture2, BikePicture3 FROM BikeInfo WHERE BikeID = @BikeID";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, connection))
                {
                    selectCommand.Parameters.AddWithValue("@BikeID", bikeID);
                    connection.Open();

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            existingPicture1Bytes = reader["BikePicture1"] as byte[];
                            existingPicture2Bytes = reader["BikePicture2"] as byte[];
                            existingPicture3Bytes = reader["BikePicture3"] as byte[];
                        }
                    }
                }
            }

            // Handle file uploads for images
            FileUpload fuPicture1 = (FileUpload)bikesGridView.Rows[e.RowIndex].FindControl("fuPicture1");
            FileUpload fuPicture2 = (FileUpload)bikesGridView.Rows[e.RowIndex].FindControl("fuPicture2");
            FileUpload fuPicture3 = (FileUpload)bikesGridView.Rows[e.RowIndex].FindControl("fuPicture3");

            byte[] updatedPicture1Bytes = null;
            byte[] updatedPicture2Bytes = null;
            byte[] updatedPicture3Bytes = null;

            if (fuPicture1.HasFile)
            {
                updatedPicture1Bytes = fuPicture1.FileBytes;
            }

            if (fuPicture2.HasFile)
            {
                updatedPicture2Bytes = fuPicture2.FileBytes;
            }

            if (fuPicture3.HasFile)
            {
                updatedPicture3Bytes = fuPicture3.FileBytes;
            }

            // Update other fields in the database
            string query = @"UPDATE BikeInfo 
                    SET Email = @Email, 
                        BikeLocation = @Location,
                        BikePostal = @Postal,
                        BikeLocality = @Locality,
                        BikePrincipleSubDivision = @PrincipleSubDivision,
                        PricePerDay = @PricePerDay,
                        BikePicture1 = COALESCE(@Picture1, BikePicture1),
                        BikePicture2 = COALESCE(@Picture2, BikePicture2),
                        BikePicture3 = COALESCE(@Picture3, BikePicture3)
                    WHERE BikeID = @BikeID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Location", location);
                    command.Parameters.AddWithValue("@Postal", postal);
                    command.Parameters.AddWithValue("@Locality", locality);
                    command.Parameters.AddWithValue("@PrincipleSubDivision", principleSubDivision);
                    command.Parameters.AddWithValue("@PricePerDay", pricePerDay);
                    command.Parameters.AddWithValue("@Picture1", updatedPicture1Bytes ?? existingPicture1Bytes);
                    command.Parameters.AddWithValue("@Picture2", updatedPicture2Bytes ?? existingPicture2Bytes);
                    command.Parameters.AddWithValue("@Picture3", updatedPicture3Bytes ?? existingPicture3Bytes);
                    command.Parameters.AddWithValue("@BikeID", bikeID);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            // get output of bikesgridview index



            bikesGridView.EditIndex = -1;
            BindBikesData();
        }


        protected void bikesGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            bikesGridView.EditIndex = -1;
            BindBikesData();
        }

        protected void bikesGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && bikesGridView.EditIndex == e.Row.RowIndex)
            {
                // Find the TextBox in edit mode by its CSS class
                TextBox txtLocation = (TextBox)e.Row.FindControl("txtLocation");
                if (txtLocation != null)
                {
                    // Add a custom attribute to indicate that this TextBox is in edit mode
                    txtLocation.Attributes["data-editmode"] = "true";
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) != 0)
                {
                    // Hide image controls and show file upload controls in edit mode
                    Image imgPicture1 = (Image)e.Row.FindControl("imgPicture1");
                    if (imgPicture1 != null)
                        imgPicture1.Visible = false;

                    // Hide imgPicture2
                    Image imgPicture2 = (Image)e.Row.FindControl("imgPicture2");
                    if (imgPicture2 != null)
                        imgPicture2.Visible = false;

                    // Hide imgPicture3
                    Image imgPicture3 = (Image)e.Row.FindControl("imgPicture3");
                    if (imgPicture3 != null)
                        imgPicture3.Visible = false;
                }
                else
                {
                    // Retrieve existing picture values from the database
                    byte[] picture1Bytes = null;
                    byte[] picture2Bytes = null;
                    byte[] picture3Bytes = null;

                    object picture1Value = DataBinder.Eval(e.Row.DataItem, "BikePicture1");
                    if (picture1Value != DBNull.Value)
                    {
                        picture1Bytes = (byte[])picture1Value;
                    }

                    object picture2Value = DataBinder.Eval(e.Row.DataItem, "BikePicture2");
                    if (picture2Value != DBNull.Value)
                    {
                        picture2Bytes = (byte[])picture2Value;
                    }

                    object picture3Value = DataBinder.Eval(e.Row.DataItem, "BikePicture3");
                    if (picture3Value != DBNull.Value)
                    {
                        picture3Bytes = (byte[])picture3Value;
                    }

                    // Convert image data to base64 string for display
                    string picture1Base64 = Convert.ToBase64String(picture1Bytes);
                    string picture2Base64 = Convert.ToBase64String(picture2Bytes);
                    string picture3Base64 = Convert.ToBase64String(picture3Bytes);

                    // Determine the image format based on the byte array content
                    string picture1Format = "image/jpeg"; // Default to JPEG if format cannot be determined
                    string picture2Format = "image/jpeg";
                    string picture3Format = "image/jpeg";

                    // Check if the first few bytes of the byte array match a specific image format signature
                    if (picture1Bytes != null && picture1Bytes.Length >= 2 && picture1Bytes[0] == 0xFF && picture1Bytes[1] == 0xD8)
                    {
                        picture1Format = "image/jpeg";
                    }
                    else if (picture1Bytes != null && picture1Bytes.Length >= 2 && picture1Bytes[0] == 0x89 && picture1Bytes[1] == 0x50)
                    {
                        picture1Format = "image/png";
                    }
                    // Add more checks for other image formats as needed

                    // Set the ImageUrl and ContentType of the Image controls to display the images
                    Image imgPicture1 = (Image)e.Row.FindControl("imgPicture1");
                    if (imgPicture1 != null)
                    {
                        imgPicture1.ImageUrl = "data:" + picture1Format + ";base64," + picture1Base64;
                        imgPicture1.Attributes["ContentType"] = picture1Format;
                    }

                    Image imgPicture2 = (Image)e.Row.FindControl("imgPicture2");
                    if (imgPicture2 != null)
                    {
                        imgPicture2.ImageUrl = "data:" + picture2Format + ";base64," + picture2Base64;
                        imgPicture2.Attributes["ContentType"] = picture2Format;
                    }

                    Image imgPicture3 = (Image)e.Row.FindControl("imgPicture3");
                    if (imgPicture3 != null)
                    {
                        imgPicture3.ImageUrl = "data:" + picture3Format + ";base64," + picture3Base64;
                        imgPicture3.Attributes["ContentType"] = picture3Format;
                    }
                }
            }
        }


        protected string GetLocationData(object bikeLocation, object bikePostal, object bikeLocality, object bikePrincipleSubDivision)
        {
            string locationData = string.Format("{0}, {1}, {2}, {3}", bikeLocation, bikePostal, bikeLocality, bikePrincipleSubDivision);
            return locationData;
        }
    }
}
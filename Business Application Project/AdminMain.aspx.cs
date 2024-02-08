using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System;

namespace Business_Application_Project
{
    public partial class AdminMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserData();
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
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Email = @NewEmail, Name = @Name, IsDeleted = @IsDeleted WHERE Email = @OldEmail", con))
                {
                    cmd.Parameters.AddWithValue("@NewEmail", newEmail);
                    cmd.Parameters.AddWithValue("@Name", newName);
                    cmd.Parameters.AddWithValue("@IsDeleted", newIsDeleted);
                    cmd.Parameters.AddWithValue("@OldEmail", oldEmail);
                    cmd.ExecuteNonQuery();
                }

                // Update the role
                using (SqlCommand cmd = new SqlCommand("UPDATE UserRoles SET Role = @NewRole WHERE Email = @Email", con))
                {
                    cmd.Parameters.AddWithValue("@NewRole", newRole);
                    cmd.Parameters.AddWithValue("@Email", newEmail);
                    cmd.ExecuteNonQuery();
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
    }
}
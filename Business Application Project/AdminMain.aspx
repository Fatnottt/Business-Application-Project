<%@ Page Title="" Language="C#" MasterPageFile="~/AdminNavbar.Master" AutoEventWireup="true" CodeBehind="AdminMain.aspx.cs" Inherits="Business_Application_Project.AdminMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- ======= Content Area ======= -->
    <div id="content-area" class="text-center">
        <!-- Content for Users -->
        <div id="users-content">
            <h2>Users Information</h2>
            <asp:GridView ID="usersGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowEditing="usersGridView_RowEditing" OnRowDeleting="usersGridView_RowDeleting" OnRowUpdating="usersGridView_RowUpdating" OnRowCancelingEdit="usersGridView_RowCancelingEdit" OnRowDataBound="usersGridView_RowDataBound" DataKeyNames="Email">
                <Columns>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Role">
                        <ItemTemplate>
                            <asp:Label ID="lblRole" runat="server" Text='<%# Eval("Role") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditRole" runat="server" SelectedValue='<%# Bind("Role") %>'>
                                <asp:ListItem Value="User">User</asp:ListItem>
                                <asp:ListItem Value="Admin">Admin</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IsDeleted">
                        <ItemTemplate>
                            <asp:Label ID="lblIsDeleted" runat="server" Text='<%# Eval("IsDeleted") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditIsDeleted" runat="server">
                                <asp:ListItem Value="True">True</asp:ListItem>
                                <asp:ListItem Value="False">False</asp:ListItem>
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="EditButton" runat="server" CssClass="btn btn-primary editButton" CommandName="Edit">
                                <i class="bi bi-pencil-square"></i> Edit
                            </asp:LinkButton>
                            <asp:LinkButton ID="DeleteButton" runat="server" CssClass="btn btn-danger" CommandName="Delete">
                                <i class="bi bi-trash-fill"></i> Delete
                            </asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="UpdateButton" runat="server" CssClass="btn btn-success" CommandName="Update">
                                <i class="bi bi-check-square-fill"></i> Update
                            </asp:LinkButton>
                            <asp:LinkButton ID="CancelButton" runat="server" CssClass="btn btn-secondary" CommandName="Cancel">
                                <i class="bi bi-x-square-fill"></i> Cancel
                            </asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>


        <!-- Content for Transactions -->
        <div id="transactions-content" style="display: none;">
            <h2>Transactions Content</h2>
            <p>This is where Transactions content will appear.</p>
        </div>

        <!-- Content for Bikes -->
        <div id="bikes-content" style="display: none;">
            <h2>Bikes Content</h2>
            <p>This is where Bikes content will appear.</p>
        </div>
    </div>
    <!-- End Content Area -->
</asp:Content>

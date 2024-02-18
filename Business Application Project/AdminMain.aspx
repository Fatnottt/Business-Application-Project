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
            <h2>Security Deposit Transactions</h2>
            <asp:GridView ID="GridViewTransactions" runat="server" AutoGenerateColumns="False" CssClass="container" OnRowCommand="GridViewTransactions_RowCommand" DataKeyNames="PayPalTransactionID" OnRowDataBound="GridViewTransactions_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="PayPalTransactionID" HeaderText="Transaction ID" SortExpression="PayPalTransactionID" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnMarkRefunded" runat="server" Text="Mark as Refunded" CommandName="Refund" CommandArgument='<%# Container.DataItemIndex %>' Visible="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <!-- Content for Bikes -->
        <div id="bikes-content" style="display: none;">
            <h2>Bikes Content</h2>
            <div class="container-fluid">
                <div style="overflow-x: auto;">
                    <contenttemplate>
                        <asp:GridView ID="bikesGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowEditing="bikesGridView_RowEditing" OnRowDeleting="bikesGridView_RowDeleting" OnRowUpdating="bikesGridView_RowUpdating" OnRowCancelingEdit="bikesGridView_RowCancelingEdit" OnRowDataBound="bikesGridView_RowDataBound" DataKeyNames="BikeID">
                            <Columns>
                                <asp:TemplateField HeaderText="Bike ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblBikeID" runat="server" Text='<%# Eval("BikeID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Picture 1">
                                    <ItemTemplate>
                                        <asp:Image ID="imgPicture1" runat="server" ImageUrl='<%# Eval("BikePicture1") %>' Height="100" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:FileUpload ID="fuPicture1" runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Picture 2">
                                    <ItemTemplate>
                                        <asp:Image ID="imgPicture2" runat="server" ImageUrl='<%# Eval("BikePicture2") %>' Height="100" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:FileUpload ID="fuPicture2" runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Picture 3">
                                    <ItemTemplate>
                                        <asp:Image ID="imgPicture3" runat="server" ImageUrl='<%# Eval("BikePicture3") %>' Height="100" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:FileUpload ID="fuPicture3" runat="server" />
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Location">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLocation" runat="server" Text='<%# GetLocationData(Eval("BikeLocation"), Eval("BikePostal"), Eval("BikeLocality"), Eval("BikePrincipleSubDivision")) %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtLocation" CssClass="editLocationTextBox" runat="server" Text='<%# Eval("BikeLocation") %>'></asp:TextBox>
                                        <asp:TextBox ID="txtPostal" runat="server" Text='<%# Eval("BikePostal") %>'></asp:TextBox>
                                        <asp:TextBox ID="txtLocality" runat="server" Text='<%# Eval("BikeLocality") %>'></asp:TextBox>
                                        <asp:TextBox ID="txtPrincipleSubDivision" runat="server" Text='<%# Eval("BikePrincipleSubDivision") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price Per Day">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPricePerDay" runat="server" Text='<%# Eval("PricePerDay") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtPricePerDay" runat="server" Text='<%# Bind("PricePerDay") %>'></asp:TextBox>
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
                    </contenttemplate>
                </div>
            </div>
        </div>
    </div>
    <!-- End Content Area -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maps.google.com/maps/api/js?key=AIzaSyDoA6MbjzIVBqN-jCDIGz_gfIlqBuSHfpw&libraries=places"></script>
    <script>
        function initializeAutocomplete() {
            // Get all TextBoxes with the editLocationTextBox class
            var textBoxes = document.querySelectorAll('.editLocationTextBox[data-editmode="true"]');
            textBoxes.forEach(function (textbox) {
                var autocomplete = new google.maps.places.Autocomplete(textbox, { types: ['geocode'] });
                autocomplete.addListener('place_changed', function () {
                    var place = autocomplete.getPlace();
                    textbox.nextElementSibling.value = place.address_components[place.address_components.length - 1].long_name;
                    textbox.nextElementSibling.nextElementSibling.value = place.address_components[place.address_components.length - 2].long_name;
                    textbox.nextElementSibling.nextElementSibling.nextElementSibling.value = place.address_components[place.address_components.length - 3].long_name;
                });
            });
        }
        google.maps.event.addDomListener(window, 'load', initializeAutocomplete);
    </script>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Business_Application_Project.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Product</h2>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-md-2" for="Id">Id</label>
            <div class="col-md-10">
                <asp:TextBox ID="Id" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-md-2" for="Name">Name</label>
            <div class="col-md-10">
                <asp:TextBox ID="Name" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Name" CssClass="text-danger" ErrorMessage="The Name field is required." />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-md-2" for="Price">Price</label>
            <div class="col-md-10">
                <asp:TextBox ID="Price" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Price" CssClass="text-danger" ErrorMessage="The Price field is required." />
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="Price" CssClass="text-danger" ErrorMessage="The Price field must be a positive number." MaximumValue="999999" MinimumValue="0" Type="Double" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-md-2" for="Category">Category</label>
            <div class="col-md-10">
                <asp:TextBox ID="Category" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Category" CssClass="text-danger" ErrorMessage="The Category field is required." />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-md-2" for="Description">Description</label>
            <div class="col-md-10">
                <asp:TextBox ID="Description" runat="server" CssClass="form-control" TextMode="MultiLine" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="EditButton" runat="server" CssClass="btn btn-default" Text="Save" OnClick="EditButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>

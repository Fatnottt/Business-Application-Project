<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="Business_Application_Project.Delete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delete Product</h2>
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
                <asp:TextBox ID="Name" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-md-2" for="Price">Price</label>
            <div class="col-md-10">
                <asp:TextBox ID="Price" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-md-2" for="Category">Category</label>
            <div class="col-md-10">
                <asp:TextBox ID="Category" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
        </div>
        <div class="form-group">
            <label class="control-label col-md-2" for="Description">Description</label>
            <div class="col-md-10">
                <asp:TextBox ID="Description" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="DeleteButton" runat="server" CssClass="btn btn-default" Text="Delete" OnClick="DeleteButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SeeCart.aspx.cs" Inherits="Business_Application_Project.SeeCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gvShoppingCart" runat="server" AutoGenerateColumns="False" CssClass="grid-view-padding"  DataKeyNames="ShoppingCart_ID" OnRowCancelingEdit="gvShoppingCart_RowCancelingEdit" OnRowDeleting="gvShoppingCart_RowDeleting" OnRowEditing="gvShoppingCart_RowEditing" OnRowUpdating="gvShoppingCart_RowUpdating" OnSelectedIndexChanged="gvShoppingCart_SelectedIndexChanged1">
     
        <Columns>
            <asp:BoundField DataField="ShoppingCart_ID" HeaderText="Cart ID" />
            <asp:BoundField DataField="Product_ID" HeaderText="Product ID" />
            <asp:BoundField DataField="Product_Desc" HeaderText="Product description"/>
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Brand" HeaderText="Brand" />
            <asp:BoundField DataField="Model" HeaderText="Model" />
            <asp:BoundField DataField="Unit_Price" HeaderText="Unit Price" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Datein" HeaderText="Datein" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
            <asp:BoundField DataField="Dateout" HeaderText="Dateout" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
            <asp:CommandField ShowSelectButton="False" ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>

    &nbsp;<br />
    <br />
    <asp:Button ID="btn_Back" runat="server" Text="Back to products page" OnClick="btn_Back_Click" />
</asp:Content>
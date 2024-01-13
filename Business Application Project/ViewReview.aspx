<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewReview.aspx.cs" Inherits="Business_Application_Project.ReviewDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvHistory_SelectedIndexChanged" DataKeyNames="Product_ID" OnRowCancelingEdit="gvHistory_RowCancelingEdit" OnRowEditing="gvHistory_RowEditing" OnRowUpdating="gvHistory_RowUpdating">
        <Columns>
            <asp:BoundField DataField="Product_ID" HeaderText="Product ID" />
            <asp:BoundField DataField="Rating" HeaderText="Rating" />
            <asp:BoundField DataField="Review" HeaderText="Review" />

            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    
</asp:Content>

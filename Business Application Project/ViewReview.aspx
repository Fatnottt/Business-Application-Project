<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="ViewReview.aspx.cs" Inherits="Business_Application_Project.ReviewDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Your Reviews</h1>
   <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" DataKeyNames="Product_ID" OnRowCancelingEdit="gvHistory_RowCancelingEdit" OnRowEditing="gvHistory_RowEditing" OnRowUpdating="gvHistory_RowUpdating" Width="100%">
        <Columns>
            <asp:TemplateField HeaderText="Product ID" SortExpression="Product_ID">
            <ItemTemplate>
                <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("Product_ID") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtProductID" runat="server" Text='<%# Bind("Product_ID") %>' ReadOnly="true"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Rating" SortExpression="Rating">
            <EditItemTemplate>
                <asp:RadioButtonList ID="rblEditRating" runat="server" Width="334px">
                    <asp:ListItem Value="1 - Terrible"></asp:ListItem>
                    <asp:ListItem Value="2 - Poor"></asp:ListItem>
                    <asp:ListItem Value="3 - Fair"></asp:ListItem>
                    <asp:ListItem Value="4 - Good"></asp:ListItem>
                    <asp:ListItem Value="5 - Excellent"></asp:ListItem>
                </asp:RadioButtonList>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblRating" runat="server" Text='<%# Bind("Rating") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Review" SortExpression="Reviews">
            <EditItemTemplate>
                <asp:TextBox ID="txtEditReview" runat="server" Text='<%# Bind("Reviews") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lblReview" runat="server" Text='<%# Bind("Reviews") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" />

        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click" />
</asp:Content>

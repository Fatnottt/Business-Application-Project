<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewReview.aspx.cs" Inherits="Business_Application_Project.ReviewDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False" DataKeyNames="Product_ID" OnRowCancelingEdit="gvHistory_RowCancelingEdit" OnRowEditing="gvHistory_RowEditing" OnRowUpdating="gvHistory_RowUpdating">
        <Columns>
            <asp:BoundField DataField="Product_ID" HeaderText="Product ID" />
            
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
            <asp:BoundField DataField="Reviews" HeaderText="Review" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Business_Application_Project.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style3 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>PRODUCT DETAILS</h2>
    <table class="auto-style3">
        <tr>
            <td rowspan="3">
                <asp:Image ID="img_Product" runat="server" Height="103px" Width="107px" />
            </td>
            <td>
                <strong>
                    <asp:Label ID="lbl_Brand" runat="server"></asp:Label>
                </strong>
                <asp:Label ID="lbl_Model" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_Category" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_Address" runat="server"></asp:Label><br />
                <asp:Label ID="lbl_ProdDesc" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <strong>
                <asp:Label ID="lbl_Price" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btn_Add" runat="server" Text="Add to Cart" OnClick="btn_Add_Click" />
                </strong>
            </td>
        </tr>
    </table>
</asp:Content>

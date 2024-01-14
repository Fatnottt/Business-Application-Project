<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="InsertReview.aspx.cs" Inherits="Business_Application_Project.InsertReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 69px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Review</h1>
    <table class="auto-style1">
        <tr>
            <td>Product ID</td>
            <td>
                <asp:TextBox ID="tb_Product_ID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Product_ID" runat="server" ControlToValidate="tb_Product_ID" ErrorMessage="Please enter Product ID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Rating</td>
            <td>
                <asp:RadioButtonList ID="rbl_Rating" runat="server" Width="334px">
                    <asp:ListItem Value="1 - Terrible"></asp:ListItem>
                    <asp:ListItem Value="2 - Poor"></asp:ListItem>
                    <asp:ListItem Value="3 - Fair"></asp:ListItem>
                    <asp:ListItem Value="4 - Good"></asp:ListItem>
                    <asp:ListItem Value="5 - Excellent"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Rate" runat="server" ControlToValidate="rbl_Rating" ErrorMessage="Please rate" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Comment</td>
            <td class="auto-style2">
                <asp:TextBox ID="tb_Review" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" OnClick="btn_Submit_Click" />
            </td>
            <td>
                 <asp:Button ID="btn_ViewReview" runat="server" Text="View Reviews" OnClick="btn_ViewReview_Click" CausesValidation="false" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

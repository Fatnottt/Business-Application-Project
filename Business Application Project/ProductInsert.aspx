<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="ProductInsert.aspx.cs" Inherits="Business_Application_Project.ProductInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        height: 74px;
    }


</style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

                        
          

    <table class="auto-style2">
        <%--<tr>
            <td>Product ID</td>
            <td>
                <asp:TextBox ID="tb_ProductID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_ProductID" runat="server" ControlToValidate="tb_ProductID" ErrorMessage="Please enter Product ID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td>Brand</td>
            <td>
                <asp:TextBox ID="tb_Brand" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Brand" runat="server" ControlToValidate="tb_Brand" ErrorMessage="Please enter a brand for your bicycle." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Model</td>
            <td>
                <asp:TextBox ID="tb_Model" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Model" runat="server" ControlToValidate="tb_Model" ErrorMessage="Please enter a model for your bicycle." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Category</td>
            <td>
                <asp:TextBox ID="tb_Category" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Category" runat="server" ControlToValidate="tb_Category" ErrorMessage="Please enter a category for your bicycle." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Price</td>
            <td class="auto-style3">
                <asp:TextBox ID="tb_UnitPrice" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="rfv_UnitPrice" runat="server" ControlToValidate="tb_UnitPrice" ErrorMessage="Please enter a Unit Price for the product." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cv_UnitPrice" runat="server" ControlToValidate="tb_UnitPrice" ErrorMessage="Only Numeric value is allowed" ForeColor="Red" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Product Desc</td>
            <td>
                <asp:TextBox ID="tb_ProductDesc" runat="server" Rows="10" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_ProductDesc" runat="server" ControlToValidate="tb_ProductDesc" ErrorMessage="Please enter a description for the product." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Address</td>
            <td>
                <asp:TextBox ID="tb_Address" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_Address" runat="server" ControlToValidate="tb_Address" ErrorMessage="Please enter the address of your bicycle." ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Product Image</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_ProductImage" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please select a Product Image" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lbl_Result" runat="server" ></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btn_Insert" runat="server" Text="Insert" OnClick="btn_Insert_Click" />
                <asp:Button ID="btn_ProductView" runat="server" Text="View Product List" OnClick="btn_ProductView_Click" CausesValidation="False" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
    Validation error message:
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" />
</asp:Content>

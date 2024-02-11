<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SeeCart.aspx.cs" Inherits="Business_Application_Project.SeeCart"  EnableViewState="true"%> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
    /* CSS for GridView */
    .grid-view-padding {
        padding: 10px;
    }
    .grid-view-header {
        background-color: #46978a;
        color: white;
    }
    .grid-view-row {
        background-color: #b7d5ce;
    }
    .grid-view-row:hover {
        background-color: #a0c7bf; 
    }
    .grid-view-alternating-row {
        background-color: #dbeae6;
    }
    .grid-view-table {
        border-collapse: collapse;
    }
    .grid-view-table th,
    .grid-view-table td {
        border: 1px solid #504b4c;
        padding: 8px;
    }
    .edit-button,
    .delete-button {
        background-color: #007bff;
        color: white;
        border: none;
        padding: 8px 12px;
        cursor: pointer;
    }
    .edit-button:hover,
    .delete-button:hover {
        opacity: 0.8;
    }

    /* CSS for buttons */
    .button {
        background-color: #008374;
        color: black;
        border: none;
        padding: 10px 20px;
        cursor: pointer;
        border-radius: 5px; /* Adding rounded corners */
    }
    .button:hover {
        opacity: 0.8;
    }
</style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <%-- <asp:GridView ID="gvShoppingCart" runat="server" AutoGenerateColumns="False" CssClass="grid-view-padding grid-view-table"
    DataKeyNames="ShoppingCart_ID" OnRowCancelingEdit="gvShoppingCart_RowCancelingEdit"
    OnRowDeleting="gvShoppingCart_RowDeleting" OnRowEditing="gvShoppingCart_RowEditing" OnRowUpdating="gvShoppingCart_RowUpdating"
    OnSelectedIndexChanged="gvShoppingCart_SelectedIndexChanged1" OnRowDataBound="gvShoppingCart_RowDataBound" Width="100%">--%>

    <asp:GridView ID="gvShoppingCart" runat="server" AutoGenerateColumns="False" CssClass="grid-view-padding grid-view-table"
    DataKeyNames="ShoppingCart_ID" 
    OnRowCancelingEdit="gvShoppingCart_RowCancelingEdit"
    OnRowDeleting="gvShoppingCart_RowDeleting" 
    OnRowEditing="gvShoppingCart_RowEditing" 
    OnRowUpdating="gvShoppingCart_RowUpdating"
    OnSelectedIndexChanged="gvShoppingCart_SelectedIndexChanged1" 
    OnRowDataBound="gvShoppingCart_RowDataBound" Width="100%">


    <HeaderStyle CssClass="grid-view-header" />
    <RowStyle CssClass="grid-view-row" />
    <AlternatingRowStyle CssClass="grid-view-alternating-row" />
    <Columns>

    

        <asp:TemplateField HeaderText="Select">
            <ItemTemplate>
                <asp:CheckBox ID="chkSelect" runat="server" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:BoundField DataField="ShoppingCart_ID" HeaderText="Cart ID" />
        <asp:BoundField DataField="Product_ID" HeaderText="Product ID" />
        <asp:BoundField DataField="Product_Desc" HeaderText="Product description" />
        <asp:BoundField DataField="Category" HeaderText="Category" />
        <asp:BoundField DataField="Brand" HeaderText="Brand" />
        <asp:BoundField DataField="Model" HeaderText="Model" />
        <asp:BoundField DataField="Unit_Price" HeaderText="Unit Price" DataFormatString="{0:c}" />
        <asp:BoundField DataField="Address" HeaderText="Address" />

        
        <asp:TemplateField HeaderText="Start Date" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Datein" runat="server" Text='<%# Bind("Datein", "{0:yyyy-MM-dd}") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txt_Datein" runat="server" Text='<%# Bind("Datein", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfv_Datein" runat="server" ControlToValidate="txt_Datein"
            ErrorMessage="Date is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="cv_Datein" runat="server" ControlToValidate="txt_Datein"
            ErrorMessage="Invalid date format. Use YYYY-MM-DD." Display="Dynamic" ForeColor="Red"
            ClientValidationFunction="validateDate"></asp:CustomValidator>
    </EditItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="End Date" ItemStyle-HorizontalAlign="Center">
    <ItemTemplate>
        <asp:Label ID="lbl_Dateout" runat="server" Text='<%# Bind("Dateout", "{0:yyyy-MM-dd}") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txt_Dateout" runat="server" Text='<%# Bind("Dateout", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfv_Dateout" runat="server" ControlToValidate="txt_Dateout"
            ErrorMessage="Date is required." Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="cv_Dateout" runat="server" ControlToValidate="txt_Dateout"
            ErrorMessage="Invalid date format. Use YYYY-MM-DD." Display="Dynamic" ForeColor="Red"
            ClientValidationFunction="validateDate"></asp:CustomValidator>
    </EditItemTemplate>
</asp:TemplateField>

       
        

        <asp:TemplateField HeaderText="Total Price">
            <ItemTemplate>
                <asp:Label ID="lblTotalPrice" runat="server" Text="$ "></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>

        <asp:CommandField CausesValidation="false" ShowSelectButton="False" ShowDeleteButton="True" ShowEditButton="True" />

      <%--<asp:TemplateField>
    <ItemTemplate>
        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" Text="Edit" />
    </ItemTemplate>
    <EditItemTemplate>
        <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Text="Update" />
        <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" Text="Cancel" />
    </EditItemTemplate>
</asp:TemplateField>--%>



    </Columns>
</asp:GridView>

   
      
 
    
    <br />
    <br />
    Total Amount: 
    <asp:Label ID="lblSelectedTotalAmount" runat="server" Text=""></asp:Label> <br /> <br />

    <asp:Button ID="btn_Back" runat="server" Text="Back to Products Page" CssClass="button" OnClick="btn_Back_Click" /> &nbsp;
<asp:Button ID="btnCalculateTotalAmount" runat="server" Text="Calculate Total Amount" CssClass="button" OnClick="btnCalculateTotalAmount_Click" /> &nbsp;
<asp:Button ID="btnRentNow" runat="server" Text="Rent Now" CssClass="button" OnClick="btnRentNow_Click" />




</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewCart.aspx.cs" Inherits="Business_Application_Project.ViewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentPlaceHolder1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:GridView ID="gv_CartView" runat="server" AutoGenerateColumns="False" DataKeyNames="ItemID" OnRowCommand="gv_CartView_RowCommand">
        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="Product ID"></asp:BoundField>
            <asp:BoundField DataField="Product_Desc" HeaderText="Product Description"></asp:BoundField>
            <asp:BoundField DataField="Category" HeaderText="Category"></asp:BoundField>
            <asp:BoundField DataField="Brand" HeaderText="Brand"></asp:BoundField>
            <asp:BoundField DataField="Model" HeaderText="Model"></asp:BoundField>
            <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="tb_Quantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:TextBox>
               <asp:LinkButton ID="btn_Remove" runat="server" CommandArgument='<%# Eval("ItemID") %>' CommandName="Remove">Remove</asp:LinkButton>
                </ItemTemplate>
                
            </asp:TemplateField>
            <asp:BoundField DataField="Product_Price" DataFormatString="{0:C}" HeaderText="Unit Price"></asp:BoundField>
            <asp:BoundField DataField="TotalPrice" DataFormatString="{0:C}" HeaderText="Price"></asp:BoundField>
        </Columns>
    </asp:GridView>

    <br />
    Total Price:
    <asp:Label ID="lbl_TotalPrice" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lbl_Error" runat="server"></asp:Label>
    <br />
    <br />
    <div>
        <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
        <asp:Button ID="btn_Clear" runat="server" Text="Clear" OnClick="btn_Clear_Click" />
        <asp:Button ID="btn_Back" runat="server" Text="Back" OnClick="btn_Back_Click" />
    </div>
    <br />
    

</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductInsert.aspx.cs" Inherits="Business_Application_Project.ProductInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style3 {
        height: 74px;
    }

    /*// containers //
.container-wrapper {
  background-color: #EDF0F9;
}

.container {
  height: 100vh;
}

.rating-wrapper {
  align-self: center;
  box-shadow: 7px 7px 25px rgba(198, 206, 237, .7),
              -7px -7px 35px rgba(255, 255, 255, .7),
              inset 0px 0px 4px rgba(255, 255, 255, .9),
              inset 7px 7px 15px rgba(198, 206, 237, .8); 
  border-radius: 5rem;
  display: inline-flex;
  direction: rtl !important;
  padding: 1.5rem 2.5rem;
  margin-left: auto;
  

  label {
    color: #E1E6F6;
    cursor: pointer;
    display: inline-flex;
    font-size: 3rem;
    padding: 1rem .6rem;
    transition: color 0.5s;
  }
  
   svg {
     -webkit-text-fill-color: transparent;
     -webkit-filter: drop-shadow (4px 1px 6px rgba(198, 206, 237, 1));
     filter:drop-shadow(5px 1px 3px rgba(198, 206, 237, 1));
  }

  input {
    height: 100%;
    width: 100%;
  }
  
  input {
    display: none;
  }

  label:hover,
  label:hover ~ label,
  input:checked ~ label  {
    color: #34AC9E;
  }

  label:hover,
  label:hover ~ label,
  input:checked ~ label  {
    color: #34AC9E;
  }*/


</style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

                        



<%--<div class="container-wrapper">  
  <div class="container d-flex align-items-center justify-content-center">
    <div class="row justify-content-center">    
      
      <!-- star rating -->
      <div class="rating-wrapper">
        
        <!-- star 5 -->
        <input type="radio" id="5-star-rating" name="star-rating" value="5">
        <label for="5-star-rating" class="star-rating">
          <i class="fas fa-star d-inline-block"></i>
        </label>
        
         <!-- star 4 -->
        <input type="radio" id="4-star-rating" name="star-rating" value="4">
        <label for="4-star-rating" class="star-rating star">
          <i class="fas fa-star d-inline-block"></i>
        </label>
        
         <!-- star 3 -->
        <input type="radio" id="3-star-rating" name="star-rating" value="3">
        <label for="3-star-rating" class="star-rating star">
          <i class="fas fa-star d-inline-block"></i>
        </label>
        
        <!-- star 2 -->
        <input type="radio" id="2-star-rating" name="star-rating" value="2">
        <label for="2-star-rating" class="star-rating star">
          <i class="fas fa-star d-inline-block"></i>
        </label>
        
        <!-- star 1 -->
        <input type="radio" id="1-star-rating" name="star-rating" value="1">
        <label for="1-star-rating" class="star-rating star">
          <i class="fas fa-star d-inline-block"></i>
        </label>
        
       </div>
      
    </div>
  </div>
</div>--%>
          

    <table class="auto-style2">
        <tr>
            <td>Product ID</td>
            <td>
                <asp:TextBox ID="tb_ProductID" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfv_ProductID" runat="server" ControlToValidate="tb_ProductID" ErrorMessage="Please enter Product ID" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
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

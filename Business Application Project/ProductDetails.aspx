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
    <asp:HiddenField ID="hf_shoppingcartID" runat="server" />
    <asp:HiddenField ID="hf_productID" runat="server" />
    <%--verlyn dh this--%>
    <table class="auto-style3">
        <tr>
            <td rowspan="3">
                <asp:Image ID="img_Product" runat="server" Height="103px" Width="107px" />
            </td>
            <td>
                <strong>
                    <asp:Label ID="lbl_Brand" runat="server"></asp:Label>
                    <asp:Label ID="lbl_ProdID" runat="server"></asp:Label>
                    <%--verlyn dh this--%>
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

                    <!-- Add a TextBox for entering a date -->
                    <%--<asp:TextBox ID="txt_Date" runat="server" placeholder="Enter Date of rent" TextMode="Date"></asp:TextBox> <br />
<asp:RequiredFieldValidator ID="rfv_Date" runat="server" ControlToValidate="txt_Date"
    ErrorMessage="Date is required. " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="rev_Date" runat="server" ControlToValidate="txt_Date"
    ErrorMessage="Invalid date format. Use YYYY-MM-DD." Display="Dynamic" ForeColor="Red"
    ValidationExpression="\d{4}-\d{2}-\d{2}"></asp:RegularExpressionValidator>--%>


                    <asp:TextBox ID="txt_Date" runat="server" placeholder="Enter Date of rent" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Date" runat="server" ControlToValidate="txt_Date"
                        ErrorMessage="Date is required. " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cv_Date" runat="server" ControlToValidate="txt_Date"
                        ErrorMessage="Invalid date format. Use YYYY-MM-DD." Display="Dynamic" ForeColor="Red"
                        ClientValidationFunction="validateDate"></asp:CustomValidator>

                    <script type="text/javascript">
                        function validateDate(sender, args) {
                            var enteredDate = document.getElementById('<%=txt_Date.ClientID %>').value;
                            var dateRegex = /^\d{4}-\d{2}-\d{2}$/;

                            if (!dateRegex.test(enteredDate)) {
                                args.IsValid = false;
                            } else {
                                args.IsValid = true;
                            }
                        }
                    </script>



                    <br />
                    <br />
                    <asp:Button ID="btn_Add" runat="server" Text="Add to Cart" OnClick="btn_Add_Click" />
                    <asp:Button ID="btn_SeeCart" runat="server" Text="Go To Cart" OnClick="btn_SeeCart_Click" />
                </strong>
            </td>
        </tr>
    </table>
    <br />


    <%--yuki's reviews part--%>
    <h2>Customer Reviews</h2>

    <div>
        <!-- Display the number of reviews -->
        <asp:Label ID="lbl_ReviewCount" runat="server" Text="0 Review" />

        <br />
        <br />
        <!-- Display reviews dynamically (you can use a Repeater or GridView) -->
        <asp:Repeater ID="rptReviews" runat="server">
        <ItemTemplate>
            <div class="review-item">
                <div>
                    <span class="stars">
                        <%# GetStarIcons(Eval("Stars")) %>
                    </span>
                    <span class="reviewer-email">
                        <%# Eval("User_Email") %>
                    </span>
                    <span class="review-date">
                        <%# Eval("Review_Date", "{0:dd/MM/yyyy}") %>
                    </span>

                </div>
                <div class="comment">
                    <%# Eval("Comment") %>
                </div>
            </div>
        </ItemTemplate>
        </asp:Repeater>

    </div>
    <%--reviews--%>

</asp:Content>

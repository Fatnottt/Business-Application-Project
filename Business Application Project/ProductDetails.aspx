
<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Business_Application_Project.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style3 {
            width: 50%;
        }

        .custReviews {
            padding: 20px; 
            background-color: #d5e9e6; 
        }

        .review-item {
            border: none; 
            padding: 15px; 
            margin-bottom: 20px; 
            background-color: #e6f2f0; 
            position: relative;
        }

        .review-header {
            margin-bottom: 10px; 
        }


        .reviewer-name {
            font-weight: bold;
            font-size: 18px;
        }

        .stars {
            color: #008374; 
            font-size: 22px;
        }

        .review-date {
            font-size: 13px;
            font-style: italic;
            position: absolute; 
            top: 17px;
            right: 17px; 
    
        }

        .comment {
            margin-top: 25px; 
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

                    Enter rental date:
                    <asp:TextBox ID="txt_Datein" runat="server" placeholder="Enter Date of rent" TextMode="Date"></asp:TextBox>
                    &nbsp; to
                    <asp:TextBox ID="txt_Dateout" runat="server" placeholder="Enter Date of rent" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_Datein" runat="server" ControlToValidate="txt_Datein"
                        ErrorMessage="Date is required. " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cv_Datein" runat="server" ControlToValidate="txt_Datein"
                        ErrorMessage="Invalid date format. Use YYYY-MM-DD." Display="Dynamic" ForeColor="Red"
                        ClientValidationFunction="validateDate"></asp:CustomValidator>


                    <asp:RequiredFieldValidator ID="rfv_Dateout" runat="server" ControlToValidate="txt_Dateout"
                        ErrorMessage="Date is required. " Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cv_Dateout" runat="server" ControlToValidate="txt_Dateout"
                        ErrorMessage="Invalid date format. Use YYYY-MM-DD." Display="Dynamic" ForeColor="Red"
                        ClientValidationFunction="validateDate"></asp:CustomValidator>

                    <script type="text/javascript">
                        function validateDate(sender, args) {
                            var enteredDate = sender.source.clientvalidationfunction == "txt_Date.ClientID" ?
                                document.getElementById('<%=txt_Datein.ClientID %>').value :
            document.getElementById('<%=txt_Dateout.ClientID %>').value;
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
    <div class="custReviews">
        <h2>Reviews <asp:Label ID="lbl_ReviewCount" runat="server" CssClass="review-count" /></h2>

        <div>
            <br />

            <asp:Repeater ID="rptReviews" runat="server">
            <ItemTemplate>
                <div class="review-item">
                    <div class="review-header">
                        <span class="reviewer-name">
                            <%# Eval("User_Name") %>
                        </span>
                        <br />
                        <span class="stars">
                            <%# GetStarIcons(Eval("Stars")) %>
                        </span>
                        <br />
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
    </div>
    <%--reviews--%>
</asp:Content>
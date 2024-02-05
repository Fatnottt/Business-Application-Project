<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RateForm.aspx.cs" Inherits="Business_Application_Project.RateForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Add your custom styling for stars here */
        .star {
            font-size: 25px;
            cursor: pointer;
            color: gray;
        }

        .star.checked {
            color: gold;
        }
    </style>

    <script>
        // JavaScript for the star rating
        function setRating(rating) {
            // Reset all stars to default (gray)
            var stars = document.getElementsByClassName('star');
            for (var i = 0; i < stars.length; i++) {
                stars[i].classList.remove('checked');
            }

            // Set selected stars to gold
            for (var i = 0; i < rating; i++) {
                stars[i].classList.add('checked');
            }

            // Update the hidden field for server-side retrieval
            document.getElementById('<%= hdRating.ClientID %>').value = rating;
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Rate Your Experience!</h2>

    <div>
        <asp:Label ID="lblProductDetails" runat="server" Text="Bike Details: " />
        <br />

        <br />

        <asp:Label ID="lbl_Category" runat="server" Text="Mountain Bike" />
        <br />
        <asp:Label ID="lbl_Brand" runat="server" Text="Brand XYZ" />
    </div>

    <br />
    <div>

        <!-- Hidden field to store the selected rating for server-side retrieval -->
        <asp:HiddenField ID="hdRating" runat="server" />

        <!-- Star icons for interactive rating -->
        <span class="star" onclick="setRating(1)">&#9733;</span>
        <span class="star" onclick="setRating(2)">&#9733;</span>
        <span class="star" onclick="setRating(3)">&#9733;</span>
        <span class="star" onclick="setRating(4)">&#9733;</span>
        <span class="star" onclick="setRating(5)">&#9733;</span>
    </div>
    <br />
    <div>

        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Columns="30" Rows="5" Placeholder="Enter your comment here..." />

    </div>

    <br />

    <div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Rating" OnClick="btnSubmit_Click" />
    </div>

</asp:Content>

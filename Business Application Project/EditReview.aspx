<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditReview.aspx.cs" Inherits="Business_Application_Project.EditReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Add your custom styling for stars here -->
    <style>
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
            // Set selected stars to gold
            for (var i = 1; i <= 5; i++) {
                var star = document.getElementById('star_' + i);
                if (i <= rating) {
                    star.classList.add('checked');
                } else {
                    star.classList.remove('checked');
                }
            }

            // Update the hidden field for server-side retrieval
            document.getElementById('<%= hdRating.ClientID %>').value = rating;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Edit Your Review</h2>

    <br />
    <div>
        <!-- Hidden field to store the selected rating for server-side retrieval -->
        <asp:HiddenField ID="hdRating" runat="server" />

        <!-- Placeholder for displaying stars -->
        <asp:PlaceHolder ID="phStars" runat="server">
            <span class="star" id="star_1" onclick="setRating(1)">&#9733;</span>
            <span class="star" id="star_2" onclick="setRating(2)">&#9733;</span>
            <span class="star" id="star_3" onclick="setRating(3)">&#9733;</span>
            <span class="star" id="star_4" onclick="setRating(4)">&#9733;</span>
            <span class="star" id="star_5" onclick="setRating(5)">&#9733;</span>
        </asp:PlaceHolder>
    </div>
    <br />
    <div>
        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Columns="30" Rows="5" />
    </div>

    <br />
    <div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update Review" OnClick="btnUpdate_Click" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
    </div>
</asp:Content>

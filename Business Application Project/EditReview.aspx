<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditReview.aspx.cs" Inherits="Business_Application_Project.EditReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Add your custom styling for stars here -->
    <style>

        body {
            background-color: #dbeae6;
        }

        .star {
            font-size: 25px;
            cursor: pointer;
            color: gray;
        }

        .star.checked {
            color: gold;
        }


        .EditRev {
            background-color: #e6f2f0; 
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); 
            text-align: center;
            width: 45%;
            margin: 0 auto; 
            margin-top: 27px; 
   
        }

        .comment {
            text-align: left;
            margin: 10px 0; /* Set margin to 10px top and bottom */
        }

        #txtComment {
            width: 100%;
            padding: 8px; /* Adjust padding as needed */
            border: 1px solid #ccc;
            border-radius: 5px;
            margin: 0; /* Reset margin to 0 */
            resize: vertical; /* Allow vertical resizing */
        }

        .update-button, .cancel-button {
            padding: 8px 20px;
            background-color: #008374; 
            color: #fff; 
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s; 
        }

        .update-button:hover, .cancel-button:hover {
            background-color: #00584c; 
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

        

        function confirmCancel() {
            return confirm("Are you sure you want to cancel? Any unsaved changes will be lost.");
        }

        function showUpdateMessage() {
            return confirm("Review updated successfully!");
        }

    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="EditRev">
        <h2>Edit Your Review</h2>

        <br />
        <div>
            <asp:HiddenField ID="hdRating" runat="server" />
            <asp:PlaceHolder ID="phStars" runat="server">
                <span class="star" id="star_1" onclick="setRating(1)">&#9733;</span>
                <span class="star" id="star_2" onclick="setRating(2)">&#9733;</span>
                <span class="star" id="star_3" onclick="setRating(3)">&#9733;</span>
                <span class="star" id="star_4" onclick="setRating(4)">&#9733;</span>
                <span class="star" id="star_5" onclick="setRating(5)">&#9733;</span>
            </asp:PlaceHolder>
        </div>
        <br />
        <div class="comment">
            <p style="font-size:15px;">Comment:</p>
            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Rows="8" Placeholder="Tell us about your experience" style="width: 100%;" />
        </div>

        <br />
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update Review" OnClick="btnUpdate_Click" CssClass="update-button" OnClientClick="return showUpdateMessage();"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="cancel-button" OnClientClick="return confirmCancel();"/>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RateForm.aspx.cs" Inherits="Business_Application_Project.RateForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        body {
            background-color: #dbeae6;
        }

        .star {
            font-size: 30px;
            cursor: pointer;
            color: gray;
        }

        .star.checked {
            color: gold;
        }


        .RateExp {
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



        .submit-button, .cancel-button {
            padding: 8px 20px;
            background-color: #008374; 
            color: #fff; 
            border: none;
            border-radius: 3px;
            cursor: pointer;
            transition: background-color 0.3s; 
        }

        .submit-button:hover, .cancel-button:hover {
            background-color: #00584c; 
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

        function validateStars() {
            var stars = parseInt(document.getElementById('<%= hdRating.ClientID %>').value);
            if (isNaN(stars) || stars < 1 || stars > 5) {
                alert("Please give a rating from 1-5");
                return false;
            }
            return true;
        }



    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="RateExp">
        <h2>Rate Your Experience!</h2>

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
        
        <div class="comment">
            <p style="font-size:15px;">Comment:</p>
            <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Rows="8" Placeholder="Tell us about your experience" style="width: 100%;" />
        </div>


        <br />

        <div class="button-container">            
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Rating" OnClick="btnSubmit_Click" CssClass="submit-button" OnClientClick="return validateForm();" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="cancel-button" OnClientClick="return closePopup();" />
        </div>

    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="BulletList" />

</asp:Content>

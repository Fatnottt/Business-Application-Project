<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RatingProdView.aspx.cs" Inherits="Business_Application_Project.RatingProdView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Bike Details</h2>

    <div>
        <!-- Display bike information here (use labels, images, etc.) -->
        <asp:Label ID="lbl_Category" runat="server" Text="Mountain Bike" />
        <br />
        <asp:Label ID="lbl_Brand" runat="server" Text="Brand XYZ" />
        <!-- Add other bike details -->
    </div>

    <hr />

    <h2>Reviews</h2>

    <div>
        <!-- Display the number of reviews -->
        <asp:Label ID="lbl_ReviewCount" runat="server" Text="0 Reviews" />

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

            </div>
            <div class="comment">
                <%# Eval("Comment") %>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>

    </div>
</asp:Content>

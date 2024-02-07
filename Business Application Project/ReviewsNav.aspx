<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ReviewsNav.aspx.cs" Inherits="Business_Application_Project.ReviewsNav" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        table {
            width: 100%;
            border: 1px solid black; 
            border-collapse: collapse;
        }
        
        th, td {
            border: 1px solid black;
            text-align: center;
        }


    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>You have recently rented bike(s)!</h2>
    <p>We'd love to hear from you about your experience. Please leave a review so that we can share it with other renters just like you.</p>

    <table class="rental-history-table">
        <tr>
            <th>Bike ID</th>
            <th>Start Date</th>
            <th>End Date</th>
            <th></th>
        </tr>

        <tr>
            <td>11</td>
            <td>10 Jan</td>
            <td>12 Jan</td>
            <td><asp:PlaceHolder ID="phBikeButtons" runat="server"></asp:PlaceHolder></td>
        </tr>

    </table>


</asp:Content>
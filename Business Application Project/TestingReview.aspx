<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="TestingReview.aspx.cs" Inherits="Business_Application_Project.TestingReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>

        body {
            background-color: #d5e9e6; /* Background color */
        }

        h2 {
            color: white; 
            padding: 15px; 
            margin: 20px;
            text-align: center; 
            font-weight: bold;
        }

        .history-entry {
            border: none; 
            padding: 20px; 
            margin: 20px; 
            background-color: #e6f2f0; 
            display: flex; 
            justify-content: space-between; 
        }

        .history-entry .data {
            margin: 10px; 
        }

        .history-entry span {
            font-weight: bold; 
            margin-right: 5px; 
        }

        .history-entry .date-range {
            color: #008374;
        }

        .history-entry .buttons {
            margin-top: 10px; 
        }

        .history-entry .price {
            color: green; 
        }

        .bike-name {
            font-size: 30px; 
        }

        .bike-id, #bikeid {
            font-size: 15px;
            color: gray;
        }

        /* Button styles */
        .rate-button, .view-button {
            padding: 8px 20px;
            background-color: #008374; 
            color: #fff; 
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s; 
        }

        .rate-button:hover, .view-button:hover {
            background-color: #00584c; 
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Rental History</h2>
    <asp:Repeater ID="rptHistory" runat="server">
        <ItemTemplate>
            <div class="history-entry">
                <!-- Display rental history data -->
                <div class="data">
                    <asp:Label runat="server" Text='<%# Eval("Bike_Name") %>' CssClass="bike-name" /><br />
                    <span id="bikeid">#</span> <asp:Label runat="server" Text='<%# Eval("Bike_Id") %>' CssClass="bike-id"/><br />
                </div>
                <div class="data">
                    <asp:Label runat="server" CssClass="date-range" Text='<%# Eval("Start_Date", "{0:dd/MM/yyyy}") + " to " + Eval("End_Date", "{0:dd/MM/yyyy}") %>' /><br />
                    <br />
                    <span>Total Price:</span> <asp:Label runat="server" Text='<%# "$" + Eval("Total_Price") %>' CssClass="price" /><br />
                </div>
                <!-- Button -->
                <div class="buttons">
                    <asp:Button ID="btnRate" runat="server" CommandName="Rate" CommandArgument='<%# Eval("Bike_Id") %>' Text='<%# Convert.ToBoolean(Eval("HasReviewed")) ? "Edit Review" : "Rate" %>' OnCommand="RateButton_Command" CssClass="rate-button" />
                    <asp:HiddenField ID="hf_BikeId" runat="server" Value='<%# Eval("Bike_Id") %>' />
                    <asp:Button ID="btnView" runat="server" Text="View Bike" OnClick="btnView_Click" CssClass="view-button" />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

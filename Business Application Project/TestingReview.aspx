<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="TestingReview.aspx.cs" Inherits="Business_Application_Project.TestingReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Rental History</h2>
    <asp:Repeater ID="rptHistory" runat="server">
        <ItemTemplate>
            <div class="history-entry">
                <!-- Display rental history data -->
                <div>
                    Bike ID: <asp:Label runat="server" Text='<%# Eval("Bike_Id") %>' /><br />
                    Bike Name: <asp:Label runat="server" Text='<%# Eval("Bike_Name") %>' /><br />
                    Start Date: <asp:Label runat="server" Text='<%# Eval("Start_Date") %>' /><br />
                    End Date: <asp:Label runat="server" Text='<%# Eval("End_Date") %>' /><br />
                    Total Price: <asp:Label runat="server" Text='<%# Eval("Total_Price") %>' /><br />
                   
                    <%--<asp:Button runat="server" Text='<%# Eval("HasReviewed", "{0}") == "True" ? "Edit Review" : "Rate" %>'
                                CommandArgument='<%# Eval("History_Id") %>' OnCommand="RateButton_Command" />--%>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>

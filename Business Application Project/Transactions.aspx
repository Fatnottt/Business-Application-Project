<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transactions.aspx.cs" Inherits="Business_Application_Project.Transactions" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Transactions</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }
        .container {
            width: 80%;
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        h1 {
            color: #333;
        }
        #GridViewTransactions {
            width: 100%;
            border-collapse: collapse;
        }
        #GridViewTransactions th, #GridViewTransactions td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        #GridViewTransactions th {
            background-color: #f2f2f2;
        }
        #GridViewTransactions tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        #GridViewTransactions tr:hover {
            background-color: #f0f0f0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Deposit Transactions</h1>
            <asp:GridView ID="GridViewTransactions" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewTransactions_RowCommand" DataKeyNames="PayPalTransactionID">
                <Columns>
                    <asp:BoundField DataField="PayPalTransactionID" HeaderText="Transaction ID" SortExpression="PayPalTransactionID" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                    <asp:ButtonField ButtonType="Button" CommandName="Refund" HeaderText="Action" Text="Refund" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

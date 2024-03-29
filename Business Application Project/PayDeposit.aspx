﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayDeposit.aspx.cs" Inherits="Business_Application_Project.PayDeposit" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>Security Deposit Payment</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        #payment-container {
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            text-align: center; /* Center the content inside the container */
        }

        #paypal-button-container {
            margin-top: 20px;
        }

        h1 {
            color: #333;
        }

        p {
            color: #666;
            font-size: 16px;
        }
    </style>
</head>
<body>
    <div id="payment-container">
        <h1>Security Deposit Payment</h1>
        <p>Thanks for registering! To complete your registration, please pay a refundable security deposit of SGD 100.</p>

        <input type="hidden" id="paypal-transaction-id" name="paypal-transaction-id">

        <script src="https://www.paypal.com/sdk/js?client-id=ARxHqFKYlPbhZqGUjfmGDICboj8wo0sY8bV-0y-NfgBkq2vOxoq2bTsPfi5gbAECfwkV7DX7fVcZvuZa"></script>

        <div id="paypal-button-container"></div>

        <script>
            paypal.Buttons({
                createOrder: function (data, actions) {
                    return actions.order.create({
                        purchase_units: [{
                            amount: {
                                value: "71.70"
                            }
                        }]
                    });
                },
                onApprove: function (data, actions) {
                    return actions.order.capture().then(function (details) {
                        saveTransactionId(details.id);
                        window.location.href = 'ThankYou.aspx';
                    });
                },
                onCancel: function (data) {
                    alert('Payment canceled. Please complete the transaction to proceed.');
                }
            }).render('#paypal-button-container');

            // Function to send the transaction ID to the server
            function saveTransactionId(transactionId) {
                // Use AJAX to send the transaction ID to the server
                var xhr = new XMLHttpRequest();
                xhr.open("POST", "PayDeposit.aspx/SaveTransactionId", true);
                xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
                xhr.send("transactionId=" + transactionId);
            }
        </script>
    </div>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Business_Application_Project.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout Page</title>
    <style>
        /* Body styles */
        body {
            background-color: #008374; /* Background color */
            margin: 0;
            padding: 0;
        }

        /* Content container styles */
        .content-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        /* Content styles */
        .content {
            text-align: center;
            background-color: #fff; /* Content background color */
            padding: 20px;
            border-radius: 10px;
        }

        /* Button styles */
        .button-57 {
            position: relative;
            overflow: hidden;
            border: 1px solid #18181a;
            color: #18181a;
            display: inline-block;
            font-size: 15px;
            line-height: 15px;
            padding: 18px 18px 17px;
            text-decoration: none;
            cursor: pointer;
            background: #fff;
            user-select: none;
            -webkit-user-select: none;
            touch-action: manipulation;
        }

        .button-57 span:first-child {
            position: relative;
            transition: color 600ms cubic-bezier(0.48, 0, 0.12, 1);
            z-index: 10;
        }

        .button-57 span:last-child {
            color: white;
            display: block;
            position: absolute;
            bottom: 0;
            transition: all 500ms cubic-bezier(0.48, 0, 0.12, 1);
            z-index: 100;
            opacity: 0;
            top: 50%;
            left: 50%;
            transform: translateY(225%) translateX(-50%);
            height: 14px;
            line-height: 13px;
        }

        .button-57:after {
            content: "";
            position: absolute;
            bottom: -50%;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: #008374;
            transform-origin: bottom center;
            transition: transform 600ms cubic-bezier(0.48, 0, 0.12, 1);
            transform: skewY(9.3deg) scaleY(0);
            z-index: 50;
        }

        .button-57:hover:after {
            transform-origin: bottom center;
            transform: skewY(9.3deg) scaleY(2);
        }

        .button-57:hover span:last-child {
            transform: translateX(-50%) translateY(-100%);
            opacity: 1;
            transition: all 900ms cubic-bezier(0.48, 0, 0.12, 1);
        }

        /* Your button styles continue... */
    </style>
</head>
<body>
    <!-- Background color -->
    <div class="background" style="background-color: #008374;">
        <!-- Content container -->
        <div class="content-container">
            <!-- Content -->
            <div class="content">
                <h1>Welcome to Bikie's Checkout Page</h1>
                <!-- Bike Icon -->
                <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/99/Circle-icons-bike.svg/512px-Circle-icons-bike.svg.png" alt="Bike Icon" style="width: 100px; height: 100px;">
                
                <p>Please click on the button below to proceed to payment:</p>

                <!-- Checkout Button -->
                <form id="btn_Checkout" runat="server">
                    <button type="submit" class="button-57" role="button">
                        <span class="text">Proceed to Payment</span>
                        <span>Stripe Checkout</span>
                    </button>
                </form>

                <!-- Custom message -->
                <p>Hope you enjoy your ride, and ride with Bikie again.</p>
            </div>
        </div>
    </div>

    <!-- Stripe JavaScript SDK -->
    <script src="https://js.stripe.com/v3/"></script>
    <script>
        // Stripe Public Key
        var stripe = Stripe('pk_test_51OjLdBAWp9OZBZFjhUFqnpfDAiqFK0ECAwUJtHR5C4iJhuvpftIo77xwBSqQbVIIERqat1oo7dcrtkOLNoJDDUDg008HRyab4K');

        // Form Submission
        var form = document.getElementById("btn_Checkout");
        form.addEventListener('submit', function (e) {
            e.preventDefault();
            stripe.redirectToCheckout({
                sessionId: "<%= sessionId %>"
            })
        });
    </script>
</body>
</html>
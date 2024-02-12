<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="ProductView.aspx.cs" Inherits="Business_Application_Project.ProductView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .container {
            display: flex;
            flex-wrap: wrap;
        }

        #map {
            flex: 1;
            height: 100vh;
            width: 45%;
        }

        .grid-view-padding {
            flex: 1;
            padding: 10px;
        }

        .product-container {
            height: 100vh; /* Set the height of the container to half of the viewport height */
            overflow: auto; /* Add overflow:auto to enable scrolling if the content exceeds the container height */
            width: 55%;
        }

            .product-container::-webkit-scrollbar {
                display: none;
            }

        .product-card {
            width: 45%;
            height: auto;
            float: left;
            margin: 2.5% 2.5%;
            box-sizing: border-box;
            padding: 10px;
            border-radius: 10px;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2); /* Add shadow effect */
            transition: box-shadow 0.3s ease-in-out; /* Add transition effect for smoother shadow change */
            /* Define card background and border */
            background-color: #ffffff;
            border: 1px solid #dddddd;
        }

            .product-card:hover {
                box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2); /* Increase shadow on hover */
                transform: translateY(-5px); /* Move the card up slightly on hover */
            }

            /* Add styles for product card content */
            .product-card p {
                margin-bottom: 5px;
            }

            .product-card img {
                width: 100%;
                border-radius: 5px;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">

        <%--<asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" CssClass="grid-view-padding" OnSelectedIndexChanged="gvProduct_SelectedIndexChanged" DataKeyNames="Product_ID" OnRowCancelingEdit="gvProduct_RowCancelingEdit" OnRowDeleting="gvProduct_RowDeleting" OnRowEditing="gvProduct_RowEditing" OnRowUpdating="gvProduct_RowUpdating">
            <Columns>
                <asp:BoundField DataField="Product_ID" HeaderText="Product ID" />
                <asp:BoundField DataField="Unit_Price" HeaderText="Unit Price" />
                <asp:BoundField DataField="Category" HeaderText="Category" />
                <asp:BoundField DataField="Brand" HeaderText="Brand" />
                <asp:BoundField DataField="Model" HeaderText="Model" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>--%>

        <%--<asp:Button ID="btn_AddProduct" runat="server" Text="Add New Product" OnClick="btn_AddProduct_Click" />--%>

        <div class="product-container">
            <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand" OnItemDataBound="rptProducts_ItemDataBound">
                <ItemTemplate>
                    <div class="product-card">
                        <asp:Image ID="img_Product" runat="server" Height="150px" />
                        <p><strong> <%# Eval("Brand") %></strong> &nbsp;<%# Eval("Model") %></p>
                        <p><strong>Category:</strong> <%# Eval("Category") %></p>
                        <p><strong>Unit Price:</strong> <%# Eval("Unit_Price", "{0:C}") %></p>
                        <p><strong>Address:</strong> <%# Eval("Address") %></p>
                        <asp:Button ID="btnViewDetails" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("Product_ID") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>


        <br />
        <br />
        <div id="map"></div>
    </div>
    <script>
        // Define the initMap() function before the Google Maps API script
        function initMap() {
            var map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -34.397, lng: 150.644 },
                zoom: 8
            });

            // Create a new marker at a specific location
            var marker = new google.maps.Marker({
                position: { lat: -34.397, lng: 150.644 },
                map: map,
                title: 'Hello World!'
            });
        }
    </script>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDxkhz74Icub96RvTnWZwMGbTw4_Bd-5zc&callback=initMap" async defer></script>
</asp:Content>


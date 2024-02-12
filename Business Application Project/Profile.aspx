<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Business_Application_Project.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .product-container {
            height: 100vh; /* Set the height of the container to half of the viewport height */
            overflow: auto; /* Add overflow:auto to enable scrolling if the content exceeds the container height */
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
    <body data-aos-easing="ease-in-out" data-aos-duration="1000" data-aos-delay="0">
        <asp:Label ID="UserEmailLabel" runat="server" Text=""></asp:Label><br />
        <asp:Label ID="SessionInfoLabel" runat="server" Text=""></asp:Label>
        <section style="background-color: #008374;">
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col col-lg-9 col-xl-7">
                        <div class="card">
                            <div class="rounded-top text-white d-flex flex-row" style="background-color: #000; height: 200px;">
                                <div class="ms-4 mt-5 d-flex flex-column" style="width: 150px;">
                                    <img src="Images/default-user-icon.png"
                                        alt="Generic placeholder image" class="img-fluid img-thumbnail mt-4 mb-2"
                                        style="width: 150px; z-index: 1">
                                    <a href="EditProfile.aspx" class="btn btn-outline-dark" data-mdb-ripple-color="dark"
                                        style="z-index: 1;">Edit profile
                                    </a>
                                </div>
                                <div class="ms-3" style="margin-top: 130px;">
                                    <h5>Andy Horwitz (Session user name here)</h5>
                                    <p>Singapore, Boon Keng (maybe have location)</p>
                                </div>
                            </div>
                            <div class="p-4 text-black" style="background-color: #f8f9fa;">
                                <div class="d-flex justify-content-end text-center py-1">
                                    <div>
                                        <p class="mb-1 h5">253</p>
                                        <p class="small text-muted mb-0">Photos</p>
                                    </div>
                                    <div class="px-3">
                                        <p class="mb-1 h5">1026</p>
                                        <p class="small text-muted mb-0">Followers</p>
                                    </div>
                                    <div>
                                        <p class="mb-1 h5">478</p>
                                        <p class="small text-muted mb-0">Following</p>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body p-4 text-black">
                                <div class="mb-5">
                                    <p class="lead fw-normal mb-1">About</p>
                                    <div class="p-4" style="background-color: #f8f9fa;">
                                        <p class="font-italic mb-1">Web Developer</p>
                                        <p class="font-italic mb-1">Lives in New York</p>
                                        <p class="font-italic mb-0">Photographer</p>
                                    </div>
                                </div>
                                <div class="d-flex justify-content-between align-items-center mb-4">
                                    <p class="lead fw-normal mb-0">Bicycles</p>
                                    <p class="mb-0"><a href="#!" class="text-muted">Show all</a></p>
                                </div>
                                <div class="row g-2">
                                    <div class="col mb-2">
                                        <div class="product-container">
                                            <asp:Repeater ID="rptProducts" runat="server" OnItemCommand="rptProducts_ItemCommand" OnItemDataBound="rptProducts_ItemDataBound">
                                                <ItemTemplate>
                                                    <div class="product-card">
                                                        <asp:Image ID="img_Product" runat="server" Height="150px" />
                                                        <p><strong><%# Eval("Brand") %></strong> &nbsp;<%# Eval("Model") %></p>
                                                        <p><strong>Category:</strong> <%# Eval("Category") %></p>
                                                        <p><strong>Unit Price:</strong> <%# Eval("Unit_Price", "{0:C}") %></p>
                                                        <p><strong>Address:</strong> <%# Eval("Address") %></p>
                                                        <asp:Button ID="btnViewDetails" runat="server" Text="View Details" CommandName="ViewDetails" CommandArgument='<%# Eval("Product_ID") %>' />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </body>
</asp:Content>

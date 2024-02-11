<%@ Page Title="" Language="C#" MasterPageFile="~/RentalPage.Master" AutoEventWireup="true" CodeBehind="BikeListing.aspx.cs" Inherits="Business_Application_Project.BikeListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        .button.container {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-top: 50px;
        }

        .invisible-button {
            background: none;
            border: none;
            cursor: pointer;
            padding: 20px; /* Increase padding to make buttons bigger */
            outline: none;
            text-align: center;
            position: relative;
            background-color: transparent;
            border-radius: 20px; /* Round the corners */
            width: 150px; /* Set a fixed width for all buttons */
            height: 150px; /* Set a fixed height for all buttons */
        }

            .invisible-button.active {
                background-color: #d3d3d3;
            }

            .invisible-button.incomplete {
                background-color: #ffcccc; /* Light red */
            }

            .invisible-button .bi {
                font-size: 2.5em; /* Adjust the font size to make the icon bigger */
            }

            .invisible-button .text {
                font-size: 18px; /* Increase text size */
                color: #333; /* Adjust color as needed */
                margin-top: 10px; /* Increase margin */
            }

        #SignUpProcess {
            /* Limit left and right spacing*/
            padding-left: 10%;
            padding-right: 10%;
            justify-content: center;
            align-content: center;
        }

            #SignUpProcess .container-fluid {
                margin-top: 5%;
            }

        .form-control {
            width: 30%; /* Adjust as needed */
            padding: 5px; /* Adjust padding as needed */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1 class="justify-content-center text-center mt-3">List Your Bike</h1>
        <div class="button container">
            <button type="button" class="invisible-button active" id="categoryButton" onclick="showCategory()">
                <i class="bi bi-bicycle"></i>
                <div class="text">Category</div>
            </button>
            <button type="button" class="invisible-button" id="detailsButton" onclick="showDetails()">
                <i class="bi bi-list-ul"></i>
                <div class="text">Details</div>
            </button>
            <button type="button" class="invisible-button" id="picturesButton" onclick="showPictures()">
                <i class="bi bi-image"></i>
                <div class="text">Pictures</div>
            </button>
            <button type="button" class="invisible-button" id="locationButton" onclick="showLocation()">
                <i class="bi bi-geo-alt"></i>
                <div class="text">Location</div>
            </button>
            <button type="button" class="invisible-button" id="pricingButton" onclick="showPricing()">
                <i class="bi bi-currency-dollar"></i>
                <div class="text">Pricing</div>
            </button>
        </div>
    </div>
    <div id="SignUpProcess">
        <div id="categoryContent" style="display: block;">
            <div class="container-fluid">
                <div class="container">
                    <p><strong>What type of bike is it?</strong></p>
                    <p>First, select the category of your bike. Then select the right subcategory.</p>

                    <!-- Dropdown for Category -->

                    <asp:DropDownList ID="ddlBikeCategory" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlBikeCategory_SelectedIndexChanged">
                        <asp:ListItem Text="Select the bike category" Value="" Selected="True" Disabled="True"></asp:ListItem>
                        <asp:ListItem Text="Urban" Value="urban"></asp:ListItem>
                        <asp:ListItem Text="Special" Value="special"></asp:ListItem>
                    </asp:DropDownList>

                    <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="form-control" AutoPostBack="True" Visible="False" Size="1">
                        <asp:ListItem Text="Specify the subcategory" Value="" Selected="True" Disabled="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="errorMessageLabel" runat="server" Text="" ForeColor="Red"></asp:Label>
                    <div class="container" style="margin-top: 20px;">
                        <asp:Button ID="nextcategory" runat="server" Text="Next" CssClass="btn btn-primary float-right"/>
                    </div>
                </div>
            </div>
        </div>
        <div id="details-content" style="display: none;">
            <div class="container-fluid">
                <div class="container">
                    <p><strong>What is the brand, model, and size of your bike?</strong></p>
                    <asp:TextBox ID="Brand" runat="server" Text="Brand"></asp:TextBox>
                    <asp:TextBox ID="Model" runat="server" Text="Model"></asp:TextBox>
                </div>
                <div class="container">
                    <p><strong>Let us know the specifics of your bike.</strong></p>
                    <asp:DropDownList ID="ddlRiderHeight" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem Text="Rider Height" Value="" Selected="True" Disabled="True"></asp:ListItem>
                        <asp:ListItem Text="155 cm - 165 cm" Value="155 cm - 165 cm"></asp:ListItem>
                        <asp:ListItem Text="165 cm - 175 cm" Value="165 cm - 175 cm"></asp:ListItem>
                        <asp:ListItem Text="175 cm - 185 cm" Value="175 cm - 185 cm"></asp:ListItem>
                        <asp:ListItem Text="185 cm - 195 cm" Value="185 cm - 195 cm"></asp:ListItem>
                        <asp:ListItem Text="195 cm - 205 cm" Value="195 cm - 205 cm"></asp:ListItem>
                    </asp:DropDownList>

                    <asp:TextBox ID="TextBox1" runat="server" Text="Model"></asp:TextBox>
                    <div class="container" style="margin-top: 20px;">
                        <asp:Button ID="backdetails" runat="server" Text="Back" CssClass="btn btn-secondary float-left" />
                        <asp:Button ID="nextdetails" runat="server" Text="Next" CssClass="btn btn-primary float-right" />
                    </div>

                </div>
            </div>
        </div>
        <div id="pictures-content" style="display: none;">
            <div class="container-fluid">
                <div class="container">
                    <p><strong>Upload pictures of your bike</strong></p>
                    <p>Upload at least 3 pictures of your bike. The first picture will be the main picture of your bike.</p>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </div>
                <div class="container" style="margin-top: 20px;">
                    <asp:Button ID="backpicture" runat="server" Text="Back" CssClass="btn btn-secondary float-left" />
                    <asp:Button ID="nextpicture" runat="server" Text="Next" CssClass="btn btn-primary float-right" />
                </div>

            </div>
        </div>
        <div id="location-content" style="display: none;">
            <div class="container-fluid">
                <div class="container">
                    <h2 id="status"></h2>
                    <p><strong>Where is your bike located?</strong></p>
                    <p>Enter the address where your bike is located.</p>
                    <asp:TextBox ID="StreetAddress" runat="server" placeholder="Street Address"></asp:TextBox>
                    <asp:TextBox ID="PostalCode" runat="server" placeholder="Postal Code"></asp:TextBox>
                    <asp:TextBox ID="City" runat="server" placeholder="City"></asp:TextBox>
                    <asp:TextBox ID="Country" runat="server" placeholder="Country"></asp:TextBox>
                    <asp:Button runat="server" Text="Find My Location" CssClass="btn btn-primary" OnClientClick="findMyLocation(); return false;" />
                </div>
                <div class="container" style="margin-top: 20px;">
                    <asp:Button ID="backlocation" runat="server" Text="Back" CssClass="btn btn-secondary float-left" />
                    <asp:Button ID="nextlocation" runat="server" Text="Next" CssClass="btn btn-primary float-right" />
                </div>

            </div>
        </div>
        <div id="pricing-content" style="display: none;">
            <div class="container-fluid">
                <div class="container">
                    <h2>Pricing</h2>
                    <asp:TextBox ID="DailyPrice" runat="server" placeholder="Daily Price"></asp:TextBox>
                    <div class="discount">
                        <asp:TextBox ID="DailyDiscount" class="discountTb" runat="server" placeholder="Daily Discount"></asp:TextBox>
                        <asp:TextBox ID="WeeklyDiscount" class="discountTb" runat="server" placeholder="Weekly Discount"></asp:TextBox>
                    </div>

                    <!-- get weekly discount from textbox and calculate the weekly price -->
                    <p>With a weekly discount of xxx you will get $xxx per week.</p>
                </div>
                <div class="container" style="margin-top: 20px;">
                    <asp:Button ID="backpricing" runat="server" Text="Back" CssClass="btn btn-secondary float-left" />
                    <asp:Button ID="finishpricing" runat="server" Text="Finish" CssClass="btn btn-success float-right" />
                </div>
            </div>
        </div>
    </div>
    <!-- End Content Area -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maps.google.com/maps/api/js?key=AIzaSyDoA6MbjzIVBqN-jCDIGz_gfIlqBuSHfpw&libraries=places"></script>

    <script>
        // Function to show content
        function showCategory() {
            document.getElementById('categoryContent').style.display = 'block';
            document.getElementById('details-content').style.display = 'none';
            document.getElementById('pictures-content').style.display = 'none';
            document.getElementById('location-content').style.display = 'none';
            document.getElementById('pricing-content').style.display = 'none';
            console.log('button clicked')
        }
        function showDetails() {
            document.getElementById('categoryContent').style.display = 'none';
            document.getElementById('details-content').style.display = 'block';
            document.getElementById('pictures-content').style.display = 'none';
            document.getElementById('location-content').style.display = 'none';
            document.getElementById('pricing-content').style.display = 'none';
            console.log('button clicked')
        }
        function showPictures() {
            document.getElementById('categoryContent').style.display = 'none';
            document.getElementById('details-content').style.display = 'none';
            document.getElementById('pictures-content').style.display = 'block';
            document.getElementById('location-content').style.display = 'none';
            document.getElementById('pricing-content').style.display = 'none';
            console.log('button clicked')
        }
        function showLocation() {
            document.getElementById('categoryContent').style.display = 'none';
            document.getElementById('details-content').style.display = 'none';
            document.getElementById('pictures-content').style.display = 'none';
            document.getElementById('location-content').style.display = 'block';
            document.getElementById('pricing-content').style.display = 'none';
            console.log('button clicked')
        }
        function showPricing() {
            document.getElementById('categoryContent').style.display = 'none';
            document.getElementById('details-content').style.display = 'none';
            document.getElementById('pictures-content').style.display = 'none';
            document.getElementById('location-content').style.display = 'none';
            document.getElementById('pricing-content').style.display = 'block';
            console.log('button clicked')
        }

        // Function to show/hide sections
        function showSection(sectionId) {
            var sections = document.querySelectorAll('.content-section');
            sections.forEach(function (section) {
                if (section.id === sectionId) {
                    section.style.display = 'block';
                } else {
                    section.style.display = 'none';
                }
            });
        }

        // Function to handle "Next" button click
        function nextSection(currentSectionId, nextSectionId) {
            showSection(nextSectionId);
        }

        // Function to handle "Back" button click
        function previousSection(currentSectionId, previousSectionId) {
            showSection(previousSectionId);
        }

        // Add event listeners to buttons
        document.getElementById('<%= nextcategory.ClientID %>').addEventListener('click', function () {
            console.log('button going to be clicked')
            nextSection('categoryContent', 'details-content');
            console.log('button clicked')
            return false;
        });

        document.getElementById('<%= backdetails.ClientID %>').addEventListener('click', function () {
            previousSection('details-content', 'categoryContent');
        });

        document.getElementById('<%= nextdetails.ClientID %>').addEventListener('click', function () {
            nextSection('details-content', 'pictures-content');
        });

        document.getElementById('<%= backpicture.ClientID %>').addEventListener('click', function () {
            previousSection('pictures-content', 'details-content');
        });

        document.getElementById('<%= nextpicture.ClientID %>').addEventListener('click', function () {
            nextSection('pictures-content', 'location-content');
        });

        document.getElementById('<%= backlocation.ClientID %>').addEventListener('click', function () {
            previousSection('location-content', 'pictures-content');
        });

        document.getElementById('<%= nextlocation.ClientID %>').addEventListener('click', function () {
            nextSection('location-content', 'pricing-content');
        });

        document.getElementById('<%= backpricing.ClientID %>').addEventListener('click', function () {
            previousSection('pricing-content', 'location-content');
        });

        const findMyLocation = () => {
            const status = document.querySelector('.status');

            const success = (position) => {
                const latitude = position.coords.latitude;
                const longitude = position.coords.longitude;

                const geoApiUrl = 'https://api.bigdatacloud.net/data/reverse-geocode-client?latitude=${latitude}&longitude=${longitude}&localityLanguage=en'

                fetch(geoApiUrl)
                    .then(response => response.json())
                    .then(data => {
                        console.log(data);
                        document.getElementById('<%= PostalCode.ClientID %>').value = data.postcode;
                        document.getElementById('<%= City.ClientID %>').value = data.locality;
                        document.getElementById('<%= Country.ClientID %>').value = data.principalSubdivision

                    })
            }

            const error = () => {
                status.textContent = 'Unable to retrieve your location';
            }

            navigator.geolocation.getCurrentPosition(success, error);
        }

        $(document).ready(function () {
            var autocomplete;
            autocomplete = new google.maps.places.Autocomplete(document.getElementById('<%= StreetAddress.ClientID %>'), {
                types: ['geocode'],
                fields: ['address_components', 'formatted_address'],
            });

            google.maps.event.addListener(autocomplete, 'place_changed', function () {
                var near_place = autocomplete.getPlace();
                var street_number = '';
                var street_name = '';
                var postal_code = '';
                for (var i = 0; i < near_place.address_components.length; i++) {
                    if (near_place.address_components[i].types[0] == 'street_number') {
                        street_number = near_place.address_components[i].long_name;
                    }
                    if (near_place.address_components[i].types[0] == 'route') {
                        street_name = near_place.address_components[i].long_name;
                    }
                    if (near_place.address_components[i].types[0] == 'postal_code') {
                        postal_code = near_place.address_components[i].long_name;
                    }
                }
                document.getElementById('<%= StreetAddress.ClientID %>').value = street_number + ' ' + street_name;
                document.getElementById('<%= PostalCode.ClientID %>').value = postal_code;
            });
        });


    </script>

</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/RentalPage.Master" AutoEventWireup="true" CodeBehind="BikeRental.aspx.cs" Inherits="Business_Application_Project.BikeRental" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        .btn-custom {
            background-color: #d3d3d3;
            border-color: #d3d3d3;
        }
        .btn-custom:hover {
            background-color: #b7b7b7;
            border-color: #b7b7b7;
        }
        .pill-button {
            border-radius: 20px;
            padding: 8px 20px;
            margin-right: 10px;
            margin-bottom: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main Content -->
    <div class="container-fluid">
        <!-- Filter Section -->
        <div class="m-3">
            <div class="row justify-content-center">
                <div class="col text-center">
                    <!-- Applied text-center class for horizontal centering -->
                    <button type="button" class="btn btn-primary pill-button btn-custom text-dark">Select dates</button>
                    <button type="button" class="btn btn-primary pill-button btn-custom text-dark">Number of bikes</button>
                    <button type="button" class="btn btn-primary pill-button btn-custom text-dark">Bike type</button>
                    <button type="button" class="btn btn-primary pill-button btn-custom text-dark">Brand</button>
                    <button type="button" class="btn btn-primary pill-button btn-custom text-dark">Rider Height</button>
                    <button type="button" class="btn btn-primary pill-button btn-custom text-dark">Sort</button>
                    <button type="button" class="btn btn-secondary pill-button btn-custom text-dark">Clear all</button>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <!-- Left half for bicycle information -->
                <div id="bicycle-info">
                    <!-- Bicycle information will be populated dynamically here -->
                    Hello Bike
                </div>
            </div>
            <div class="col-md-6">
                <!-- Right half for map -->
                <div id="map-container">
                    Hello Map
                    <div id="map">Hello Map</div>
                </div>
            </div>
        </div>
    </div>


    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&callback=initMap" async defer></script>
    <script>
        function initMap() {
            // Initialize map
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 12,
                center: { lat: 0, lng: 0 } // Set default center
            });

            // Place markers for each bicycle
            bicyclesData.forEach(function (bicycle) {
                var marker = new google.maps.Marker({
                    position: { lat: bicycle.Latitude, lng: bicycle.Longitude },
                    map: map,
                    title: bicycle.Name // Display bicycle name as marker title
                });
            });
        }
    </script>
    <script>
        // Populate bicycle information dynamically
        $(document).ready(function () {
            var bicyclesHtml = '';
            bicyclesData.forEach(function (bicycle) {
                bicyclesHtml += '<div><strong>' + bicycle.Name + '</strong></div>';
                // Add other bicycle information as needed
            });
            $('#bicycle-info').html(bicyclesHtml);
        });
    </script>
</asp:Content>

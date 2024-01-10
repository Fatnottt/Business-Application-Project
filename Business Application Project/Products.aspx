﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Business_Application_Project.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
@page
@model BikeRental.Pages.Products.IndexModel
@{
    ViewData["Title"] = "Products";
}

<h1>Products</h1>

<p>
    <a asp-page="Create">Create New</a>
</p>
<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Product[0].Name)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Product[0].Price)
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Product[0].Category)
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
@foreach (var item in Model.Product) {
        <tr>
            <td>
                @Html.DisplayFor(modelItem => item.Name)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Price)
            </td>
            <td>
                @Html.DisplayFor(modelItem => item.Category)
            </td>
            <td>
                <a asp-page="./Edit" asp-route-id="@item.Id">Edit</a> |
                <a asp-page="./Details" asp-route-id="@item.Id">Details</a> |
                <form method="post" asp-page="./Index" asp-route-id="@item.Id">
                    <input type="submit" value="Delete" class="btn btn-danger" onclick="return confirm('Are you sure you want to delete this product?');" />
                </form>
            </td>
        </tr>
}
    </tbody>
</table>
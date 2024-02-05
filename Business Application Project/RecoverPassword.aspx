<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="Business_Application_Project.RecoverPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-horizontal">
            <h2>Reset Password</h2>
            <hr />
            <div class="form-group">
                <asp:Label ID="lblMsg" runat="server" CssClass="col-md-2 control-label" Font-Size="XX-Large" Font-Bold="True"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblPassword" runat="server" CssClass="col-md-2 control-label" Text="New Password" Visible="False"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbNewPass" CssClass="form-control" TextMode="Password" runat="server" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" CssClass="text-danger" runat="server" ErrorMessage="Please enter your new Password !" ControlToValidate="tbNewPass"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="lblRetypePass" runat="server" CssClass="col-md-2 control-label" Text="Confirm Password" Visible="False"></asp:Label>
                <div class="col-md-3">
                    <asp:TextBox ID="tbConfirmPass" CssClass="form-control" TextMode="Password" runat="server" Visible="False"></asp:TextBox>
                    <br />

                </div>
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="ErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="SuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="btRecPass" runat="server" CssClass="btn btn-primary" Text="Reset" Visible="False" OnClick="btRecPass_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

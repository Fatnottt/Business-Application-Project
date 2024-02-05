<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Business_Application_Project.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="vh-100" style="background-color: #008374;">
        <div class="container py-5 h-100">
            <div class="row d-flex align-items-center justify-content-center h-100">
                <div class="col-md-8 col-lg-7 col-xl-6">
                    <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.svg"
                        class="img-fluid" alt="Phone image">
                </div>
                <div class="col-md-7 col-lg-5 col-xl-5 offset-xl-1">
                    <form>
                        <!-- Email input -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="Email" class="form-control form-control-lg" type="email" runat="server"></asp:TextBox>
                            <label class="form-label" for="Email">Email address</label>
                        </div>

                        <!-- Password input -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control form-control-lg"></asp:TextBox>
                            <label class="form-label" for="Password">Password</label>
                        </div>

                        <div class="d-flex justify-content-around align-items-center mb-4">
                            <!-- Checkbox -->
                            <div class="form-check">
                                <input class="form-check-input" type="checkbox" value="" id="RmbMeCheckbox" checked runat="server"/>
                                <label class="form-check-label" for="RmbMeCheckbox">Remember me </label>
                            </div>
                            <a href="ForgotPassword.aspx">Forgot password?</a>
                        </div>

                        <!-- Submit button -->
                        <div>
                            <asp:Button ID="SubmitButton" class="btn btn-primary btn-lg btn-block" runat="server" Text="Login" OnClick="LoginButton_Click"/>
                            <asp:Label ID="ErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>


                        </div>

                        <div class="divider d-flex align-items-center my-4">
                            <p class="text-center fw-bold mx-3 mb-0 text-muted">OR</p>
                        </div>

                        <a class="btn btn-primary btn-lg btn-block" style="background-color: #3b5998" href="#!"
                            role="button">
                            <i class="fab fa-facebook-f me-2"></i>Continue with Facebook
                        </a>
                        <a class="btn btn-primary btn-lg btn-block" style="background-color: #55acee" href="#!"
                            role="button">
                            <i class="fab fa-twitter me-2"></i>Continue with Twitter</a>

                    </form>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

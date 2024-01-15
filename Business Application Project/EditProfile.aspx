<%@ Page Title="" Language="C#" MasterPageFile="~/WithNavbar.Master" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="Business_Application_Project.EditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="background-color: #008374;">
        <div class="container rounded bg-white mt-5 mb-5">
            <div class="row">
                <div class="col-md-3 h-100">
                    <div class="d-flex flex-column align-items-center text-center p-3 py-5">
                        <img class="rounded-circle mt-5" width="150px" src="https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg"><span class="font-weight-bold">Edogaru</span><span class="text-black-50">edogaru@mail.com.my</span><span> </span>
                    </div>
                </div>
                <div class="col-md-5 border-right">
                    <div class="p-3 py-5">
                        <div class="d-flex justify-content-between align-items-center mb-3">
                            <h4 class="text-right">Profile Settings</h4>
                        </div>
                        <div class="row mt-2">
                            <div class="col-md-12">
                                <label class="labels">Name</label>
                                <asp:TextBox ID="Name" runat="server" class="form-control" placeholder="New Name"></asp:TextBox>
                            </div>

                        </div>
                        <div class="row mt-3">
                            <div class="col-md-12">
                                <label class="labels">Current Email</label>
                                <asp:TextBox ID="CurrentEmail" runat="server" CssClass="form-control" placeholder="Current Email Address"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-md-12">
                                <label class="labels">New Email</label>
                                <asp:TextBox ID="NewEmail" runat="server" CssClass="form-control" placeholder="New Email Address"></asp:TextBox>
                            </div>
                        </div>

                        <asp:Label ID="ErrorMessage1" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:Label ID="SuccessMessage1" runat="server" Text="" ForeColor="Green"></asp:Label>


                        <div class="mt-5 text-center">
                            <asp:Button ID="SaveBtn" class="btn btn-primary profile-button" runat="server" Text="Save Profile" OnClick="SaveBtn_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="p-3 py-5">
                        <div class="d-flex justify-content-between align-items-center experience">
                            <h4>Change Password</h4>
                        </div>
                        <br>
                        <div class="col-md-12">
                            <label class="labels">Current Password</label>
                            <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Current Password"></asp:TextBox>
                        </div>
                        <br>
                        <div class="col-md-12">
                            <label class="labels">New Password</label>
                            <asp:TextBox ID="ActualPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="New Password"></asp:TextBox>
                        </div>
                        <br>
                        <div class="col-md-12">
                            <label class="labels">Repeat Password</label>
                            <asp:TextBox ID="RepeatPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Repeat Password"></asp:TextBox>
                        </div>

                        <asp:Label ID="ErrorMessage2" runat="server" Text="" ForeColor="Red"></asp:Label>


                        <div class="mt-5 text-center">
                            <asp:Button ID="UpdateBtn" class="btn btn-primary profile-button" runat="server" Text="Update Password" OnClick="UpdateBtn_Click"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-8 border-right">
                    <div class="d-flex flex-column align-items-center p-3 py-5">
                        <h4>Delete Account</h4>
                        <div class="row mt-2">
                            <div class="col-md-12">
                                <label class="labels">Email</label>
                                <asp:TextBox ID="Email" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>
                            </div>

                        </div>
                        <div class="row mt-3">
                            <div class="col-md-12">
                                <label class="labels">Password</label>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
                            </div>
                        </div>

                        <asp:Label ID="ErrorMessage3" runat="server" Text="" ForeColor="Red"></asp:Label>
                        <asp:Label ID="SuccessMessage3" runat="server" Text="" ForeColor="Green"></asp:Label>


                        <div class="mt-5 text-center">
                            <asp:Button ID="DeleteBtn" class="btn btn-danger profile-button" runat="server" Text="Delete Profile" OnClick="DeleteBtn_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

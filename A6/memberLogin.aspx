<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="memberLogin.aspx.cs" Inherits="A6.memberLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-body">
                        <h5 class="card-title text-center mb-4">Member Login</h5>
                        <p class="text-center">Welcome back! Please sign in to access your account.</p>
                        <asp:Label ID="MessageLabel" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                        <div class="form-group row justify-content-center">
                            <label for="UsernameTextBox" class="col-sm-2 col-form-label text-right">Username:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control" placeholder="Enter your username"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label for="PasswordTextBox" class="col-sm-2 col-form-label text-right">Password:</label>
                            <div class="col-sm-4">
                                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your password"></asp:TextBox>
                            </div>
                        </div>
                                                <br />
                        <div class="form-group row justify-content-center">
                            <div class="col-sm-6 text-center">
                                <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="LoginButton_Click" />
                            </div>
                        </div>

                        <p class="text-center mt-3">Don't have login details? <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/memberSignUp.aspx">Sign Up here</asp:HyperLink>.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

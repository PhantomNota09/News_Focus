<%@ Page Title="Sign Up" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="memberSignUp.aspx.cs" Inherits="A6.memberSignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-body">
                        <h5 class="card-title text-center mb-4">Sign Up</h5>
                        <p class="text-center">Join our community today! Sign up to access exclusive content and features.</p>
                        <asp:Label ID="MessageLabel" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                        <div class="form-group row justify-content-center">
                            <label for="UsernameTextBox" class="col-sm-3 col-form-label text-right">Username:</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="UsernameTextBox" runat="server" CssClass="form-control" placeholder="Enter your username"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label for="PasswordTextBox" class="col-sm-3 col-form-label text-right">Password:</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label for="ConfirmPasswordTextBox" class="col-sm-3 col-form-label text-right">Confirm Password:</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirm your password"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row justify-content-center">
                            <div class="col-sm-6 text-center">
                                <asp:Button ID="SignUpButton" runat="server" CssClass="btn btn-success btn-block" Text="Sign Up" OnClick="SignUpButton_Click" />
                            </div>
                        </div>
                        <p class="text-center mt-3">Already have an account? <asp:HyperLink ID="LoginLink" runat="server" NavigateUrl="~/memberLogin.aspx">Login here</asp:HyperLink>.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

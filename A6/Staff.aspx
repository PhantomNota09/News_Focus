<%@ Page Title="Staff" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="A6.Staff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-body">
                        <h5 class="card-title text-center mb-4">Staff Login</h5>
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
                        <br />
                        <div class="form-group row justify-content-center">
                            <div class="col-sm-6 text-center">
                                <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary btn-block mb-3" Text="Login" OnClick="LoginButton_Click" />
                            </div>
                        </div>
                        <hr />
                        <h5 class="card-title text-center mb-4">New Staff Sign Up</h5>
                        <div class="form-group row justify-content-center">
                            <label for="NewUsernameTextBox" class="col-sm-3 col-form-label text-right">New Username:</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="NewUsernameTextBox" runat="server" CssClass="form-control" placeholder="Enter new username"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label for="NewPasswordTextBox" class="col-sm-3 col-form-label text-right">Password:</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="NewPasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group row justify-content-center">
                            <label for="ConfirmNewPasswordTextBox" class="col-sm-3 col-form-label text-right">Confirm Password:</label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="ConfirmNewPasswordTextBox" runat="server" TextMode="Password" CssClass="form-control" placeholder="Confirm password"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="form-group row justify-content-center">
                            <div class="col-sm-6 text-center">
                                <asp:Button ID="SignUpButton" runat="server" CssClass="btn btn-success btn-block" Text="Sign Up" OnClick="SignUpButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

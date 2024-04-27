<%@ Page Title="Staff Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StaffDashboard.aspx.cs" Inherits="A6.StaffDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow">
                    <div class="card-body">
                        <asp:Label ID="UsernameLabel" runat="server" CssClass="card-title text-center mb-4 font-weight-bold"></asp:Label>
                        <br />
                        <br />
                        <p class="text-center">You have successfully logged in to the Staff Dashboard.</p>
                        <br />
                        <p class="text-center">
                            Buckle up, we're taking a trip through the quantum realm of session states! Current position: 
                        </p>

                        <div class="d-flex justify-content-center">
                            <asp:Label ID="StaffSessionsLabel" runat="server" CssClass="card-title mb-4"></asp:Label>
                        </div>
                        <p class="text-center">Don't forget to hit refresh for an exhilarating ride!</p>
                        <br />
                        <br />

                        <h5 class="card-title text-center mb-4">New Staff Sign Up</h5>
                        <asp:Label ID="MessageLabel" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
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
                        <br />
                        <br />
                        <br />

                        <div class="text-left">
                            <asp:Button ID="LogoutButton" runat="server" Text="Logout" CssClass="btn btn-danger" OnClick="LogoutButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

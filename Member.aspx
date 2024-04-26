<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Member.aspx.cs" Inherits="A6.Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow">
                    <div class="card-body">
                        <h5 class="card-title text-center mb-4">Welcome to the Member Page</h5>
                        <p class="text-center">This is a private area exclusively for our members. Here, you can access exclusive services and more.</p>
                        <div class="text-center mt-4">
                            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-primary mx-2" Text="Login" OnClick="LoginButton_Click" />
                            <asp:Button ID="SignUpButton" runat="server" CssClass="btn btn-success mx-2" Text="Sign Up" OnClick="SignUpButton_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

﻿<%@ Page Title="News Focus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsFocus.aspx.cs" Inherits="A6.NewsFocus" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow">
                    <div class="card-body">
                        <h2 class="text-primary">Find all the news</h2>
                        <p class="lead">Returns all news URLs related to provided topics</p>
                        <hr />
                        <p><strong>Method Name:</strong> NewsFocus(string[] topics)</p>
                        <p><strong>Input:</strong> array of string</p>
                        <p><strong>Output:</strong> array of URLs related to topics</p>
                        <p><strong>Example Input:</strong> jobs, software</p>

                        <div class="row justify-content-left mt-4">
                            <div class="col-md-6">
                                <label class="form-label">Please enter all the topics separated by comma</label>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter topics"></asp:TextBox>
                            </div>

                            <div class="col-md-3 mt-4">
                                <asp:Button ID="Button1" runat="server" Text="Find News" CssClass="btn btn-primary btn-block" OnClick="Button1_Click" />
                            </div>
                        </div>

                        <div class="mt-4">
                            <p class="lead"><strong>Answer:</strong></p>
                            <asp:Label ID="Label1" runat="server" CssClass="result-label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow">
                    <div class="card-body">
                        <h2 class="text-primary">Find the key words in a news article</h2>
                        <p class="lead">Filters out stop words from news text and returns a string of content words</p>
                        <hr />
                        <p><strong>Method Name:</strong> WordFilter(string siteText)</p>
                        <p><strong>Input:</strong> string</p>
                        <p><strong>Output:</strong> string of content words only</p>
                        <p><strong>Example Input:</strong> The weather will be cloudy with a chance of meatballs.</p>

                        <div class="row justify-content-left mt-4">
                            <div class="col-md-6">
                                <label class="form-label2">Please enter a string of text</label>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Enter news text"></asp:TextBox>
                            </div>

                            <div class="col-md-3 mt-4">
                                <asp:Button ID="Button3" runat="server" Text="Filter Text" CssClass="btn btn-primary btn-block" OnClick="Button3_Click" />
                            </div>
                        </div>

                        <div class="mt-4">
                            <p class="lead"><strong>Answer:</strong></p>
                            <asp:Label ID="Label2" runat="server" CssClass="result-label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Logout button -->
    <asp:Button ID="LogoutButton" runat="server" Text="Logout" CssClass="btn btn-danger mt-4" OnClick="LogoutButton_Click" />
</asp:Content>
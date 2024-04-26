﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="A6._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .service-container {
            margin-bottom: 30px; 
        }

        .service-description {
            margin-top: 20px;
        }

        .service-card {
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 20px;
            margin-bottom: 20px;
        }

        .service-card:hover {
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.1);
        }

        .service-title {
            font-size: 24px;
            margin-bottom: 10px;
        }

        .button-container {
            text-align: center;
            margin-top: 30px;
        }

        .btn {
            margin: 0 10px;
        }
    </style>

    <div class="container">
        <div class="jumbotron text-center">
            <h1>Welcome to Our Service Platform</h1>
            <p>Discover the range of services we offer to our members.</p>
        </div>

        <div class="row service-container">
            <div class="col-md-6">
                <div class="service-card">
                    <h2 class="service-title">News Focus</h2>
                    <p class="service-description">
                        News Focus is a WSDL service that uses News API to find all the URLs related to the provided topics.<br />
                        Returns all news URLs related to provided topics<br />
                        Localhost URL of the service: http://webstrar114.fulton.asu.edu/page0/Service1.svc <br />
                        Method Name: NewsFocus(string[] topics)<br />
                        Input: array of string<br />
                        Output: array of URLs related to topics
                    </p>
                </div>
            </div>
            <!-- Add more service cards for other services if needed -->
        <div class="row service-container">
            <div class="col-md-6">
                <div class="service-card">
                    <h2 class="service-title">Word Filter</h2>
                    <p class="service-description">
                        Word Filter is a service that removes stop words from news text and returns only content words (the more significant words).<br />
                        Returns a string of content words<br />
                        Localhost URL of the service: http://webstrar114.fulton.asu.edu/page0/Service2.svc <br />
                        Method Name: WordFilter(string siteText)<br />
                        Input: string<br />
                        Output: string of content words
                    </p>
                </div>
            </div>
        </div>
        <div class="row service-container">
            <div class="col-md-6">
                <div class="service-card">
                    <h2 class="service-title">Top Ten Content Words</h2>
                    <p class="service-description">
                        Top Ten Content Words is a service that removes stop words from news text and returns the top ten most used content words, sorted from most to least used, separated by commas<br />
                        Returns an array of most used content words<br />
                        Localhost URL of the service: http://webstrar114.fulton.asu.edu/page0/Service3.svc <br />
                        Method Name: topTen(string pageContents)<br />
                        Input: string<br />
                        Output: array of string (top ten most used content words)
                    </p>
                </div>
            </div>
        </div>

        <div class="button-container">
            <asp:Button ID="Button1" runat="server" OnClick="memberButtonClick" Text="Member Page" CssClass="btn btn-primary" />
            <asp:Button ID="Button2" runat="server" OnClick="staffButtonClick" Text="Staff Page" CssClass="btn btn-secondary" />
        </div>
    </div>

</asp:Content>

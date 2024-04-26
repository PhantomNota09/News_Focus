<%@ Page Title="News Focus" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsFocus.aspx.cs" Inherits="A6.NewsFocus" %>

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
            <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow">
                    <div class="card-body">
                        <h2 class="text-primary">Top Ten Content Words</h2>
                        <p class="lead">Filters out stop words from news text and returns an array of the top ten content words, from most used to least used, separated by commas</p>
                        <hr />
                        <p><strong>Method Name:</strong> TopTen(string pageContents)</p>
                        <p><strong>Input:</strong> string</p>
                        <p><strong>Output:</strong> array of string </p>
                        <p><strong>Example Input:</strong>  Either make the tree good and its fruit good, 
                                                            or make the tree bad and its fruit bad, for the tree is known by its fruit.
                                                            You brood of vipers! How can you speak good, when you are evil? 
                                                            For out of the abundance of the heart the mouth speaks. 
                                                            The good person out of his good treasure brings forth good, 
                                                            and the evil person out of his evil treasure brings forth evil. 
                                                            I tell you, son the day of judgment people will give account 
                                                            for every careless word they speak, for by your words you will be justified, 
                                                            and by your words you will be condemned.
                                                            
                                                            The Sign of Jonah
                            
                                                            Then some of the scribes and Pharisees answered him, saying, 
                                                            “Teacher, wwe wish to see a sign from you.” But he answered them, 
                                                            “An evil and adulterous generation seeks for a sign, but no sign will be given to it 
                                                            except the sign of the prophet Jonah. For just as Jonah was three days and three nights 
                                                            in the belly of the great fish, so will the Son of Man be three days and three nights 
                                                            in the heart of the earth. The men of Nineveh will rise up at the judgment with this generation and condemn it, 
                                                            for they repented at the preaching of Jonah, and behold, something greater than Jonah is here. 
                                                            The queen of the South will rise up at the judgment with this generation and condemn it, 
                                                            for she came from the ends of the earth to hear the wisdom of Solomon, and behold, 
                                                            something greater than Solomon is here.
                        </p>
                        <div class="row justify-content-left mt-4">
                            <div class="col-md-6">
                                <label class="form-label3">Please enter a string of text</label>
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Enter news text"></asp:TextBox>
                            </div>

                            <div class="col-md-3 mt-4">
                                <asp:Button ID="Button4" runat="server" Text="Filter Text" CssClass="btn btn-primary btn-block" OnClick="Button4_Click" />
                            </div>
                        </div>

                        <div class="mt-4">
                            <p class="lead"><strong>Answer:</strong></p>
                            <asp:Label ID="Label3" runat="server" CssClass="result-label"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Logout button -->
    <asp:Button ID="LogoutButton" runat="server" Text="Logout" CssClass="btn btn-danger mt-4" OnClick="LogoutButton_Click" />
</asp:Content>

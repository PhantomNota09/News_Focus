﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace A6 
{
    public partial class NewsFocus : System.Web.UI.Page
    {
        // Utility class with a method to clear the label text
        public class Util
        {
            public void clearLabel(Label lbl)
            {
                // Clears the text of the label in the parameter
                lbl.Text = "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve user profile information from cookie if available
            HttpCookie userProfileCookie = Request.Cookies["UserProfile"];
            if (userProfileCookie != null)
            {
                string username = userProfileCookie["Username"];
                // Display the username
                UsernameLabel.InnerText = $"Welcome, {username}!";
            }

            // Check if the member is not authenticated, redirect to login page
            if (Session["IsMemberAuthenticated"] == null || !(bool)Session["IsMemberAuthenticated"])
            {
                Response.Redirect("~/memberLogin.aspx");
            }
        }


        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Clear the user authentication status
            Session["IsMemberAuthenticated"] = false;

            // Redirect to the login page
            Response.Redirect("~/memberLogin.aspx");
        }


        // Event handler for the button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the NewsFocus web service client
            WSDLReference.Service1Client client = new WSDLReference.Service1Client();

            // Create an instance of the utility class
            Util util = new Util();

            // Clear the text of the label using the utility method
            util.clearLabel(Label1);

            // Retrieve input from the text box
            string input = TextBox1.Text;

            // Split the input into an array of topics using commas as delimiters
            string[] topics = input.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            // Check if there are topics entered
            if (topics.Length > 0)
            {
                // Call the NewsFocus method of the web service
                string[] data = client.NewsFocus(topics);

                // Check if any data is returned
                if (data.Length > 0)
                {
                    // Iterate through the array of URLs and display them as clickable links
                    foreach (string urls in data)
                    {
                        Label1.Text += $"<a href='{urls}' target='_blank'>{urls}</a><br /><br />";
                    }
                }
                else
                {
                    // Display a message if no news resources are available for the provided topics
                    Label1.Text = "No news resources available for the provided topics.";
                }
            }
            else
            {
                // Display a message if no valid topics are entered
                Label1.Text = "Please enter valid topics.";
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            string siteText = TextBox3.Text;
            Label2.Text = WordFilter(siteText).ToString();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string siteText = TextBox4.Text;
            string[] ans = topTen(siteText);
            string output = ans[0];

            for (int i = 1; i < 10; i++)
            {
                output += ", " + ans[i];
            }

            Label3.Text = output;
        }

        public string WordFilter(string siteText)
        {

            string[] siteParse = siteText.Split(' ');
            string[] stopWords = { "a", "A", "an", "An", "and", "And", "are", "Are", "as", "As", "at", "At", "be", "Be", "but", "But", "by", "By", "for", "For", "if", "If", "in", "In", "into", "Into", "is", "Is", "it", "It", "its", "Its", "no", "No", "not", "Not", "of", "Of", "or", "Or", "such", "Such", "that", "That", "the", "The", "their", "Their", "then", "Then", "there", "There", "these", "These", "they", "They", "this", "This", "to", "To", "was", "Was", "will", "Will", "with", "With" };
            string[] htmlSymbols = { "<", ">", "=" };
            char[] trimChars = { ',', '.' };

            for (int i = 0; i < siteParse.Length; i++)
            {
                bool isHTML = htmlSymbols.Contains(siteParse[i]);
                if (isHTML)
                {
                    siteParse[i] = " ";
                }
                isHTML = false;
            }

            for (int i = 0; i < siteParse.Length; i++)
            {
                siteParse[i] = siteParse[i].TrimEnd(trimChars);
            }

            for (int i = 0; i < siteParse.Length; i++)
            {
                bool isStop = stopWords.Contains(siteParse[i]);
                if (isStop)
                {
                    siteParse[i] = " ";
                }
                isStop = false;
            }

            string filterString = siteParse[0];

            for (int i = 1; i < siteParse.Length; i++)
            {
                if (!siteParse[i].Equals(" "))
                {
                    filterString = filterString + " " + siteParse[i];
                }
            }

            return filterString;
        }

        public string[] topTen(string pageContents)
        {

            string filteredString = WordFilter(pageContents);

            //then, need to figure out how to analyze top 10 words from string 
            string[] filteredArray = filteredString.Split(' ');

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string word in filteredArray)
            {
                if (!wordCount.ContainsKey(word))
                    wordCount.Add(word, 1);
                else wordCount[word]++;
            }

            var sortedContent = wordCount.OrderByDescending(x => x.Value);

            string[] topTen = new string[10];
            int i = 0;

            foreach (var pair in sortedContent)
            {
                if (i < 10)
                {
                    topTen[i] = pair.Key;
                }
                i++;
            }

            return topTen;
        }
    }
}
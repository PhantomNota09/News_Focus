using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

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
            Session["name"] = "Member";
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Log the user out and redirect to the default page
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Default.aspx");
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

        public string WordFilter(string siteText)
        {

            string[] siteParse = siteText.Split(' ');
            string[] stopWords = { "a", "A", "an", "An", "and", "And", "are", "Are", "as", "As", "at", "At", "be", "Be", "but", "But", "by", "By", "for", "For", "if", "If", "in", "In", "into", "Into", "is", "Is", "it", "It", "no", "No", "not", "Not", "of", "Of", "or", "Or", "such", "Such", "that", "That", "the", "The", "their", "Their", "then", "Then", "there", "There", "these", "These", "they", "They", "this", "This", "to", "To", "was", "Was", "will", "Will", "with", "With"};
            string[] htmlSymbols = { "<", ">", "=" };

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
    }
}
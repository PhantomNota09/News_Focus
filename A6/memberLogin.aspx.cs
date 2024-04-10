﻿using EncDec;
using System;
using System.Web;
using System.Web.Security;
using System.Xml;

namespace A6
{
    public partial class memberLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate username and password against stored credentials
                string username = UsernameTextBox.Text;
                string password = PasswordTextBox.Text;

                if (AuthenticateUser(username, password))
                {
                    // Redirect to the NewsFocus page upon successful login
                    FormsAuthentication.RedirectFromLoginPage(username, false);
                    Response.Redirect("~/NewsFocus.aspx"); // Redirect to the NewsFocus page
                }
                else
                {
                    MessageLabel.Text = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageLabel.Text = "An error occurred: " + ex.Message;
            }
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            // Redirect to the memberSignUp page
            Response.Redirect("~/memberSignUp.aspx");
        }

        private bool AuthenticateUser(string username, string password)
        {
            try
            {
                // Load the XML document
                string xmlFilePath = Server.MapPath("~/App_Data/members.xml");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                // Find the member node with the provided username
                XmlNode memberNode = xmlDoc.SelectSingleNode("//Member[Username='" + username + "']");
                if (memberNode != null)
                {
                    // Get the password stored for this member
                    string storedPassword = memberNode.SelectSingleNode("Password").InnerText;

                    // Create an instance of EncryptionDecryption
                    EncryptionDecryption encryptionDecryption = new EncryptionDecryption();

                    // Decrypt the stored password using the instance
                    string decryptedPassword = encryptionDecryption.Decrypt(storedPassword);

                    // Compare the decrypted stored password with the provided password
                    if (decryptedPassword == password)
                    {
                        return true; // Authentication successful
                    }
                }
                return false; // Authentication failed
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Authentication error: " + ex.Message);
            }
        }
    }
}

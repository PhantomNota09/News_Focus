using System;
using EncDec;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Xml;

namespace A6
{
    public partial class memberSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            // Create a new user account
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string confirmPassword = ConfirmPasswordTextBox.Text;

            if (password != confirmPassword)
            {
                MessageLabel.Text = "Passwords do not match.";
                return;
            }

            if (CreateUser(username, password))
            {
                // Redirect to the memberLogin page after successful signup
                Response.Redirect("~/memberLogin.aspx");
            }
            else
            {
                MessageLabel.Text = "Failed to create user account.";
            }
        }

        private bool CreateUser(string username, string password)
        {
            try
            {
                // Store user credentials (e.g., save to XML file)
                string filePath = Server.MapPath("~/App_Data/members.xml");

                // Encrypt password before storing (you can use a more secure encryption algorithm)
                EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
                string encryptedPassword = encryptionDecryption.Encrypt(password);

                // Create XML structure if the file doesn't exist
                if (!File.Exists(filePath))
                {
                    XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.UTF8);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("members");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }

                // Append new user to XML file
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlElement root = doc.DocumentElement;
                XmlElement member = doc.CreateElement("Member");
                XmlElement userNode = doc.CreateElement("Username");
                userNode.InnerText = username;
                XmlElement passNode = doc.CreateElement("Password");
                passNode.InnerText = encryptedPassword;
                member.AppendChild(userNode);
                member.AppendChild(passNode);
                root.AppendChild(member);
                doc.Save(filePath);

                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return false;
            }
        }
    }
}

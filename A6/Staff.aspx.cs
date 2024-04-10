using System;
using EncDec;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Xml;

namespace A6
{
    public partial class Staff : Page
    {
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            // Check username and password against stored credentials
            if (AuthenticateUser(username, password))
            {
                // Redirect to staff dashboard or any other page after successful login
                Response.Redirect("~/StaffDashboard.aspx");
            }
            else
            {
                MessageLabel.Text = "Invalid username or password.";
                MessageLabel.Visible = true;
            }
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            string newUsername = NewUsernameTextBox.Text;
            string newPassword = NewPasswordTextBox.Text;
            string confirmNewPassword = ConfirmNewPasswordTextBox.Text;

            // Check if passwords match
            if (newPassword != confirmNewPassword)
            {
                MessageLabel.Text = "Passwords do not match.";
                MessageLabel.Visible = true;
                return;
            }

            // Create new staff account
            if (CreateStaff(newUsername, newPassword))
            {
                // Redirect to staff dashboard or any other page after successful sign up
                Response.Redirect("~/StaffDashboard.aspx");
            }
            else
            {
                MessageLabel.Text = "Failed to create staff account.";
                MessageLabel.Visible = true;
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            // Perform authentication logic here
            // You can use your existing logic for checking credentials
            // For demonstration, let's assume authentication is successful
            return true;
        }

        private bool CreateStaff(string username, string password)
        {
            try
            {
                string filePath = Server.MapPath("~/App_Data/staff.xml");

                // Check if file exists, if not, create it with root element
                if (!File.Exists(filePath))
                {
                    // Create XML file with root element if it doesn't exist
                    using (XmlWriter writer = XmlWriter.Create(filePath))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Staff");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }
                }

                // Check if username already exists
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNodeList users = doc.SelectNodes("//Staff/Member");
                foreach (XmlNode user in users)
                {
                    string existingUsername = user.SelectSingleNode("Username").InnerText;
                    if (existingUsername == username)
                    {
                        MessageLabel.Text = "Username already exists.";
                        MessageLabel.Visible = true;
                        return false;
                    }
                }

                // Encrypt password before storing
                EncryptionDecryption encryptionDecryption = new EncryptionDecryption();
                string encryptedPassword = encryptionDecryption.Encrypt(password);

                // Add new staff member to XML file
                XmlNode root = doc.SelectSingleNode("//Staff");
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

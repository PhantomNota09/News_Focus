using System;
using EncDec;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Drawing.Imaging;
using System.Drawing;

namespace A6
{
    public partial class Staff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is authenticated as staff
            if (!IsPostBack && Session["IsStaffAuthenticated"] == null)
            {
                MessageLabel.Text = "Please login First";
            }
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            // Check if both username and password are provided
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageLabel.Text = "Please enter both username and password.";
                MessageLabel.Visible = true;
                return;
            }

            // Check username and password against stored credentials
            if (AuthenticateUser(username, password))
            {
                string captchaInput = Request.Form["txtCaptcha"];
                string sessionCaptcha = Session["CaptchaCode"] as string;

                if (captchaInput != null && sessionCaptcha != null && captchaInput.Equals(sessionCaptcha, StringComparison.OrdinalIgnoreCase))
                {
                    MessageLabel.Text = "CAPTCHA validation successful!";
                    // Set session variable to indicate staff authentication
                    Session["IsStaffAuthenticated"] = true;

                    // Redirect to staff dashboard after successful login
                    Response.Redirect("~/StaffDashboard.aspx");
                }
                else
                {
                    MessageLabel.Text = "CAPTCHA verification failed. Please try again.";
                    // Generate a new CAPTCHA code for security
                    Session["CaptchaCode"] = GenerateRandomCode();
                }
            }
            else
            {
                MessageLabel.Text = "Invalid username or password.";
                MessageLabel.Visible = true;
            }
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            // Check if the user is authenticated as staff
            if (Session["IsStaffAuthenticated"] != null && (bool)Session["IsStaffAuthenticated"])
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
                    // Redirect to staff dashboard after successful sign up
                    Response.Redirect("~/StaffDashboard.aspx");
                }
                else
                {
                    MessageLabel.Text = "Failed to create staff account.";
                    MessageLabel.Visible = true;
                }
            }
            else
            {
                MessageLabel.Text = "You need to login as staff first.";
                MessageLabel.Visible = true;
            }
        }
        private bool AuthenticateUser(string username, string password)
        {
            try
            {
                // Load the XML document
                string xmlFilePath = Server.MapPath("~/App_Data/staff.xml");
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
        private string GenerateRandomCode()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] captchaChars = new char[6];
            for (int i = 0; i < 6; i++)
            {
                captchaChars[i] = chars[random.Next(chars.Length)];
            }
            return new string(captchaChars);
        }
    }
}

using System;
using EncDec;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;

namespace A6
{
    public partial class Staff : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["IsStaffAuthenticated"] != null && (bool)Session["IsStaffAuthenticated"])
            {
                Response.Redirect("~/StaffDashboard.aspx");
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

                    HttpCookie staffCookie = new HttpCookie("StaffUsername");
                    staffCookie["Username"] = username; // Store username
                    staffCookie.Expires = DateTime.Now.AddDays(1); // Set expiration time
                    Response.Cookies.Add(staffCookie); // Add cookie to the response

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
using System;
using System.Web;
using System.Web.UI;
using EncDec;
using System.IO;
using System.Xml;

namespace A6
{
    public partial class StaffDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is authenticated as staff
            if (Session["IsStaffAuthenticated"] != null && (bool)Session["IsStaffAuthenticated"])
            {
                // Check if this is a new session
                if (!IsPostBack && Session["Username"] == null)
                {
                    // Increment staff session count
                    Application.Lock();
                    Application["StaffSessionsCount"] = ((int)Application["StaffSessionsCount"]) + 1;

                    Application.UnLock();

                    // Retrieve staff username from cookie if available
                    HttpCookie staffCookie = Request.Cookies["StaffUsername"];
                    if (staffCookie != null)
                    {
                        string staffUsername = staffCookie["Username"];
                        UsernameLabel.Text = $"Welcome, {staffUsername}"; // Display username on the page
                    }
                    else
                    {
                        // If the staff cookie is not available, redirect to the login page
                        Response.Redirect("~/Staff.aspx");
                    }
                }

                // Display active session count
                int staffSessions = (int)Application["StaffSessionsCount"];
                StaffSessionsLabel.Text = $"{staffSessions}. ";
            }
            else
            {
                // If the user is not authenticated as staff, redirect to the staff login page
                Response.Redirect("~/Staff.aspx");
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Clear the staff authentication status
            Session["IsStaffAuthenticated"] = false;

            // Decrement staff session count when staff logs out
            Application.Lock();
            Application["StaffSessionsCount"] = ((int)Application["StaffSessionsCount"]) - 1;
            Application.UnLock();

            // Redirect to the staff login page after logout
            Response.Redirect("~/Staff.aspx");
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

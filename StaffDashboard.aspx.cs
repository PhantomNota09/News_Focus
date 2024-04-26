using System;
using System.Web.UI;

namespace A6
{
    public partial class StaffDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["name"] = "Staff";
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            // Clear the session variable indicating staff authentication
            Session["IsStaffAuthenticated"] = null;
            // Redirect to the login page after logout
            Response.Redirect("~/Default.aspx");
        }
    }
}

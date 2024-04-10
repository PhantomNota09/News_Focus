using System;

namespace A6
{
    public partial class Member : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is already logged in
                if (User.Identity.IsAuthenticated)
                {
                    // Redirect to the News Focus page if the user is already authenticated
                    Response.Redirect("~/NewsFocus.aspx");
                }
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            // Redirect to the memberLogin page
            Response.Redirect("~/memberLogin.aspx");
        }

        protected void SignUpButton_Click(object sender, EventArgs e)
        {
            // Redirect to the memberSignUp page
            Response.Redirect("~/memberSignUp.aspx");
        }
    }
}

using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace A6
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Application["MemberSessionsCount"] = 0;
            Application["StaffSessionsCount"] = 0;
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Increment session count for respective user type
            if (HttpContext.Current.Session["IsStaffAuthenticated"] != null && (bool)HttpContext.Current.Session["IsStaffAuthenticated"])
            {
                Application.Lock();
                if (Application["StaffSessionsCount"] == null)
                {
                    Application["StaffSessionsCount"] = 0;
                }
                Application["StaffSessionsCount"] = (int)Application["StaffSessionsCount"] + 1;
                Application.UnLock();
            }
            else
            {
                Application.Lock();
                if (Application["MemberSessionsCount"] == null)
                {
                    Application["MemberSessionsCount"] = 0;
                }
                Application["MemberSessionsCount"] = (int)Application["MemberSessionsCount"] + 1;
                Application.UnLock();
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Decrement session count for respective user type
            if (HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session["IsStaffAuthenticated"] != null && (bool)HttpContext.Current.Session["IsStaffAuthenticated"])
                {
                    Application.Lock();
                    if (Application["StaffSessionsCount"] != null)
                    {
                        Application["StaffSessionsCount"] = (int)Application["StaffSessionsCount"] - 1;
                    }
                    Application.UnLock();
                }
                else
                {
                    Application.Lock();
                    if (Application["MemberSessionsCount"] != null)
                    {
                        Application["MemberSessionsCount"] = (int)Application["MemberSessionsCount"] - 1;
                    }
                    Application.UnLock();
                }
            }
        }
    }
}

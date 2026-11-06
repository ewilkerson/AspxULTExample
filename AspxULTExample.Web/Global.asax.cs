
using System;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using AspxULTExample.Models;
using AspxULTExample.BL;
using AspxULTExample.Repository;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            string sessionId = Session.SessionID;
            string sessionName = "AspxULTExample_";

            if (!(Session.Count != 0 && (int)Session[sessionName + "UserInfoID"] != 0))
            {
                string userInfoUserName = User.Identity.Name;
                //string userInfoUserName = "blakler1";
                /*            LoadUserInfo loadUserInfo = new LoadUserInfo()
                {
                UserInfoID = 3,
                UserInfoUserIdentityName = "earlw",
                UserInfoUserName = userInfoUserName,
                UserInfoFullName = "Earl L. Wilkerson Jr.",
                UserInfoEmailAddress = "earl.wilkerson.jr@gmail.com",
                UserInfoJobTitle = "Software Engineering",
                UserInfoActiveYesNo = true,
                UserInfoAccessLevelName = "Super Access Level",
                UserInfoAccessLevelID = 1
                };
                */


                ILoadUserInfoStringBL bl =
                new LoadUserInfoStringBL(new LoadUserInfoStringSqlXmlRepository());
                LoadUserInfo loadUserInfo = bl.GetLoadUserInfoByString(userInfoUserName);

                Session[sessionName + "UserInfoUserName"] = string.Empty;
                Session[sessionName + "UserInfoUserIdentityName"] = string.Empty;
                Session[sessionName + "UserInfoID"] = 0;
                Session[sessionName + "UserInfoFullName"] = string.Empty;
                Session[sessionName + "UserInfoEmailAddress"] = string.Empty;
                Session[sessionName + "UserInfoJobTitle"] = string.Empty;
                Session[sessionName + "UserInfoAccessLevelID"] = 0;
                Session[sessionName + "UserInfoActiveYesNo"] = false;
                Session[sessionName + "UserInfoAccessLevelName"] = string.Empty;

                if (loadUserInfo != null && loadUserInfo.UserInfoAccessLevelID != 0)
                {
                    Session[sessionName + "UserInfoID"] = loadUserInfo.UserInfoID;
                    Session[sessionName + "UserInfoUserIdentityName"] = loadUserInfo.UserInfoUserIdentityName;
                    Session[sessionName + "UserInfoUserName"] = loadUserInfo.UserInfoUserName;
                    Session[sessionName + "UserInfoFullName"] = loadUserInfo.UserInfoFullName;
                    Session[sessionName + "UserInfoEmailAddress"] = loadUserInfo.UserInfoEmailAddress;
                    Session[sessionName + "UserInfoJobTitle"] = loadUserInfo.UserInfoJobTitle;
                    Session[sessionName + "UserInfoAccessLevelID"] = loadUserInfo.UserInfoAccessLevelID;
                    Session[sessionName + "UserInfoActiveYesNo"] = loadUserInfo.UserInfoActiveYesNo;
                    Session[sessionName + "UserInfoAccessLevelName"] = loadUserInfo.UserInfoAccessLevelName;
                }
                else
                {
                    Session.Clear();
                    Session.RemoveAll();

                    Log4ExceptionConnDb.Ex(new Exception("User not found. UserName: " + userInfoUserName));
                    Response.Redirect("AccessDenied.aspx");
                }
            }

        }

        void Application_Error(object sender, EventArgs e)
        {
            Exception ex = HttpContext.Current.Server.GetLastError();

            if (ex != null)
            {
                Log4ExceptionConnDb.Ex(ex);
                Server.Transfer("Error.aspx", true);
            }

        }

    }
}

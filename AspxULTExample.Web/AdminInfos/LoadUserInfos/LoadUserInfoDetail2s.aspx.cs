
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//  using System.Drawing;
using System.IO;
using AspxULTExample.BL;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;
using AspxULTExample.Repository;

namespace AspxULTExample.Web.AdminInfos.LoadUserInfos
{

    public partial class LoadUserInfoDetail2s : System.Web.UI.Page
    {

        private ILoadUserInfoBL bl;

        public LoadUserInfoDetail2s()
        {
            bl = new AdminLoadUserInfoBL(new AdminLoadUserInfoXmlRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SessionRedirect();


            if (!IsPostBack)
            {


                string rawUserInfoID = Request.QueryString["id"];
                int userInfoID;
                bool successUserInfoID = int.TryParse(rawUserInfoID, out userInfoID);
                if (!successUserInfoID)
                {
                    userInfoID = 0;
                }



                if (userInfoID != 0)
                {

                    LoadUserInfo loadUserInfo = bl.GetLoadUserInfoById(userInfoID);

                    HiddenField_UserInfoID.Value = loadUserInfo.UserInfoID.ToString();
                    LabelDisplayForUserInfoID.Text = loadUserInfo.UserInfoID.ToString();


                    LabelDisplayForUserInfoUserIdentityName.Text = loadUserInfo.UserInfoUserIdentityName.ToString();


                    LabelDisplayForUserInfoUserName.Text = loadUserInfo.UserInfoUserName.ToString();


                    LabelDisplayForUserInfoFullName.Text = loadUserInfo.UserInfoFullName.ToString();


                    LabelDisplayForUserInfoEmailAddress.Text = loadUserInfo.UserInfoEmailAddress.ToString();


                    LabelDisplayForUserInfoJobTitle.Text = loadUserInfo.UserInfoJobTitle.ToString();


                    LabelDisplayForUserInfoActiveYesNo.Text = loadUserInfo.UserInfoActiveYesNo.ToString();


                    LabelDisplayForUserInfoAccessLevelID.Text = loadUserInfo.UserInfoAccessLevelID.ToString();

                    LabelDisplayForUserInfoAccessLevelName.Text = loadUserInfo.UserInfoAccessLevelName.ToString();

                }
                else
                {
                    DisplayAlert("userInfoID cannot be zero.");
                }

            }
        }

        private string SessionName()
        {
            string sessionName = "AspxULTExample_";
            return sessionName;
        }

        private bool SessionAdminBool()
        {
            bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[SessionName() + "UserInfoActiveYesNo"];
            bool sessionAdminBool = sessionBool && ((int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelSr || (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelJr);

            return sessionAdminBool;
        }

        private void SessionRedirect()
        {
            if (!SessionAdminBool())
            {
                Response.Redirect("~", false);
            }

        }
        protected void DisplayAlert(string msg)
        {
            if (!string.IsNullOrWhiteSpace(msg))
            {
                string msgHtml = ((SiteMaster)Master)?.MsgHtml(msg);
                ((SiteMaster)Master)?.DisplayAlert(msgHtml);
                ModelState.AddModelError("", msgHtml);
            }
        }

    }

}

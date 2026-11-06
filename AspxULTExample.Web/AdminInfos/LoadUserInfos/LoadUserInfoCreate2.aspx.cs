
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

    public partial class LoadUserInfoCreate2 : System.Web.UI.Page
    {

        private ILoadUserInfoBL bl;

        public LoadUserInfoCreate2()
        {
            bl = new AdminLoadUserInfoBL(new AdminLoadUserInfoXmlRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            SessionRedirect();

            if (!IsPostBack)
            {
                BindUserInfo();
            }

        }

        private void BindUserInfo()
        {
            try
            {
                IUserInfoAccessLevelBL blUserInfoAccessLevel = new AdminUserInfoAccessLevelBL(new AdminUserInfoAccessLevelXmlRepository());
                IEnumerable<UserInfoAccessLevel> userInfoAccessLevelLists = blUserInfoAccessLevel.GetUserInfoAccessLevels();
                DropDownListUserInfoAccessLevelID.DataSource = userInfoAccessLevelLists;
                DropDownListUserInfoAccessLevelID.DataValueField = "UserInfoAccessLevelID";
                DropDownListUserInfoAccessLevelID.DataTextField = "UserInfoAccessLevelName";
                DropDownListUserInfoAccessLevelID.DataBind();

            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.Ex(exception);
                DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }
        }

        protected void Submit_Create(Object sender, EventArgs e)
        {
            try
            {
                SessionRedirect();

                string userInfoUserIdentityName = TextBoxUserInfoUserIdentityName.Text;
                string userInfoUserName = TextBoxUserInfoUserName.Text;
                string userInfoFullName = TextBoxUserInfoFullName.Text;
                string userInfoEmailAddress = TextBoxUserInfoEmailAddress.Text;
                string userInfoJobTitle = TextBoxUserInfoJobTitle.Text;
                bool userInfoActiveYesNo = CheckBoxUserInfoActiveYesNo.Checked;

                int userInfoAccessLevelID;
                bool successUserInfoAccessLevelID = int.TryParse(DropDownListUserInfoAccessLevelID.SelectedValue, out userInfoAccessLevelID);
                if (!successUserInfoAccessLevelID)
                {
                    userInfoAccessLevelID = 0;
                }



                LoadUserInfo loadUserInfo = new LoadUserInfo()
                {
                    UserInfoID = 1,
                    UserInfoUserIdentityName = userInfoUserIdentityName,
                    UserInfoUserName = userInfoUserName,
                    UserInfoFullName = userInfoFullName,
                    UserInfoEmailAddress = userInfoEmailAddress,
                    UserInfoJobTitle = userInfoJobTitle,
                    UserInfoActiveYesNo = userInfoActiveYesNo,
                    UserInfoAccessLevelID = userInfoAccessLevelID
                };

                ValidationContext context = new ValidationContext(loadUserInfo, serviceProvider: null, items: null);
                List<ValidationResult> results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(loadUserInfo, context, results, false);

                Validate();
                if (Page.IsValid && isValid)
                {

                    if (bl.InsertLoadUserInfo(loadUserInfo))
                    {
                        if (loadUserInfo.ErrID != 0)
                        {
                            DisplayAlert(loadUserInfo.ErrText);
                        }
                        else
                        {
                            Response.Redirect("../LoadUserInfos/LoadUserInfoEditDelete.aspx?id=" + loadUserInfo.UserInfoID, false);
                        }

                    }
                    else
                    {
                        DisplayAlert(MsgText(loadUserInfo));
                    }

                }
            }
            catch (DataException exception)
            {
                DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
                Log4ExceptionConnDb.Ex(exception);
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

        protected string MsgText(LoadUserInfo loadUserInfo)
        {
            string msg = string.Empty;

            if (loadUserInfo != null)
            {

                Dictionary<string, string>
                isVal = bl.LoadUserInfoIsValid(loadUserInfo);


                foreach (var kvp in isVal)
                    msg += "*\t" + kvp.Value + "\n";

            }
            else
            {
                msg = "LoadUserInfo cannot be null.";
            }

            return msg;
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

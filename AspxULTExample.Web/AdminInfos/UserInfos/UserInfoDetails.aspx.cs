
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

    namespace AspxULTExample.Web.AdminInfos.UserInfos
    {
    
    public partial class UserInfoDetails : System.Web.UI.Page
    {

    private IUserInfoBL bl;

    public UserInfoDetails()
    {
    bl = new AdminUserInfoBL(new AdminUserInfoXmlRepository());
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

    UserInfo userInfo = bl.GetUserInfoById(userInfoID);
    
    HiddenField_UserInfoID.Value = userInfo.UserInfoID.ToString();
    LabelDisplayForUserInfoID.Text = userInfo.UserInfoID.ToString();
  

    LabelDisplayForUserInfoUserIdentityName.Text = userInfo.UserInfoUserIdentityName.ToString();
  

    LabelDisplayForUserInfoUserName.Text = userInfo.UserInfoUserName.ToString();
  

    LabelDisplayForUserInfoFullName.Text = userInfo.UserInfoFullName.ToString();
  

    LabelDisplayForUserInfoEmailAddress.Text = userInfo.UserInfoEmailAddress.ToString();
  

    LabelDisplayForUserInfoJobTitle.Text = userInfo.UserInfoJobTitle.ToString();
  

    LabelDisplayForUserInfoActiveYesNo.Text = userInfo.UserInfoActiveYesNo.ToString();
  


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
    if(!string.IsNullOrWhiteSpace(msg)){
    string msgHtml = ((SiteMaster)Master)?.MsgHtml(msg);
    ((SiteMaster)Master)?.DisplayAlert(msgHtml);
    ModelState.AddModelError("", msgHtml);
    }
    }

    }
  
    }
  
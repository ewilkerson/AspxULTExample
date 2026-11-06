
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoAccessLevels
    {
    
    public partial class UserInfoAccessLevelTelerikRadDetails : System.Web.UI.Page
    {

    private IUserInfoAccessLevelBL bl;

    public UserInfoAccessLevelTelerikRadDetails()
    {
    bl = new AdminUserInfoAccessLevelBL(new AdminUserInfoAccessLevelXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawUserInfoAccessLevelID = Request.QueryString["id"];
    int userInfoAccessLevelID;
    bool successUserInfoAccessLevelID = int.TryParse(rawUserInfoAccessLevelID, out userInfoAccessLevelID);
    if (!successUserInfoAccessLevelID)
    {
    userInfoAccessLevelID = 0;
    }
  


    if (userInfoAccessLevelID != 0)
    {

    UserInfoAccessLevel userInfoAccessLevel = bl.GetUserInfoAccessLevelById(userInfoAccessLevelID);
    
    HiddenField_UserInfoAccessLevelID.Value = userInfoAccessLevel.UserInfoAccessLevelID.ToString();
    LabelDisplayForUserInfoAccessLevelID.Text = userInfoAccessLevel.UserInfoAccessLevelID.ToString();
  

    LabelDisplayForUserInfoAccessLevelName.Text = userInfoAccessLevel.UserInfoAccessLevelName.ToString();
  

    LabelDisplayForUserInfoAccessLevelNum.Text = userInfoAccessLevel.UserInfoAccessLevelNum.ToString();
  

    LabelDisplayForUserInfoAccessLevelActiveYesNo.Text = userInfoAccessLevel.UserInfoAccessLevelActiveYesNo.ToString();
  

    }
    else
    {
    DisplayAlert("userInfoAccessLevelID cannot be zero.");
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
  
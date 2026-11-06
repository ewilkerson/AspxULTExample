
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoUserInfoAccessLevelXrefs
    {
    
    public partial class UserInfoUserInfoAccessLevelXrefTelerikRadDetails : System.Web.UI.Page
    {

    private IUserInfoUserInfoAccessLevelXrefBL bl;

    public UserInfoUserInfoAccessLevelXrefTelerikRadDetails()
    {
    bl = new AdminUserInfoUserInfoAccessLevelXrefBL(new AdminUserInfoUserInfoAccessLevelXrefXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawUserInfoUserInfoAccessLevelXrefID = Request.QueryString["id"];
    int userInfoUserInfoAccessLevelXrefID;
    bool successUserInfoUserInfoAccessLevelXrefID = int.TryParse(rawUserInfoUserInfoAccessLevelXrefID, out userInfoUserInfoAccessLevelXrefID);
    if (!successUserInfoUserInfoAccessLevelXrefID)
    {
    userInfoUserInfoAccessLevelXrefID = 0;
    }
  


    if (userInfoUserInfoAccessLevelXrefID != 0)
    {

    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = bl.GetUserInfoUserInfoAccessLevelXrefById(userInfoUserInfoAccessLevelXrefID);
    
    HiddenField_UserInfoUserInfoAccessLevelXrefID.Value = userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID.ToString();
    LabelDisplayForUserInfoUserInfoAccessLevelXrefID.Text = userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID.ToString();
  

    LabelDisplayForUserInfoID.Text = userInfoUserInfoAccessLevelXref.UserInfoID.ToString();
  

    LabelDisplayForUserInfoAccessLevelID.Text = userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID.ToString();
  

    LabelDisplayForUserInfoUserInfoAccessLevelXrefActiveYesNo.Text = userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefActiveYesNo.ToString();
  

    }
    else
    {
    DisplayAlert("userInfoUserInfoAccessLevelXrefID cannot be zero.");
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
  
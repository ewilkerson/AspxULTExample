
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoUserInfoCompanyXrefs
    {
    
    public partial class UserInfoUserInfoCompanyXrefDetails : System.Web.UI.Page
    {

    private IUserInfoUserInfoCompanyXrefBL bl;

    public UserInfoUserInfoCompanyXrefDetails()
    {
    bl = new AdminUserInfoUserInfoCompanyXrefBL(new AdminUserInfoUserInfoCompanyXrefXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {

    
    string rawUserInfoUserInfoCompanyXrefID = Request.QueryString["id"];
    int userInfoUserInfoCompanyXrefID;
    bool successUserInfoUserInfoCompanyXrefID = int.TryParse(rawUserInfoUserInfoCompanyXrefID, out userInfoUserInfoCompanyXrefID);
    if (!successUserInfoUserInfoCompanyXrefID)
    {
    userInfoUserInfoCompanyXrefID = 0;
    }
  


    if (userInfoUserInfoCompanyXrefID != 0)
    {

    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = bl.GetUserInfoUserInfoCompanyXrefById(userInfoUserInfoCompanyXrefID);
    
    HiddenField_UserInfoUserInfoCompanyXrefID.Value = userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID.ToString();
    LabelDisplayForUserInfoUserInfoCompanyXrefID.Text = userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID.ToString();
  

    LabelDisplayForUserInfoID.Text = userInfoUserInfoCompanyXref.UserInfoID.ToString();
  

    LabelDisplayForUserInfoCompanyID.Text = userInfoUserInfoCompanyXref.UserInfoCompanyID.ToString();
  

    LabelDisplayForUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo.Text = userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo.ToString();
  

    LabelDisplayForUserInfoUserInfoCompanyXrefActiveYesNo.Text = userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefActiveYesNo.ToString();
  


    }
    else
    {
    DisplayAlert("userInfoUserInfoCompanyXrefID cannot be zero.");
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
  
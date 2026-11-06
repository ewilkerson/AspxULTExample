
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoCompanys
    {
    
    public partial class UserInfoCompanyDetails : System.Web.UI.Page
    {

    private IUserInfoCompanyBL bl;

    public UserInfoCompanyDetails()
    {
    bl = new AdminUserInfoCompanyBL(new AdminUserInfoCompanyXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {

    
    string rawUserInfoCompanyID = Request.QueryString["id"];
    int userInfoCompanyID;
    bool successUserInfoCompanyID = int.TryParse(rawUserInfoCompanyID, out userInfoCompanyID);
    if (!successUserInfoCompanyID)
    {
    userInfoCompanyID = 0;
    }
  


    if (userInfoCompanyID != 0)
    {

    UserInfoCompany userInfoCompany = bl.GetUserInfoCompanyById(userInfoCompanyID);
    
    HiddenField_UserInfoCompanyID.Value = userInfoCompany.UserInfoCompanyID.ToString();
    LabelDisplayForUserInfoCompanyID.Text = userInfoCompany.UserInfoCompanyID.ToString();
  

    LabelDisplayForUserInfoCompanyEIN.Text = userInfoCompany.UserInfoCompanyEIN.ToString();
  

    LabelDisplayForUserInfoCompanyName.Text = userInfoCompany.UserInfoCompanyName.ToString();
  

    LabelDisplayForUserInfoCompanyAddress1.Text = userInfoCompany.UserInfoCompanyAddress1.ToString();
  

    LabelDisplayForUserInfoCompanyAddress2.Text = userInfoCompany.UserInfoCompanyAddress2.ToString();
  

    LabelDisplayForUserInfoCompanyCityStateZip.Text = userInfoCompany.UserInfoCompanyCityStateZip.ToString();
  

    LabelDisplayForUserInfoCompanyTelephone.Text = userInfoCompany.UserInfoCompanyTelephone.ToString();
  

    LabelDisplayForUserInfoCompanyEmailAddress.Text = userInfoCompany.UserInfoCompanyEmailAddress.ToString();
  

    LabelDisplayForUserCompanyWebsiteAddress.Text = userInfoCompany.UserCompanyWebsiteAddress.ToString();
  

    LabelDisplayForUserInfoCountriesID.Text = userInfoCompany.UserInfoCountriesID.ToString();
  

    LabelDisplayForUserInfoCompanyActiveYesNo.Text = userInfoCompany.UserInfoCompanyActiveYesNo.ToString();
  


    }
    else
    {
    DisplayAlert("userInfoCompanyID cannot be zero.");
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
  
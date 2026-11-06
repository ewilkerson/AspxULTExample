
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoCountriess
    {
    
    public partial class UserInfoCountriesDetails : System.Web.UI.Page
    {

    private IUserInfoCountriesBL bl;

    public UserInfoCountriesDetails()
    {
    bl = new AdminUserInfoCountriesBL(new AdminUserInfoCountriesXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {

    
    string rawUserInfoCountriesID = Request.QueryString["id"];
    int userInfoCountriesID;
    bool successUserInfoCountriesID = int.TryParse(rawUserInfoCountriesID, out userInfoCountriesID);
    if (!successUserInfoCountriesID)
    {
    userInfoCountriesID = 0;
    }
  


    if (userInfoCountriesID != 0)
    {

    UserInfoCountries userInfoCountries = bl.GetUserInfoCountriesById(userInfoCountriesID);
    
    HiddenField_UserInfoCountriesID.Value = userInfoCountries.UserInfoCountriesID.ToString();
    LabelDisplayForUserInfoCountriesID.Text = userInfoCountries.UserInfoCountriesID.ToString();
  

    LabelDisplayForUserInfoCountriesName.Text = userInfoCountries.UserInfoCountriesName.ToString();
  

    LabelDisplayForUserInfoCountriesActiveYesNo.Text = userInfoCountries.UserInfoCountriesActiveYesNo.ToString();
  


    }
    else
    {
    DisplayAlert("userInfoCountriesID cannot be zero.");
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
  
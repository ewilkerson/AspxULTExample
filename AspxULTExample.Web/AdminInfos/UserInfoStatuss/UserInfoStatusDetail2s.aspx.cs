
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoStatuss
    {
    
    public partial class UserInfoStatusDetail2s : System.Web.UI.Page
    {

    private IUserInfoStatusBL bl;

    public UserInfoStatusDetail2s()
    {
    bl = new AdminUserInfoStatusBL(new AdminUserInfoStatusXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {

    
    string rawUserInfoStatusID = Request.QueryString["id"];
    int userInfoStatusID;
    bool successUserInfoStatusID = int.TryParse(rawUserInfoStatusID, out userInfoStatusID);
    if (!successUserInfoStatusID)
    {
    userInfoStatusID = 0;
    }
  


    if (userInfoStatusID != 0)
    {

    UserInfoStatus userInfoStatus = bl.GetUserInfoStatusById(userInfoStatusID);
    
    HiddenField_UserInfoStatusID.Value = userInfoStatus.UserInfoStatusID.ToString();
    LabelDisplayForUserInfoStatusID.Text = userInfoStatus.UserInfoStatusID.ToString();
  

    LabelDisplayForUserInfoStatusName.Text = userInfoStatus.UserInfoStatusName.ToString();
  

    LabelDisplayForUserInfoStatusActiveYesNo.Text = userInfoStatus.UserInfoStatusActiveYesNo.ToString();
  


    }
    else
    {
    DisplayAlert("userInfoStatusID cannot be zero.");
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
  
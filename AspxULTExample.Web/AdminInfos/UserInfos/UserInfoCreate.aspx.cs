
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
    
    public partial class UserInfoCreate : System.Web.UI.Page
    {

    private IUserInfoBL bl;

    public UserInfoCreate()
    {
    bl = new AdminUserInfoBL(new AdminUserInfoXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();
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


    UserInfo userInfo = new UserInfo()
    {
    UserInfoID = 1,
UserInfoUserIdentityName = userInfoUserIdentityName,
UserInfoUserName = userInfoUserName,
UserInfoFullName = userInfoFullName,
UserInfoEmailAddress = userInfoEmailAddress,
UserInfoJobTitle = userInfoJobTitle,
UserInfoActiveYesNo = userInfoActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfo, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfo, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertUserInfo(userInfo))
    {
    if (userInfo.ErrID != 0)
    {
    DisplayAlert(userInfo.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfos/UserInfoGridView.aspx",false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfo));
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

    protected string MsgText(UserInfo userInfo)
    {
    string msg = string.Empty;

    if (userInfo != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoIsValid(userInfo);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfo cannot be null.";
    }

    return msg;
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
  
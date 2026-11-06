
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
    
    public partial class UserInfoAccessLevelCreate2 : System.Web.UI.Page
    {

    private IUserInfoAccessLevelBL bl;

    public UserInfoAccessLevelCreate2()
    {
    bl = new AdminUserInfoAccessLevelBL(new AdminUserInfoAccessLevelXmlRepository());
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

    string userInfoAccessLevelName = TextBoxUserInfoAccessLevelName.Text;

    int userInfoAccessLevelNum;
    bool successUserInfoAccessLevelNum = int.TryParse(TextBoxUserInfoAccessLevelNum.Text, out userInfoAccessLevelNum);
    if (!successUserInfoAccessLevelNum)
    {
    userInfoAccessLevelNum = 0;
    }
  
bool userInfoAccessLevelActiveYesNo = CheckBoxUserInfoAccessLevelActiveYesNo.Checked;


    UserInfoAccessLevel userInfoAccessLevel = new UserInfoAccessLevel()
    {
    UserInfoAccessLevelID = 1,
UserInfoAccessLevelName = userInfoAccessLevelName,
UserInfoAccessLevelNum = userInfoAccessLevelNum,
UserInfoAccessLevelActiveYesNo = userInfoAccessLevelActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoAccessLevel, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoAccessLevel, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertUserInfoAccessLevel(userInfoAccessLevel))
    {
    if (userInfoAccessLevel.ErrID != 0)
    {
    DisplayAlert(userInfoAccessLevel.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoAccessLevels/UserInfoAccessLevelEditDelete.aspx?id=" + userInfoAccessLevel.UserInfoAccessLevelID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoAccessLevel));
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

    protected string MsgText(UserInfoAccessLevel userInfoAccessLevel)
    {
    string msg = string.Empty;

    if (userInfoAccessLevel != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoAccessLevelIsValid(userInfoAccessLevel);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoAccessLevel cannot be null.";
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
  
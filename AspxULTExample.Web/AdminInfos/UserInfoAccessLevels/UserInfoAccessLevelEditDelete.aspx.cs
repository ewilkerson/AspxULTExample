
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
    
    public partial class UserInfoAccessLevelEditDelete : System.Web.UI.Page
    {

    private IUserInfoAccessLevelBL bl;

    public UserInfoAccessLevelEditDelete()
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
    LabelUserInfoAccessLevelID.Text = userInfoAccessLevel.UserInfoAccessLevelID.ToString();
  

    TextBoxUserInfoAccessLevelName.Text = userInfoAccessLevel.UserInfoAccessLevelName;
TextBoxUserInfoAccessLevelNum.Text = userInfoAccessLevel.UserInfoAccessLevelNum.ToString();
CheckBoxUserInfoAccessLevelActiveYesNo.Checked = userInfoAccessLevel.UserInfoAccessLevelActiveYesNo;


    }
    else
    {
    DisplayAlert("userInfoAccessLevelID cannot be zero.");
    }

    }
    }

    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int userInfoAccessLevelID;
    bool successUserInfoAccessLevelID = int.TryParse(HiddenField_UserInfoAccessLevelID.Value, out userInfoAccessLevelID);
    if (!successUserInfoAccessLevelID)
    {
    userInfoAccessLevelID = 0;
    }
  
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
    UserInfoAccessLevelID = userInfoAccessLevelID,
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

    if (bl.UpdateUserInfoAccessLevel(userInfoAccessLevel))
    {
    if (userInfoAccessLevel.ErrID != 0)
    {
    DisplayAlert(userInfoAccessLevel.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoAccessLevels/UserInfoAccessLevelEditDelete.aspx?id=" + userInfoAccessLevelID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoAccessLevel));
    }
    }

    }
    catch (Exception exception)
    {
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);

    }

    }
    protected void Submit_Delete(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int userInfoAccessLevelID;
    bool successUserInfoAccessLevelID = int.TryParse(HiddenField_UserInfoAccessLevelID.Value, out userInfoAccessLevelID);
    if (!successUserInfoAccessLevelID)
    {
    userInfoAccessLevelID = 0;
    }
  



    if(userInfoAccessLevelID != 0)
    {

    UserInfoAccessLevel userInfoAccessLevel = bl.GetUserInfoAccessLevelById(userInfoAccessLevelID);

    if (bl.DeleteUserInfoAccessLevel(userInfoAccessLevelID, userInfoAccessLevel))
    {
    if (userInfoAccessLevel.ErrID != 0)
    {
    DisplayAlert(userInfoAccessLevel.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoAccessLevels/UserInfoAccessLevelGridView2.aspx",false);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoAccessLevel));
    }

    }
    else
    {
    DisplayAlert("userInfoAccessLevelID cannot be zero.");
    }

    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

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
  
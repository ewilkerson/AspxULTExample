
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
    
    public partial class UserInfoStatusTelerikRadCreate : System.Web.UI.Page
    {

    private IUserInfoStatusBL bl;


    public UserInfoStatusTelerikRadCreate()
    {
    bl = new AdminUserInfoStatusBL(new AdminUserInfoStatusXmlRepository());
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

    string userInfoStatusName = TextBoxUserInfoStatusName.Text;
bool userInfoStatusActiveYesNo = CheckBoxUserInfoStatusActiveYesNo.Checked != null ? CheckBoxUserInfoStatusActiveYesNo.Checked.Value : false;


    UserInfoStatus userInfoStatus = new UserInfoStatus()
    {
    UserInfoStatusID = 1,
UserInfoStatusName = userInfoStatusName,
UserInfoStatusActiveYesNo = userInfoStatusActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoStatus, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoStatus, context, results, false);


    Validate();
    if (Page.IsValid && isValid)
    {


    if (bl.InsertUserInfoStatus(userInfoStatus))
    {
    if (userInfoStatus.ErrID != 0)
    {
    DisplayAlert(userInfoStatus.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoStatuss/UserInfoStatusTelerikRadEditDelete.aspx?id=" + userInfoStatus.UserInfoStatusID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoStatus));
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

    protected string MsgText(UserInfoStatus userInfoStatus)
    {
    string msg = string.Empty;

    if (userInfoStatus != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoStatusIsValid(userInfoStatus);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoStatus cannot be null.";
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
  
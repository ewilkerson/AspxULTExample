
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
    
    public partial class UserInfoUserInfoAccessLevelXrefCreate2 : System.Web.UI.Page
    {

    private IUserInfoUserInfoAccessLevelXrefBL bl;

    public UserInfoUserInfoAccessLevelXrefCreate2()
    {
    bl = new AdminUserInfoUserInfoAccessLevelXrefBL(new AdminUserInfoUserInfoAccessLevelXrefXmlRepository());
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

    
    int userInfoID;
    bool successUserInfoID = int.TryParse(TextBoxUserInfoID.Text, out userInfoID);
    if (!successUserInfoID)
    {
    userInfoID = 0;
    }
  

    int userInfoAccessLevelID;
    bool successUserInfoAccessLevelID = int.TryParse(TextBoxUserInfoAccessLevelID.Text, out userInfoAccessLevelID);
    if (!successUserInfoAccessLevelID)
    {
    userInfoAccessLevelID = 0;
    }
  
bool userInfoUserInfoAccessLevelXrefActiveYesNo = CheckBoxUserInfoUserInfoAccessLevelXrefActiveYesNo.Checked;


    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref()
    {
    UserInfoUserInfoAccessLevelXrefID = 1,
UserInfoID = userInfoID,
UserInfoAccessLevelID = userInfoAccessLevelID,
UserInfoUserInfoAccessLevelXrefActiveYesNo = userInfoUserInfoAccessLevelXrefActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoUserInfoAccessLevelXref, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoUserInfoAccessLevelXref, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertUserInfoUserInfoAccessLevelXref(userInfoUserInfoAccessLevelXref))
    {
    if (userInfoUserInfoAccessLevelXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoAccessLevelXref.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoUserInfoAccessLevelXrefs/UserInfoUserInfoAccessLevelXrefEditDelete.aspx?id=" + userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoAccessLevelXref));
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

    protected string MsgText(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {
    string msg = string.Empty;

    if (userInfoUserInfoAccessLevelXref != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoUserInfoAccessLevelXrefIsValid(userInfoUserInfoAccessLevelXref);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoUserInfoAccessLevelXref cannot be null.";
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
  
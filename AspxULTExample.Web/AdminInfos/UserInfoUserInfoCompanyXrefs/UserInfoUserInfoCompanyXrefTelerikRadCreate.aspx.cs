
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
    
    public partial class UserInfoUserInfoCompanyXrefTelerikRadCreate : System.Web.UI.Page
    {

    private IUserInfoUserInfoCompanyXrefBL bl;


    public UserInfoUserInfoCompanyXrefTelerikRadCreate()
    {
    bl = new AdminUserInfoUserInfoCompanyXrefBL(new AdminUserInfoUserInfoCompanyXrefXmlRepository());
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

    int userInfoID = TextBoxUserInfoID.Value != null ? (int)TextBoxUserInfoID.Value: 0;
int userInfoCompanyID = TextBoxUserInfoCompanyID.Value != null ? (int)TextBoxUserInfoCompanyID.Value: 0;
bool userInfoUserInfoCompanyXrefEmailAddressActiveYesNo = CheckBoxUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo.Checked != null ? CheckBoxUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo.Checked.Value : false;
bool userInfoUserInfoCompanyXrefActiveYesNo = CheckBoxUserInfoUserInfoCompanyXrefActiveYesNo.Checked != null ? CheckBoxUserInfoUserInfoCompanyXrefActiveYesNo.Checked.Value : false;


    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref()
    {
    UserInfoUserInfoCompanyXrefID = 1,
UserInfoID = userInfoID,
UserInfoCompanyID = userInfoCompanyID,
UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo = userInfoUserInfoCompanyXrefEmailAddressActiveYesNo,
UserInfoUserInfoCompanyXrefActiveYesNo = userInfoUserInfoCompanyXrefActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoUserInfoCompanyXref, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoUserInfoCompanyXref, context, results, false);


    Validate();
    if (Page.IsValid && isValid)
    {


    if (bl.InsertUserInfoUserInfoCompanyXref(userInfoUserInfoCompanyXref))
    {
    if (userInfoUserInfoCompanyXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoCompanyXref.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefTelerikRadEditDelete.aspx?id=" + userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoCompanyXref));
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

    protected string MsgText(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {
    string msg = string.Empty;

    if (userInfoUserInfoCompanyXref != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoUserInfoCompanyXrefIsValid(userInfoUserInfoCompanyXref);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoUserInfoCompanyXref cannot be null.";
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
  
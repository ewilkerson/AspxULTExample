
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
    
    public partial class UserInfoUserInfoCompanyXrefTelerikRadEditDelete : System.Web.UI.Page
    {

    private IUserInfoUserInfoCompanyXrefBL bl;

    public UserInfoUserInfoCompanyXrefTelerikRadEditDelete()
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
    HiddenField_UserInfoUserInfoCompanyXrefID.Value = userInfoUserInfoCompanyXrefID.ToString();
    LabelUserInfoUserInfoCompanyXrefID.Text = userInfoUserInfoCompanyXrefID.ToString();

    TextBoxUserInfoID.Value = userInfoUserInfoCompanyXref.UserInfoID;
TextBoxUserInfoCompanyID.Value = userInfoUserInfoCompanyXref.UserInfoCompanyID;
CheckBoxUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo.Checked = userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo;
CheckBoxUserInfoUserInfoCompanyXrefActiveYesNo.Checked = userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefActiveYesNo;


    }
    else
    {
    DisplayAlert("userInfoUserInfoCompanyXrefID cannot be zero.");
    }

    }
    }

    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int userInfoUserInfoCompanyXrefID;
    bool successUserInfoUserInfoCompanyXrefID = int.TryParse(HiddenField_UserInfoUserInfoCompanyXrefID.Value, out userInfoUserInfoCompanyXrefID);
    if (!successUserInfoUserInfoCompanyXrefID)
    {
    userInfoUserInfoCompanyXrefID = 0;
    }
  
int userInfoID = TextBoxUserInfoID.Value != null ? (int)TextBoxUserInfoID.Value: 0;
int userInfoCompanyID = TextBoxUserInfoCompanyID.Value != null ? (int)TextBoxUserInfoCompanyID.Value: 0;
bool userInfoUserInfoCompanyXrefEmailAddressActiveYesNo = CheckBoxUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo.Checked != null ? CheckBoxUserInfoUserInfoCompanyXrefEmailAddressActiveYesNo.Checked.Value : false;
bool userInfoUserInfoCompanyXrefActiveYesNo = CheckBoxUserInfoUserInfoCompanyXrefActiveYesNo.Checked != null ? CheckBoxUserInfoUserInfoCompanyXrefActiveYesNo.Checked.Value : false;


    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref()
    {
    UserInfoUserInfoCompanyXrefID = userInfoUserInfoCompanyXrefID,
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

    if (bl.UpdateUserInfoUserInfoCompanyXref(userInfoUserInfoCompanyXref))
    {
    if (userInfoUserInfoCompanyXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoCompanyXref.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefTelerikRadEditDelete.aspx?id=" + userInfoUserInfoCompanyXrefID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoCompanyXref));
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

    
    int userInfoUserInfoCompanyXrefID;
    bool successUserInfoUserInfoCompanyXrefID = int.TryParse(HiddenField_UserInfoUserInfoCompanyXrefID.Value, out userInfoUserInfoCompanyXrefID);
    if (!successUserInfoUserInfoCompanyXrefID)
    {
    userInfoUserInfoCompanyXrefID = 0;
    }
  


    if(userInfoUserInfoCompanyXrefID != 0)
    {
    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = bl.GetUserInfoUserInfoCompanyXrefById(userInfoUserInfoCompanyXrefID);

    if (bl.DeleteUserInfoUserInfoCompanyXref(userInfoUserInfoCompanyXrefID, userInfoUserInfoCompanyXref))
    {
    if (userInfoUserInfoCompanyXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoCompanyXref.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoUserInfoCompanyXrefs/UserInfoUserInfoCompanyXrefTelerikRadGrid2.aspx",false);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoCompanyXref));
    }

    }
    else
    {
    DisplayAlert("userInfoUserInfoCompanyXrefID cannot be zero.");
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
  
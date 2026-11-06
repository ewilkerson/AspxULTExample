
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
    
    public partial class UserInfoUserInfoAccessLevelXrefTelerikRadEditDelete : System.Web.UI.Page
    {

    private IUserInfoUserInfoAccessLevelXrefBL bl;

    public UserInfoUserInfoAccessLevelXrefTelerikRadEditDelete()
    {
    bl = new AdminUserInfoUserInfoAccessLevelXrefBL(new AdminUserInfoUserInfoAccessLevelXrefXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawUserInfoUserInfoAccessLevelXrefID = Request.QueryString["id"];
    int userInfoUserInfoAccessLevelXrefID;
    bool successUserInfoUserInfoAccessLevelXrefID = int.TryParse(rawUserInfoUserInfoAccessLevelXrefID, out userInfoUserInfoAccessLevelXrefID);
    if (!successUserInfoUserInfoAccessLevelXrefID)
    {
    userInfoUserInfoAccessLevelXrefID = 0;
    }
  


    if (userInfoUserInfoAccessLevelXrefID != 0)

    {

    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = bl.GetUserInfoUserInfoAccessLevelXrefById(userInfoUserInfoAccessLevelXrefID);
    HiddenField_UserInfoUserInfoAccessLevelXrefID.Value = userInfoUserInfoAccessLevelXrefID.ToString();
    LabelUserInfoUserInfoAccessLevelXrefID.Text = userInfoUserInfoAccessLevelXrefID.ToString();

    TextBoxUserInfoID.Value = userInfoUserInfoAccessLevelXref.UserInfoID;
TextBoxUserInfoAccessLevelID.Value = userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID;
CheckBoxUserInfoUserInfoAccessLevelXrefActiveYesNo.Checked = userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefActiveYesNo;


    }
    else
    {
    DisplayAlert("userInfoUserInfoAccessLevelXrefID cannot be zero.");
    }

    }
    }

    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int userInfoUserInfoAccessLevelXrefID;
    bool successUserInfoUserInfoAccessLevelXrefID = int.TryParse(HiddenField_UserInfoUserInfoAccessLevelXrefID.Value, out userInfoUserInfoAccessLevelXrefID);
    if (!successUserInfoUserInfoAccessLevelXrefID)
    {
    userInfoUserInfoAccessLevelXrefID = 0;
    }
  
int userInfoID = TextBoxUserInfoID.Value != null ? (int)TextBoxUserInfoID.Value: 0;
int userInfoAccessLevelID = TextBoxUserInfoAccessLevelID.Value != null ? (int)TextBoxUserInfoAccessLevelID.Value: 0;
bool userInfoUserInfoAccessLevelXrefActiveYesNo = CheckBoxUserInfoUserInfoAccessLevelXrefActiveYesNo.Checked != null ? CheckBoxUserInfoUserInfoAccessLevelXrefActiveYesNo.Checked.Value : false;


    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref()
    {
    UserInfoUserInfoAccessLevelXrefID = userInfoUserInfoAccessLevelXrefID,
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

    if (bl.UpdateUserInfoUserInfoAccessLevelXref(userInfoUserInfoAccessLevelXref))
    {
    if (userInfoUserInfoAccessLevelXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoAccessLevelXref.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoUserInfoAccessLevelXrefs/UserInfoUserInfoAccessLevelXrefTelerikRadEditDelete.aspx?id=" + userInfoUserInfoAccessLevelXrefID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoAccessLevelXref));
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

    
    int userInfoUserInfoAccessLevelXrefID;
    bool successUserInfoUserInfoAccessLevelXrefID = int.TryParse(HiddenField_UserInfoUserInfoAccessLevelXrefID.Value, out userInfoUserInfoAccessLevelXrefID);
    if (!successUserInfoUserInfoAccessLevelXrefID)
    {
    userInfoUserInfoAccessLevelXrefID = 0;
    }
  


    if(userInfoUserInfoAccessLevelXrefID != 0)
    {
    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = bl.GetUserInfoUserInfoAccessLevelXrefById(userInfoUserInfoAccessLevelXrefID);

    if (bl.DeleteUserInfoUserInfoAccessLevelXref(userInfoUserInfoAccessLevelXrefID, userInfoUserInfoAccessLevelXref))
    {
    if (userInfoUserInfoAccessLevelXref.ErrID != 0)
    {
    DisplayAlert(userInfoUserInfoAccessLevelXref.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoUserInfoAccessLevelXrefs/UserInfoUserInfoAccessLevelXrefTelerikRadGrid2.aspx",false);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoUserInfoAccessLevelXref));
    }

    }
    else
    {
    DisplayAlert("userInfoUserInfoAccessLevelXrefID cannot be zero.");
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
  
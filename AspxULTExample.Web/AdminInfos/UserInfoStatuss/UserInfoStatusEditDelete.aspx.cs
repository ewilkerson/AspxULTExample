
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
    
    public partial class UserInfoStatusEditDelete : System.Web.UI.Page
    {

    private IUserInfoStatusBL bl;

    public UserInfoStatusEditDelete()
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
    LabelUserInfoStatusID.Text = userInfoStatus.UserInfoStatusID.ToString();
  

    TextBoxUserInfoStatusName.Text = userInfoStatus.UserInfoStatusName;
CheckBoxUserInfoStatusActiveYesNo.Checked = userInfoStatus.UserInfoStatusActiveYesNo;


    }
    else
    {
    DisplayAlert("userInfoStatusID cannot be zero.");
    }

    }
    }

    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int userInfoStatusID;
    bool successUserInfoStatusID = int.TryParse(HiddenField_UserInfoStatusID.Value, out userInfoStatusID);
    if (!successUserInfoStatusID)
    {
    userInfoStatusID = 0;
    }
  
string userInfoStatusName = TextBoxUserInfoStatusName.Text;
bool userInfoStatusActiveYesNo = CheckBoxUserInfoStatusActiveYesNo.Checked;


    UserInfoStatus userInfoStatus = new UserInfoStatus()
    {
    UserInfoStatusID = userInfoStatusID,
UserInfoStatusName = userInfoStatusName,
UserInfoStatusActiveYesNo = userInfoStatusActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoStatus, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoStatus, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoStatus(userInfoStatus))
    {
    if (userInfoStatus.ErrID != 0)
    {
    DisplayAlert(userInfoStatus.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoStatuss/UserInfoStatusEditDelete.aspx?id=" + userInfoStatusID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoStatus));
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

    
    int userInfoStatusID;
    bool successUserInfoStatusID = int.TryParse(HiddenField_UserInfoStatusID.Value, out userInfoStatusID);
    if (!successUserInfoStatusID)
    {
    userInfoStatusID = 0;
    }
  



    if(userInfoStatusID != 0)
    {

    UserInfoStatus userInfoStatus = bl.GetUserInfoStatusById(userInfoStatusID);

    if (bl.DeleteUserInfoStatus(userInfoStatusID, userInfoStatus))
    {
    if (userInfoStatus.ErrID != 0)
    {
    DisplayAlert(userInfoStatus.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoStatuss/UserInfoStatusGridView2.aspx",false);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoStatus));
    }

    }
    else
    {
    DisplayAlert("userInfoStatusID cannot be zero.");
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
  
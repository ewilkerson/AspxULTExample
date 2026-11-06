
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
    // using System.Drawing;
    using System.IO;
    using Telerik.Web.UI;
    using AspxULTExample.BL;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;
    using AspxULTExample.Repository;

    namespace AspxULTExample.Web.AdminInfos.UserInfos
    {
    
    public partial class UserInfoTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IUserInfoBL bl;

    public UserInfoTelerikRadGrid()
    {
    bl = new AdminUserInfoBL(new AdminUserInfoXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetUserInfos();

    (sender as RadGrid).DataSource = myData;
    }

    protected void RadGrid1_DataBound(object sender, EventArgs e)
    {
    if (!string.IsNullOrWhiteSpace(gridMessage))
    {
    DisplayMessage(gridMessage);
    }
    }

    protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
    {

    try
    {
    SessionRedirect();

    GridEditableItem editedItem = (e.Item as GridEditableItem);
    Hashtable newValues = new Hashtable();
    e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);

    int userInfoID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoID"];
string userInfoUserIdentityName = (string)newValues["UserInfoUserIdentityName"];
string userInfoUserName = (string)newValues["UserInfoUserName"];
string userInfoFullName = (string)newValues["UserInfoFullName"];
string userInfoEmailAddress = (string)newValues["UserInfoEmailAddress"];
string userInfoJobTitle = (string)newValues["UserInfoJobTitle"];
bool userInfoActiveYesNo = newValues["UserInfoActiveYesNo"] != null ? (bool)newValues["UserInfoActiveYesNo"] : false;


    UserInfo userInfo = new UserInfo()
    {
    UserInfoID = userInfoID,
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

    if (bl.UpdateUserInfo(userInfo))
    {
    if (userInfo.ErrID != 0)
    {
    DisplayAlert(userInfo.ErrText);
    }
    else
    {
    SetMessage("Item updated!");
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfo));
    }

    }


    }
    catch (Exception exception)
    {
    DisplayAlert("Update failed. Reason: " + exception.Message);
    e.Canceled = true;
    Log4ExceptionConnDb.Ex(exception);
    }

    }

    protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
    {

    try
    {
    SessionRedirect();

    GridEditableItem editedItem = (e.Item as GridEditableItem);
    Hashtable newValues = new Hashtable();
    e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);

    string userInfoUserIdentityName = (string)newValues["UserInfoUserIdentityName"];
string userInfoUserName = (string)newValues["UserInfoUserName"];
string userInfoFullName = (string)newValues["UserInfoFullName"];
string userInfoEmailAddress = (string)newValues["UserInfoEmailAddress"];
string userInfoJobTitle = (string)newValues["UserInfoJobTitle"];
bool userInfoActiveYesNo = newValues["UserInfoActiveYesNo"] != null ? (bool)newValues["UserInfoActiveYesNo"] : false;


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
    SetMessage("New product is inserted!");
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
    DisplayAlert("Insert failed. Reason: " + exception.Message);
    e.Canceled = true;
    Log4ExceptionConnDb.Ex(exception);
    }


    }


    protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
    {
    try
    {
    SessionRedirect();

    GridEditableItem editedItem = (e.Item as GridEditableItem);
    Hashtable newValues = new Hashtable();
    e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editedItem);

    int userInfoID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoID"];


    if(userInfoID != 0)
    {

    UserInfo userInfo = bl.GetUserInfoById(userInfoID);


    if (bl.DeleteUserInfo(userInfoID, userInfo))
    {
    if (userInfo.ErrID != 0)
    {
    DisplayAlert(userInfo.ErrText);

    }
    else
    {
    SetMessage("Item deleted!");
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfo));
    }


    }
    else
    {
    DisplayAlert("userInfoID cannot be zero.");
    }

    }
    catch (Exception exception)
    {
    DisplayAlert("Delete failed. Reason: " + exception.Message);
    e.Canceled = true;
    Log4ExceptionConnDb.Ex(exception);

    }

    }

    private void DisplayMessage(string text)
    {
    string msg = string.Format("<span style='color:red'>{0}</span>", text);
    RadGrid1.Controls.Add(new LiteralControl(msg));
    }

    private void SetMessage(string message)
    {
    gridMessage = message;
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
  
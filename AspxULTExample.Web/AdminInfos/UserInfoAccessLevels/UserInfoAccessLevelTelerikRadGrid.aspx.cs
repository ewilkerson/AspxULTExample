
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoAccessLevels
    {
    
    public partial class UserInfoAccessLevelTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IUserInfoAccessLevelBL bl;

    public UserInfoAccessLevelTelerikRadGrid()
    {
    bl = new AdminUserInfoAccessLevelBL(new AdminUserInfoAccessLevelXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetUserInfoAccessLevels();

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

    int userInfoAccessLevelID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoAccessLevelID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoAccessLevelID"];
string userInfoAccessLevelName = (string)newValues["UserInfoAccessLevelName"];

    int userInfoAccessLevelNum;
    bool successUserInfoAccessLevelNum = int.TryParse((string)newValues["UserInfoAccessLevelNum"], out userInfoAccessLevelNum);
    if (!successUserInfoAccessLevelNum)
    {
    userInfoAccessLevelNum = 0;
    }
  
bool userInfoAccessLevelActiveYesNo = newValues["UserInfoAccessLevelActiveYesNo"] != null ? (bool)newValues["UserInfoAccessLevelActiveYesNo"] : false;


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
    SetMessage("Item updated!");
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

    string userInfoAccessLevelName = (string)newValues["UserInfoAccessLevelName"];

    int userInfoAccessLevelNum;
    bool successUserInfoAccessLevelNum = int.TryParse((string)newValues["UserInfoAccessLevelNum"], out userInfoAccessLevelNum);
    if (!successUserInfoAccessLevelNum)
    {
    userInfoAccessLevelNum = 0;
    }
  
bool userInfoAccessLevelActiveYesNo = newValues["UserInfoAccessLevelActiveYesNo"] != null ? (bool)newValues["UserInfoAccessLevelActiveYesNo"] : false;


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
    SetMessage("New product is inserted!");
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

    int userInfoAccessLevelID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoAccessLevelID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoAccessLevelID"];


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
    SetMessage("Item deleted!");
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
  
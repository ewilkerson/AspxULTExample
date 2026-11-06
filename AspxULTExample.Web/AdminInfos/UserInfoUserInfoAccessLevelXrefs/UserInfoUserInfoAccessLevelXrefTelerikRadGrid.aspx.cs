
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoUserInfoAccessLevelXrefs
    {
    
    public partial class UserInfoUserInfoAccessLevelXrefTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IUserInfoUserInfoAccessLevelXrefBL bl;

    public UserInfoUserInfoAccessLevelXrefTelerikRadGrid()
    {
    bl = new AdminUserInfoUserInfoAccessLevelXrefBL(new AdminUserInfoUserInfoAccessLevelXrefXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetUserInfoUserInfoAccessLevelXrefs();

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

    int userInfoUserInfoAccessLevelXrefID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoUserInfoAccessLevelXrefID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoUserInfoAccessLevelXrefID"];

    int userInfoID;
    bool successUserInfoID = int.TryParse((string)newValues["UserInfoID"], out userInfoID);
    if (!successUserInfoID)
    {
    userInfoID = 0;
    }
  

    int userInfoAccessLevelID;
    bool successUserInfoAccessLevelID = int.TryParse((string)newValues["UserInfoAccessLevelID"], out userInfoAccessLevelID);
    if (!successUserInfoAccessLevelID)
    {
    userInfoAccessLevelID = 0;
    }
  
bool userInfoUserInfoAccessLevelXrefActiveYesNo = newValues["UserInfoUserInfoAccessLevelXrefActiveYesNo"] != null ? (bool)newValues["UserInfoUserInfoAccessLevelXrefActiveYesNo"] : false;


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
    SetMessage("Item updated!");
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

    
    int userInfoID;
    bool successUserInfoID = int.TryParse((string)newValues["UserInfoID"], out userInfoID);
    if (!successUserInfoID)
    {
    userInfoID = 0;
    }
  

    int userInfoAccessLevelID;
    bool successUserInfoAccessLevelID = int.TryParse((string)newValues["UserInfoAccessLevelID"], out userInfoAccessLevelID);
    if (!successUserInfoAccessLevelID)
    {
    userInfoAccessLevelID = 0;
    }
  
bool userInfoUserInfoAccessLevelXrefActiveYesNo = newValues["UserInfoUserInfoAccessLevelXrefActiveYesNo"] != null ? (bool)newValues["UserInfoUserInfoAccessLevelXrefActiveYesNo"] : false;


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
    SetMessage("New product is inserted!");
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

    int userInfoUserInfoAccessLevelXrefID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoUserInfoAccessLevelXrefID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoUserInfoAccessLevelXrefID"];


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
    SetMessage("Item deleted!");
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
  
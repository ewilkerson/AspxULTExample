
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoUserInfoCompanyXrefs
    {
    
    public partial class UserInfoUserInfoCompanyXrefTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IUserInfoUserInfoCompanyXrefBL bl;

    public UserInfoUserInfoCompanyXrefTelerikRadGrid()
    {
    bl = new AdminUserInfoUserInfoCompanyXrefBL(new AdminUserInfoUserInfoCompanyXrefXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetUserInfoUserInfoCompanyXrefs();

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

    int userInfoUserInfoCompanyXrefID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoUserInfoCompanyXrefID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoUserInfoCompanyXrefID"];

    int userInfoID;
    bool successUserInfoID = int.TryParse((string)newValues["UserInfoID"], out userInfoID);
    if (!successUserInfoID)
    {
    userInfoID = 0;
    }
  

    int userInfoCompanyID;
    bool successUserInfoCompanyID = int.TryParse((string)newValues["UserInfoCompanyID"], out userInfoCompanyID);
    if (!successUserInfoCompanyID)
    {
    userInfoCompanyID = 0;
    }
  
bool userInfoUserInfoCompanyXrefEmailAddressActiveYesNo = newValues["UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"] != null ? (bool)newValues["UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"] : false;
bool userInfoUserInfoCompanyXrefActiveYesNo = newValues["UserInfoUserInfoCompanyXrefActiveYesNo"] != null ? (bool)newValues["UserInfoUserInfoCompanyXrefActiveYesNo"] : false;


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
    SetMessage("Item updated!");
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
  

    int userInfoCompanyID;
    bool successUserInfoCompanyID = int.TryParse((string)newValues["UserInfoCompanyID"], out userInfoCompanyID);
    if (!successUserInfoCompanyID)
    {
    userInfoCompanyID = 0;
    }
  
bool userInfoUserInfoCompanyXrefEmailAddressActiveYesNo = newValues["UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"] != null ? (bool)newValues["UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"] : false;
bool userInfoUserInfoCompanyXrefActiveYesNo = newValues["UserInfoUserInfoCompanyXrefActiveYesNo"] != null ? (bool)newValues["UserInfoUserInfoCompanyXrefActiveYesNo"] : false;


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
    SetMessage("New product is inserted!");
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

    int userInfoUserInfoCompanyXrefID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoUserInfoCompanyXrefID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoUserInfoCompanyXrefID"];


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
    SetMessage("Item deleted!");
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
  
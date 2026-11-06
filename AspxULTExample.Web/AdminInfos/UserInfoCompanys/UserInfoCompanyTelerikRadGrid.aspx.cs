
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoCompanys
    {
    
    public partial class UserInfoCompanyTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IUserInfoCompanyBL bl;

    public UserInfoCompanyTelerikRadGrid()
    {
    bl = new AdminUserInfoCompanyBL(new AdminUserInfoCompanyXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetUserInfoCompanys();

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

    int userInfoCompanyID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoCompanyID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoCompanyID"];
string userInfoCompanyEIN = (string)newValues["UserInfoCompanyEIN"];
string userInfoCompanyName = (string)newValues["UserInfoCompanyName"];
string userInfoCompanyAddress1 = (string)newValues["UserInfoCompanyAddress1"];
string userInfoCompanyAddress2 = (string)newValues["UserInfoCompanyAddress2"];
string userInfoCompanyCityStateZip = (string)newValues["UserInfoCompanyCityStateZip"];
string userInfoCompanyTelephone = (string)newValues["UserInfoCompanyTelephone"];
string userInfoCompanyEmailAddress = (string)newValues["UserInfoCompanyEmailAddress"];
string userCompanyWebsiteAddress = (string)newValues["UserCompanyWebsiteAddress"];

    int userInfoCountriesID;
    bool successUserInfoCountriesID = int.TryParse((string)newValues["UserInfoCountriesID"], out userInfoCountriesID);
    if (!successUserInfoCountriesID)
    {
    userInfoCountriesID = 0;
    }
  
bool userInfoCompanyActiveYesNo = newValues["UserInfoCompanyActiveYesNo"] != null ? (bool)newValues["UserInfoCompanyActiveYesNo"] : false;


    UserInfoCompany userInfoCompany = new UserInfoCompany()
    {
    UserInfoCompanyID = userInfoCompanyID,
UserInfoCompanyEIN = userInfoCompanyEIN,
UserInfoCompanyName = userInfoCompanyName,
UserInfoCompanyAddress1 = userInfoCompanyAddress1,
UserInfoCompanyAddress2 = userInfoCompanyAddress2,
UserInfoCompanyCityStateZip = userInfoCompanyCityStateZip,
UserInfoCompanyTelephone = userInfoCompanyTelephone,
UserInfoCompanyEmailAddress = userInfoCompanyEmailAddress,
UserCompanyWebsiteAddress = userCompanyWebsiteAddress,
UserInfoCountriesID = userInfoCountriesID,
UserInfoCompanyActiveYesNo = userInfoCompanyActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCompany, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCompany, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoCompany(userInfoCompany))
    {
    if (userInfoCompany.ErrID != 0)
    {
    DisplayAlert(userInfoCompany.ErrText);
    }
    else
    {
    SetMessage("Item updated!");
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCompany));
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

    string userInfoCompanyEIN = (string)newValues["UserInfoCompanyEIN"];
string userInfoCompanyName = (string)newValues["UserInfoCompanyName"];
string userInfoCompanyAddress1 = (string)newValues["UserInfoCompanyAddress1"];
string userInfoCompanyAddress2 = (string)newValues["UserInfoCompanyAddress2"];
string userInfoCompanyCityStateZip = (string)newValues["UserInfoCompanyCityStateZip"];
string userInfoCompanyTelephone = (string)newValues["UserInfoCompanyTelephone"];
string userInfoCompanyEmailAddress = (string)newValues["UserInfoCompanyEmailAddress"];
string userCompanyWebsiteAddress = (string)newValues["UserCompanyWebsiteAddress"];

    int userInfoCountriesID;
    bool successUserInfoCountriesID = int.TryParse((string)newValues["UserInfoCountriesID"], out userInfoCountriesID);
    if (!successUserInfoCountriesID)
    {
    userInfoCountriesID = 0;
    }
  
bool userInfoCompanyActiveYesNo = newValues["UserInfoCompanyActiveYesNo"] != null ? (bool)newValues["UserInfoCompanyActiveYesNo"] : false;


    UserInfoCompany userInfoCompany = new UserInfoCompany()
    {
    UserInfoCompanyID = 1,
UserInfoCompanyEIN = userInfoCompanyEIN,
UserInfoCompanyName = userInfoCompanyName,
UserInfoCompanyAddress1 = userInfoCompanyAddress1,
UserInfoCompanyAddress2 = userInfoCompanyAddress2,
UserInfoCompanyCityStateZip = userInfoCompanyCityStateZip,
UserInfoCompanyTelephone = userInfoCompanyTelephone,
UserInfoCompanyEmailAddress = userInfoCompanyEmailAddress,
UserCompanyWebsiteAddress = userCompanyWebsiteAddress,
UserInfoCountriesID = userInfoCountriesID,
UserInfoCompanyActiveYesNo = userInfoCompanyActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCompany, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCompany, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertUserInfoCompany(userInfoCompany))
    {
    if (userInfoCompany.ErrID != 0)
    {
    DisplayAlert(userInfoCompany.ErrText);

    }
    else
    {
    SetMessage("New product is inserted!");
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoCompany));
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

    int userInfoCompanyID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoCompanyID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoCompanyID"];


    if(userInfoCompanyID != 0)
    {

    UserInfoCompany userInfoCompany = bl.GetUserInfoCompanyById(userInfoCompanyID);


    if (bl.DeleteUserInfoCompany(userInfoCompanyID, userInfoCompany))
    {
    if (userInfoCompany.ErrID != 0)
    {
    DisplayAlert(userInfoCompany.ErrText);

    }
    else
    {
    SetMessage("Item deleted!");
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCompany));
    }


    }
    else
    {
    DisplayAlert("userInfoCompanyID cannot be zero.");
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


    protected string MsgText(UserInfoCompany userInfoCompany)
    {
    string msg = string.Empty;

    if (userInfoCompany != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoCompanyIsValid(userInfoCompany);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoCompany cannot be null.";
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
  
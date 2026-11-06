
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoCountriess
    {
    
    public partial class UserInfoCountriesTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IUserInfoCountriesBL bl;

    public UserInfoCountriesTelerikRadGrid()
    {
    bl = new AdminUserInfoCountriesBL(new AdminUserInfoCountriesXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetUserInfoCountriess();

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

    int userInfoCountriesID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoCountriesID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoCountriesID"];
string userInfoCountriesName = (string)newValues["UserInfoCountriesName"];
bool userInfoCountriesActiveYesNo = newValues["UserInfoCountriesActiveYesNo"] != null ? (bool)newValues["UserInfoCountriesActiveYesNo"] : false;


    UserInfoCountries userInfoCountries = new UserInfoCountries()
    {
    UserInfoCountriesID = userInfoCountriesID,
UserInfoCountriesName = userInfoCountriesName,
UserInfoCountriesActiveYesNo = userInfoCountriesActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCountries, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCountries, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoCountries(userInfoCountries))
    {
    if (userInfoCountries.ErrID != 0)
    {
    DisplayAlert(userInfoCountries.ErrText);
    }
    else
    {
    SetMessage("Item updated!");
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCountries));
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

    string userInfoCountriesName = (string)newValues["UserInfoCountriesName"];
bool userInfoCountriesActiveYesNo = newValues["UserInfoCountriesActiveYesNo"] != null ? (bool)newValues["UserInfoCountriesActiveYesNo"] : false;


    UserInfoCountries userInfoCountries = new UserInfoCountries()
    {
    UserInfoCountriesID = 1,
UserInfoCountriesName = userInfoCountriesName,
UserInfoCountriesActiveYesNo = userInfoCountriesActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCountries, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCountries, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertUserInfoCountries(userInfoCountries))
    {
    if (userInfoCountries.ErrID != 0)
    {
    DisplayAlert(userInfoCountries.ErrText);

    }
    else
    {
    SetMessage("New product is inserted!");
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoCountries));
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

    int userInfoCountriesID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoCountriesID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["UserInfoCountriesID"];


    if(userInfoCountriesID != 0)
    {

    UserInfoCountries userInfoCountries = bl.GetUserInfoCountriesById(userInfoCountriesID);


    if (bl.DeleteUserInfoCountries(userInfoCountriesID, userInfoCountries))
    {
    if (userInfoCountries.ErrID != 0)
    {
    DisplayAlert(userInfoCountries.ErrText);

    }
    else
    {
    SetMessage("Item deleted!");
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCountries));
    }


    }
    else
    {
    DisplayAlert("userInfoCountriesID cannot be zero.");
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


    protected string MsgText(UserInfoCountries userInfoCountries)
    {
    string msg = string.Empty;

    if (userInfoCountries != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoCountriesIsValid(userInfoCountries);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoCountries cannot be null.";
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
  
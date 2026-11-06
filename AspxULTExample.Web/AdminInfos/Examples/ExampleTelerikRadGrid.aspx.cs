
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

    namespace AspxULTExample.Web.AdminInfos.Examples
    {
    
    public partial class ExampleTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IExampleBL bl;

    public ExampleTelerikRadGrid()
    {
    bl = new AdminExampleBL(new AdminExampleXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetExamples();

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

    int exampleID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExampleID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExampleID"];

    int exampleUserInfoStatusID;
    bool successExampleUserInfoStatusID = int.TryParse((string)newValues["ExampleUserInfoStatusID"], out exampleUserInfoStatusID);
    if (!successExampleUserInfoStatusID)
    {
    exampleUserInfoStatusID = 0;
    }
  

    int exampleUserInfoCompanyID;
    bool successExampleUserInfoCompanyID = int.TryParse((string)newValues["ExampleUserInfoCompanyID"], out exampleUserInfoCompanyID);
    if (!successExampleUserInfoCompanyID)
    {
    exampleUserInfoCompanyID = 0;
    }
  
string title = (string)newValues["Title"];

    int release;
    bool successRelease = int.TryParse((string)newValues["Release"], out release);
    if (!successRelease)
    {
    release = 0;
    }
  

    DateTime releaseDateTime;
    bool successReleaseDateTime = DateTime.TryParse((string)newValues["ReleaseDateTime"], out releaseDateTime);
    if (!successReleaseDateTime)
    {
    releaseDateTime = DateTime.Now;
    }
  
string genre = (string)newValues["Genre"];

    decimal price;
    bool successPrice = decimal.TryParse((string)newValues["Price"], out price);
    if (!successPrice)
    {
    price = 0.0M;
    }
  
bool priceYesNo = newValues["PriceYesNo"] != null ? (bool)newValues["PriceYesNo"] : false;

    DateTime releaseDate;
    bool successReleaseDate = DateTime.TryParse((string)newValues["ReleaseDate"], out releaseDate);
    if (!successReleaseDate)
    {
    releaseDate = DateTime.Now.Date;
    }
    releaseDate = releaseDate.Date;
  
TimeSpan releaseTime = newValues["ReleaseTime"] != null ? ((DateTime)newValues["ReleaseTime"]).TimeOfDay : TimeSpan.Zero;
string message = (string)newValues["Message"];
string message2 = (string)newValues["Message2"];
string phoneNumber = (string)newValues["PhoneNumber"];
string emailAddress = (string)newValues["EmailAddress"];
string creditCard = (string)newValues["CreditCard"];
string password = (string)newValues["Password"];
string url = (string)newValues["Url"];
bool exampleActiveYesNo = newValues["ExampleActiveYesNo"] != null ? (bool)newValues["ExampleActiveYesNo"] : false;


    Example example = new Example()
    {
    ExampleID = exampleID,
ExampleUserInfoStatusID = exampleUserInfoStatusID,
ExampleUserInfoCompanyID = exampleUserInfoCompanyID,
Title = title,
Release = release,
ReleaseDateTime = releaseDateTime,
Genre = genre,
Price = price,
PriceYesNo = priceYesNo,
ReleaseDate = releaseDate,
ReleaseTime = releaseTime,
Message = message,
Message2 = message2,
PhoneNumber = phoneNumber,
EmailAddress = emailAddress,
CreditCard = creditCard,
Password = password,
Url = url,
ExampleActiveYesNo = exampleActiveYesNo
    };

    ValidationContext context = new ValidationContext(example, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(example, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateExample(example))
    {
    if (example.ErrID != 0)
    {
    DisplayAlert(example.ErrText);
    }
    else
    {
    SetMessage("Item updated!");
    }
    }
    else
    {
    DisplayAlert(MsgText(example));
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

    
    int exampleUserInfoStatusID;
    bool successExampleUserInfoStatusID = int.TryParse((string)newValues["ExampleUserInfoStatusID"], out exampleUserInfoStatusID);
    if (!successExampleUserInfoStatusID)
    {
    exampleUserInfoStatusID = 0;
    }
  

    int exampleUserInfoCompanyID;
    bool successExampleUserInfoCompanyID = int.TryParse((string)newValues["ExampleUserInfoCompanyID"], out exampleUserInfoCompanyID);
    if (!successExampleUserInfoCompanyID)
    {
    exampleUserInfoCompanyID = 0;
    }
  
string title = (string)newValues["Title"];

    int release;
    bool successRelease = int.TryParse((string)newValues["Release"], out release);
    if (!successRelease)
    {
    release = 0;
    }
  

    DateTime releaseDateTime;
    bool successReleaseDateTime = DateTime.TryParse((string)newValues["ReleaseDateTime"], out releaseDateTime);
    if (!successReleaseDateTime)
    {
    releaseDateTime = DateTime.Now;
    }
  
string genre = (string)newValues["Genre"];

    decimal price;
    bool successPrice = decimal.TryParse((string)newValues["Price"], out price);
    if (!successPrice)
    {
    price = 0.0M;
    }
  
bool priceYesNo = newValues["PriceYesNo"] != null ? (bool)newValues["PriceYesNo"] : false;

    DateTime releaseDate;
    bool successReleaseDate = DateTime.TryParse((string)newValues["ReleaseDate"], out releaseDate);
    if (!successReleaseDate)
    {
    releaseDate = DateTime.Now.Date;
    }
    releaseDate = releaseDate.Date;
  
TimeSpan releaseTime = newValues["ReleaseTime"] != null ? ((DateTime)newValues["ReleaseTime"]).TimeOfDay : TimeSpan.Zero;
string message = (string)newValues["Message"];
string message2 = (string)newValues["Message2"];
string phoneNumber = (string)newValues["PhoneNumber"];
string emailAddress = (string)newValues["EmailAddress"];
string creditCard = (string)newValues["CreditCard"];
string password = (string)newValues["Password"];
string url = (string)newValues["Url"];
bool exampleActiveYesNo = newValues["ExampleActiveYesNo"] != null ? (bool)newValues["ExampleActiveYesNo"] : false;


    Example example = new Example()
    {
    ExampleID = 1,
ExampleUserInfoStatusID = exampleUserInfoStatusID,
ExampleUserInfoCompanyID = exampleUserInfoCompanyID,
Title = title,
Release = release,
ReleaseDateTime = releaseDateTime,
Genre = genre,
Price = price,
PriceYesNo = priceYesNo,
ReleaseDate = releaseDate,
ReleaseTime = releaseTime,
Message = message,
Message2 = message2,
PhoneNumber = phoneNumber,
EmailAddress = emailAddress,
CreditCard = creditCard,
Password = password,
Url = url,
ExampleActiveYesNo = exampleActiveYesNo
    };

    ValidationContext context = new ValidationContext(example, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(example, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertExample(example))
    {
    if (example.ErrID != 0)
    {
    DisplayAlert(example.ErrText);

    }
    else
    {
    SetMessage("New product is inserted!");
    }

    }
    else
    {
    DisplayAlert(MsgText(example));
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

    int exampleID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExampleID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExampleID"];


    if(exampleID != 0)
    {

    Example example = bl.GetExampleById(exampleID);


    if (bl.DeleteExample(exampleID, example))
    {
    if (example.ErrID != 0)
    {
    DisplayAlert(example.ErrText);

    }
    else
    {
    SetMessage("Item deleted!");
    }
    }
    else
    {
    DisplayAlert(MsgText(example));
    }


    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
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


    protected string MsgText(Example example)
    {
    string msg = string.Empty;

    if (example != null)
    {

    Dictionary<string, string>
    isVal = bl.ExampleIsValid(example);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "Example cannot be null.";
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
  

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

    namespace AspxULTExample.Web.AdminInfos.ExampleApproves
    {
    
    public partial class ExampleApproveTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IExampleApproveBL bl;

    public ExampleApproveTelerikRadGrid()
    {
    bl = new AdminExampleApproveBL(new AdminExampleApproveXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetExampleApproves();

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

    int exampleApproveID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExampleApproveID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExampleApproveID"];

    int exampleID;
    bool successExampleID = int.TryParse((string)newValues["ExampleID"], out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  

    int userInfoID;
    bool successUserInfoID = int.TryParse((string)newValues["UserInfoID"], out userInfoID);
    if (!successUserInfoID)
    {
    userInfoID = 0;
    }
  
string userInfoJobTitle = (string)newValues["UserInfoJobTitle"];


    ExampleApprove exampleApprove = new ExampleApprove()
    {
    ExampleApproveID = exampleApproveID,
ExampleID = exampleID,
UserInfoID = userInfoID,
UserInfoJobTitle = userInfoJobTitle
    };

    ValidationContext context = new ValidationContext(exampleApprove, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(exampleApprove, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateExampleApprove(exampleApprove))
    {
    if (exampleApprove.ErrID != 0)
    {
    DisplayAlert(exampleApprove.ErrText);
    }
    else
    {
    SetMessage("Item updated!");
    }
    }
    else
    {
    DisplayAlert(MsgText(exampleApprove));
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

    
    int exampleID;
    bool successExampleID = int.TryParse((string)newValues["ExampleID"], out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  

    int userInfoID;
    bool successUserInfoID = int.TryParse((string)newValues["UserInfoID"], out userInfoID);
    if (!successUserInfoID)
    {
    userInfoID = 0;
    }
  
string userInfoJobTitle = (string)newValues["UserInfoJobTitle"];


    ExampleApprove exampleApprove = new ExampleApprove()
    {
    ExampleApproveID = 1,
ExampleID = exampleID,
UserInfoID = userInfoID,
UserInfoJobTitle = userInfoJobTitle
    };

    ValidationContext context = new ValidationContext(exampleApprove, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(exampleApprove, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertExampleApprove(exampleApprove))
    {
    if (exampleApprove.ErrID != 0)
    {
    DisplayAlert(exampleApprove.ErrText);

    }
    else
    {
    SetMessage("New product is inserted!");
    }

    }
    else
    {
    DisplayAlert(MsgText(exampleApprove));
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

    int exampleApproveID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExampleApproveID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["ExampleApproveID"];


    if(exampleApproveID != 0)
    {

    ExampleApprove exampleApprove = bl.GetExampleApproveById(exampleApproveID);


    if (bl.DeleteExampleApprove(exampleApproveID, exampleApprove))
    {
    if (exampleApprove.ErrID != 0)
    {
    DisplayAlert(exampleApprove.ErrText);

    }
    else
    {
    SetMessage("Item deleted!");
    }
    }
    else
    {
    DisplayAlert(MsgText(exampleApprove));
    }


    }
    else
    {
    DisplayAlert("exampleApproveID cannot be zero.");
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


    protected string MsgText(ExampleApprove exampleApprove)
    {
    string msg = string.Empty;

    if (exampleApprove != null)
    {

    Dictionary<string, string>
    isVal = bl.ExampleApproveIsValid(exampleApprove);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "ExampleApprove cannot be null.";
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
  
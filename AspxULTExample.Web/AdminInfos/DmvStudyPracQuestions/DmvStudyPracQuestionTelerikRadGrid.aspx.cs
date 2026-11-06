
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

    namespace AspxULTExample.Web.AdminInfos.DmvStudyPracQuestions
    {
    
    public partial class DmvStudyPracQuestionTelerikRadGrid : System.Web.UI.Page
    {
    private string gridMessage = null;

    private IBL<DmvStudyPracQuestion> bl;

    public DmvStudyPracQuestionTelerikRadGrid()
    {
    bl = new AdminDmvStudyPracQuestionBL(new AdminDmvStudyPracQuestionXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();


    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {

    var myData = bl.GetAll();

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

    int dmvStudyPracQuestionID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DmvStudyPracQuestionID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DmvStudyPracQuestionID"];

    int dmvStudyPracID;
    bool successDmvStudyPracID = int.TryParse((string)newValues["DmvStudyPracID"], out dmvStudyPracID);
    if (!successDmvStudyPracID)
    {
    dmvStudyPracID = 0;
    }
  
string dmvStudyPracQuestionText = (string)newValues["DmvStudyPracQuestionText"];
string dmvStudyPracQuestionAnswerText = (string)newValues["DmvStudyPracQuestionAnswerText"];
bool dmvStudyPracQuestionPicsYesNo = newValues["DmvStudyPracQuestionPicsYesNo"] != null ? (bool)newValues["DmvStudyPracQuestionPicsYesNo"] : false;
bool dmvStudyPracQuestionActiveYesNo = newValues["DmvStudyPracQuestionActiveYesNo"] != null ? (bool)newValues["DmvStudyPracQuestionActiveYesNo"] : false;


    DmvStudyPracQuestion dmvStudyPracQuestion = new DmvStudyPracQuestion()
    {
    DmvStudyPracQuestionID = dmvStudyPracQuestionID,
DmvStudyPracID = dmvStudyPracID,
DmvStudyPracQuestionText = dmvStudyPracQuestionText,
DmvStudyPracQuestionAnswerText = dmvStudyPracQuestionAnswerText,
DmvStudyPracQuestionPicsYesNo = dmvStudyPracQuestionPicsYesNo,
DmvStudyPracQuestionActiveYesNo = dmvStudyPracQuestionActiveYesNo
    };

    ValidationContext context = new ValidationContext(dmvStudyPracQuestion, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(dmvStudyPracQuestion, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.Update(dmvStudyPracQuestion))
    {
    if (dmvStudyPracQuestion.ErrID != 0)
    {
    DisplayAlert(dmvStudyPracQuestion.ErrText);
    }
    else
    {
    SetMessage("Item updated!");
    }
    }
    else
    {
    DisplayAlert(MsgText(dmvStudyPracQuestion));
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

    
    int dmvStudyPracID;
    bool successDmvStudyPracID = int.TryParse((string)newValues["DmvStudyPracID"], out dmvStudyPracID);
    if (!successDmvStudyPracID)
    {
    dmvStudyPracID = 0;
    }
  
string dmvStudyPracQuestionText = (string)newValues["DmvStudyPracQuestionText"];
string dmvStudyPracQuestionAnswerText = (string)newValues["DmvStudyPracQuestionAnswerText"];
bool dmvStudyPracQuestionPicsYesNo = newValues["DmvStudyPracQuestionPicsYesNo"] != null ? (bool)newValues["DmvStudyPracQuestionPicsYesNo"] : false;
bool dmvStudyPracQuestionActiveYesNo = newValues["DmvStudyPracQuestionActiveYesNo"] != null ? (bool)newValues["DmvStudyPracQuestionActiveYesNo"] : false;


    DmvStudyPracQuestion dmvStudyPracQuestion = new DmvStudyPracQuestion()
    {
    DmvStudyPracQuestionID = 1,
DmvStudyPracID = dmvStudyPracID,
DmvStudyPracQuestionText = dmvStudyPracQuestionText,
DmvStudyPracQuestionAnswerText = dmvStudyPracQuestionAnswerText,
DmvStudyPracQuestionPicsYesNo = dmvStudyPracQuestionPicsYesNo,
DmvStudyPracQuestionActiveYesNo = dmvStudyPracQuestionActiveYesNo
    };

    ValidationContext context = new ValidationContext(dmvStudyPracQuestion, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(dmvStudyPracQuestion, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.Insert(dmvStudyPracQuestion))
    {
    if (dmvStudyPracQuestion.ErrID != 0)
    {
    DisplayAlert(dmvStudyPracQuestion.ErrText);

    }
    else
    {
    SetMessage("New product is inserted!");
    }

    }
    else
    {
    DisplayAlert(MsgText(dmvStudyPracQuestion));
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

    int dmvStudyPracQuestionID = editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DmvStudyPracQuestionID"] == null ? 0  : (int)editedItem.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DmvStudyPracQuestionID"];


    if(dmvStudyPracQuestionID != 0)
    {

    DmvStudyPracQuestion dmvStudyPracQuestion = bl.GetById(dmvStudyPracQuestionID);


    if (bl.Delete(dmvStudyPracQuestionID, dmvStudyPracQuestion))
    {
    if (dmvStudyPracQuestion.ErrID != 0)
    {
    DisplayAlert(dmvStudyPracQuestion.ErrText);

    }
    else
    {
    SetMessage("Item deleted!");
    }
    }
    else
    {
    DisplayAlert(MsgText(dmvStudyPracQuestion));
    }


    }
    else
    {
    DisplayAlert("dmvStudyPracQuestionID cannot be zero.");
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


    protected string MsgText(DmvStudyPracQuestion dmvStudyPracQuestion)
    {
    string msg = string.Empty;

    if (dmvStudyPracQuestion != null)
    {

    Dictionary<string, string>
    isVal = bl.IsValid(dmvStudyPracQuestion);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "DmvStudyPracQuestion cannot be null.";
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
  

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

    namespace AspxULTExample.Web.AdminInfos.ExampleLogs
    {
    
    public partial class ExampleLogEditDelete : System.Web.UI.Page
    {

    private IExampleLogBL bl;

    public ExampleLogEditDelete()
    {
    bl = new AdminExampleLogBL(new AdminExampleLogXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawExampleLogID = Request.QueryString["id"];
    int exampleLogID;
    bool successExampleLogID = int.TryParse(rawExampleLogID, out exampleLogID);
    if (!successExampleLogID)
    {
    exampleLogID = 0;
    }
  


    if (exampleLogID != 0)
    {

    ExampleLog exampleLog = bl.GetExampleLogById(exampleLogID);
    
    HiddenField_ExampleLogID.Value = exampleLog.ExampleLogID.ToString();
    LabelExampleLogID.Text = exampleLog.ExampleLogID.ToString();
  

    TextBoxExampleID.Text = exampleLog.ExampleID.ToString();
TextBoxLogMessage.Text = exampleLog.LogMessage;


    }
    else
    {
    DisplayAlert("exampleLogID cannot be zero.");
    }

    }
    }

    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleLogID;
    bool successExampleLogID = int.TryParse(HiddenField_ExampleLogID.Value, out exampleLogID);
    if (!successExampleLogID)
    {
    exampleLogID = 0;
    }
  

    int exampleID;
    bool successExampleID = int.TryParse(TextBoxExampleID.Text, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  
string logMessage = TextBoxLogMessage.Text;


    ExampleLog exampleLog = new ExampleLog()
    {
    ExampleLogID = exampleLogID,
ExampleID = exampleID,
LogMessage = logMessage
    };

    ValidationContext context = new ValidationContext(exampleLog, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(exampleLog, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateExampleLog(exampleLog))
    {
    if (exampleLog.ErrID != 0)
    {
    DisplayAlert(exampleLog.ErrText);
    }
    else
    {
    Response.Redirect("../ExampleLogs/ExampleLogEditDelete.aspx?id=" + exampleLogID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(exampleLog));
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

    
    int exampleLogID;
    bool successExampleLogID = int.TryParse(HiddenField_ExampleLogID.Value, out exampleLogID);
    if (!successExampleLogID)
    {
    exampleLogID = 0;
    }
  



    if(exampleLogID != 0)
    {

    ExampleLog exampleLog = bl.GetExampleLogById(exampleLogID);

    if (bl.DeleteExampleLog(exampleLogID, exampleLog))
    {
    if (exampleLog.ErrID != 0)
    {
    DisplayAlert(exampleLog.ErrText);
    }
    else
    {
    Response.Redirect("../ExampleLogs/ExampleLogGridView2.aspx",false);
    }
    }
    else
    {
    DisplayAlert(MsgText(exampleLog));
    }

    }
    else
    {
    DisplayAlert("exampleLogID cannot be zero.");
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

    protected string MsgText(ExampleLog exampleLog)
    {
    string msg = string.Empty;

    if (exampleLog != null)
    {

    Dictionary<string, string>
    isVal = bl.ExampleLogIsValid(exampleLog);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "ExampleLog cannot be null.";
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
  
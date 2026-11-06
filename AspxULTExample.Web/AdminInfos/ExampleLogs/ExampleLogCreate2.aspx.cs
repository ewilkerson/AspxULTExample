
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
    
    public partial class ExampleLogCreate2 : System.Web.UI.Page
    {

    private IExampleLogBL bl;

    public ExampleLogCreate2()
    {
    bl = new AdminExampleLogBL(new AdminExampleLogXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();
    }

    protected void Submit_Create(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleID;
    bool successExampleID = int.TryParse(TextBoxExampleID.Text, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  
string logMessage = TextBoxLogMessage.Text;


    ExampleLog exampleLog = new ExampleLog()
    {
    ExampleLogID = 1,
ExampleID = exampleID,
LogMessage = logMessage
    };

    ValidationContext context = new ValidationContext(exampleLog, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(exampleLog, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertExampleLog(exampleLog))
    {
    if (exampleLog.ErrID != 0)
    {
    DisplayAlert(exampleLog.ErrText);
    }
    else
    {
    Response.Redirect("../ExampleLogs/ExampleLogEditDelete.aspx?id=" + exampleLog.ExampleLogID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(exampleLog));
    }

    }
    }
    catch (DataException exception)
    {
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);
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
  
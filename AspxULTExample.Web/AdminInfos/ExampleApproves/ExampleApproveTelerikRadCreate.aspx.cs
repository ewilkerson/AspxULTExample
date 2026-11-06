
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

    namespace AspxULTExample.Web.AdminInfos.ExampleApproves
    {
    
    public partial class ExampleApproveTelerikRadCreate : System.Web.UI.Page
    {

    private IExampleApproveBL bl;


    public ExampleApproveTelerikRadCreate()
    {
    bl = new AdminExampleApproveBL(new AdminExampleApproveXmlRepository());
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

    int exampleID = TextBoxExampleID.Value != null ? (int)TextBoxExampleID.Value: 0;
int userInfoID = TextBoxUserInfoID.Value != null ? (int)TextBoxUserInfoID.Value: 0;
string userInfoJobTitle = TextBoxUserInfoJobTitle.Text;


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
    Response.Redirect("../ExampleApproves/ExampleApproveTelerikRadEditDelete.aspx?id=" + exampleApprove.ExampleApproveID,false);
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
  
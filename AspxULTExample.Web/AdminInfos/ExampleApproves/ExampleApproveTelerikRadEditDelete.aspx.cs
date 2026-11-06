
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
    
    public partial class ExampleApproveTelerikRadEditDelete : System.Web.UI.Page
    {

    private IExampleApproveBL bl;

    public ExampleApproveTelerikRadEditDelete()
    {
    bl = new AdminExampleApproveBL(new AdminExampleApproveXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawExampleApproveID = Request.QueryString["id"];
    int exampleApproveID;
    bool successExampleApproveID = int.TryParse(rawExampleApproveID, out exampleApproveID);
    if (!successExampleApproveID)
    {
    exampleApproveID = 0;
    }
  


    if (exampleApproveID != 0)

    {

    ExampleApprove exampleApprove = bl.GetExampleApproveById(exampleApproveID);
    HiddenField_ExampleApproveID.Value = exampleApproveID.ToString();
    LabelExampleApproveID.Text = exampleApproveID.ToString();

    TextBoxExampleID.Value = exampleApprove.ExampleID;
TextBoxUserInfoID.Value = exampleApprove.UserInfoID;
TextBoxUserInfoJobTitle.Text = exampleApprove.UserInfoJobTitle;


    }
    else
    {
    DisplayAlert("exampleApproveID cannot be zero.");
    }

    }
    }

    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleApproveID;
    bool successExampleApproveID = int.TryParse(HiddenField_ExampleApproveID.Value, out exampleApproveID);
    if (!successExampleApproveID)
    {
    exampleApproveID = 0;
    }
  
int exampleID = TextBoxExampleID.Value != null ? (int)TextBoxExampleID.Value: 0;
int userInfoID = TextBoxUserInfoID.Value != null ? (int)TextBoxUserInfoID.Value: 0;
string userInfoJobTitle = TextBoxUserInfoJobTitle.Text;


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
    Response.Redirect("../ExampleApproves/ExampleApproveTelerikRadEditDelete.aspx?id=" + exampleApproveID,false);
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
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);

    }

    }
    protected void Submit_Delete(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleApproveID;
    bool successExampleApproveID = int.TryParse(HiddenField_ExampleApproveID.Value, out exampleApproveID);
    if (!successExampleApproveID)
    {
    exampleApproveID = 0;
    }
  


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
    Response.Redirect("../ExampleApproves/ExampleApproveTelerikRadGrid2.aspx",false);
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
  
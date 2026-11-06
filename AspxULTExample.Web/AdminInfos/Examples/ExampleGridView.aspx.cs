
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

    namespace AspxULTExample.Web.AdminInfos.Examples
    {
    
    public partial class ExampleGridView : System.Web.UI.Page
    {

    private IExampleBL bl;

    public ExampleGridView()
    {
    bl = new AdminExampleBL(new AdminExampleXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    SessionRedirect();

    if (!IsPostBack)
    {
    BindUserInfo();
    }

    }


    private void BindUserInfo()
    {
    try
    {


    var examples = bl.GetExamples();

    ResultGridView.DataSource = examples;
    ResultGridView.DataBind();
    ResultGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
    ResultGridView.UseAccessibleHeader = true;

    if (ResultGridView.Rows.Count > 0)
    {
    ResultGridView.FooterRow.TableSection = TableRowSection.TableFooter;
    }

    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    protected void ResultGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {

    foreach (LinkButton link in e.Row.Cells[21].Controls.OfType<LinkButton>
    ())
    {
    if (link.CommandName == "Delete")
    {
    link.OnClientClick = "javascript:return DeleteConfirm();";
    }
    }
    }
    }

    protected void ResultGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    ResultGridView.PageIndex = e.NewPageIndex;

    BindUserInfo();

    }


    protected void ResultGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    try
    {
    SessionRedirect();

    int exampleID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


    if(exampleID != 0)
    {

    Example example = bl.GetExampleById(exampleID);


    if (bl.DeleteExample(exampleID, example))
    {
    if (example.ErrID != 0)
    {
    DisplayAlert(example.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(example));    }

    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
    }

    BindUserInfo();
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    protected void ResultGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {

    ResultGridView.EditIndex = e.NewEditIndex;

    BindUserInfo();

    }

    protected void ResultGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    try
    {
    SessionRedirect();

    int exampleID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];

    int exampleUserInfoStatusID;
    bool successExampleUserInfoStatusID = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtExampleUserInfoStatusID")).Text, out exampleUserInfoStatusID);
    if (!successExampleUserInfoStatusID)
    {
    exampleUserInfoStatusID = 0;
    }
  

    int exampleUserInfoCompanyID;
    bool successExampleUserInfoCompanyID = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtExampleUserInfoCompanyID")).Text, out exampleUserInfoCompanyID);
    if (!successExampleUserInfoCompanyID)
    {
    exampleUserInfoCompanyID = 0;
    }
  
string title = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtTitle")).Text;

    int release;
    bool successRelease = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtRelease")).Text, out release);
    if (!successRelease)
    {
    release = 0;
    }
  

    DateTime releaseDateTime;
    bool successReleaseDateTime = DateTime.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtReleaseDateTime")).Text, out releaseDateTime);
    if (!successReleaseDateTime)
    {
    releaseDateTime = DateTime.Now;
    }
  
string genre = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtGenre")).Text;

    decimal price;
    bool successPrice = decimal.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtPrice")).Text, out price);
    if (!successPrice)
    {
    price = 0.0M;
    }
  
bool priceYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxPriceYesNo")).Checked;

    DateTime releaseDate;
    bool successReleaseDate = DateTime.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtReleaseDate")).Text, out releaseDate);
    if (!successReleaseDate)
    {
    releaseDate = DateTime.Now.Date;
    }
    releaseDate = releaseDate.Date;
  

    TimeSpan releaseTime;
    bool successReleaseTime = TimeSpan.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtReleaseTime")).Text, out releaseTime);
    if (!successReleaseTime)
    {
    releaseTime = TimeSpan.Zero;
    }
  
string message = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtMessage")).Text;
string message2 = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtMessage2")).Text;
string phoneNumber = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtPhoneNumber")).Text;
string emailAddress = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtEmailAddress")).Text;
string creditCard = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtCreditCard")).Text;
string password = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtPassword")).Text;
string url = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUrl")).Text;
bool exampleActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxExampleActiveYesNo")).Checked;


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
    }
    else
    {
    DisplayAlert(MsgText(example));
    }

    ResultGridView.EditIndex = -1;
    BindUserInfo();
    }

    }
    catch (Exception exception)
    {
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);

    }

    }

    protected void ResultGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    ResultGridView.EditIndex = -1;

    BindUserInfo();

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
  
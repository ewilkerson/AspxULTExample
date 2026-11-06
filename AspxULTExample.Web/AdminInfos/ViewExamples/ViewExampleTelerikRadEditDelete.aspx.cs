
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

    namespace AspxULTExample.Web.AdminInfos.ViewExamples
    {
    
    public partial class ViewExampleTelerikRadEditDelete : System.Web.UI.Page
    {

    private IViewExampleBL bl;
    public bool editYesNo = false;
    public bool buttonEditYesNo = false;
    public bool buttonUnsignedYesNo = false;
    public bool buttonApprovedYesNo = false;


    public ViewExampleTelerikRadEditDelete()
    {
    bl = new AdminViewExampleBL(new AdminViewExampleXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawExampleID = Request.QueryString["id"];
    int exampleID;
    bool successExampleID = int.TryParse(rawExampleID, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  


    if (exampleID != 0)
    {
    ViewExample viewExample = bl.GetViewExampleById(exampleID);
    
    HiddenField_ExampleID.Value = viewExample.ExampleID.ToString();
    LabelExampleID.Text = viewExample.ExampleID.ToString();
  

    
    HiddenField_ExampleUserInfoStatusID.Value = viewExample.ExampleUserInfoStatusID.ToString();
    LabelExampleStatusName.Text = viewExample.UserInfoStatusName;
  
RadDropDownExampleUserInfoCompanyID.SelectedValue = viewExample.ExampleUserInfoCompanyID.ToString();
TextBoxTitle.Text = viewExample.Title;
TextBoxRelease.Value = viewExample.Release;
TextBoxReleaseDateTime.SelectedDate = viewExample.ReleaseDateTime;
TextBoxGenre.Text = viewExample.Genre;
TextBoxPrice.Value = (double)viewExample.Price;
CheckBoxPriceYesNo.Checked = viewExample.PriceYesNo;
TextBoxReleaseDate.SelectedDate = viewExample.ReleaseDate;
TextBoxReleaseTime.SelectedTime = viewExample.ReleaseTime;
TextBoxMessage.Text = viewExample.Message;
TextBoxMessage2.Text = viewExample.Message2;
TextBoxPhoneNumber.Text = viewExample.PhoneNumber;
TextBoxEmailAddress.Text = viewExample.EmailAddress;
TextBoxCreditCard.Text = viewExample.CreditCard;
TextBoxPassword.Text = viewExample.Password;
TextBoxUrl.Text = viewExample.Url;
CheckBoxExampleActiveYesNo.Checked = viewExample.ExampleActiveYesNo;


    ButtonEditApprovedYesNo(exampleID, viewExample.ExampleUserInfoStatusID);
    BindUserInfo(exampleID);
    BindUserInfo2();

    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
    }

    
    RadDropDownExampleUserInfoCompanyID.Enabled = editYesNo;
  
    TextBoxTitle.Enabled = editYesNo;
  
    TextBoxRelease.Enabled = editYesNo;
  
    TextBoxReleaseDateTime.Enabled = editYesNo;
  
    TextBoxGenre.Enabled = editYesNo;
  
    TextBoxPrice.Enabled = editYesNo;
  
    CheckBoxPriceYesNo.Enabled = editYesNo;
  
    TextBoxReleaseDate.Enabled = editYesNo;
  
    TextBoxReleaseTime.Enabled = editYesNo;
  
    TextBoxMessage.Enabled = editYesNo;
  
    TextBoxMessage2.Enabled = editYesNo;
  
    TextBoxPhoneNumber.Enabled = editYesNo;
  
    TextBoxEmailAddress.Enabled = editYesNo;
  
    TextBoxCreditCard.Enabled = editYesNo;
  
    TextBoxPassword.Enabled = editYesNo;
  
    TextBoxUrl.Enabled = editYesNo;
  
    CheckBoxExampleActiveYesNo.Enabled = editYesNo;
  

    }
    }

    private void BindUserInfo(int id)
    {
    try
    {
    if(id != 0)
    {

    IEnumerable<ExampleApprove> viewExampleApproves = bl.GetViewExampleApprovesById(id);

    ResultGridViewApproves.DataSource = viewExampleApproves;
    ResultGridViewApproves.DataBind();

    ResultGridViewApproves.HeaderRow.TableSection = TableRowSection.TableHeader;
    ResultGridViewApproves.UseAccessibleHeader = true;

    if (ResultGridViewApproves.Rows.Count > 0)
    {
    ResultGridViewApproves.FooterRow.TableSection = TableRowSection.TableFooter;
    }

    IEnumerable<ExampleLog> viewExampleLogs = bl.GetViewExampleLogsById(id);

    ResultGridViewLogs.DataSource = viewExampleLogs;
    ResultGridViewLogs.DataBind();

    ResultGridViewLogs.HeaderRow.TableSection = TableRowSection.TableHeader;
    ResultGridViewLogs.UseAccessibleHeader = true;

    if (ResultGridViewLogs.Rows.Count > 0)
    {
    ResultGridViewLogs.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    }
    else
    {
    DisplayAlert("id cannot be zero.");
    }


    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    private void BindUserInfo2()
    {
    try
    {

    int userInfoID = SessionAdminBool() ? (int)Session[SessionName() + "UserInfoID"] : 0;
    IEnumerable<UserInfoUserInfoCompanyXref> companyLists = bl.GetLoadUserInfoUserInfoCompanyXrefsById(userInfoID);
    RadDropDownExampleUserInfoCompanyID.DataSource = companyLists;
    RadDropDownExampleUserInfoCompanyID.DataValueField = "UserInfoCompanyID";
    RadDropDownExampleUserInfoCompanyID.DataTextField = "UserInfoCompanyName";
    RadDropDownExampleUserInfoCompanyID.DataBind();

    foreach (int us in Enum.GetValues(typeof(EnumUserInfoStatusACRR)))
    {
    ListItem item = new ListItem(Enum.GetName(typeof(EnumUserInfoStatusACRR), us), us.ToString());
    ApproveCompeteRejectRevokeList.Items.Add(item);
    }

    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }


    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleID;
    bool successExampleID = int.TryParse(HiddenField_ExampleID.Value, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  

    if(exampleID != 0)
    {
    ViewExample viewExample = bl.GetViewExampleById(exampleID);

    ButtonEditApprovedYesNo(exampleID, viewExample.ExampleUserInfoStatusID);
    BindUserInfo(exampleID);

    
    int exampleUserInfoStatusID;
    bool successExampleUserInfoStatusID = int.TryParse(HiddenField_ExampleUserInfoStatusID.Value, out exampleUserInfoStatusID);
    if (!successExampleUserInfoStatusID)
    {
    exampleUserInfoStatusID = 0;
    }
  

    int exampleUserInfoCompanyID;
    bool successExampleUserInfoCompanyID = int.TryParse(RadDropDownExampleUserInfoCompanyID.SelectedValue, out exampleUserInfoCompanyID);
    if (!successExampleUserInfoCompanyID)
    {
    exampleUserInfoCompanyID = 0;
    }
  
string title = TextBoxTitle.Text;
int release = TextBoxRelease.Value != null ? (int)TextBoxRelease.Value: 0;
DateTime releaseDateTime = TextBoxReleaseDateTime.SelectedDate != null ? TextBoxReleaseDateTime.SelectedDate.Value : DateTime.Now;
string genre = TextBoxGenre.Text;
decimal price = TextBoxPrice.Value != null ? (decimal)TextBoxPrice.Value: 0.0M;
bool priceYesNo = CheckBoxPriceYesNo.Checked != null ? CheckBoxPriceYesNo.Checked.Value : false;
DateTime releaseDate = TextBoxReleaseDate.SelectedDate != null ? TextBoxReleaseDate.SelectedDate.Value.Date : DateTime.Now.Date;
TimeSpan releaseTime = TextBoxReleaseTime.SelectedTime != null ? TextBoxReleaseTime.SelectedTime.Value : TimeSpan.Zero;
string message = TextBoxMessage.Text;
string message2 = TextBoxMessage2.Text;
string phoneNumber = TextBoxPhoneNumber.Text;
string emailAddress = TextBoxEmailAddress.Text;
string creditCard = TextBoxCreditCard.Text;
string password = TextBoxPassword.Text;
string url = TextBoxUrl.Text;
bool exampleActiveYesNo = CheckBoxExampleActiveYesNo.Checked != null ? CheckBoxExampleActiveYesNo.Checked.Value : false;


    viewExample = new ViewExample()
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

    if (bl.UpdateViewExample(viewExample))
    {
    if (viewExample.ErrID != 0)
    {
    DisplayAlert(viewExample.ErrText);
    }
    else
    {
    Response.Redirect("../ViewExamples/ViewExampleTelerikRadEditDelete.aspx?id=" + exampleID, false);
    }

    }
    else
    {
    DisplayAlert(MsgText(viewExample));
    }
    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
    }

    }
    catch (Exception exception)
    {
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);

    }

    }

    protected void Submit_Signed(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleID;
    bool successExampleID = int.TryParse(HiddenField_ExampleID.Value, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  

    if(exampleID != 0)
    {

    ViewExample viewExample = bl.GetViewExampleById(exampleID);

    ButtonEditApprovedYesNo(exampleID, viewExample.ExampleUserInfoStatusID);
    BindUserInfo(exampleID);

    
    int exampleUserInfoStatusID;
    bool successExampleUserInfoStatusID = int.TryParse(HiddenField_ExampleUserInfoStatusID.Value, out exampleUserInfoStatusID);
    if (!successExampleUserInfoStatusID)
    {
    exampleUserInfoStatusID = 0;
    }
  

    int exampleUserInfoCompanyID;
    bool successExampleUserInfoCompanyID = int.TryParse(RadDropDownExampleUserInfoCompanyID.SelectedValue, out exampleUserInfoCompanyID);
    if (!successExampleUserInfoCompanyID)
    {
    exampleUserInfoCompanyID = 0;
    }
  
string title = TextBoxTitle.Text;
int release = TextBoxRelease.Value != null ? (int)TextBoxRelease.Value: 0;
DateTime releaseDateTime = TextBoxReleaseDateTime.SelectedDate != null ? TextBoxReleaseDateTime.SelectedDate.Value : DateTime.Now;
string genre = TextBoxGenre.Text;
decimal price = TextBoxPrice.Value != null ? (decimal)TextBoxPrice.Value: 0.0M;
bool priceYesNo = CheckBoxPriceYesNo.Checked != null ? CheckBoxPriceYesNo.Checked.Value : false;
DateTime releaseDate = TextBoxReleaseDate.SelectedDate != null ? TextBoxReleaseDate.SelectedDate.Value.Date : DateTime.Now.Date;
TimeSpan releaseTime = TextBoxReleaseTime.SelectedTime != null ? TextBoxReleaseTime.SelectedTime.Value : TimeSpan.Zero;
string message = TextBoxMessage.Text;
string message2 = TextBoxMessage2.Text;
string phoneNumber = TextBoxPhoneNumber.Text;
string emailAddress = TextBoxEmailAddress.Text;
string creditCard = TextBoxCreditCard.Text;
string password = TextBoxPassword.Text;
string url = TextBoxUrl.Text;
bool exampleActiveYesNo = CheckBoxExampleActiveYesNo.Checked != null ? CheckBoxExampleActiveYesNo.Checked.Value : false;


    viewExample = new ViewExample()
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

    ValidationContext context = new ValidationContext(viewExample, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(viewExample, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {
    viewExample.ExampleUserInfoStatusID = (int)EnumUserInfoStatus.Signed;
    if (bl.SignedUnsignedUpdateViewExample(viewExample))
    {
    if (viewExample.ErrID != 0)
    {
    DisplayAlert(viewExample.ErrText);
    }
    else
    {
    MailMessage(viewExample);
    Response.Redirect("../ViewExamples/ViewExampleTelerikRadEditDelete.aspx?id=" + exampleID, false);
    }

    }
    else
    {
    DisplayAlert(MsgText(viewExample));
    }
    }
    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
    }

    }
    catch (Exception exception)
    {
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);

    }

    }

    protected void Submit_Unsigned(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleID;
    bool successExampleID = int.TryParse(HiddenField_ExampleID.Value, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  

    if(exampleID != 0)
    {
    ViewExample viewExample = bl.GetViewExampleById(exampleID);

    ButtonEditApprovedYesNo(exampleID, viewExample.ExampleUserInfoStatusID);
    BindUserInfo(exampleID);

    viewExample.ExampleUserInfoStatusID = (int)EnumUserInfoStatus.Unsigned;

    if (bl.SignedUnsignedUpdateViewExample(viewExample))
    {
    if (viewExample.ErrID != 0)
    {
    DisplayAlert(viewExample.ErrText);
    }
    else
    {
    MailMessage(viewExample);
    Response.Redirect("../ViewExamples/ViewExampleTelerikRadEditDelete.aspx?id=" + exampleID, false);
    }
    }
    else
    {
    DisplayAlert(MsgText(viewExample));
    }

    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
    }

    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }

    }

    protected void Submit_ApproveCompeteRejectRevoke(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleID;
    bool successExampleID = int.TryParse(HiddenField_ExampleID.Value, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  

    if(exampleID != 0)
    {

    int approveCompeteRejectRevokeID;
    bool successApproveCompeteRejectRevokeID = int.TryParse(ApproveCompeteRejectRevokeList.SelectedValue, out approveCompeteRejectRevokeID);
    if (!successApproveCompeteRejectRevokeID)
    {
    approveCompeteRejectRevokeID = 0;
    }

    if (approveCompeteRejectRevokeID != 0)
    {
    ViewExample viewExample = bl.GetViewExampleById(exampleID);

    ButtonEditApprovedYesNo(exampleID, viewExample.ExampleUserInfoStatusID);
    BindUserInfo(exampleID);

    viewExample.ExampleUserInfoStatusID = approveCompeteRejectRevokeID;

    string noteMessage = TextBoxApproveCompeteRejectRevoke.Text;

    if (bl.ApproveCompeteRejectRevokeViewExample(viewExample, noteMessage))
    {
    if (viewExample.ErrID != 0)
    {
    DisplayAlert(viewExample.ErrText);
    }
    else
    {
    MailMessage(viewExample);
    Response.Redirect("../ViewExamples/ViewExampleTelerikRadEditDelete.aspx?id=" + exampleID, false);
    }

    }
    else
    {
    DisplayAlert(MsgText(viewExample));
    }

    }
    else
    {
    DisplayAlert("approveCompeteRejectRevokeID cannot be zero.");
    }

    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
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

    
    int exampleID;
    bool successExampleID = int.TryParse(HiddenField_ExampleID.Value, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  

    if(exampleID != 0)
    {
    ViewExample viewExample = bl.GetViewExampleById(exampleID);

    if (bl.DeleteViewExample(exampleID, viewExample))
    {
    if (viewExample.ErrID != 0)
    {
    DisplayAlert(viewExample.ErrText);
    }
    else
    {
    Response.Redirect("../ViewExamples/ViewExampleTelerikRadGrid2.aspx",false);
    }
    }
    else
    {
    DisplayAlert(MsgText(viewExample));
    }

    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
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

    private bool SessionBool()
    {
    bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[SessionName() + "UserInfoActiveYesNo"];
    return sessionBool;
    }

    private bool SessionAdminBool()
    {
    bool sessionAdminBool = SessionBool() && ((int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelSr || (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelJr);
    return sessionAdminBool;
    }

    private bool SessionApproveBool()
    {
    bool sessionApproveBool = SessionAdminBool() || (SessionBool() && (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.ApproveAccessLevel);
    return sessionApproveBool;
    }


    private void SessionRedirect()
    {
    if (!SessionAdminBool())
    {
    Response.Redirect("~", false);
    }
    }

    private void ButtonEditApprovedYesNo(int id, int statusID)
    {
    int id2 = id;
    bool idYesNo = id != 0 && id2 == id;
    editYesNo = idYesNo && statusID == (int)EnumUserInfoStatus.Created;
    buttonEditYesNo = editYesNo;
    buttonUnsignedYesNo = idYesNo && statusID == (int)EnumUserInfoStatus.Signed;
    buttonApprovedYesNo = idYesNo && (statusID == (int)EnumUserInfoStatus.Signed || statusID == (int)EnumUserInfoStatus.Approved || statusID == (int)EnumUserInfoStatus.Rejected ) && SessionApproveBool();
    }

    protected string MsgText(ViewExample viewExample)
    {
    string msg = string.Empty;

    if (viewExample != null)
    {

    Dictionary<string, string>
    isVal = bl.ViewExampleIsValid(viewExample);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "ViewExample cannot be null.";
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

    protected void MailMessage(ViewExample viewExample)
    {

    if (viewExample != null)
    {
    MailMessageObject mail = new MailMessageObject();
    mail.MailMessage(viewExample.ExampleID, viewExample.ExampleUserInfoCompanyID, viewExample.NoteMessage);

    }
    else
    {
    DisplayAlert("ViewExample cannot be null.");
    }


    }

    }
  
    }
  
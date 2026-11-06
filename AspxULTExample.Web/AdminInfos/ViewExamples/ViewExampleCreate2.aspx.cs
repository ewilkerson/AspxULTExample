
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
    
    public partial class ViewExampleCreate2 : System.Web.UI.Page
    {

    private IViewExampleBL bl;

    public ViewExampleCreate2()
    {
    bl = new AdminViewExampleBL(new AdminViewExampleXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();

    if (!IsPostBack)
    {
    
    HiddenField_ExampleUserInfoStatusID.Value = ((int)EnumUserInfoStatus.Created).ToString();
    LabelExampleStatusName.Text = "Not Created";
  

    BindUserInfo();
    }


    }

    private void BindUserInfo()
    {
    try
    {

    int userInfoID = SessionAdminBool() ? (int)Session[SessionName() + "UserInfoID"] : 0;
    IEnumerable<UserInfoUserInfoCompanyXref> companyLists = bl.GetLoadUserInfoUserInfoCompanyXrefsById(userInfoID);
    DropDownListExampleUserInfoCompanyID.DataSource = companyLists;
    DropDownListExampleUserInfoCompanyID.DataValueField = "UserInfoCompanyID";
    DropDownListExampleUserInfoCompanyID.DataTextField = "UserInfoCompanyName";
    DropDownListExampleUserInfoCompanyID.DataBind();

    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    protected void Submit_Create(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int exampleUserInfoStatusID;
    bool successExampleUserInfoStatusID = int.TryParse(HiddenField_ExampleUserInfoStatusID.Value, out exampleUserInfoStatusID);
    if (!successExampleUserInfoStatusID)
    {
    exampleUserInfoStatusID = 0;
    }
  

    int exampleUserInfoCompanyID;
    bool successExampleUserInfoCompanyID = int.TryParse(DropDownListExampleUserInfoCompanyID.SelectedValue, out exampleUserInfoCompanyID);
    if (!successExampleUserInfoCompanyID)
    {
    exampleUserInfoCompanyID = 0;
    }
  
string title = TextBoxTitle.Text;

    int release;
    bool successRelease = int.TryParse(TextBoxRelease.Text, out release);
    if (!successRelease)
    {
    release = 0;
    }
  

    DateTime releaseDateTime;
    bool successReleaseDateTime = DateTime.TryParse(TextBoxReleaseDateTime.Text, out releaseDateTime);
    if (!successReleaseDateTime)
    {
    releaseDateTime = DateTime.Now;
    }
  
string genre = TextBoxGenre.Text;

    decimal price;
    bool successPrice = decimal.TryParse(TextBoxPrice.Text, out price);
    if (!successPrice)
    {
    price = 0.0M;
    }
  
bool priceYesNo = CheckBoxPriceYesNo.Checked;

    DateTime releaseDate;
    bool successReleaseDate = DateTime.TryParse(TextBoxReleaseDate.Text, out releaseDate);
    if (!successReleaseDate)
    {
    releaseDate = DateTime.Now.Date;
    }
    releaseDate = releaseDate.Date;
  

    TimeSpan releaseTime;
    bool successReleaseTime = TimeSpan.TryParse(TextBoxReleaseTime.Text, out releaseTime);
    if (!successReleaseTime)
    {
    releaseTime = TimeSpan.Zero;
    }
  
string message = TextBoxMessage.Text;
string message2 = TextBoxMessage2.Text;
string phoneNumber = TextBoxPhoneNumber.Text;
string emailAddress = TextBoxEmailAddress.Text;
string creditCard = TextBoxCreditCard.Text;
string password = TextBoxPassword.Text;
string url = TextBoxUrl.Text;
bool exampleActiveYesNo = CheckBoxExampleActiveYesNo.Checked;

    ViewExample viewExample = new ViewExample()
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
ExampleActiveYesNo = exampleActiveYesNo,

    };

    if (bl.InsertViewExample(viewExample))
    {
    if (viewExample.ErrID != 0)
    {
    DisplayAlert(viewExample.ErrText);
    }
    else
    {
    Response.Redirect("../ViewExamples/ViewExampleEditDelete.aspx?id=" + viewExample.ExampleID, false);
    }

    }
    else
    {
    DisplayAlert(MsgText(viewExample));
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

    }
  
    }
  
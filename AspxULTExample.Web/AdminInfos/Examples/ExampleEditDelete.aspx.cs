
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
    
    public partial class ExampleEditDelete : System.Web.UI.Page
    {

    private IExampleBL bl;

    public ExampleEditDelete()
    {
    bl = new AdminExampleBL(new AdminExampleXmlRepository());
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

    Example example = bl.GetExampleById(exampleID);
    
    HiddenField_ExampleID.Value = example.ExampleID.ToString();
    LabelExampleID.Text = example.ExampleID.ToString();
  

    TextBoxExampleUserInfoStatusID.Text = example.ExampleUserInfoStatusID.ToString();
TextBoxExampleUserInfoCompanyID.Text = example.ExampleUserInfoCompanyID.ToString();
TextBoxTitle.Text = example.Title;
TextBoxRelease.Text = example.Release.ToString();
TextBoxReleaseDateTime.Text = string.Format("{0:M/d/yyyy HH:mm:ss}",example.ReleaseDateTime);
TextBoxGenre.Text = example.Genre;
TextBoxPrice.Text = example.Price.ToString();
CheckBoxPriceYesNo.Checked = example.PriceYesNo;
TextBoxReleaseDate.Text = example.ReleaseDate.ToShortDateString();
TextBoxReleaseTime.Text = example.ReleaseTime.ToString();
TextBoxMessage.Text = example.Message;
TextBoxMessage2.Text = example.Message2;
TextBoxPhoneNumber.Text = example.PhoneNumber;
TextBoxEmailAddress.Text = example.EmailAddress;
TextBoxCreditCard.Text = example.CreditCard;
TextBoxPassword.Text = example.Password;
TextBoxUrl.Text = example.Url;
CheckBoxExampleActiveYesNo.Checked = example.ExampleActiveYesNo;


    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
    }

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
  

    int exampleUserInfoStatusID;
    bool successExampleUserInfoStatusID = int.TryParse(TextBoxExampleUserInfoStatusID.Text, out exampleUserInfoStatusID);
    if (!successExampleUserInfoStatusID)
    {
    exampleUserInfoStatusID = 0;
    }
  

    int exampleUserInfoCompanyID;
    bool successExampleUserInfoCompanyID = int.TryParse(TextBoxExampleUserInfoCompanyID.Text, out exampleUserInfoCompanyID);
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
    Response.Redirect("../Examples/ExampleEditDelete.aspx?id=" + exampleID,false);
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
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);

    }

    }
    protected void Submit_Delete(Object sender, EventArgs e)
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

    Example example = bl.GetExampleById(exampleID);

    if (bl.DeleteExample(exampleID, example))
    {
    if (example.ErrID != 0)
    {
    DisplayAlert(example.ErrText);
    }
    else
    {
    Response.Redirect("../Examples/ExampleGridView2.aspx",false);
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
  
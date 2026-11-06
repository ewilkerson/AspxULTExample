
    using AspxULTExample.Repository;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    namespace AspxULTExample.Web
    {

    public partial class ContactUs : Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();
    }

    protected void Submit_Create(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    string fullName = TextBoxFullName.Text;
    string emailAddress = TextBoxEmailAddress.Text;
    string comments = TextBoxComments.Text;

    Models.ContactUs contactUs = new Models.ContactUs()
    {
    FullName = fullName,
    EmailAddress = emailAddress,
    Comments = comments
    };

    ValidationContext context = new ValidationContext(contactUs, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(contactUs, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {
    ContactUsMailMessageObject contactUsMailMessageObject = new ContactUsMailMessageObject();
    contactUsMailMessageObject.ContactUsMailMessage(contactUs);
    Response.Redirect("~", false);
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

    private bool SessionBool()
    {
    bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[SessionName() + "UserInfoActiveYesNo"];
    return sessionBool;
    }

    private void SessionRedirect()
    {
    if (!SessionBool())
    {
    Response.Redirect("~", false);
    }
    }

    protected void DisplayAlert(string msg)
    {
    if (!string.IsNullOrWhiteSpace(msg))
    {
    string msgHtml = ((SiteMaster)Master)?.MsgHtml(msg);
    ((SiteMaster)Master)?.DisplayAlert(msgHtml);
    ModelState.AddModelError("", msgHtml);
    }
    }
    }
    }
  
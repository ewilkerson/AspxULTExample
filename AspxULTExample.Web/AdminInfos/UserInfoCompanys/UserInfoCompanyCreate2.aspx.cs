
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoCompanys
    {
    
    public partial class UserInfoCompanyCreate2 : System.Web.UI.Page
    {

    private IUserInfoCompanyBL bl;

    public UserInfoCompanyCreate2()
    {
    bl = new AdminUserInfoCompanyBL(new AdminUserInfoCompanyXmlRepository());
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

    string userInfoCompanyEIN = TextBoxUserInfoCompanyEIN.Text;
string userInfoCompanyName = TextBoxUserInfoCompanyName.Text;
string userInfoCompanyAddress1 = TextBoxUserInfoCompanyAddress1.Text;
string userInfoCompanyAddress2 = TextBoxUserInfoCompanyAddress2.Text;
string userInfoCompanyCityStateZip = TextBoxUserInfoCompanyCityStateZip.Text;
string userInfoCompanyTelephone = TextBoxUserInfoCompanyTelephone.Text;
string userInfoCompanyEmailAddress = TextBoxUserInfoCompanyEmailAddress.Text;
string userCompanyWebsiteAddress = TextBoxUserCompanyWebsiteAddress.Text;

    int userInfoCountriesID;
    bool successUserInfoCountriesID = int.TryParse(TextBoxUserInfoCountriesID.Text, out userInfoCountriesID);
    if (!successUserInfoCountriesID)
    {
    userInfoCountriesID = 0;
    }
  
bool userInfoCompanyActiveYesNo = CheckBoxUserInfoCompanyActiveYesNo.Checked;


    UserInfoCompany userInfoCompany = new UserInfoCompany()
    {
    UserInfoCompanyID = 1,
UserInfoCompanyEIN = userInfoCompanyEIN,
UserInfoCompanyName = userInfoCompanyName,
UserInfoCompanyAddress1 = userInfoCompanyAddress1,
UserInfoCompanyAddress2 = userInfoCompanyAddress2,
UserInfoCompanyCityStateZip = userInfoCompanyCityStateZip,
UserInfoCompanyTelephone = userInfoCompanyTelephone,
UserInfoCompanyEmailAddress = userInfoCompanyEmailAddress,
UserCompanyWebsiteAddress = userCompanyWebsiteAddress,
UserInfoCountriesID = userInfoCountriesID,
UserInfoCompanyActiveYesNo = userInfoCompanyActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCompany, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCompany, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertUserInfoCompany(userInfoCompany))
    {
    if (userInfoCompany.ErrID != 0)
    {
    DisplayAlert(userInfoCompany.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoCompanys/UserInfoCompanyEditDelete.aspx?id=" + userInfoCompany.UserInfoCompanyID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoCompany));
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

    protected string MsgText(UserInfoCompany userInfoCompany)
    {
    string msg = string.Empty;

    if (userInfoCompany != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoCompanyIsValid(userInfoCompany);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoCompany cannot be null.";
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
  
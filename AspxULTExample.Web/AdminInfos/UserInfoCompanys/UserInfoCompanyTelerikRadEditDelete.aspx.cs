
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
    
    public partial class UserInfoCompanyTelerikRadEditDelete : System.Web.UI.Page
    {

    private IUserInfoCompanyBL bl;

    public UserInfoCompanyTelerikRadEditDelete()
    {
    bl = new AdminUserInfoCompanyBL(new AdminUserInfoCompanyXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawUserInfoCompanyID = Request.QueryString["id"];
    int userInfoCompanyID;
    bool successUserInfoCompanyID = int.TryParse(rawUserInfoCompanyID, out userInfoCompanyID);
    if (!successUserInfoCompanyID)
    {
    userInfoCompanyID = 0;
    }
  


    if (userInfoCompanyID != 0)

    {

    UserInfoCompany userInfoCompany = bl.GetUserInfoCompanyById(userInfoCompanyID);
    HiddenField_UserInfoCompanyID.Value = userInfoCompanyID.ToString();
    LabelUserInfoCompanyID.Text = userInfoCompanyID.ToString();

    TextBoxUserInfoCompanyEIN.Text = userInfoCompany.UserInfoCompanyEIN;
TextBoxUserInfoCompanyName.Text = userInfoCompany.UserInfoCompanyName;
TextBoxUserInfoCompanyAddress1.Text = userInfoCompany.UserInfoCompanyAddress1;
TextBoxUserInfoCompanyAddress2.Text = userInfoCompany.UserInfoCompanyAddress2;
TextBoxUserInfoCompanyCityStateZip.Text = userInfoCompany.UserInfoCompanyCityStateZip;
TextBoxUserInfoCompanyTelephone.Text = userInfoCompany.UserInfoCompanyTelephone;
TextBoxUserInfoCompanyEmailAddress.Text = userInfoCompany.UserInfoCompanyEmailAddress;
TextBoxUserCompanyWebsiteAddress.Text = userInfoCompany.UserCompanyWebsiteAddress;
TextBoxUserInfoCountriesID.Value = userInfoCompany.UserInfoCountriesID;
CheckBoxUserInfoCompanyActiveYesNo.Checked = userInfoCompany.UserInfoCompanyActiveYesNo;


    }
    else
    {
    DisplayAlert("userInfoCompanyID cannot be zero.");
    }

    }
    }

    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int userInfoCompanyID;
    bool successUserInfoCompanyID = int.TryParse(HiddenField_UserInfoCompanyID.Value, out userInfoCompanyID);
    if (!successUserInfoCompanyID)
    {
    userInfoCompanyID = 0;
    }
  
string userInfoCompanyEIN = TextBoxUserInfoCompanyEIN.Text;
string userInfoCompanyName = TextBoxUserInfoCompanyName.Text;
string userInfoCompanyAddress1 = TextBoxUserInfoCompanyAddress1.Text;
string userInfoCompanyAddress2 = TextBoxUserInfoCompanyAddress2.Text;
string userInfoCompanyCityStateZip = TextBoxUserInfoCompanyCityStateZip.Text;
string userInfoCompanyTelephone = TextBoxUserInfoCompanyTelephone.Text;
string userInfoCompanyEmailAddress = TextBoxUserInfoCompanyEmailAddress.Text;
string userCompanyWebsiteAddress = TextBoxUserCompanyWebsiteAddress.Text;
int userInfoCountriesID = TextBoxUserInfoCountriesID.Value != null ? (int)TextBoxUserInfoCountriesID.Value: 0;
bool userInfoCompanyActiveYesNo = CheckBoxUserInfoCompanyActiveYesNo.Checked != null ? CheckBoxUserInfoCompanyActiveYesNo.Checked.Value : false;


    UserInfoCompany userInfoCompany = new UserInfoCompany()
    {
    UserInfoCompanyID = userInfoCompanyID,
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

    if (bl.UpdateUserInfoCompany(userInfoCompany))
    {
    if (userInfoCompany.ErrID != 0)
    {
    DisplayAlert(userInfoCompany.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoCompanys/UserInfoCompanyTelerikRadEditDelete.aspx?id=" + userInfoCompanyID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoCompany));
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

    
    int userInfoCompanyID;
    bool successUserInfoCompanyID = int.TryParse(HiddenField_UserInfoCompanyID.Value, out userInfoCompanyID);
    if (!successUserInfoCompanyID)
    {
    userInfoCompanyID = 0;
    }
  


    if(userInfoCompanyID != 0)
    {
    UserInfoCompany userInfoCompany = bl.GetUserInfoCompanyById(userInfoCompanyID);

    if (bl.DeleteUserInfoCompany(userInfoCompanyID, userInfoCompany))
    {
    if (userInfoCompany.ErrID != 0)
    {
    DisplayAlert(userInfoCompany.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoCompanys/UserInfoCompanyTelerikRadGrid2.aspx",false);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCompany));
    }

    }
    else
    {
    DisplayAlert("userInfoCompanyID cannot be zero.");
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
  
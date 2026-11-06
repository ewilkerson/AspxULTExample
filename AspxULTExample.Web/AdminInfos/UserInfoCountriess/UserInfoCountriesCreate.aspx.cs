
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoCountriess
    {
    
    public partial class UserInfoCountriesCreate : System.Web.UI.Page
    {

    private IUserInfoCountriesBL bl;

    public UserInfoCountriesCreate()
    {
    bl = new AdminUserInfoCountriesBL(new AdminUserInfoCountriesXmlRepository());
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

    string userInfoCountriesName = TextBoxUserInfoCountriesName.Text;
bool userInfoCountriesActiveYesNo = CheckBoxUserInfoCountriesActiveYesNo.Checked;


    UserInfoCountries userInfoCountries = new UserInfoCountries()
    {
    UserInfoCountriesID = 1,
UserInfoCountriesName = userInfoCountriesName,
UserInfoCountriesActiveYesNo = userInfoCountriesActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCountries, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCountries, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.InsertUserInfoCountries(userInfoCountries))
    {
    if (userInfoCountries.ErrID != 0)
    {
    DisplayAlert(userInfoCountries.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoCountriess/UserInfoCountriesGridView.aspx",false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoCountries));
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

    protected string MsgText(UserInfoCountries userInfoCountries)
    {
    string msg = string.Empty;

    if (userInfoCountries != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoCountriesIsValid(userInfoCountries);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoCountries cannot be null.";
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
  
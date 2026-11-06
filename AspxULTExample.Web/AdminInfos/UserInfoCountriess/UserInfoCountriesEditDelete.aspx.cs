
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
    
    public partial class UserInfoCountriesEditDelete : System.Web.UI.Page
    {

    private IUserInfoCountriesBL bl;

    public UserInfoCountriesEditDelete()
    {
    bl = new AdminUserInfoCountriesBL(new AdminUserInfoCountriesXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawUserInfoCountriesID = Request.QueryString["id"];
    int userInfoCountriesID;
    bool successUserInfoCountriesID = int.TryParse(rawUserInfoCountriesID, out userInfoCountriesID);
    if (!successUserInfoCountriesID)
    {
    userInfoCountriesID = 0;
    }
  


    if (userInfoCountriesID != 0)
    {

    UserInfoCountries userInfoCountries = bl.GetUserInfoCountriesById(userInfoCountriesID);
    
    HiddenField_UserInfoCountriesID.Value = userInfoCountries.UserInfoCountriesID.ToString();
    LabelUserInfoCountriesID.Text = userInfoCountries.UserInfoCountriesID.ToString();
  

    TextBoxUserInfoCountriesName.Text = userInfoCountries.UserInfoCountriesName;
CheckBoxUserInfoCountriesActiveYesNo.Checked = userInfoCountries.UserInfoCountriesActiveYesNo;


    }
    else
    {
    DisplayAlert("userInfoCountriesID cannot be zero.");
    }

    }
    }

    protected void Submit_Edit(Object sender, EventArgs e)
    {
    try
    {
    SessionRedirect();

    
    int userInfoCountriesID;
    bool successUserInfoCountriesID = int.TryParse(HiddenField_UserInfoCountriesID.Value, out userInfoCountriesID);
    if (!successUserInfoCountriesID)
    {
    userInfoCountriesID = 0;
    }
  
string userInfoCountriesName = TextBoxUserInfoCountriesName.Text;
bool userInfoCountriesActiveYesNo = CheckBoxUserInfoCountriesActiveYesNo.Checked;


    UserInfoCountries userInfoCountries = new UserInfoCountries()
    {
    UserInfoCountriesID = userInfoCountriesID,
UserInfoCountriesName = userInfoCountriesName,
UserInfoCountriesActiveYesNo = userInfoCountriesActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCountries, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCountries, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoCountries(userInfoCountries))
    {
    if (userInfoCountries.ErrID != 0)
    {
    DisplayAlert(userInfoCountries.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoCountriess/UserInfoCountriesEditDelete.aspx?id=" + userInfoCountriesID,false);
    }

    }
    else
    {
    DisplayAlert(MsgText(userInfoCountries));
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

    
    int userInfoCountriesID;
    bool successUserInfoCountriesID = int.TryParse(HiddenField_UserInfoCountriesID.Value, out userInfoCountriesID);
    if (!successUserInfoCountriesID)
    {
    userInfoCountriesID = 0;
    }
  



    if(userInfoCountriesID != 0)
    {

    UserInfoCountries userInfoCountries = bl.GetUserInfoCountriesById(userInfoCountriesID);

    if (bl.DeleteUserInfoCountries(userInfoCountriesID, userInfoCountries))
    {
    if (userInfoCountries.ErrID != 0)
    {
    DisplayAlert(userInfoCountries.ErrText);
    }
    else
    {
    Response.Redirect("../UserInfoCountriess/UserInfoCountriesGridView2.aspx",false);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCountries));
    }

    }
    else
    {
    DisplayAlert("userInfoCountriesID cannot be zero.");
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
  